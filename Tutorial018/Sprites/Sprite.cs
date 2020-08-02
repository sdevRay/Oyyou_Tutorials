using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Tutorial018.Sprites
{
	public class Sprite : Component
	{
		protected Texture2D _texture;
		protected Texture2D _rectangleTexture;

		public Vector2 Position;
		public Rectangle Rectangle
		{
			get { return new Rectangle((int)Position.X, (int)Position.Y, _texture.Width, _texture.Height);  }
		}

		public bool ShowRectangle { get; set; }


		public Sprite(Texture2D texture)
		{
			_texture = texture;

			ShowRectangle = false;
		}

		public Sprite(GraphicsDevice graphics, Texture2D texture) : this(texture)
		{
			SetRectangleTexture(graphics, texture);
		}

		private void SetRectangleTexture(GraphicsDevice graphics, Texture2D texture)
		{
			var colors = new List<Color>();

			for(int y = 0; y < texture.Height; y++)
			{
				for (int x = 0; x < texture.Width; x++)
				{
					if(x == 0 || y == 0 || x == texture.Width - 1 || y == texture.Height - 1) // These are edges of the texture
					{
						colors.Add(new Color(255, 255, 255, 255)); // border color
					}
					else 
					{
						colors.Add(new Color(0, 0, 0, 0)); // transparent interior
					}
				}
			}

			_rectangleTexture = new Texture2D(graphics, texture.Width, texture.Height);
			_rectangleTexture.SetData<Color>(colors.ToArray());
		}

		public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
		{ 
			spriteBatch.Draw(_texture, Position, Color.White);

			if (ShowRectangle)
			{
				if(_rectangleTexture != null)
				{
					spriteBatch.Draw(_rectangleTexture, Position, Color.Red);
				}
			}
		}

		public override void Update(GameTime gameTime)
		{
		}
	}
}

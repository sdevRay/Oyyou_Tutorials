using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Tutorial007.Sprites
{
	public class Bomb : Sprite
	{
		public Bomb(Texture2D texture) : base(texture)
		{
			Position = new Vector2(Game1.Random.Next(0, Game1.ScreenWidth - texture.Width), -_texture.Height);
			Speed = Game1.Random.Next(3, 10);
		}

		public override void Update(GameTime gameTime, List<Sprite> sprites)
		{
			Position.Y += Speed;

			if(Rectangle.Bottom >= (Game1.ScreenHeight + Rectangle.Height))
			{
				IsRemoved = true;
			}
		}
	}


}

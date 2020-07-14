﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Tutorial008.Models;

namespace Tutorial008.Sprites
{
	public class Sprite
	{
		protected Texture2D _texture;

		public Vector2 Position;
		public float Speed;
		public Color Color = Color.White;
		public Input Input;
		public bool IsRemoved;
		public Rectangle Rectangle
		{
			get
			{
				return new Rectangle((int)Position.X, (int)Position.Y, _texture.Width, _texture.Height);
			}
		}

		public Sprite(Texture2D texture)
		{
			_texture = texture;
		}

		public virtual void Update(GameTime gameTime, List<Sprite> sprites)
		{

		}

		public virtual void Draw(SpriteBatch spriteBatch)
		{
			spriteBatch.Draw(_texture, Position, Color);
		}

	}
}

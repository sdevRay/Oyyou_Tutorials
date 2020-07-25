﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace Tutorial010.Sprites
{
	public class Bat : Sprite
	{
		public Bat(Texture2D texture) : base(texture)
		{
			Speed = 5f;
		}

		public override void Update(GameTime gameTime, List<Sprite> sprites)
		{
			if (Input == null)
				throw new Exception("give a value to 'input'");
			if (Keyboard.GetState().IsKeyDown(Input.Up))
				Velocity.Y = -Speed;
			else if (Keyboard.GetState().IsKeyDown(Input.Down))
				Velocity.Y = Speed;

			Position += Velocity;

			Position.Y = MathHelper.Clamp(Position.Y, 0, Game1.ScreenHeight - _texture.Height);

			Velocity = Vector2.Zero;
		}
	}
}

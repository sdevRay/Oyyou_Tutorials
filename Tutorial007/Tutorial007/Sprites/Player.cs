﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace Tutorial007.Sprites
{
	public class Player : Sprite
	{
		public bool HasDied = false;
		public Player(Texture2D texture) : base(texture)
		{

		}

		public override void Update(GameTime gameTime, List<Sprite> sprites)
		{
			Move();

			foreach(var sprite in sprites)
			{
				if (sprite is Player)
					continue;

				if (sprite.Rectangle.Intersects(this.Rectangle))
				{
					this.HasDied = true;
				}

			}

			Position += Velocity;

			// KEEP THE PLAYER ON THE SCREEN
			Position.X = MathHelper.Clamp(Position.X, 0, Game1.ScreenWidth - Rectangle.Width);

			// RESET THE VELOCITY FOR WHEN THE USER ISNT HOLDING DOWN A KEY
			Velocity = Vector2.Zero;
		}

		private void Move()
		{
			if (Input == null)
			{
				throw new Exception("Please assign a value to Input");
			}

			if (Keyboard.GetState().IsKeyDown(Input.Left))
				Velocity.X = -Speed;
			if (Keyboard.GetState().IsKeyDown(Input.Right))
				Velocity.X = +Speed;
		}
	}
}

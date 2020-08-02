using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tutorial018.Sprites
{
	public class Player : Sprite
	{
		public Player(GraphicsDevice graphics, Texture2D texture) : base (graphics, texture)
		{

		}

		public override void Update(GameTime gameTime)
		{
			if (Keyboard.GetState().IsKeyDown(Keys.W))
				Position.Y -= 3;
			if (Keyboard.GetState().IsKeyDown(Keys.S))
				Position.Y += 3;
			if (Keyboard.GetState().IsKeyDown(Keys.A))
				Position.X -= 3;
			if (Keyboard.GetState().IsKeyDown(Keys.D))
				Position.X += 3;

			base.Update(gameTime);
		}
	}
}

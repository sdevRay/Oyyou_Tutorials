﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace Tutorial006.Sprites
{
	public class Ship : Sprite
	{
		public Bullet Bullet;
	
		public Ship(Texture2D texture) : base(texture)
		{

		}

		public override void Update(GameTime gameTime, List<Sprite> sprites)
		{
			_previousKey = _currentKey;
			_currentKey = Keyboard.GetState();

			if (_currentKey.IsKeyDown(Keys.A))
			{
				_rotation -= MathHelper.ToRadians(RotationVelocity);
			} 
			else if (_currentKey.IsKeyDown(Keys.D)) 
			{
				_rotation += MathHelper.ToRadians(RotationVelocity);
			}

			Direction = new Vector2((float)Math.Cos(_rotation), (float)Math.Sin(_rotation));

			if (_currentKey.IsKeyDown(Keys.W))
			{
				Position += Direction * LinearVelocity;
			}

			if(_currentKey.IsKeyDown(Keys.Space) && _previousKey.IsKeyUp(Keys.Space))
			{
				AddBullet(sprites);
			}

			//base.Update(gameTime, sprites);
		}

		private void AddBullet(List<Sprite> sprites)
		{
			var bullet = Bullet.Clone() as Bullet;
			bullet.Direction = Direction;
			bullet.Position = Position;
			bullet.LinearVelocity = LinearVelocity * 2;
			bullet.LifeSpan = 2f;
			bullet.Parent = Parent; // NOT IN TUTORIAL YET 

			sprites.Add(bullet);
		}
	}
}

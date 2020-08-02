﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Tutorial015.Controls
{
	public class Button : Component
	{
		private MouseState _currentMouse;
		private MouseState _prevMouse;
		private SpriteFont _font;
		private bool _isHovering;
		private Texture2D _texture;


		public event EventHandler Click;
		public bool Clicked { get; set; }
		public Color PenColor { get; set; }
		public Vector2 Position { get; set; }
		public Rectangle Rectangle
		{
			get
			{
				return new Rectangle((int)Position.X, (int)Position.Y, _texture.Width, _texture.Height);
			}
		}

		public string Text;

		public Button(Texture2D texture, SpriteFont font)
		{
			_texture = texture;
			_font = font;

			PenColor = Color.Black;
		}
		public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
		{
			var color = Color.White;

			if (_isHovering)
				color = Color.Gray;

			spriteBatch.Draw(_texture, Rectangle, color);

			if (!string.IsNullOrEmpty(Text))
			{
				var x = (Rectangle.X + (Rectangle.Width / 2)) - (_font.MeasureString(Text).X / 2);
				var y = (Rectangle.Y + (Rectangle.Height / 2)) - (_font.MeasureString(Text).Y / 2);

				spriteBatch.DrawString(_font, Text, new Vector2(x , y), PenColor);
			}
		}

		public override void Update(GameTime gameTime)
		{
			_prevMouse = _currentMouse;
			_currentMouse = Mouse.GetState();

			var mouseRectangle = new Rectangle(_currentMouse.X, _currentMouse.Y, 1, 1);

			_isHovering = false;

			if (mouseRectangle.Intersects(Rectangle))
			{
				_isHovering = true;

				if(_currentMouse.LeftButton == ButtonState.Released && _prevMouse.LeftButton == ButtonState.Pressed)
				{
					Click?.Invoke(this, new EventArgs());
				}
			}
		}
	}
}

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using Tutorial018.Sprites;

namespace Tutorial018
{
	/// <summary>
	/// This is the main type for your game.
	/// </summary>
	public class Game1 : Game
	{
		GraphicsDeviceManager graphics;
		SpriteBatch spriteBatch;

		private KeyboardState _currentKey;
		private KeyboardState _prevKey;

		private bool _showBorders = false;

		private List<Sprite> _sprites;

		public Game1()
		{
			graphics = new GraphicsDeviceManager(this);
			Content.RootDirectory = "Content";
		}

		/// <summary>
		/// Allows the game to perform any initialization it needs to before starting to run.
		/// This is where it can query for any required services and load any non-graphic
		/// related content.  Calling base.Initialize will enumerate through any components
		/// and initialize them as well.
		/// </summary>
		protected override void Initialize()
		{
			// TODO: Add your initialization logic here

			base.Initialize();
		}

		/// <summary>
		/// LoadContent will be called once per game and is the place to load
		/// all of your content.
		/// </summary>
		protected override void LoadContent()
		{
			// Create a new SpriteBatch, which can be used to draw textures.
			spriteBatch = new SpriteBatch(GraphicsDevice);

			_sprites = new List<Sprite>()
			{
				new Sprite(graphics.GraphicsDevice, Content.Load<Texture2D>("Square"))
				{
					Position = new Vector2(100, 100)
				},
				new Player(graphics.GraphicsDevice, Content.Load<Texture2D>("Apple"))
				{
					Position = new Vector2(200, 100)
				},
				new Sprite(graphics.GraphicsDevice, Content.Load<Texture2D>("Bomb"))
				{
					Position = new Vector2(200, 200)
				}
			};

			// TODO: use this.Content to load your game content here
		}

		/// <summary>
		/// UnloadContent will be called once per game and is the place to unload
		/// game-specific content.
		/// </summary>
		protected override void UnloadContent()
		{
			// TODO: Unload any non ContentManager content here
		}

		/// <summary>
		/// Allows the game to run logic such as updating the world,
		/// checking for collisions, gathering input, and playing audio.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Update(GameTime gameTime)
		{
			if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
				Exit();

			_prevKey = _currentKey;
			_currentKey = Keyboard.GetState();

			if (_prevKey.IsKeyDown(Keys.F1) && _currentKey.IsKeyUp(Keys.F1))
				_showBorders = !_showBorders;

			foreach(var sprite in _sprites)
			{
				sprite.Update(gameTime);
			}
			// TODO: Add your update logic here

			base.Update(gameTime);
		}

		/// <summary>
		/// This is called when the game should draw itself.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Draw(GameTime gameTime)
		{
			GraphicsDevice.Clear(Color.CornflowerBlue);

			spriteBatch.Begin();

			foreach (var sprite in _sprites)
			{
				sprite.ShowRectangle = _showBorders;
				sprite.Draw(gameTime, spriteBatch);
			}

			spriteBatch.End();

			// TODO: Add your drawing code here

			base.Draw(gameTime);
		}
	}
}

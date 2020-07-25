using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using Tutorial012.Controls;

namespace Tutorial012
{
	/// <summary>
	/// This is the main type for your game.
	/// </summary>
	public class Game1 : Game
	{
		GraphicsDeviceManager graphics;
		SpriteBatch spriteBatch;

		private Color _backgroundColor = Color.CornflowerBlue;

		private List<Component> _gameComponents;

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
			IsMouseVisible = true;
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

			var randomButton = new Button(Content.Load<Texture2D>("Controls/Button"), Content.Load<SpriteFont>("Fonts/Font"))
			{
				Position = new Vector2(350, 200),
				Text = "Random"
			};

			randomButton.Click += RandomButton_Click;

			var quitButton = new Button(Content.Load<Texture2D>("Controls/Button"), Content.Load<SpriteFont>("Fonts/Font"))
			{
				Position = new Vector2(350,250),
				Text = "Quit"
			};

			quitButton.Click += QuitButton_Click;

			_gameComponents = new List<Component>()
			{
				randomButton,
				quitButton
			};
			// TODO: use this.Content to load your game content here
		}

		private void QuitButton_Click(object sender, System.EventArgs e)
		{
			Exit();
		}

		private void RandomButton_Click(object sender, System.EventArgs e)
		{
			var random = new Random();
		
			_backgroundColor = new Color(random.Next(0, 255), random.Next(0, 255), random.Next(0, 255));
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

			foreach(var comp in _gameComponents)
			{
				comp.Update(gameTime);
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
			GraphicsDevice.Clear(_backgroundColor);

			spriteBatch.Begin();

			foreach (var comp in _gameComponents)
			{
				comp.Draw(gameTime, spriteBatch);
			}

			spriteBatch.End();

			// TODO: Add your drawing code here

			base.Draw(gameTime);
		}
	}
}

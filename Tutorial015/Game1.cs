using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Linq;
using Tutorial015.Controls;
using Tutorial015.Managers;

namespace Tutorial015
{
	/// <summary>
	/// This is the main type for your game.
	/// </summary>
	public class Game1 : Game
	{
		GraphicsDeviceManager graphics;
		SpriteBatch spriteBatch;

		private Button _button;
		private SpriteFont _font;
		private int _score;
		private ScoreManager _scoreManager;

		private float _timer;

		public static Random Random;

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
			Random = new Random();
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
			_scoreManager = ScoreManager.Load();
			_font = Content.Load<SpriteFont>("Font");

			_button = new Button(Content.Load<Texture2D>("Button"), _font)
			{
				Text = "Click Me"
			};

			_button.Click += Button_Click;

			SetButtonPosition(_button);

			_timer = 5f;

			// Create a new SpriteBatch, which can be used to draw textures.
			spriteBatch = new SpriteBatch(GraphicsDevice);

			// TODO: use this.Content to load your game content here
		}

		private void Button_Click(object sender, EventArgs e)
		{
			SetButtonPosition((Button)sender);

			_score++;
		}

		private void SetButtonPosition(Button button)
		{
			var x = Random.Next(0, graphics.PreferredBackBufferWidth - button.Rectangle.Width);
			var y = Random.Next(0, graphics.PreferredBackBufferHeight - button.Rectangle.Height);

			button.Position = new Vector2(x, y);
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

			_timer -= (float)gameTime.ElapsedGameTime.TotalSeconds;

			if(_timer <= 0)
			{
				SetButtonPosition(_button);

				_scoreManager.Add(new Models.Score()
				{
					PlayerName = "Bob",
					Value = _score
				});

				ScoreManager.Save(_scoreManager);
				_timer = 5;
				_score = 0;
			}

			_button.Update(gameTime);

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

			_button.Draw(gameTime, spriteBatch);

			spriteBatch.DrawString(_font, "Score: " + _score, new Vector2(10, 10), Color.Red);
			spriteBatch.DrawString(_font, "Time: " + _timer.ToString("N2"), new Vector2(10, 30), Color.Red);

			var highscores = _scoreManager.HighScores.Select(hs => hs.PlayerName + ": " + hs.Value).ToArray();

			spriteBatch.DrawString(_font, "HighScores:\n" + string.Join("\n", highscores), new Vector2(680, 10), Color.Red);

			spriteBatch.End();
			// TODO: Add your drawing code here

			base.Draw(gameTime);
		}
	}
}

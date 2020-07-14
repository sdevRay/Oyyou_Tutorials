using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using Tutorial009.Models;
using Tutorial009.Sprites;

namespace Tutorial009
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

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

			// TODO: use this.Content to load your game content here
			var playerTexture = Content.Load<Texture2D>("Block");

			_sprites = new List<Sprite>()
			{
				new Player(playerTexture)
				{
					Input = new Input()
					{
						Left = Keys.A,
						Right = Keys.D,
						Down = Keys.S,
						Up = Keys.W
					},
					Position = new Vector2(100, 100),
					Color = Color.Blue,
					Speed = 5f
				},
				new Player(playerTexture)
				{
					Input = new Input()
					{
						Left = Keys.Left,
						Right = Keys.Right,
						Down = Keys.Down,
						Up = Keys.Up
					},
					Position = new Vector2(300, 100),
					Color = Color.Red,
					Speed = 5f
				}
			};
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

			foreach(var sprite in _sprites)
			{
				sprite.Update(gameTime, _sprites);
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

			// TODO: Add your drawing code here
			spriteBatch.Begin();
			foreach (var sprite in _sprites)
			{
				sprite.Draw(spriteBatch);
			}
			spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}

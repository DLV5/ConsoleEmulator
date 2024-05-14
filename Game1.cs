using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace ConsoleEmulator
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Console _console;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            _graphics.IsFullScreen = false;
            _graphics.PreferredBackBufferWidth = 677;
            _graphics.PreferredBackBufferHeight = 343;
            _graphics.ApplyChanges();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            _console = new Console(Content, _graphics, _spriteBatch);

            _spriteBatch.Begin();
            _console.PrintString("Lorem ipsum dolor sit amet, consectetur adipiscing elit. Morbi vitae sem dapibus, vulputate sapien vel, v");
            _console.PrintString("Mixture Mixture Mixture MixtureMixtureMixtureMixtureMixture");
            _console.PrintString("Mixture Mixture Mixture MixtureMixtureMixtureMixtureMixture");
            _console.PrintString("Mixture Mixture Mixture MixtureMixtureMixtureMixtureMixture");
            _spriteBatch.End();
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            //GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
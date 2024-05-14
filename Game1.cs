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
            //_console.PrintString("Hello world!Hello world!Hello world!Hello world!Hello world!Hello world!Hello world!Hello world!Hello world!Hello world!Hello world!Hello world!Hello world!");
            _console.PrintString("Lorem ipsum dolor sit amet, consectetur adipiscing elit. Morbi vitae sem dapibus, vulputate sapien vel, venenatis nunc. Nam auctor sapien erat, a tincidunt massa feugiat sit amet. Nulla pellentesque hendrerit rutrum. Maecenas pellentesque eros non euismod cursus. Aliquam erat volutpat. Nulla blandit ipsum ut mauris dapibus lobortis eu eu ex. Vestibulum ultrices urna id pulvinar egestas. Nunc tellus est, aliquam id ligula at, porttitor ultrices elit. Vivamus pellentesque tellus quis nibh fermentum, nec pulvinar dui placerat. Sed at dui sollicitudin, vestibulum ex eu, pellentesque mi. Morbi sodales, tortor id congue scelerisque, lacus mi sagittis risus, eget laoreet ex nisl in eros. Fusce nec lacus eu neque maximus dignissim quis eget ligula. Mauris vehicula non libero non mollis. Maecenas mattis lectus metus, sed volutpat neque varius fringilla. Nam rhoncus est ac faucibus bibendum.\r\n\r\nAliquam congue justo quis metus viverra pharetra. Curabitur varius lectus eget ipsum finibus iaculis. Vestibulum malesuada, sem blandit volutpat lacinia, ligula libero porttitor nisi, nec hendrerit risus mauris sit amet lorem. Suspendisse interdum metus felis, non luctus ipsum mollis sed. Mauris nec maximus justo, sit amet dictum mi. Pellentesque nec augue justo. Sed commodo interdum molestie.\r\n\r\nVivamus a lectus arcu. Cras tincidunt mattis leo ac auctor. Integer faucibus suscipit mattis. Curabitur sit amet ipsum sit amet nisi tempus egestas quis a ex. Sed facilisis ante sit amet justo consectetur rhoncus. Maecenas tincidunt porta elit eu viverra. Maecenas tincidunt diam vel nisi porta placerat. Praesent a ligula tempus sem dignissim tincidunt vel id augue.");
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
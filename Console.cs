using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
namespace ConsoleEmulator
{
    internal class Console
    {
        private string _defaultPrompt = "-->";
        private Grid _grid;

        private ContentManager _content;
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        public Console(ContentManager content, GraphicsDeviceManager graphics, SpriteBatch spriteBatch) {
            _content = content;
            _graphics = graphics;
            _spriteBatch = spriteBatch;

            _grid = new Grid(new Vector2(68, 18));
            _grid.Initialize(content, graphics);

            _spriteBatch.Begin();
            PrintString(_defaultPrompt);
            _spriteBatch.End();
        }

        public void PrintStringLine(string text)
        {
            _grid.DrawString(_graphics, _spriteBatch, _defaultPrompt);

            _grid.DrawStringLine(_graphics, _spriteBatch, text);
        }
        
        public void PrintString(string text)
        {
            _grid.DrawString(_graphics, _spriteBatch, text);
        }
    }
}

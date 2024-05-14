using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Linq;

namespace ConsoleEmulator
{
    internal class Console
    {
        private string _defaultPrompt = "-->";
        private Grid _grid;
        private Vector2 _currentCursorPosition;

        private ContentManager _content;
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        public Console(ContentManager content, GraphicsDeviceManager graphics, SpriteBatch spriteBatch) {
            _content = content;
            _graphics = graphics;
            _spriteBatch = spriteBatch;

            _grid = new Grid(new Vector2(60, 20));
            _grid.Initialize(content, graphics);
        }

        public void PrintString(string text)
        {
            _grid.DrawString(_graphics, _spriteBatch, _defaultPrompt);

            _grid.DrawStringLine(_graphics, _spriteBatch, text);
        }
    }
}

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

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

            _grid = new Grid(new Vector2(80, 20));
            _grid.Initialize(content, graphics);
        }

        public void PrintString(string text)
        {
            string message = _defaultPrompt + text;

            if(_currentCursorPosition.X + message.Length > _grid.Size.X)
            {
                _currentCursorPosition = new Vector2((_currentCursorPosition.X + message.Length) % _grid.Size.X, 
                    _currentCursorPosition.Y + 1);
            } else
            {
                _currentCursorPosition = new Vector2(_currentCursorPosition.X + message.Length,
                    _currentCursorPosition.Y);
            }

            _grid.DrawSymbol(_graphics, _spriteBatch);
            _grid.DrawString(_graphics, _spriteBatch, _currentCursorPosition, message);
        }
    }
}

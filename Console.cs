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

            _grid = new Grid(new Vector2(41, 20));
            _grid.Initialize(content, graphics);
        }

        public void PrintString(string text)
        {
            _grid.DrawString(_graphics, _spriteBatch, _currentCursorPosition / Cell.Size.X, _defaultPrompt);

            MoveCursorToTheNextLeft((int)(_defaultPrompt.Length * Cell.Size.X));

            string message = text;

            if(_currentCursorPosition.X + message.Length * Cell.Size.X > _grid.Size.X * Cell.Size.X)
            {
                string firstMessagePart = "";
                string secondMessagePart = "";

                for (int i = 0; i < message.Length; i++)
                {
                    if(_currentCursorPosition.X + i * Cell.Size.X > _grid.Size.X * Cell.Size.X)
                    {
                        firstMessagePart = message.Substring(0, i - 1);
                        secondMessagePart = message.Substring(i);
                        break;
                    }
                }

                _grid.DrawString(_graphics, _spriteBatch, _currentCursorPosition / Cell.Size.X, firstMessagePart);

                MoveCursorToTheNextLine();

                _grid.DrawString(_graphics, _spriteBatch, _currentCursorPosition / Cell.Size.X, secondMessagePart);

                MoveCursorToTheNextLine();
            } else
            {
                _grid.DrawString(_graphics, _spriteBatch, _currentCursorPosition / Cell.Size.X, message);
                MoveCursorToTheNextLine();
            }

        }

        private void MoveCursorToTheNextLine()
        {
            _currentCursorPosition = new Vector2(0, _currentCursorPosition.Y + Cell.Size.Y);
        }
        
        private void MoveCursorToTheNextLeft(int amout)
        {
            _currentCursorPosition = new Vector2(_currentCursorPosition.X + amout, _currentCursorPosition.Y);
        }
       
    }
}

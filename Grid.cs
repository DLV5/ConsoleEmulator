using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace ConsoleEmulator
{
    internal class Grid
    {
        private Vector2 _size;
        private Vector2 _currentCursorPosition = Vector2.Zero;

        private List<List<Cell>> _cells = new List<List<Cell>>();

        public Vector2 Size { get => _size; }

        public Grid(Vector2 size)
        {
            _size = size;
        }

        public void Initialize(ContentManager content, GraphicsDeviceManager graphics)
        {
            for (int i = 0; i < _size.Y; i++)
            {
                List<Cell> cells = new List<Cell>();
                for (int j = 0; j < _size.X; j++)
                {
                    Cell cell = new Cell(_cells.Count, new Vector2(j * Cell.Size.X, i * Cell.Size.Y), ' ', content, graphics);

                    cells.Add(cell);
                }
                _cells.Add(cells);
            }
        }
        
        public void DrawEmpty(ContentManager content, GraphicsDeviceManager graphics)
        {
            for (int i = 0; i < _size.Y; i++)
            {
                List<Cell> cells = new List<Cell>();
                for (int j = 0; j < _size.X; j++)
                {
                    Cell cell = new Cell(_cells.Count, new Vector2(j * Cell.Size.X, i * Cell.Size.Y), ' ', content, graphics);

                    cells.Add(cell);
                }
                _cells.Add(cells);
            }
        }

        public void DrawSymbols(GraphicsDeviceManager graphics, SpriteBatch spriteBatch)
        {
            for (int i = 0; i < _cells.Count; i++)
            {
                for (int j = 0; j < _cells[i].Count; j++)
                {
                    _cells[i][j].CreateBackgroundAndDraw(graphics, spriteBatch);
                    _cells[i][j].DrawSymbol(spriteBatch);
                }
            }
        }
        
        public void DrawString(GraphicsDeviceManager graphics, SpriteBatch spriteBatch, string message)
        {
            for (int i = 0; i < message.Length; i++)
            {
                if ((int)_currentCursorPosition.X / Cell.Size.X + 1 >= _cells[0].Count)
                {
                    MoveCursorToTheNextLine();
                }

                if(_currentCursorPosition.Y / Cell.Size.Y + 1 >= _cells.Count)
                {
                    MoveAllOneRowUp(_cells);
                    DrawSymbols(graphics, spriteBatch);
                }

                _cells[(int)(_currentCursorPosition.Y / Cell.Size.Y)][(int)(_currentCursorPosition.X / Cell.Size.X)].CreateBackgroundAndDraw(graphics, spriteBatch);
                _cells[(int)(_currentCursorPosition.Y / Cell.Size.Y)][(int)(_currentCursorPosition.X / Cell.Size.X)].ChangeSymbol(message[i]);
                _cells[(int)(_currentCursorPosition.Y / Cell.Size.Y)][(int)(_currentCursorPosition.X / Cell.Size.X)].DrawSymbol(spriteBatch);

                MoveCursorToTheNextLeft(1);
            }
        }
        
        public void DrawStringLine(GraphicsDeviceManager graphics, SpriteBatch spriteBatch, string message)
        {
            DrawString(graphics, spriteBatch, message);

            MoveCursorToTheNextLine();
        }

        private void MoveCursorToTheNextLine()
        {
            _currentCursorPosition = new Vector2(0, _currentCursorPosition.Y + Cell.Size.Y);
        }

        private void MoveCursorToTheNextLeft(int amout)
        {
            _currentCursorPosition = new Vector2(_currentCursorPosition.X + amout * Cell.Size.X, _currentCursorPosition.Y);
        }

        private void MoveAllOneRowUp(List<List<Cell>> cells)
        {
            for (int i = 0; i < cells.Count; i++)
            {
                for (int j = 0; j < cells[i].Count; j++)
                {
                    if (i == 0)
                        break;

                    char c = cells[i][j].Symbol.ToCharArray()[0];
                    cells[i - 1][j].ChangeSymbol(c);
                }
                ClearRow(cells, i);
            }

            _currentCursorPosition = new Vector2(0, _currentCursorPosition.Y - Size.Y);
        }

        private void ClearRow(List<List<Cell>> cells, int rowIndex)
        {
            for (int i = 0; i < cells[rowIndex].Count; i++)
            {
                cells[rowIndex][i].ChangeSymbol(' ');
            }
        }
    }
}

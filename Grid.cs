using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace ConsoleEmulator
{
    internal class Grid
    {
        private Vector2 _size;

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

        public void DrawSymbol(GraphicsDeviceManager graphics, SpriteBatch spriteBatch)
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
        
        public void DrawString(GraphicsDeviceManager graphics, SpriteBatch spriteBatch, Vector2 position, string message)
        {
            for (int i = 0; i < message.Length; i++)
            {
                _cells[(int)position.Y][(int)position.X].CreateBackgroundAndDraw(graphics, spriteBatch);
                _cells[(int)position.Y][(int)position.X].ChangeSymbol(message[i]);
                _cells[(int)position.Y][(int)position.X].DrawSymbol(spriteBatch);

                position.X += 1;
            }
        }
    }
}

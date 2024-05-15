using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace ConsoleEmulator
{
    internal class Cell
    {
        public static Vector2 Size = new Vector2(10, 20);

        private int _index;

        private Vector2 _position;

        private Color _symbolColor;

        private Color _backgroundColor;
        private string _symbol;

        private SpriteFont _font;

        private Texture2D _rect;

        public Color BackgroundColor { get => _backgroundColor; set => _backgroundColor = value; }
        public string Symbol { get => _symbol; }

        public Cell(int index, Vector2 position, char symbol, ContentManager content, GraphicsDeviceManager graphics)
        {
            _index = index;
            _position = position;
            _symbolColor = Color.White;
            _backgroundColor = Color.Black;
            _symbol = symbol.ToString();

            _font = content.Load<SpriteFont>("ConsoleDefault2");
            _rect = new Texture2D(graphics.GraphicsDevice, (int)Size.X, (int)Size.Y);
        }

        public Cell(int index, Vector2 position, Color color, char symbol, ContentManager content)
        {
            _index = index;
            _position = position;
            _symbolColor = color;
            _symbol = symbol.ToString();

            _font = content.Load<SpriteFont>("ConsoleDefault");
        }

        public void ChangeSymbol(char symbol) => _symbol = symbol.ToString();

        public void DrawSymbol(SpriteBatch spriteBatch)
        {
            try
            {
                spriteBatch.DrawString(_font, _symbol, _position, _symbolColor);
            } catch
            {
                spriteBatch.DrawString(_font, "o", _position, _symbolColor);
            }
        }

        public void CreateBackgroundAndDraw(GraphicsDeviceManager graphics, SpriteBatch spriteBatch) 
        { 
            Color[] data = new Color[(int)(Size.X * Size.Y)];
            for (int i = 0; i < data.Length; ++i) data[i] = Color.Black;
            _rect.SetData(data);

            spriteBatch.Draw(_rect, _position, Color.Black);
        }
        
        public void CreateBackgroundAndDraw(GraphicsDeviceManager graphics, SpriteBatch spriteBatch, Color color) 
        { 
            Color[] data = new Color[(int)(Size.X * Size.Y)];
            for (int i = 0; i < data.Length; ++i) data[i] = color;
            _rect.SetData(data);

            spriteBatch.Draw(_rect, _position, color);
        }
    }
}

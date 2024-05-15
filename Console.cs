using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace ConsoleEmulator
{
    internal class Console
    {
        private string _defaultPrompt = "-->";
        private Grid _grid;

        private ContentManager _content;
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private Timer _timer;
        private int _numberOfPrintedSymbols = 0;

        public Console(ContentManager content, GraphicsDeviceManager graphics, SpriteBatch spriteBatch) {
            _content = content;
            _graphics = graphics;
            _spriteBatch = spriteBatch;

            _grid = new Grid(new Vector2(68, 18));
            _grid.Initialize(content, graphics);

            _spriteBatch.Begin();
            PrintDefaultPrompt();
            _spriteBatch.End();

            InitTimer();
        }

        private void InitTimer()
        {
            _timer = new Timer();
            _timer.Tick += new EventHandler(timer_Tick);
            _timer.Interval = 1000; // in miliseconds
            _timer.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            _grid.ToggleCursorBackground(_graphics, _spriteBatch);
        }

        public void PrintStringLine(string text)
        {
            _grid.DrawString(_graphics, _spriteBatch, _defaultPrompt);

            _grid.DrawStringLine(_graphics, _spriteBatch, text);
        }

        public void PrintDefaultPrompt()
        {
            _grid.DrawString(_graphics, _spriteBatch, _defaultPrompt);
        }

        public void PrintString(string text)
        {
            _grid.DrawString(_graphics, _spriteBatch, text);

            _numberOfPrintedSymbols++;
        }

        public void DeleteSymbol()
        {
            if(_numberOfPrintedSymbols == 0) 
                return;

            _grid.DeleteSymbol(_graphics, _spriteBatch);

            _numberOfPrintedSymbols--;
        }
    }
}

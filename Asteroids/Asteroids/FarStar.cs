using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroids
{
    class FarStar
    {
        protected Point Pos;
        protected Point Dir;
        protected int Radius;
        protected Brush Color;

        private static Random _rnd = new Random();
        private static Brush[] _colors = new Brush[] { Brushes.White, Brushes.Red, Brushes.Orange, Brushes.Yellow };


        public FarStar()
        {
            Init();
        }

        public void Draw()
        {
            Game.Buffer.Graphics.FillEllipse(Color, new Rectangle(Pos.X, Pos.Y, Radius, Radius));
        }

        public void Update()
        {
            Pos.Y = Pos.Y + Dir.Y;

			if (Pos.Y > Game.Height) Init();
		}

        public void Init(bool reinit=false)
		{
            int ypos = _rnd.Next(0, 2 * Game.Height) - Game.Height;
            if(reinit)
			{
                ypos -= Game.Height;
			}
            Pos = new Point(_rnd.Next(0, Game.Width), ypos);
            Dir = new Point(0, _rnd.Next(2, 30));
            Radius = _rnd.Next(2, 5);
            Color = _colors[_rnd.Next(_colors.Length)];
        }

    }
}

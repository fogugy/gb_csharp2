using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Asteroids
{
    static class Game
    {
        private static BufferedGraphicsContext _context;
        public static BufferedGraphics Buffer;
        static Asteroid[] _asteroids;
        static FarStar[] _farStars;

        public static int Width { get; set; }
        public static int Height { get; set; }

        public static void Init(Form form)
        {
            Graphics g = form.CreateGraphics();
            _context = BufferedGraphicsManager.Current;
            Width = form.ClientSize.Width;
            Height = form.ClientSize.Height;
            Buffer = _context.Allocate(g, new Rectangle(0, 0, Width, Height));

            Load();

            Timer timer = new Timer();
            timer.Interval = 60;
            timer.Tick += OnTime;
            timer.Start();
        }

        private static void OnTime(object sender, EventArgs e)
        {
            Draw();
            Update();
        }

        public static void Draw()
        {
            Buffer.Graphics.Clear(Color.Black);

            foreach (FarStar star in _farStars)
                star.Draw();

            Buffer.Graphics.FillEllipse(Brushes.Red, new Rectangle(100, 100, 100, 100));

            foreach (Asteroid asteroid in _asteroids)
                asteroid.Draw();


            Buffer.Render();
        }

        public static void Load()
        {
            var random = new Random();

            _asteroids = new Asteroid[15];
            for (int i = 0; i < _asteroids.Length; i++)
            {
                var size = random.Next(10, 50);
                _asteroids[i] = new Asteroid(new Point(600, i * 20 + 10), new Point(-i - 1, -i - 1), new Size(size, size));
            }

            _farStars = new FarStar[50];
            for (int i = 0; i < _farStars.Length; i++)
			{
                _farStars[i] = new FarStar();
			}
        }

        public static void Update()
        {
            foreach (Asteroid asteroid in _asteroids)
                asteroid.Update();

            foreach (FarStar flash in _farStars)
                flash.Update();
        }

    }
}

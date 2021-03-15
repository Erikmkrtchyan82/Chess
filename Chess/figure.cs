using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Chess
{
    class field:Image
    {
        public field()
        {
            Source = new BitmapImage(new Uri("/resources/ramka.gif", UriKind.Relative));
        }
    }
    public enum Color { BLACK, WHITE };
    abstract class figure
    {
        public figure(point pos, Color color)
        {
            image = new Image();
            image.Width = 32;
            image.Height = 32;
            image.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
            image.VerticalAlignment = System.Windows.VerticalAlignment.Bottom;
            image.Margin = new Thickness(10, 0, 0, 14);

            moves = new chess_t();

            this.color = color;
            this.pos = pos;
            moved = true;
            get_moves();
            moved = false;
        }
        public void set_position(int x, int y)
        {
            set_position(new point(x, y));
        }

        public abstract void set_position(point pos);
        public abstract chess_t get_moves();

        protected point pos;
        protected chess_t moves;
        public bool moved;

        public point position() { return this.pos; }

        protected Color color;

        private int _weight;
        public int weight {
            get { return _weight; }
            protected set {
                _weight =
                    color == Color.BLACK ?
                    -Math.Abs(value) :
                    Math.Abs(value);
            }
        }

        private string _path;
        protected string path {
            set
            {
                if (color == Color.BLACK)
                    _path = "/resources/b" + value;
                else
                    _path = "/resources/w" + value;

                image.Source= new BitmapImage(new Uri(_path,UriKind.Relative));
            }
            get { return _path; }
        }
        public Image image { protected set; get; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Chess
{
    abstract class figure
    {
        public const int Size = 32*2;
        public bool moved;
        public Image image { protected set; get; }
        protected const string extension = ".png";
        protected point pos;
        protected chess_t moves;
        protected Color color;
        private int _weight;
        private string _path;
        public field field { protected set; get; }

        public figure(point pos, Color color)
        {
            image = new Image();
            image.Width = Size;
            image.Height = Size;
            image.HorizontalAlignment = HorizontalAlignment.Left;
            image.VerticalAlignment = VerticalAlignment.Bottom;
            image.Margin = new Thickness(10, 0, 0, 14);

            moves = new chess_t();

            field = new field("select.png");

            this.color = color;
            this.pos = field.position = pos;
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
        public point get_position() { return this.pos; }
        public int weight {
            get { return _weight; }
            protected set {
                _weight =
                    color == Color.BLACK ?
                    -Math.Abs(value) :
                    Math.Abs(value);
            }
        }

        protected string path {
            set
            {
                if (color == Color.BLACK)
                    _path = "/resources/b" + value+extension;
                else
                    _path = "/resources/w" + value+extension;

                image.Source= new BitmapImage(new Uri(_path,UriKind.Relative));
            }
            get { return _path; }
        }

    }
}

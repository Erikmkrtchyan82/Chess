using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Chess
{
    abstract class figure
    {
        public figure(point pos,Color color)
        {
            this.color = color;
            this.pos = pos;
            moved = true;
            //get_moves();
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
        public enum Color {BLACK,WHITE};

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

using System;
using System.Collections.Generic;
using System.Text;

namespace Chess
{
    abstract class figure
    {
        public figure(point pos)
        {
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
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Chess
{
    class knight:figure
    {
        public knight(int x, int y) : this(new point(x, y)) { }
        public knight(point pos) : base(pos) { }

        public override chess_t get_moves()
        {
            if (!moved)
                return moves;

            int[] arr = { 1, 1, -1, -1, 1 };

            /*
             ( 1;2)   (2;1)
             (-1;2)  (-2;1)
             ( 1;-2)  (2;-1)
             (-1;-2) (-2;-1)
            */
            for (int i = 0; i < 4; ++i)
            {
                moves.add(pos.x + arr[i] * 1, pos.y + arr[i + 1] * 2);
                moves.add(pos.x + arr[i] * 2, pos.y + arr[i + 1] * 1);
            }

            return moves;
        }

        public override void set_position(point pos)
        {
            if (chess_t.check(pos))
            {
                this.pos = pos;
                moved = true;
            }
        }
    }
}

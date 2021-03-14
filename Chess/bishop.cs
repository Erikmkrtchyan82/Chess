using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace Chess
{
    class bishop:figure
    {
        public bishop(int x, int y, Color color) : this(new point(x, y), color) { }
        public bishop(point pos, Color color) : base(pos, color) {
            image = new Image();
            this.weight = 33;
            path = "b.gif";
        }
        public static void bishop_moves(chess_t moves, point pos, bool moved)
        {
            if (!moved)
                return;

            int[] coords = { 1, 1, -1, -1, 1 };

            for (int i = 0; i < 4; ++i)
            {
                int x = pos.x + coords[i];
                int y = pos.y + coords[i + 1];

                while (x >= 0 && x <= 7 && y >= 0 && y <= 7)
                {
                    moves.add(x, y);
                    x = x + coords[i];
                    y = y + coords[i + 1];
                }
            }
        }
        public override chess_t get_moves()
        {
            bishop_moves(moves, pos, moved);
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

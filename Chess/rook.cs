using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace Chess
{
    class rook:figure
    {
        public rook(int x, int y, Color color) : this(new point(x, y), color) { }
        public rook(point pos, Color color) : base(pos, color) {
            this.weight = 50;
            path = "r";
        }
        public static void rook_moves(chess_t moves, point pos)
        {
            for (int i = 0; i < 8; ++i)
            {
                moves.add(i, pos.y);
                moves.add(pos.x, i);
            }
        }

        public override chess_t get_moves()
        {
            if (moved)
            {
                moves.clear();
                rook_moves(moves, pos);
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

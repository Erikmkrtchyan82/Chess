using System;
using System.Collections.Generic;
using System.Text;

namespace Chess
{
    class rook:figure
    {
        public rook(int x, int y) : this(new point(x, y)) { }
        public rook(point pos) : base(pos) { }
        public static void rook_moves(chess_t moves, point pos, bool moved)
        {
            if (!moved)
                return;

            moves = new chess_t();

            for (int i = 0; i < 8; ++i)
            {
                moves.add(i, pos.y);
                moves.add(pos.x, i);
            }
        }

        public override chess_t get_moves()
        {
            rook_moves(moves, pos, moved);
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

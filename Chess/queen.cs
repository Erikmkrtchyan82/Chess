using System;
using System.Collections.Generic;
using System.Text;

namespace Chess
{
    class queen:figure
    {
        public queen(int x, int y) : this(new point(x, y)) { }
        public queen(point pos) : base(pos) { }

        public override chess_t get_moves()
        {
            bishop.bishop_moves(moves, pos, moved);
            rook.rook_moves(moves, pos, moved);
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

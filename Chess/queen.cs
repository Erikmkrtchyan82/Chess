using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace Chess
{
    class queen:figure
    {
        public queen(int x, int y,Color color) : this(new point(x, y),color) { }
        public queen(point pos, Color color) : base(pos, color) {
            this.weight = 90;
            path = "q.gif";
        }

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

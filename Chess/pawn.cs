using System;
using System.Collections.Generic;
using System.Text;

namespace Chess
{
    class pawn:figure
    {
        pawn(int x, int y) : this(new point(x, y)) { }
        pawn(point pos) : base(pos) { }

        public override chess_t get_moves()
        {
            if (!moved)
                return moves;

            moves.add(pos.x, pos.y + 1);
            
            if (is_first_move)
                moves.add(pos.x, pos.y + 2);

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

        private bool is_first_move = true;
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace Chess
{
    class pawn:figure
    {
        private bool is_first_move = true;

        public pawn(int x, int y, Color color) : this(new point(x, y), color) { }
        public pawn(point pos, Color color) : base(pos, color) {
            this.weight = 10;
            path = "p";
        }

        public override chess_t get_moves()
        {
            if (moved)
            {
                moves.clear();
                pawn_moves();
            }

            return moves;
        }
        private void pawn_moves()
        {
            int count = color == Color.WHITE ? 1 : -1;

            moves.add(pos.x, pos.y + count);
            
            if (is_first_move)
                moves.add(pos.x, pos.y + 2*count);
        }
        public override void set_position(point pos)
        {
            if (chess_t.check(pos))
            {
                this.pos = pos;
                moved = true;
                is_first_move = false;
            }
        }

    }
}

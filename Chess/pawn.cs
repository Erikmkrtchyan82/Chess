using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace Chess
{
    class pawn:figure
    {
        public pawn(int x, int y, Color color) : this(new point(x, y), color) { }
        public pawn(point pos, Color color) : base(pos, color) {
            image = new Image();
            this.weight = 10;
            path = "p.gif";
        }

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

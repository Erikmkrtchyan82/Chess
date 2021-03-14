using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace Chess
{
   
    class king:figure
    {
        public king(int x, int y,Color color) : this(new point(x, y),color) { }
        public king(point pos, Color color) : base(pos, color) {
            image = new Image();
            this.weight = 1000;
            path = "k.gif";
        }
        public override chess_t get_moves()
        {
            if (!moved)
                return moves;

            for(int i = pos.x-1; i <= pos.x+1; ++i)
            {
                for(int j = pos.y - 1; j <= pos.y + 1; ++j)
                {
                    if (i == pos.x && j == pos.y) continue;
                    moves.add(i, j);
                }
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

using System;
using System.Windows;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace Chess
{
   
    class king:figure
    {
        public king(int x, int y,Color color) : this(new point(x, y),color) { }
        public king(point pos, Color color) : base(pos, color) {
            this.weight = 1000;
            path = "k";
        }


        public override chess_t get_moves()
        {
            moves.clear();
            king_moves();
            return moves;
        }
        
        private void king_moves()
        {
            for (int i = pos.x-1; i <= pos.x+1; ++i)
            {
                for(int j = pos.y - 1; j <= pos.y + 1; ++j)
                {
                    if (i == pos.x && j == pos.y) continue;
                    if (board.self().has_figure_at(i, j))
                    {
                        figure f = board.self().figure_at(i,j);
                        if (f != null && f.color != board.self().figure_at(pos).color)
                        {
                            field field = new field("hit.png");
                            field.Margin = new Thickness(
                                field.standard_thickness.Left + figure.Size * i,
                                0,
                                0,
                                field.standard_thickness.Bottom + figure.Size * j
                                );
                            field.position = f.get_position();
                            board.self().moves.Add(field);
                            board.self().get_grid().Children.Add(field);
                        }
                        continue;
                    }
                    moves.add(i, j);
                }
            }
        }

        public override void set_position(point pos)
        {
            if (chess_t.check(pos))
            {
                this.pos = pos;
            }
        }
    }
}

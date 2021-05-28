using System;
using System.Windows;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace Chess
{
    class knight:figure
    {
        public knight(int x, int y,Color color) : this(new point(x, y),color) { }
        public knight(point pos, Color color) : base(pos, color) {
            this.weight = 30;
            path = "n";
        }


        public override chess_t get_moves()
        {
            moves.clear();
            knight_moves();
            return moves;
        }
        private void knight_moves()
        {
            int[] arr = { 1, 1, -1, -1, 1 };

            /*
             ( 1;2)   (2;1)
             (-1;2)  (-2;1)
             ( 1;-2)  (2;-1)
             (-1;-2) (-2;-1)
            */
            for (int i = 0; i < 4; ++i)
            {
                int x1 = pos.x + arr[i] * 1;
                int y1 = pos.y + arr[i + 1] * 2;

                int x2= pos.x + arr[i] * 2;
                int y2=pos.y + arr[i + 1] * 1;

                if (!board.self().has_figure_at(x1,y1)) 
                    moves.add(x1, y1);
                else
                {
                    figure f = board.self().figure_at(x1, y1);
                    if (f != null && f.color != board.self().figure_at(pos).color)
                    {
                        field field = new field("hit.png");
                        field.Margin = new Thickness(
                            field.standard_thickness.Left + figure.Size * x1,
                            0,
                            0,
                            field.standard_thickness.Bottom + figure.Size * y1
                            );
                        field.position = f.get_position();
                        board.self().moves.Add(field);
                        board.self().get_grid().Children.Add(field);
                    }
                }

                if (!board.self().has_figure_at(x2, y2))
                    moves.add(x2, y2);
                else
                {
                    figure f = board.self().figure_at(x2,y2);
                    if (f != null && f.color != board.self().figure_at(pos).color)
                    {
                        field field = new field("hit.png");
                        field.Margin = new Thickness(
                            field.standard_thickness.Left + figure.Size * x2,
                            0,
                            0,
                            field.standard_thickness.Bottom + figure.Size * y2
                            );
                        field.position = f.get_position();
                        board.self().moves.Add(field);
                        board.self().get_grid().Children.Add(field);
                    }
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

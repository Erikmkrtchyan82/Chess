using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace Chess
{
    class bishop:figure
    {
        public bishop(int x, int y, Color color) : this(new point(x, y), color) { }
        public bishop(point pos, Color color) : base(pos, color) {
            this.weight = 33;
            path = "b";
        }
        public static void bishop_moves(chess_t moves, point pos)
        {
            int[] coords = { 1, 1, -1, -1, 1 };

            for (int i = 0; i < 4; ++i)
            {
                int x = pos.x + coords[i];
                int y = pos.y + coords[i + 1];

                while (x >= 0 && x <= 7 && y >= 0 && y <= 7)
                {
                    if (board.self().has_figure_at(x, y))
                    {
                        figure f = board.self().figure_at(x, y);
                        if(f!=null && f.color != board.self().figure_at(pos).color)
                        {
                            field field = new field("hit.png");
                            field.Margin = new Thickness(
                                field.standard_thickness.Left + figure.Size * x,
                                0,
                                0,
                                field.standard_thickness.Bottom + figure.Size * y
                                );
                            field.position = f.get_position();
                            board.self().moves.Add(field);
                            board.self().get_grid().Children.Add(field);
                            moves.add(x, y);
                        }
                        break;
                    }
                    moves.add(x, y);
                    x = x + coords[i];
                    y = y + coords[i + 1];
                }
            }
        }
        public override chess_t get_moves()
        {
            moves.clear();
            bishop_moves(moves, pos);
            return moves;
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

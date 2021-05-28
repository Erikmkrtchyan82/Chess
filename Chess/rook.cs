using System;
using System.Windows;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace Chess
{
    class rook:figure
    {
        public rook(int x, int y, Color color) : this(new point(x, y), color) { }
        public rook(point pos, Color color) : base(pos, color) {
            this.weight = 50;
            path = "r";
        }
        public static void rook_moves(chess_t moves, point pos)
        {
            for (int i = pos.x + 1; i < 8; ++i)
            {
                if(board.self().has_figure_at(i, pos.y))
                {
                    figure f = board.self().figure_at(i, pos.y);
                    if (f != null && f.color != board.self().figure_at(pos).color)
                    {
                        field field = new field("hit.png");
                        field.Margin = new Thickness(
                            field.standard_thickness.Left + figure.Size * i,
                            0,
                            0,
                            field.standard_thickness.Bottom + figure.Size * pos.y
                            );
                        field.position = f.get_position();
                        board.self().moves.Add(field);
                        board.self().get_grid().Children.Add(field);
                        moves.add(i, pos.y);
                    }
                    break;
                }
                moves.add(i, pos.y);
            }

            for (int i = pos.x - 1; i >= 0; --i)
            {
                if(board.self().has_figure_at(i, pos.y))
                {
                    figure f = board.self().figure_at(i, pos.y);
                    if (f != null && f.color != board.self().figure_at(pos).color)
                    {
                        field field = new field("hit.png");
                        field.Margin = new Thickness(
                            field.standard_thickness.Left + figure.Size * i,
                            0,
                            0,
                            field.standard_thickness.Bottom + figure.Size * pos.y
                            );
                        field.position = f.get_position();
                        board.self().moves.Add(field);
                        board.self().get_grid().Children.Add(field);
                    }
                    break;
                }
                moves.add(i, pos.y);
            }

            for (int j = pos.y + 1; j < 8 ; ++j)
            {
                if (board.self().has_figure_at(pos.x, j))
                {
                    figure f = board.self().figure_at(pos.x, j);
                    if (f != null && f.color != board.self().figure_at(pos).color)
                    {
                        field field = new field("hit.png");
                        field.Margin = new Thickness(
                            field.standard_thickness.Left + figure.Size * pos.x,
                            0,
                            0,
                            field.standard_thickness.Bottom + figure.Size * j
                            );
                        field.position = f.get_position();
                        board.self().moves.Add(field);
                        board.self().get_grid().Children.Add(field);
                    }
                    break;
                }
                moves.add(pos.x, j);
            }

            for (int j = pos.y - 1; j >= 0; --j)
            {
                if (board.self().has_figure_at(pos.x, j))
                {
                    figure f = board.self().figure_at(pos.x, j);
                    if (f != null && f.color != board.self().figure_at(pos).color)
                    {
                        field field = new field("hit.png");
                        field.Margin = new Thickness(
                            field.standard_thickness.Left + figure.Size * pos.x,
                            0,
                            0,
                            field.standard_thickness.Bottom + figure.Size * j
                            );
                        field.position = f.get_position();
                        board.self().moves.Add(field);
                        board.self().get_grid().Children.Add(field);
                    }
                    break;
                }
                moves.add(pos.x, j);
            }
        }

        public override chess_t get_moves()
        {
            moves.clear();
            rook_moves(moves, pos);

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

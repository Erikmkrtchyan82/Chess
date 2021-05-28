using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
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
            moves.clear();
            pawn_moves();

            return moves;
        }
        private void pawn_moves()
        {
            int count = color == Color.WHITE ? 1 : -1;

            if (!board.self().has_figure_at(pos.x, pos.y+ count))
                moves.add(pos.x, pos.y + count);
            
            if (is_first_move && !board.self().has_figure_at(pos.x, pos.y + 2 * count))
                moves.add(pos.x, pos.y + 2*count);

            int x1 = pos.x - count;
            int x2 = pos.x + count;
            int y = pos.y + count;
            figure figure1 = board.self().figure_at(x1, y);
            figure figure2 = board.self().figure_at(x2, y);
            
            if(figure1!=null && figure1.color!=this.color)
            {
                field d = new field("hit.png");
                d.Margin = new Thickness(
                    field.standard_thickness.Left + figure.Size * x1,
                    0,
                    0,
                    field.standard_thickness.Bottom + figure.Size * y
                    );
                d.position = figure1.get_position();
                board.self().moves.Add(d);
                board.self().get_grid().Children.Add(d);
            }

            if (figure2 != null && figure2.color != this.color)
            {
                field d = new field("hit.png");
                d.Margin = new Thickness(
                    field.standard_thickness.Left + figure.Size * x2,
                    0,
                    0,
                    field.standard_thickness.Bottom + figure.Size * y
                    );
                d.position = figure2.get_position();
                board.self().moves.Add(d);
                board.self().get_grid().Children.Add(d);
            }

        }
        public override void set_position(point pos)
        {
            if (chess_t.check(pos))
            {
                this.pos = pos;
                is_first_move = false;
            }
        }

    }
}

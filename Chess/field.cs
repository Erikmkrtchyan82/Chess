using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Input;

namespace Chess
{
    class field :Image
    {
        public string path { private set; get; }
        public point position;
        public static Thickness standard_thickness= new Thickness(10, 0, 0, 14);
        public field(string path= "field.png")
        {
            Source = new BitmapImage(new Uri("/resources/"+path, UriKind.Relative));
            this.path = path;
            Width = Height = figure.Size;

            HorizontalAlignment = HorizontalAlignment.Left;
            VerticalAlignment = VerticalAlignment.Bottom;
            Margin =standard_thickness;

            MouseDown += clicked;
        }

        private void clicked(object sender, MouseButtonEventArgs e)
        {
            if (board.selected_figure == null)
                return;
            if (board.selected_figure.get_position() != position)
            {
                if (path.StartsWith("hit"))
                {
                    if (board.self().figure_at(position) is king)
                        return;

                    board.self().remove(board.self().figure_at(position));
                }
                
                board.selected_figure.image.Margin = new Thickness(
                    Margin.Left,
                    Margin.Top,
                    Margin.Right,
                    Margin.Bottom
                    );

                board.selected_figure.set_position(position);
                board.prev_color = board.selected_figure.color;
                if (is_check(board.selected_figure.color))
                {
                    return;
                }
            }
            
            board.self().clear_moves();
            board.self().clear_selected();

        }

        private bool is_check(Color color)
        {
            figure king = board.self().get_king((Color)(-(int)color));
            point pos = king.get_position();

            foreach (figure f in board.self().figures)
            {
                if (f.color != color) continue;
                
                if(f.get_moves().moves.Contains(pos))
                {
                    field field = new field("hit.png");
                    field.position = pos;
                    field.Margin = king.image.Margin;
                    board.check = field;
                    board.self().get_grid().Children.Add(field);
                    return true;
                }

            }

            return false;
        }

    }
}

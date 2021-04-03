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
            if (board.selected_figure.get_position() != position)
            {
                board.selected_figure.image.Margin = new Thickness(
                    Margin.Left,
                    Margin.Top,
                    Margin.Right,
                    Margin.Bottom
                    );

                if (path.StartsWith("hit"))
                {
                    board.self().remove(board.self().figure_at(position));
                }

                board.selected_figure.set_position(position);
            }
            
            board.self().clear_moves();
            board.self().clear_selected();

        }

    }
}

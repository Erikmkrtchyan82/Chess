using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

/*
    y
    ^
    |
    |
    |
    |
    |
    |
    |
    -----------------------> x
*/

namespace Chess
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    
    public partial class MainWindow : Window
    {
        board brd;

        public MainWindow()
        {
            InitializeComponent();

            board.Width = 8 * figure.Size;
            board.Height = 8 * figure.Size;
            brd = new board(table);

            standard();
        }

        private void standard()
        {
            brd.clear();

            brd.add(new rook(0, 0, Color.WHITE));
            brd.add(new rook(7, 0, Color.WHITE));
            brd.add(new rook(0, 7, Color.BLACK));
            brd.add(new rook(7, 7, Color.BLACK));

            brd.add(new knight(1, 0, Color.WHITE));
            brd.add(new knight(6, 0, Color.WHITE));
            brd.add(new knight(1, 7, Color.BLACK));
            brd.add(new knight(6, 7, Color.BLACK));

            brd.add(new bishop(2, 0, Color.WHITE));
            brd.add(new bishop(5, 0, Color.WHITE));
            brd.add(new bishop(2, 7, Color.BLACK));
            brd.add(new bishop(5, 7, Color.BLACK));

            brd.add(new king(4, 0, Color.WHITE));
            brd.add(new queen(3, 0, Color.WHITE));
            brd.add(new king(4, 7, Color.BLACK));
            brd.add(new queen(3, 7, Color.BLACK));

            for (int i = 0; i < 8; ++i)
            {
                brd.add(new pawn(i, 1, Color.WHITE));
                brd.add(new pawn(i, 6, Color.BLACK));
            }
        }

        private void standard(object sender, MouseButtonEventArgs e)
        {
            standard();
        }

        private void clear(object sender, MouseButtonEventArgs e)
        {
            brd.clear();
        }

        private void MouseDown(object sender, MouseButtonEventArgs e)
        {
            coordx.Text = "" + ((e.GetPosition(this).X - board.Margin.Left) / figure.Size);
            coordy.Text = "" + ((Math.Abs(640 - e.GetPosition(this).Y) - 38 - 14) / figure.Size);

            brd.set_moves(
                (int)((e.GetPosition(this).X - board.Margin.Left) / figure.Size),
                (int)((Math.Abs(640 - e.GetPosition(this).Y) - 38 - 14) / figure.Size)
                );
        }
    }
}

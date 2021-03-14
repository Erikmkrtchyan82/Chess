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
        List<figure> list;
        public MainWindow()
        {
            InitializeComponent();

            list = new List<figure>();

            list.Add( new bishop(5,5,figure.Color.BLACK));
            list.Add( new bishop(5,5,figure.Color.WHITE));

            list.Add(new king(5, 5, figure.Color.BLACK));
            list.Add(new king(5, 5, figure.Color.WHITE));

            list.Add(new queen(5, 5, figure.Color.BLACK));
            list.Add(new queen(5, 5, figure.Color.WHITE));

            list.Add(new rook(5, 5, figure.Color.BLACK));
            list.Add(new rook(5, 5, figure.Color.WHITE));

            list.Add(new pawn(5, 5, figure.Color.BLACK));
            list.Add(new pawn(5, 5, figure.Color.WHITE));

            list.Add(new knight(5, 5, figure.Color.BLACK));
            list.Add(new knight(5, 5, figure.Color.WHITE));

            x.Source = list[i].image.Source;
            ++i;
        }

        static int i = 0;

        private void mouse(object sender, MouseEventArgs e)
        {
            x.Source = list[i].image.Source;
            if (i < 11)
                ++i;
        }
    }
}

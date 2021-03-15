using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using System.Windows;

namespace Chess
{
    class board
    {
        private static Grid _grid;

        List<figure> figures;
        List<field> moves;
        public figure GetField() { return figures[2]; }
        public Grid get() { return _grid; }
        public board(Grid table)
        {
            if (_grid == null)
            {
                _grid = table;
                figures = new List<figure>();
            }
        }
        public void add(figure f)
        {
            f.image.Margin = new Thickness(
                f.image.Margin.Left + 32 * f.position().x,
                0,
                0,
                f.image.Margin.Bottom + 32 * f.position().y
                );
            _grid.Children.Add(f.image);
            figures.Add(f);
        }
        public void clear()
        {
            foreach(figure img in figures)
            {
                _grid.Children.Remove(img.image);
            }
        }

        public void set_moves(figure f)
        {
            foreach(point p in f.get_moves().moves)
            {
                field a = new field();
                a.Margin = new Thickness(
                    10+f.position().x*32,
                    0,
                    0,
                    14+f.position().y*32
                    );
                _grid.Children.Add(a);
            }

            

        }
    }
}

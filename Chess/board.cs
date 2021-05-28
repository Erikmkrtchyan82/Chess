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
        private static board _self = null;
        public List<figure> figures { private set; get; }
        public List<field> moves { private set; get; }
        public static figure selected_figure;
        public static Color prev_color = Color.BLACK;
        public static field check;

        public figure GetField() { return figures[2]; }
        public Grid get_grid() { return _grid; }
        public board(Grid table)
        {
            if (_grid == null)
            {
                _grid = table;
                figures = new List<figure>();
                moves = new List<field>();
                _self = this;
            }
        }
        public static board self()
        {
            return _self;
        }
        public void add(figure f)
        {
            f.image.Margin = new Thickness(
                f.image.Margin.Left + figure.Size * f.get_position().x,
                0,
                0,
                f.image.Margin.Bottom + figure.Size * f.get_position().y
                );
            _grid.Children.Add(f.image);
            figures.Add(f);
        }
        public void remove(figure f)
        {
            figures.Remove(f);
            _grid.Children.Remove(f.image);
        }
        public void clear()
        {
            prev_color = Color.BLACK;
            clear_figures();
            clear_moves();
        }
        public void clear_figures()
        {
            foreach (figure img in figures)
                _grid.Children.Remove(img.image);
            figures.Clear();
        }
        public void clear_moves()
        {
            foreach (field f in moves)
                _grid.Children.Remove(f);
            moves.Clear();
        }
        public void clear_selected()
        {
            _grid.Children.Remove(selected_figure?.field);
            selected_figure = null;
        }
        public bool has_figure_at(int x, int y)
        {
            return figure_at(x, y) != null;
        }
        public figure figure_at(point p)
        {
            return figure_at(p.x, p.y);
        }
        public figure figure_at(int x, int y)
        {
            return figures.Find((figure f) => { return f.get_position().x == x && f.get_position().y == y; });
        }
        public void set_moves(int x, int y)
        {
            clear_moves();
            clear_selected();

            figure figure = figure_at(x, y);
            if (figure != null && figure.color != prev_color)
            {
                set_moves(figure);
            }
        }
        private void set_moves(figure f)
        {
            foreach(point p in f.get_moves().moves)
            {
                field a = new field();
                double x = a.Margin.Left + figure.Size * p.x;
                double y = a.Margin.Bottom + figure.Size * p.y;
                a.Margin = new Thickness(
                    x,
                    0,
                    0,
                    y
                    );
                a.position = p;
                moves.Add(a);
                _grid.Children.Add(a);
            }

            f.field.Margin = new Thickness(
                field.standard_thickness.Left + figure.Size * f.get_position().x,
                0,
                0,
                field.standard_thickness.Bottom + figure.Size * f.get_position().y
                );
            f.field.position = f.get_position();

            _grid.Children.Add(f.field);

            selected_figure = f;

        }

        public figure get_king(Color color)
        {
            return figures.Find((figure f) => f is king && f.color == color);
        }
    }
}

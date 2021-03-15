using System;
using System.Collections.Generic;
using System.Text;

/*
 *          0 1 2 3 4 5 6 7
 *          _ _ _ _ _ _ _ _
 *      0  |_|_|_|_|_|_|_|_|
 *      1  |_|_|_|_|_|_|_|_|
 *      2  |_|_|_|_|_|_|_|_|
 *      3  |_|_|_|_|_|_|_|_|
 *      4  |_|_|_|_|_|_|_|_|
 *      5  |_|_|_|_|_|_|_|_|
 *      6  |_|_|_|_|_|_|_|_|
 *      7  |_|_|_|_|_|_|_|_|
 *      
 * 
 * 
 * */


namespace Chess
{
    class point
    {
        public point(int x,int y)
        {
            this.x = x;
            this.y = y;
        }

        public override bool Equals(object obj)
        {
            var p = obj as point;
            if (p == null)
                return false;
            return this.x == p.x && this.y == p.y;
        }

        public override int GetHashCode()
        {
            return this.x.GetHashCode() ^ this.y.GetHashCode();
        }


#if false
        public static bool operator==(point p1,point p2)
        {
            return p1.x == p2.x && p1.y == p2.y;
        }

        public static bool operator !=(point p1,point p2)
        {
            return p1.x != p2.x || p1.y != p2.y;
        }
#endif

        public int x { get; private set; }
        public int y { get; private set; }
    }


    class chess_t
    {
        public chess_t(int x=-1, int y=-1)
        {
            moves = new List<point>();
            add(x, y);
        }

        public void add(int x, int y)
        {
            if (check(x, y))
            {
                moves.Add(new point(x,y));
            }
        }

        public void remove(int x,int y)
        {
            if (check(x, y))
            {
                moves.Remove(new point(x, y));
            }
        }

        public void clear()
        {
            moves.Clear();
        }

        public static bool check(point p)
        {
            return check(p.x, p.y);
        }
        public static bool check(int x, int y)
        {
            return x >= 0 && x <= 7
                && y >= 0 && y <= 7;
        }

        public List<point> moves { get; private set; }
    }

}

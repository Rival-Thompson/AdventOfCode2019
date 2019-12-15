using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace RT.AOC2019.CMD.Day3
{
    public class Coordinate : IEquatable<Coordinate>
    {
        public static Coordinate NullPoint => new Coordinate(0, 0);

        public Coordinate(int x, int y)
        {
            X = x;
            Y = y;
        }


        public Coordinate MoveRight()
        {
            return new Coordinate(X + 1, Y);
        }

        public Coordinate MoveLeft()
        {
            return new Coordinate(X - 1, Y);
        }

        public Coordinate MoveUp()
        {
            return new Coordinate(X, Y + 1);
        }

        public Coordinate MoveDown()
        {
            return new Coordinate(X, Y - 1);
        }

        public int X { get; set; }
        public int Y { get; set; }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != typeof(Coordinate))
            {
                return false;
            }
            return Equals((Coordinate)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + X.GetHashCode();
                hash = hash * 23 + Y.GetHashCode();
                return hash;
            }
        }

        public override string ToString()
        {
            return $"{X}, {Y}";
        }

        public int DistanceBetween(Coordinate a)
        {
            var distanceX = Math.Abs(a.X) + Math.Abs(X);
            var distanceY = Math.Abs(a.Y) + Math.Abs(Y);
            return distanceX + distanceY;
        }

        public bool Equals([AllowNull] Coordinate other)
        {
            if (other != null)
            {
                return other.X == X && other.Y == Y;

            }
            return false;
        }
    }

    public class CoordinateList
    {
        public List<Coordinate> Coordinates { get; private set; } = new List<Coordinate>() { Coordinate.NullPoint};

        public void MoveRight(int move)
        {
            for (int i = 1; i <= move; i++)
            {
                Coordinates.Add(Coordinates.Last().MoveRight());
            }
        }

        public void MoveLeft(int move)
        {
            for (int i = 1; i <= move; i++)
            {
                Coordinates.Add(Coordinates.Last().MoveLeft());
            }
        }

        public void Moveup(int move)
        {
            for (int i = 1; i <= move; i++)
            {
                Coordinates.Add(Coordinates.Last().MoveUp());
            }
        }

        public void MoveDown(int move)
        {
            for (int i = 1; i <= move; i++)
            {
                Coordinates.Add(Coordinates.Last().MoveDown());
            }
        }

        public void PrepForComparison()
        {
            Coordinates.RemoveAt(0);
            Coordinates.Distinct();
        }
    }
}

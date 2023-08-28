using System;
using System.Collections.Generic;
using System.Text;

namespace DSALib.Util
{
    public class Point
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }
        public Point(float x = 0, float y = 0, float z = 0)
        {
            X = x;
            Y = y;
            Z = z;
        }
        public Point(Point point)
        {
            X = point.X;
            Y = point.Y;
            Z = point.Z;
        }

        public override bool Equals(Object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                Point p = (Point)obj;
                return (X == p.X) && (Y == p.Y) && (Z == p.Z);
            }
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + X.GetHashCode();
                hash = hash * 23 + Y.GetHashCode();
                hash = hash * 23 + Z.GetHashCode();
                return hash;
            }
        }

        public override string ToString()
        {
            return String.Format("Point({0}, {1}, {2})", X, Y, Z);
        }
    }
}

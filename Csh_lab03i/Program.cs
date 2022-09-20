using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csh_lab03i
{
    class Program
    {
        public struct Vector
        {
            double X;
            double Y;
            double Z;

            public Vector(double x, double y, double z)
            {
                X = x;
                Y = y;
                Z = z;
            }
            private double lenght()
            {
                return (Math.Sqrt(Math.Pow(X - 0, 2) + Math.Pow(Y - 0, 2) + Math.Pow(Z - 0, 2)));
            }

            public void print()
            {
                Console.WriteLine($"X - {X}");
                Console.WriteLine($"Y - {Y}");
                Console.WriteLine($"Z - {Z}");
                Console.WriteLine("\n");
            }
            public static Vector operator +(Vector vec1, Vector vec2)
            {
                Vector resultVec = new Vector(vec1.X + vec2.X, vec1.Y + vec2.Y, vec1.Z + vec2.Z);
                return resultVec;
            }

            public static Vector operator *(Vector vec, double f)
            {
                double _x = vec.X * f;
                double _y = vec.Y * f;
                double _z = vec.Z * f;
                return new Vector(_x, _y, _z);
            }

            public static Vector operator *(Vector vec1, Vector vec2)
            {
                Vector newVec = new Vector(vec1.X * vec2.X, vec1.Y * vec2.Y, vec1.Z * vec2.Z);
                return newVec;
            }

            public static bool operator >(Vector vec1, Vector vec2)
            {
                if (vec1.lenght() > vec2.lenght())
                {
                    return true;
                }
                return false;
            }
            public static bool operator <(Vector vec1, Vector vec2)
            {
                if (vec1.lenght() < vec2.lenght())
                {
                    return true;
                }
                return false;
            }

            public static bool operator >=(Vector vec1, Vector vec2)
            {
                if (vec1.lenght() >= vec2.lenght())
                {
                    return true;
                }
                return false;
            }
            public static bool operator <=(Vector vec1, Vector vec2)
            {
                if (vec1.lenght() <= vec2.lenght())
                {
                    return true;
                }
                return false;
            }

            public static bool operator ==(Vector vec1, Vector vec2)
            {
                if (vec1.lenght() == vec2.lenght())
                {
                    return true;
                }
                return false;
            }

            public static bool operator !=(Vector vec1, Vector vec2)
            {
                if (vec1.lenght() != vec2.lenght())
                {
                    return true;
                }
                return false;
            }


        }


        static void Main(string[] args)
        {
            Vector vecNew;
            Vector vecOne = new Vector(1, 1, 1);
            Vector vecTwo = new Vector(3, 2, 5);

            vecNew = vecOne * 5;
            vecNew.print();

            vecNew = vecOne * vecTwo;
            vecNew.print();

            vecNew = vecOne + vecTwo;
            vecNew.print();

            vecOne = vecOne * vecTwo;
            Console.WriteLine(vecOne == vecTwo);
        }
    }

}


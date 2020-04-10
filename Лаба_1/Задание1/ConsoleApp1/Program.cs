using System;
using System.Linq;

namespace Task1
{
    // не учитываются повороты, но учитывается хаотичный порядок точек
    public class Rectangle
    {

        private double[] x;
        private double[] y;

        public Rectangle() { }

        public Rectangle(double[] x, double[] y)
        {
            this.x = x;
            this.y = y;
        }

        public double Diagonal()
        {

            if (x == null || y == null)
                throw new NullReferenceException();

            if ((x.Length != 4) || (y.Length != 4))
                throw new ArgumentException("должно быть 4 координаты");

            Point[] points = new Point[4];
            for (int i = 0; i < 4; i++)
            {
                Point a = new Point(x[i], y[i]);
                points[i] = a;
            }

            // TODO просто исп. уравнением лежат ли точки на одной прямой
            
            for (int i = 0; i < 2; i++)
                for (int i1 = i+1; i1 < 3; i1++)
                    if (points[i] == points[i1])
                        throw new ArgumentException("Есть дублирующие координаты");

/*          
            Скалярные произведения в лоб, но порядок обхода немного неточный
            
           var sorted = points.OrderBy(s => s.X).ThenBy(s => s.X);
            for (int i = 0; i < 4; i++)
            {
                x[i] = sorted.ElementAt(i).X;
                y[i] = sorted.ElementAt(i).Y;
            }
            if (!((x[1] - x[0]) * (x[2] - x[1]) + (y[1] - y[0]) * (y[2] - y[1]) == 0
                & (x[2] - x[1]) * (x[3] - x[2]) + (y[2] - y[1]) * (y[3] - y[2]) == 0
                & (x[3] - x[2]) * (x[0] - x[3]) + (y[3] - y[2]) * (y[0] - y[3]) == 0
                & (x[0] - x[3]) * (x[1] - x[0]) + (y[0] - y[3]) * (y[1] - y[0]) == 0))
            {
                throw new ArgumentException("Не образуется прямоугольник");
            }*/
            //var sorted = points.OrderBy(s => s.X);

            // глупое сравнение, но я не сильна в геометрии :Р
            var sorted = points.OrderBy(s => s.X);
            if ((sorted.ElementAt(0).X == sorted.ElementAt(1).X)
                && (sorted.ElementAt(2).X == sorted.ElementAt(3).X))
            {
                sorted = points.OrderBy(s => s.Y);

                if ((sorted.ElementAt(0).Y == sorted.ElementAt(1).Y)
                 && (sorted.ElementAt(2).Y == sorted.ElementAt(3).Y))
                {

                    // находим  противоопложные углы и меряем расстояние 
                    // между двумя координатами
                    // По классике т Пифагора
                    sorted = points.OrderBy(s => s.X).ThenBy(s => s.Y);
                    Point vertices1 = new Point(sorted.ElementAt(0));
                    Point vertices2 = new Point(sorted.ElementAt(3));

                    double d2 = Math.Pow((vertices1.X) - (vertices2.X), 2)
                        + Math.Pow((vertices1.Y) - (vertices2.Y), 2);

                    double d = Math.Sqrt(d2);
                    return Math.Round(d, 3);
                }
                else
                    throw new ArgumentException("Не правильный прямоугольник");

            }
            else
            {
                throw new ArgumentException("Не правильный прямоугольник");
            }
        }

        public void SetVertices(double[] x, double[] y)
        {
            this.x = x;
            this.y = y;
        }

        static void Main(string[] args) { }
    }

    class Point
    {
        public double X { get; private set; }
        public double Y { get; private set; }

        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }
        public Point(Point p)
        {
            X = p.X;
            Y = p.Y;
        }
        public static bool operator ==(Point a, Point b)
        {
            return ((a.X == b.X) && (a.Y == b.Y));
        }
        public static bool operator !=(Point a, Point b)
        {
            return !(a == b);
        }
    }
}

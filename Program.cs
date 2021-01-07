using System;

namespace geometric
{
    class Point
    {
        int x;
        int y;
        public int X
        {
            get { return x; }
            set { x = value; }
        }
        public int Y
        {
            get { return y; }
            set { y = value; }
        }
        public Point(int a, int b)
        {
            x = a;
            y = b;
        }
        public override string ToString()
        {
            return "Point";
        }
        public static float length(Point a, Point b)
        {
            return Convert.ToSingle(Math.Sqrt(Math.Pow((a.x - b.x), 2) + Math.Pow((a.y - b.y), 2)));
        }
        public static float cos(Point a, Point b, Point c)
        {
            return Convert.ToSingle(((a.x - b.x) * (c.x - b.x) + (a.y - b.y) * (c.y - b.y)) / (length(a, b) * length(b, c)));
        }
        public static bool collinear(Point a, Point b, Point c)
        {
            if ((a.x-b.x) * (a.y - c.y) == (a.x - c.x) * (a.y - b.y)) return true;
            return false;
        }
        public static bool parallel(Point a, Point b, Point c, Point d)
        {
            if ((b.x - a.x) * (c.y - d.y) == (b.y - a.y) * (c.x - d.x)) return true;
            return false;
        }
    }
    abstract class Shape
    {
        public abstract float getPerimeter();
        public abstract float getArea();
    }
    
    class Circle:Shape
    {
        private Point center;
        public Point Center
        {
            get { return center; }
            set { center = value; }
        }
        byte radius;
        public byte Radius
        {
            get { return radius; }
            set { radius = value; }
        }
        public Circle(Point c,byte r)
        {
            center = c;
            radius = r;
        }
        public override string ToString()
        {
            return "Circle";
        }
        public override float getArea()
        {
            return Convert.ToSingle(Math.PI * Math.Pow(radius, 2));
        }
        public override float getPerimeter()
        {
            return Convert.ToSingle(2 * Math.PI * radius);
        }
    }
    class Triangle:Shape
    {
        protected Point p1;
        public Point P1
        {
            get { return p1; }
            set { p1 = value; }
        }
        protected Point p2;
        public Point P2
        {
            get { return p2; }
            set { p2 = value; }
        }
        protected Point p3;
        public Point P3
        {
            get { return p3; }
            set { p3 = value; }
        }
        public Triangle(Point x1,Point x2,Point x3)
        {
            p1 = x1;
            p2 = x2;
            p3 = x3;
            if ( Point.collinear(x1,x2,x3 ) )
            {
                Exception a = new Exception("3 collinear points, not make a triangle");
                throw a;
            }
        }
        public override string ToString()
        {
            return "Triangle";
        }
        public override float getPerimeter()
        {
            float p = (Point.length(p1, p2) + Point.length(p1, p2) + Point.length(p2, p3)); 
            return p;
        }
        public override float getArea()
        {
            float p = (Point.length(p1, p2) + Point.length(p2, p3) + Point.length(p3, p1) ) / 2;
            return Convert.ToSingle(Math.Sqrt(p * (p - Point.length(p1, p2)) * (p - Point.length(p2, p3)) * (p - Point.length(p3, p1))));
        }
    }
    class ConvexQuadrangle : Triangle
    {
        protected Point p4;
        public Point P4
        {
            get { return p4; }
            set { P4 = value; }
        }
        public ConvexQuadrangle(Point x1, Point x2, Point x3, Point x4) : 
            base(x1, x2, x3)
        {
            p4 = x4;
            if (Point.collinear(x1, x2, x3) || Point.collinear(x2, x3, x4) || Point.collinear(x3, x4, x1) || Point.collinear(x4, x3, x2)
                || Math.Acos(Point.cos(x1,x2,x3))+Math.Acos(Point.cos(x2,x3,x4))+Math.Acos(Point.cos(x3,x4,x1))+Math.Acos(Point.cos(x4,x1,x2)) < 2 * Math.PI)
              
            {
                Exception a = new Exception("The shape is not a convex quadrangle");
                throw a;
            }
        }
        public override string ToString()
        {
            return "Convex Quadrangle";
        }
        public override float getPerimeter()
        {
            return Point.length(p1, p2) + Point.length(p2, p3) + Point.length(p3, p4) + Point.length(p4, p1);
        }
        public override float getArea()
        {
            Triangle ABC = new Triangle(p1, p2, p3);
            Triangle ADC = new Triangle(p1, p4, p3);
            return ABC.getArea() + ADC.getArea();
        }
    }

    class Trapezium : ConvexQuadrangle
    {
        public Trapezium(Point x1,Point x2,Point x3,Point x4 ):
            base(x1, x2, x3, x4)
        {
            if ( Point.parallel(x1,x2,x3,x4) == false && Point.parallel(x1,x4,x3,x2) == false )
            {
                Exception a = new Exception("The shape is not a trapezium");
                throw a;
            }
        }
        public override string ToString()
        {
            return "Trapezium";
        }
        public override float getPerimeter()
        {
            return base.getPerimeter();
        }
        public override float getArea()
        {
            return base.getArea();
        }
    }
    class Parallelogram : ConvexQuadrangle
    {
        public Parallelogram(Point x1,Point x2,Point x3,Point x4):
            base(x1,x2,x3,x4)
        {
            if (Point.parallel(x1, x2, x3, x4) == false || Point.parallel(x1, x4, x3, x2) == false)
            {
                Exception a = new Exception("The shape is not a parallelogram");
                throw a;
            }
        }
        public override string ToString()
        {
            return "Parallelogram";
        }
        public override float getPerimeter()
        {
            return 2 * (Point.length(p1, p2) + Point.length(p2, p3));
        }
        public override float getArea()
        {
            float sin, h;
            sin = Convert.ToSingle(Math.Sqrt(1-Point.cos(p1, p4, p3) * Point.cos(p1, p4, p3)));
            h = Point.length(p1, p4) * sin;
            return h * Point.length(p3, p4);
        }
    }
    interface IRectangle
    {
    }
    class Rectangle : Parallelogram,IRectangle
    {
        public Rectangle(Point x1,Point x2,Point x3,Point x4):
            base(x1,x2,x3,x4)
        {
            if (Point.cos(x1, x2, x3) != 0)
            {             
                    Exception a = new Exception("The shape is not a quadrangle");
                    throw a;
            } 
        }
        public override string ToString()
        {
            return "Rectangle";
        }
        public override float getPerimeter()
        {
            return base.getPerimeter();
        }
        public override float getArea()
        {
            return Point.length(p1, p2) * Point.length(p2, p3);
        }
    }
    class Lozenge : Parallelogram
    {
        public Lozenge(Point x1,Point x2,Point x3,Point x4):
            base(x1,x2,x3,x4)
        {
            if (Point.length(x1,x2) == Point.length(x2,x3))
            {
                Exception a = new Exception("The shape is not a lozenge");
                throw a;
            }
        }
        public override string ToString()
        {
            return "Lozenge";
        }
        public override float getPerimeter()
        {
            return 4 * Point.length(p1, p2);
        }
        public override float getArea()
        {
            return Point.length(p1, p3) * Point.length(p2, p4) / 2;
        }
    }
    class Square : Lozenge,IRectangle
    {
        public Square(Point x1, Point x2, Point x3, Point x4) :
            base(x1, x2, x3, x4)
        {
            if (Point.cos(x1, x2, x3) == 0)
            {
                Exception a = new Exception("The shape is not a square");
                throw a;
            }
        }
        public override string ToString()
        {
            return "Square";
        }
        public override float getPerimeter()
        {
            return base.getPerimeter();
        }
        public override float getArea()
        {
            Rectangle ABCD = new Rectangle(p1, p2, p3, p4);
            return ABCD.getArea();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            ////Convex Quadrangle 
            //Point A = new Point(0, 0);
            //Point B = new Point(2, 0);
            //Point C = new Point(2, 2);
            //Point D = new Point(0, 2);
            //ConvexQuadrangle ABCD = new ConvexQuadrangle(A, B, C, D);
            //Console.WriteLine(" " + ABCD.getPerimeter());
        }
    }
}
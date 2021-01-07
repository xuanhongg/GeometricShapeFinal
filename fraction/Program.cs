using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Fraction
{
    class Frac
    {
        int tu;
        int mau;
        public Frac(int nume, int deno)
        {
            if (deno == 0)
                throw new Exception("Error!");
            try
            {
                if (deno == 0)
                {
                    throw new Exception("Phan so khong hop le");
                }
                else
                {
                    int r = GCD(nume, deno);
                    tu = nume / r;
                    mau = deno / r;
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Phan so khong hop le.");
            }
            finally 
            {
                while (deno == 0)
                {
                    Console.WriteLine("Nhap mot mau so khac");
                    deno = int.Parse(Console.ReadLine());
                }
                int r = GCD(nume, deno);
                tu = nume / r;
                mau = deno / r;
            }
        }
        static int GCD (int x, int y)
        {
            int r;
            while (x % y != 0)
            {
                r = x % y;
                x = y;
                y = r;
            }
            return y;
        }
        // cac phep tinh giua phan so va phan so
        public static Frac operator -(Frac a)
        {
            return new Frac(-a.tu, a.mau);
        }
        public static Frac operator *(Frac a, Frac b)
        {
            int x = a.tu * b.tu;
            int y = a.mau * b.mau;
            int r = GCD(x, y);
            return new Frac(x/r, y/r);
        }
        public static Frac operator +(Frac a, Frac b)
        {
            int x = a.tu*b.mau + a.mau*b.tu;
            int y = a.mau * b.mau;
            int r = GCD(x, y);
            return new Frac(x/r, y/r);
        }
        public static Frac operator -(Frac a, Frac b)
        {
            return a + (-b);
        }
        
        //thuc hien phep tinh phan so voi so nguyen
        public static Frac operator +(Frac a, int b)
        {
            Frac c = new Frac(b, 1);
            return a + c;
        }
        public static Frac operator +(int a, Frac b)
        {
            return b + a;
        }
        public static Frac operator -(Frac a, int b)
        {
            Frac c = new Frac(b, 1);
            return a - c;
        }
        public static Frac operator -(int a, Frac b)
        {
            return (-b) + a;
        }
        public static Frac operator *(Frac a, int b)
        {
            Frac c = new Frac(b, 1);
            return a * c;
        }
        public static Frac operator *(int a, Frac b)
        {
            return b * a;
        }
        
        
        // cac phep toan logic
        public override bool Equals(object o)
        {
            if (!(o is Frac)) 
                return false;
            return this == (Frac) o; 
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        //so sanh hai phan so
        public static bool operator ==(Frac a, Frac b)
        {
            Frac c = a - b;
            if (c.tu == 0) 
                return true;
            return false;
        }
        public static bool operator != (Frac a, Frac b)
        {
            if (a == b) return false;
            return true;
        }
        public static bool operator >(Frac a, Frac b)
        {
            Frac c = a - b;
            if (c.tu * c.mau > 0) 
                return true;
            return false;
        }
        public static bool operator >=(Frac a, Frac b)
        {
            if ( a > b) return true;
            if ( a == b) return true;
            return false;
        }
        public static bool operator <(Frac a, Frac b)
        {
            if (a >= b) return false;
            return true;
        }
        public static bool operator <=(Frac a, Frac b)
        {
            if (a > b) return false;
            return true;
        }
        //so sanh phan so va so nguyen
        public static bool operator ==(Frac a, int b)
        {
            Frac c = new Frac(b, 1);
            if (a == c) 
                return true;
            return false;
        }
        public static bool operator ==(int a, Frac b)
        {
            if (b == a) 
                return true;
            return false;
        }
        public static bool operator !=(Frac a, int b)
        {
            Frac c = new Frac(b, 1);
            if (a != c) return true;
            return false;
        }
        public static bool operator !=(int a, Frac b)
        {
            if (b != a) return true;
            return false;
        }
        public static bool operator >(Frac a, int b)
        {
            Frac c = new Frac(b, 1);
            if (a > c) 
                return true;
            return false;
        }
        public static bool operator >(int a, Frac b)
        {
            Frac c = new Frac(a, 1);
            if (c > b) 
                return true;
            return false;
        }
        public static bool operator >=(Frac a, int b)
        {
            if ( a > b) return true;
            if ( a == b) return true;
            return false;
        }
        public static bool operator >=(int a, Frac b)
        {
            if ( a > b) return true;
            if ( a == b) return true;
            return false;
        }
        public static bool operator <(Frac a, int b)
        {
            if (a >= b) return false;
            return true;
        }
        public static bool operator <(int a, Frac b)
        {
            if (a >= b) return false;
            return true;
        }
        public static bool operator <=(Frac a, int b)
        {
            if (a > b) return false;
            return true;
        }
        public static bool operator <=(int a, Frac b)
        {
            if (a > b) return false;
            return true;
        }
        public override string ToString()
        {
            if (mau == 1)
                return tu.ToString();
            return tu.ToString() + "/" + mau.ToString();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("nhap vao so n: ");
            int n;
            n = int.Parse(Console.ReadLine());
            List<Frac> a = new List<Frac>();
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("nhap vao phan so thu " + (i+1));
                Console.Write("Nhap tu so: ");
                int x = int.Parse(Console.ReadLine());
                Console.Write("Nhap mau so: ");
                int y = int.Parse(Console.ReadLine());
                Frac c = new Frac(x, y);
                a.Add(c);
            }
            //sap xep lai List a
            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < n; j++)
                    if (a[i] > a[j])
                    {
                        Frac tg = a[i];
                        a[i] = a[j];
                        a[j] = tg;
                    }
            }
            Console.WriteLine("Day da sap xep la: ");
            foreach ( Frac b in a)
                Console.Write(b + " ");
            Console.WriteLine();
            Frac s = new Frac(0, 1);
            for (int i = 0; i < n; i++)
                s = s + a[i];
            Console.WriteLine("Tong la: " + s);
        }
    }
}

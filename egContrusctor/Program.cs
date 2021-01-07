using System;

namespace egContrusctor
{
    class SV
    {
        string name;
        int msv;
        float point;
        public SV (string ten, int mssv, float diem)
        {
            name = ten;
            msv = mssv;
            point = diem;
        }
        public void disphay()
        {
            Console.WriteLine("sinh vien {0} (ma so: {1}) dat {2} diem", name, msv, point);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("nhap vao so luong sinh vien: ");
            int n = int.Parse(Console.ReadLine());
            List<SV> a = new List<SV>();
            for (int i = 0; i < n; i++)
            {
                Console.Write("nhap vao ten cua sinh vien thu {0}: ", i + 1);
                string ten = Console.ReadLine();
                Console.Write("nhap vao mssv sinh vien thu {0}: ", i + 1);
                int mssv = int.Parse(Console.ReadLine());
                Console.Write("nhap vao diem cua sinh vien thu {0}: ", i + 1);
                float diem = float.Parse(Console.ReadLine());
                SV b = new SV(ten, mssv, diem);
                a.Add(b);
            }
            for (int i = 0; i < n; i++)
                a[i].disphay();
            Console.ReadKey();
        }
    }
}

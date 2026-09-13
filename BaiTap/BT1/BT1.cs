using System;

class BT1
{
    static void Main()
    {
        int a, b, c;

        // Enter number 1
        while (true)
        {
            Console.Write("Nhap so thu nhat: ");
            try
            {
                a = int.Parse(Console.ReadLine());
                break;
            }
            catch
            {
                Console.WriteLine("Du lieu khong hop le! Vui long nhap lai.");
            }
        }

        // Enter number 2
        while (true)
        {
            Console.Write("Nhap so thu hai: ");
            try
            {
                b = int.Parse(Console.ReadLine());
                break;
            }
            catch
            {
                Console.WriteLine("Du lieu khong hop le! Vui long nhap lai.");
            }
        }

        // Enter number 3
        while (true)
        {
            Console.Write("Nhap so thu ba: ");
            try
            {
                c = int.Parse(Console.ReadLine());
                break;
            }
            catch
            {
                Console.WriteLine("Du lieu khong hop le! Vui long nhap lai.");
            }
        }

        // Caculate sum
        Console.WriteLine($"{a} + {b} + {c} = {a+b+c}");
    }
}

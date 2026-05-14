using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace szamologep
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Egyik szám: ");
            int a = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Másik szám: ");
            int b = Convert.ToInt32(Console.ReadLine());

            int osszeg = a + b;
            Console.WriteLine($"{a} + {b} = {osszeg}");

            int kul = a - b;
            Console.WriteLine($"{a} - {b} = {kul}");

            int szor = a * b;
            Console.WriteLine($"{a} * {b} = {szor}");

            double hany = (double) a / b;
            Console.WriteLine($"{a} / {b} = {hany}");

            int maradek = a % b;
            Console.WriteLine($"{a} % {b} = {maradek}");


        }
    }
}

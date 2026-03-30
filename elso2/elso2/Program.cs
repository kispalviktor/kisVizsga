using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace elso2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine("Mi a neved? ");
            string nev = Console.ReadLine();
            Console.WriteLine("Csókolom " + nev + "!");

            int egesz = 56;
            double tort = 3.14;
            string szoveg = "alma";
            char betu = 'A';
            bool logikai = true;

            Console.WriteLine($"Ez egy egész szám: {egesz}");
            Console.WriteLine($"Ez egy törtszám: {tort}");
            Console.WriteLine($"Ez egy szöveg: {szoveg}");
            Console.WriteLine($"Ez egy karakter: {betu}");
            Console.WriteLine($"Ez egy logikai érték: {logikai}");

            
        }
    }
}

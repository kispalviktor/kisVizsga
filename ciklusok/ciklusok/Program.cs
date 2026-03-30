using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ciklusok
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Írjuk ki 1-től 10-ig a számokat:
            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("_________________________");

            //Írjuk ki 2-től 100-ig a páros számokat:
            for (int i = 2; i <= 100; i += 2)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("_________________________");

            //Írjuk ki 50-től 0-ig csökkenő sorrendben a számokat:
            for (int i = 50; i >= 0; i--)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("_________________________");

            //Olvassunk be egy egész számot és írjuk ki az osztóit:
            Console.Write("Írjon be egy egész számot: ");
            int szam = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("A szám osztói: ");
            Console.WriteLine("1, ");
            for (int i = 2; i <= szam / 2; i++) //1-től indul. 'szam'-ig megy. eggyesével.
            {
                if (szam % i == 0)
                {
                    Console.Write($"{i}, ");
                }
            }
            Console.WriteLine(szam);
            Console.WriteLine();
            Console.WriteLine("_________________________");


            //Olvassunk be számokat addig, amíg 6-ot nem írnak be:
            Console.Write("Írjon be egy számot: ");
            szam = Convert.ToInt32(Console.ReadLine());
            while (szam != 6)
            {
                Console.Write("Írjon be egy számot: ");
                szam = Convert.ToInt32(Console.ReadLine());
            }
            Console.WriteLine("Eltaláltad!");
            Console.WriteLine("_________________________");

            //Ugyanez hátul tesztelő ciklussal:
            do
            {
                Console.Write("Írjon be egy számot: ");
                szam = Convert.ToInt32(Console.ReadLine());
            } while (szam != 6);
            Console.WriteLine("Eltaláltad!");
            Console.WriteLine("_________________________");

            //Olvassunk be számokat, amíg 0-t nem írnak be, írjuk ki a számok összegét:
            int osszeg = 0;
            int a = 0;
            do
            {
                Console.Write("Írjon be egy számot: ");
                a = Convert.ToInt32(Console.ReadLine());
                osszeg += a;
            } while (a != 0);
            Console.WriteLine($"A számok összege: {osszeg}");
            Console.WriteLine("_________________________");

            //Generáljunk 100 db 1 és 50 közé eső véletlen számot!
            //Írjunk ki, hogy hány darab páros volt közöttük

            Random r = new Random();
            int parosdb = 0;
            for (int i = 1; i <= 100; i++)
            {
                int vel = r.Next(1, 51);
                Console.WriteLine($"{vel},");
                if (vel % 2 == 0)
                {
                    parosdb++;
                }
            }
            Console.WriteLine($"{parosdb} db páros szám volt.");
            Console.WriteLine("_________________________");

            //Olvassunk be egy osztály tanulóinak magasságát!
            //A beolvasás végét -1 beírásával jelezzük!
            //Írjuk ki, hogy hányadik tanuló a legmagassabb, és hány cm magas
            int max = 0;   //legnagyobb magasság
            int ssz = 1;   //személy sorszáma
            int cm = 0;    //beolvasott magasság
            int maxi = 0;  //legnagyobb magasság sorszáma
            while (cm != -1)
            {
                Console.Write("Írja be az osztály tanulóinak magasságát: ");
                cm = Convert.ToInt32(Console.ReadLine());
                ssz++;

                if (max < cm)
                {
                    max = cm;
                    maxi = ssz;
                }
            }
            Console.WriteLine($"A legmagasabb {maxi}-edik, a magassága {max} cm.");

            //Olvassuk be egy számot (n)
            //Írjuk ki az első n db négyzetszámot
            Console.Write("Írja be az osztály tanulóinak magasságát: ");
            int n = Convert.ToInt32(Console.ReadLine());
            for (int i = 1; i <= n; i++)
            {
                Console.Write($"{i * i}, ");
            }
        }
    }
}

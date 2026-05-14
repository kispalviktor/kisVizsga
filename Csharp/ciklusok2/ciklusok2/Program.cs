using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ciklusok2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Olvassunk be egy számot,és írjuk ki a faktoriálisát!
            Console.Write("Írja be a számot: ");
            int n = Convert.ToInt32(Console.ReadLine());
            int fakt = 1;
            for (int i = 1; i <= n; i++)
            {
                fakt *= i; //fakt = fakt * i
            }
            Console.WriteLine($"{n}! = {fakt}");
            Console.WriteLine("_________________________");

            //Olvassunk be egy számot, és írjunk ki a Fibonacci-sorozatot az annyadik elemi
            Console.Write("Írja be a számot: ");
            n = Convert.ToInt32(Console.ReadLine());
            int elozoelotti = 1;
            int elozo = 1;

            Console.Write($"1, 1, ");
            for (int i = 2; i <= n; i++)
            {
                int kovetkezo = elozo + elozoelotti;
                Console.Write($"{kovetkezo}, ");
                elozoelotti = elozo;
                elozo = kovetkezo;
            }
            Console.WriteLine("_________________________");

            //Olvassunk be lábméreteket amíg 0-t nem írnak be
            //Írjuk ki, hogy mekkora és hogy hányadik a legkisebb láb
            int meret = 0;
            int ssz = 0;             //sorszám
            int min = int.MaxValue;  //legkisebb
            int mini = 0;            //legkisebb sorszáma
            do
            {
                Console.Write("Következő láb: ");
                meret = Convert.ToInt32(Console.ReadLine());
                ssz++;
                if (meret < min && meret != 0)
                {
                    min = meret;
                    mini = ssz;
                }
            }while (meret != 0);
            Console.WriteLine($"A legkisebb láb {min} cm, a {mini}. volt");
            Console.WriteLine("_________________________");

            //Generáljunk le egy hét napi hőmérsékleteit! (-10, 10 között)
            //Írjuk ki, hogy hány napon fagyott!
            Random r = new Random();
            int fagynap = 0;
            for (int i = 1; i <= 7; i++)
            {
                int vel = r.Next(-10, 11);
                if (vel < 0)
                {
                    fagynap++;
                }
            }
            Console.WriteLine($"A héten {fagynap}db napon fagyott");

        }
    }
}

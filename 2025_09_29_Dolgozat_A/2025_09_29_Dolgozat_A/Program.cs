using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2025_09_29_Dolgozat_A
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("/// 2025.09.29. Dolgozat - A csoport ///");
            Console.WriteLine("----------------------------------------");
            int kg = 0;
            int max = 0;
            int konnyudb = 0;
            int kozepesdb = 0;
            int nehezdb = 0;
            while (kg != -1)
            {
                Console.Write("Írja be az érkező csomag tömegét: ");
                kg = Convert.ToInt32(Console.ReadLine());
                if (kg < 10 && kg >= 0)
                {
                    Console.WriteLine("A csomag könnyű.");
                    konnyudb++;
                    if(max < kg)
                    {
                        max = kg;
                    }
                }
                else if (kg >= 10 && kg < 50)
                {
                    Console.WriteLine("A csomag közepes.");
                    kozepesdb++;
                    if (max < kg)
                    {
                        max = kg;
                    }
                }
                else if(kg >= 50)
                {
                    Console.WriteLine("A csomag nehéz.");
                    nehezdb++;
                    if (max < kg)
                    {
                        max = kg;
                    }
                }
                else if(kg == -1)
                {
                    Console.WriteLine("Vége az adatbevitelnek.");
                }
            }
            Console.WriteLine("----------------------------------------");
            Console.WriteLine($"{konnyudb} db könnyű csomagot pakolt a gép.");
            Console.WriteLine($"{kozepesdb} db közepes csomagot pakolt a gép.");
            Console.WriteLine($"{nehezdb} db nehéz csomagot pakolt a gép.");
            Console.WriteLine($"{max} kg volt a legnehezebb csomag.");
        }
    }
}

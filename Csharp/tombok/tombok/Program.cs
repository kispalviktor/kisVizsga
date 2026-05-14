using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tombok
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Tároljunk el 100 db 1 és 500 közötti véletlen számot

            Random rnd = new Random();
            int[] szamok = new int[100]; //100 elemű egészeket tároló tömb

            for(int i = 0; i < szamok.Length; i++)
            {
                szamok[i] = rnd.Next(1, 1001);
            }

            for(int i = 0;i < szamok.Length;i++)
            {
                Console.Write($"{szamok[i]}, ");
            }

            //Írjuk ki a páros számok átlagát!

            int osszeg = 0;
            int db = 0;

            for (int i = 0; i < szamok.Length; i++)
            {
                if(szamok[i] % 2 == 0)
                {
                    osszeg += szamok[i];
                    db++;
                }
            }

            double atlag = (double) osszeg / db;
            Console.WriteLine($"\nA páros számok átlaga: {atlag:0.00}");

            //Melyik a legnagyobb szám és hányadik a sorban

            int max = 0;
            int idb = 0;

            for(int i = 0; i < szamok.Length; i++)
            {
                if(szamok[i] > max)
                {
                    max = szamok[i];
                    idb = i;
                }
            }

            Console.WriteLine($"A legnagyobb szám a {max} és {idb + 1}. a sorban");

            //Számoljuk meg, hogy hány db 3-mal osztható szám van a sorozatban.

            int haromdb = 0;

            for(int i = 0; i < szamok.Length; i++)
            {
                if (szamok[i] % 3 == 0)
                {
                    haromdb++;
                }
            }

            Console.WriteLine($"{haromdb} db 3-mal osztható szám van a sorozatban.");
        }
    }
}
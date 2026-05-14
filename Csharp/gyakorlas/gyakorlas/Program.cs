using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gyakorlas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            int[] szamok = new int[50];

            for (int i = 0; i < szamok.Length; i++)
            {
                szamok[i] = rnd.Next(-60, 101);
                Console.Write($"{szamok[i]}, ");
            }

            Console.WriteLine();

            long szorzat = 1;
            for(int i = 0; i < szamok.Length; i++)
            {
                szorzat *= szamok[i];
            }

            Console.WriteLine($"1. feladat: {szorzat}");


            Console.WriteLine("2. feladat: ");
            for(int i = szamok.Length - 1; i >= 0; i--)
            {
                if (szamok[i] % 5 == 0 || szamok[i] % 7 == 0)
                {
                    Console.WriteLine($"Az utolsó 5-tel vagy 7-tel osztható szám indexe: {i}");
                    break;
                }
            }


            Console.WriteLine("3. feladat: ");
            for (int i = 0; i < szamok.Length; i++)
            {
                if (szamok[i] % 3 == 0 && szamok[i] % 7 == 0)
                {
                    Console.WriteLine($"Az első 3-mal és 7-tel osztható szám indexe: {i}");
                    break;
                }
            }

            Console.WriteLine("4. feladat: ");
            bool mindnegativ = true;
            for(int i = 0; i < szamok.Length; i++)
            {
                if (szamok[i] >= 0)
                {
                    mindnegativ = false;
                    break;
                }
            }

            if(mindnegativ == true)
            {
                Console.WriteLine("Mindeggyik negatív.");
            }
            else
            {
                Console.WriteLine("Van közte pozitív.");
            }

            Console.WriteLine("6. feladat: ");
            int db = 0;
            for(int i = 0; i < szamok.Length; i++)
            {
                if(szamok[i] % 18 == 0)
                {
                    db++;
                }
            }

            Console.WriteLine($"A 18-cal osztható számok száma {db}");

            Console.WriteLine("7. feladat: ");
            int min = szamok[0];
            int mini = 0;

            for(int i = 0;i < szamok.Length; i++)
            {
                if (szamok[i] < min)
                {
                    min = szamok[i];
                    mini = i;
                }
            }

            Console.WriteLine($"A legkisebb szám a {min}, indexe a {mini}");

            Console.WriteLine("9. feladat: ");
            bool van = false;
            for(int i = 1; i < szamok.Length; i++)
            {
                if( szamok[i] < 0 && szamok[i + 1] > 0 && szamok[i - 1] > 0)
                {
                    van = true;
                    break;
                }
            }

            if(van == true)
            {
                Console.WriteLine("Van ilyen szám.");
            }
            else
            {
                Console.WriteLine("Nincs ilyen szám.");
            }
        }
    }
}

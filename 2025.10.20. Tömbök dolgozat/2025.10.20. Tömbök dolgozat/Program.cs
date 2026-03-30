using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2025._10._20.Tömbök_dolgozat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            int[] szamok = new int[30];

            for (int i = 0; i < szamok.Length; i++)
            {
                szamok[i] = rnd.Next(-20, 71);
                Console.Write($"{szamok[i]}, ");
            }


            Console.WriteLine();


            for (int i = szamok.Length - 1; i >= 0; i--)
            {
                if (szamok[i] % 3 == 0 || szamok[i] % 5 == 0)
                {
                    Console.WriteLine($"1. feladat: Az utolsó 3-mal vagy 5-tel osztható szám indexe: {i}.");
                    break;
                }
            }


            bool van = false;
            for (int i = 0; i < szamok.Length; i++)
            {
                if (szamok[i] < -10 && szamok[i] > -30)
                {
                    van = true;
                    break;
                }
            }
            if (van == true)
            {
                Console.WriteLine("2. feladat: Van a számok közül olyan, amely -10-nél kisebb, de -30-nál nagyobb.");
            }
            else
            {
                Console.WriteLine("2. feladat: Nincs a számok közül olyan, amely -10-nél kisebb, de -30-nál nagyobb.");
            }


            int db = 0;
            for (int i = 0; i < szamok.Length; i++)
            {
                if (szamok[i] % 7 == 0)
                {
                    db++;
                }
            }
            Console.WriteLine($"3. feladat: A 7-tel osztható számok száma {db}.");


            int max = 0;
            for (int i = 0; i < szamok.Length; i++)
            {
                if (szamok[i] > max)
                {
                    max = szamok[i];
                }
            }
            Console.WriteLine($"4. feladat: A legnagyobb szám {max}.");
        }
    }
}

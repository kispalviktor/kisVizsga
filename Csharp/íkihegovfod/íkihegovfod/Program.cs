using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace íkihegovfod
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            int[] szamok = new int[40];

            for (int i = 0; i < szamok.Length; i++)
            {
                szamok[i] = rnd.Next(-50, 81);
            }

            for (int i = 0; i < szamok.Length; i++)
            {
                Console.Write($"{szamok[i]}, ");
            }

            Console.WriteLine();
            Console.WriteLine();

            int atlag = 0;
            for (int i = 0; i < szamok.Length; i++)
            {
                atlag += szamok[i];
            }

            Console.WriteLine($"1. feladat: A sorozatban található számok átlaga: {atlag / 40}");


                for (int i = szamok.Length - 1; i >= 0; i--)
            {
                if (szamok[i] % 5 == 0 && szamok[i] % 9 == 0)
                {
                    Console.WriteLine($"2. feladat: Az utolsó 5-tel és 9-cel osztható szám indexe: {i + 1}");
                    break;
                }
            }



            for (int i = 0; i < szamok.Length; i++)
            {
                if (szamok[i] % 2 == 0 || szamok[i] % 7 == 0)
                {
                    Console.WriteLine($"3. feladat: Az első 2-vel vagy 7-tel osztható szám indexe: {i + 1}");
                    break;
                }
            }



            bool parose = false;
            for (int i = 0; i < szamok.Length; i++)
            {
                if(szamok[i] % 2 == 0)
                {
                    parose = true;
                    break;
                }
            }

            if(parose == true)
            {
                Console.WriteLine("4. feladat: Nem minden szám páros");
            }
            else
            {
                Console.WriteLine("4. feladat: Minden szám páros");
            }



            bool nagyobb = false;
            for (int i = 0; i < szamok.Length; i++)
            {
                if (szamok[i] > 70)
                {
                    nagyobb = true;
                    break;
                }
            }

            if (nagyobb = true)
            {
                Console.WriteLine("5. feladat: Van a sorozatban olyan szám, amelyik 70-nél nagyobb");
            }
            else
            {
                Console.WriteLine("5. feladat: Nincs a sorozatban olyan szám, amelyik 70-nél nagyobb");
            }



            int negativ = 0;
            for (int i = 0; i < szamok.Length; i++)
            {
                if (szamok[i] < 0)
                {
                    negativ++;
                }
            }

            Console.WriteLine($"6. Feladat: {negativ} db negatív szám található a sorozatban");



            int max = 0;
            for (int i = 0; i < szamok.Length; i++)
            {
                if (szamok[i] > max && szamok[i] % 4 == 0)
                {
                    max = szamok[i];
                }
            }
            Console.WriteLine($"7. feladat: A legnagyobb 4-gyel osztható szám: {max}");
        }
    }
}

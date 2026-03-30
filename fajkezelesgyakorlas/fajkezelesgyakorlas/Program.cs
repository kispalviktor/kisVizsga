using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace fajkezelesgyakorlas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] sorok = File.ReadAllLines("03_000.txt");
            int[] szamok = new int[sorok.Length];

            for(int i = 0; i < sorok.Length; i++)
            {
                szamok[i] = int.Parse(sorok[i]);
            }

            bool van = false;
            for(int i = 0; i < sorok.Length; i++)
            {
                if(szamok[i] % 100 == 0)
                {
                    van = true;
                    break;
                }
            }

            if(van == true)
            {
                Console.WriteLine("1. feladat: Van a sorozatban 100-zal osztható szám.");
            }
            else
            {
                Console.WriteLine("1. feladat: Nincs a sorozatban 100-zal osztható szám.");
            }

            for(int i = szamok.Length - 1; i >= 0; i--)
            {
                if (szamok[i] % 7 == 0)
                {
                    Console.WriteLine($"2. feladat: Az utolsó 7-tel osztható szám indexét: {i}");
                    break;
                }
            }

            int osszeg = 0;
            for(int i = 0; i < sorok.Length; i++)
            {
                osszeg += szamok[i];
            }

            double atlag = (double) osszeg / szamok.Length;
            Console.WriteLine($"4. feladat: A sorozatban található számok átlagának a négyzete: {atlag}");

            int db = 0;
            for(int i = 0; i < sorok.Length; i++)
            {
                if (szamok[i] < 0)
                {
                    db++;
                }
            }

            Console.WriteLine($"6. feladat: A sorozatban {db} db negatív szám van");

            int min = int.MaxValue;
            for(int i = 0; i < sorok.Length; i++)
            {
                if(szamok[i] < min)
                {
                    min = szamok[i];
                }
            }

            Console.WriteLine($"A legkissebb elem fele {min / 2}");
            StreamWriter negativ = new StreamWriter("negativ.txt");
            StreamWriter pozitiv = new StreamWriter("pozitiv.txt");

            for(int i = 0; i < sorok.Length; i++)
            {
                if (szamok[i] < 0)
                {
                    negativ.WriteLine(szamok[i]);
                }
                else
                {
                    pozitiv.WriteLine(szamok[i]);
                }
            }

            negativ.Close();
            pozitiv.Close();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace fajlkezeles_Bdolgozat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] sorok = File.ReadAllLines("be.txt");
            int[] szamok = new int[sorok.Length];

            for (int i = 0; i < sorok.Length; i++)
            {
                szamok[i] = int.Parse(sorok[i]);
            }



            int db = 0;
            for(int i = 0; i < sorok.Length; i++)
            {
                if(szamok[i] > 30)
                {
                    db++;
                }
            }
            Console.WriteLine($"1. feladat: {db} db 30-nál nagyobb szám van a sorozatban");



            for (int i = szamok.Length - 1; i >= 0; i--)
            {
                if (szamok[i] % 9 == 0 || szamok[i] % 15 == 0)
                {
                    Console.WriteLine($"2. feladat: Az utolsó 9-cel vagy 15-tel osztható szám indexe: {i}");
                    break;
                }
            }



            int szorzat = 1;
            for(int i = 0; i < sorok.Length; i++)
            {
                szorzat = szamok[i] * szorzat;
            }
            Console.WriteLine($"3. feladat: A sorozatban található számok szorzatának a fele: {szorzat / 2}");



            int max = 0;
            for(int i = 0; i < sorok.Length; i++)
            {
                if (szamok[i] < -10 && szamok[i] < max)
                {
                    max = szamok[i];
                }
            }
            Console.WriteLine($"4. feladat: A legnagyobb szám a -10-nél kisebbek közül: {max}");



            StreamWriter ki = new StreamWriter("ki.txt");

            for (int i = 0; i < sorok.Length; i++)
            {
                if (szamok[i] > 0)
                {
                    ki.WriteLine(szamok[i] * 2);
                }
            }

            ki.Close();
            Console.WriteLine("5. feladat: [tekintse meg a 'ki.txt' nevű fájlt]");
        }
    }
}

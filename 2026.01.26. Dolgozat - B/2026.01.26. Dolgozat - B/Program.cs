using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _2026._01._26.Dolgozat___B
{
    internal class Program
    {
        class Snooker
        {
            public int Helyezes { get; set; }
            public string Nev { get; set; }
            public string Orszag { get; set; }
            public int Nyeremeny { get; set; }

            public Snooker(string sor)
            {
                string[] darabok = sor.Split(';');
                Helyezes = int.Parse(darabok[0]);
                Nev = darabok[1];
                Orszag = darabok[2];
                Nyeremeny = int.Parse(darabok[3]);
            }
        }

        static void Main(string[] args)
        {
            string[] sorok = File.ReadAllLines("snooker.txt");
            List<Snooker> snookerek = new List<Snooker>();

            for (int i = 1; i < sorok.Length; i++)
            {
                Snooker s = new Snooker(sorok[i]);
                snookerek.Add(s);
            }

            // 1. feladat
            Console.WriteLine($"1. feladat: {snookerek.Count} versenyző szerepel a világranglistán!");

            // 2. feladat
            bool lengyel = false;
            foreach(var s in snookerek)
            {
                if(s.Orszag == "Lengyelország")
                {
                    lengyel = true;
                    break;
                }
            }

            if(lengyel == true)
            {
                Console.WriteLine("2. feladat: Igen, szerepel rajta lengyel játékos!");
            }
            else
            {
                Console.WriteLine("2. feladat: Nem, nem szerepel rajta lengyel játékos!");
            }

            // 3. feladat
            int walesNyeremeny = 0;
            int Nyeremenydb = 0;
            foreach(var s in snookerek)
            {
                if (s.Orszag == "Wales")
                {
                    walesNyeremeny += s.Nyeremeny;
                    Nyeremenydb++;
                }
            }

            Console.WriteLine($"3. feladat: Átlagosan {walesNyeremeny / Nyeremenydb} Ft-ot kerestek a walesi versenyzők!");

            // 4. feladat
            string masodik = "";
            foreach(var s in snookerek)
            {
                if(s.Helyezes == 2)
                {
                    masodik = s.Nev;
                }
            }

            Console.WriteLine($"4. feladat: {masodik}, aki a második helyen áll a világranglistán!");

            // 5. feladat
            Console.WriteLine("5. feladat: Országonként ennyi pénzt kerestek a versenyzőik!");
            HashSet<string> orszagok = new HashSet<string>();
            foreach (var s in snookerek)
            {
                orszagok.Add(s.Orszag);
            }

            foreach (var o in orszagok)
            {
                int osszNyeremeny = 0;
                foreach (var s in snookerek)
                {
                    if (s.Orszag == o)
                    {
                        osszNyeremeny += s.Nyeremeny;
                    }
                }
                Console.WriteLine($"\t{o} - {osszNyeremeny} Ft");
            }
        }
    }
}

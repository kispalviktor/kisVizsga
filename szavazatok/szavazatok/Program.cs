using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace szavazatok
{
    internal class Program
    {
        class Vote
        {
            public int Korzet { get; set; }
            public int Szavazatok { get; set; }
            public string Vezeteknev { get; set; }
            public string Utonev { get; set; }
            public string Part { get; set; }
        }
        static void Main(string[] args)
        {
            string[] sorok = File.ReadAllLines("szavazatok.txt");
            List<Vote> votes = new List<Vote>();

            for (int i = 0; i < sorok.Length; i++)
            {
                string[] darabok = sorok[i].Split(' ');
                Vote v = new Vote();
                v.Korzet = int.Parse(darabok[0]);
                v.Szavazatok = int.Parse(darabok[1]);
                v.Vezeteknev = darabok[2];
                v.Utonev = darabok[3];
                v.Part = darabok[4];

                votes.Add(v);
            }

            Console.WriteLine($"1. feladat: {votes.Count} db jelölt indult a választáson.");

            int hep = 0;
            foreach(var v in votes)
            {
                if(v.Part == "HEP")
                {
                    hep++;
                }
            }
            Console.WriteLine($"2. feladat: {hep} db jelöltet indított a 'HEP' nevű párt.");

            int min = 10000;
            string vezetek = "uh";
            string uto = "hu";
            foreach(var v in votes)
            {
                if(v.Korzet == 7 && v.Szavazatok < min)
                {
                    min = v.Szavazatok;
                    vezetek = v.Vezeteknev;
                    uto = v.Utonev;
                }
            }
            Console.WriteLine($"3. feladat: A 7-es körzetben {vezetek} {uto} kapta a legkevesebb szavazatot.");

            Console.WriteLine($"4. feladat: A pártok ennyi jelölteket indítottak:");
            HashSet<string> partok = new HashSet<string>();
            foreach (var v in votes)
            {
                partok.Add(v.Part);
            }

            foreach (var p in partok)
            {
                int db = 0;
                foreach (var v in votes)
                {
                    if (v.Part == p)
                    {
                        db++;
                    }
                }
                Console.WriteLine($"\t{p} - {db} fő");
            }
        }
    }
}

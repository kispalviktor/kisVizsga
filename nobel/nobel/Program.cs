using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace nobel
{
    internal class Program
    {
        class Dij
        {
            public int Evszam { get; set; }
            public string Tipus { get; set; }
            public string Vezetek { get; set; }
            public string Kereszt { get; set; }

            public Dij(int evszam, string tipus, string kereszt, string vezetek)
            {
                Evszam = evszam;
                Tipus = tipus;
                Vezetek = vezetek;
                Kereszt = kereszt;
            }
        }
        static void Main(string[] args)
        {
            List<Dij> dijak = new List<Dij>();
            string[] sorok = File.ReadAllLines("nobel.txt");

            for (int i = 1; i < sorok.Length; i++)
            {
                string[] darabok = sorok[i].Split(';');
                Dij d = new Dij(int.Parse(darabok[0]), darabok[1], darabok[2], darabok[3]);
                dijak.Add(d);
            }

            foreach (var d in dijak)
            {
                if(d.Kereszt == "Arthur B." && d.Vezetek == "McDonald")
                {
                    Console.WriteLine($"3. feladat: {d.Tipus}");
                    break;
                }
            }


            foreach (var d in dijak)
            {
                if (d.Evszam == 2017 && d.Tipus == "irodalmi")
                {
                    Console.WriteLine($"4. feladat: {d.Kereszt} {d.Vezetek}");
                    break;
                }
            }

            foreach (var d in dijak)
            {
                if (d.Evszam == 1990 && d.Tipus == "beke" && d.Vezetek == "")
                {
                    Console.WriteLine($"5. feladat: {d.Kereszt} {d.Vezetek}");
                    break;
                }
            }

            Console.WriteLine("6. feladat: ");
            foreach (var d in dijak)
            {
                if (d.Vezetek.Contains("Curie"))
                {
                    Console.WriteLine($"\t{d.Evszam}: {d.Kereszt} {d.Vezetek} ({d.Tipus})");
                }
            }

            HashSet<string> kategoriak = new HashSet<string>();
            foreach (var d in dijak)
            {
                kategoriak.Add(d.Tipus);
            }

            foreach(var k in kategoriak)
            {
                int db = 0;
                foreach(var d in dijak)
                {
                    if(d.Tipus == k)
                    {
                        db++;
                    }
                }
                Console.WriteLine($"{k}\t{db} db");
            }

            StreamWriter sw = new StreamWriter("orvosi.txt");
            foreach(var d in dijak)
            {
                if(d.Tipus == "orvosi")
                {
                    sw.WriteLine($"{d.Evszam}:{d.Kereszt} {d.Vezetek}");
                }
            }

            sw.Close();
        }
    }
}

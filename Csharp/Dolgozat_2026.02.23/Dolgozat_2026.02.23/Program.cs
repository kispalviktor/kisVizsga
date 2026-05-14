using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Dolgozat_2026._02._23
{
    class Futam
    {
        public string Date { get; set; }
        public string Grandprix { get; set; }
        public int Position { get; set; }
        public int Laps { get; set; }
        public int Points { get; set; }
        public string Team { get; set; }
        public string Status { get; set; }

        public Futam(string sor)
        {
            string[] f = sor.Split(';');
            Date = f[0];
            Grandprix = f[1];
            Position = int.Parse(f[2]);
            Laps = int.Parse(f[3]);
            Points = int.Parse(f[4]);
            Team = f[5];
            Status = f[6];
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            string[] sorok = File.ReadAllLines("schumacher.txt");
            List<Futam> futamok = new List<Futam>();

            for (int i = 1; i < sorok.Length; i++)
            {
                Futam f = new Futam(sorok[i]);
                futamok.Add(f);
            }

            Console.WriteLine($"1. feladat: {futamok.Count}db információ található a forrásállományban!");


            int engine = 0;

            foreach (var f in futamok)
            {
                if(f.Status == "Engine")
                {
                    engine++;
                }
            }

            Console.WriteLine($"2. feladat: {engine}db futam volt olyan, amit motorhiba miatt kellett feladnia!");

            int max = 0;
            string benetton = "";
            foreach(var f in futamok)
            {
                if(f.Points > max && f.Team == "Benetton")
                {
                    max = f.Points;
                }
            }

            Console.WriteLine($"3. feladat: {max}pont volt a legtöbb pont, amit szerzett a Benetton színeiben szereztek");

            Console.WriteLine("4. feladat: Az egyes csapatok színeiben ennyi első helyet szerzett:");
            HashSet<string> csapatok = new HashSet<string>();

            foreach (var f in futamok)
            {
                csapatok.Add(f.Team);
            }

            foreach(var c in csapatok)
            {
                int osszElso = 0;
                foreach(var f in futamok)
                {
                    if(f.Team == c && f.Position == 1)
                    {
                        osszElso++;
                    }
                }
                Console.WriteLine($"\t{c} - {osszElso}");
            }
        }
    }
}

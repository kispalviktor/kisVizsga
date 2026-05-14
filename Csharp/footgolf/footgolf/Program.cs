using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace footgolf
{
    internal class Program
    {
        class Eredmeny
        {
            public List<int> Pontok = new List<int>();
            public string Nev { get; set; }
            public string Kat { get; set; }
            public string Egyesulet { get; set; }

            public Eredmeny(string sor)
            {
                string[] d = sor.Split(';');
                Nev = d[0];
                Kat = d[1];
                Egyesulet = d[2];
                for (int i = 3; i < d.Length; i++)
                {
                    Pontok.Add(int.Parse(d[i]));
                }
            }

            public int Osszpont()
            {
                Pontok.Sort();
                int ossz = 0;
                if (Pontok[0] != 0) ossz += 10;
                if (Pontok[1] != 0) ossz += 10;

                for (int i = 2; i < Pontok.Count; i++)
                {
                    ossz += Pontok[i];
                }
                
                return ossz;

            }

        }
        static void Main(string[] args)
        {
            string[] sorok = File.ReadAllLines("fob2016.txt");
            List<Eredmeny> eredmenyek = new List<Eredmeny>();
            foreach (string s in sorok)
            {
                Eredmeny e = new Eredmeny(s);
                eredmenyek.Add(e);
            }

            Console.WriteLine($"Versenyzők száma: {eredmenyek.Count}");

            int nok = 0;
            foreach (var e in eredmenyek)
            {
                if(e.Kat == "Noi")
                {
                    nok++;
                }
            }

            double szazalek = (double) nok / eredmenyek.Count * 100;

            Console.WriteLine($"Női versenyzők aránya: {szazalek:0.00}%");

            string nev = "";
            int max = 0;

            foreach(var e in eredmenyek)
            {
                if(e.Kat == "Noi" && e.Osszpont() > max)
                {
                    max = e.Osszpont();
                    nev = e.Nev;
                }
            }

            Console.WriteLine($"Legjobb női: {nev}, pont: {max}");

            StreamWriter sw = new StreamWriter("osszpontFF.txt");

            foreach (var e in eredmenyek)
            {
                if (e.Kat == "Felnott ferfi")
                {
                    sw.WriteLine($"{e.Nev};{e.Osszpont()}");
                }
            }

            sw.Close();

            HashSet<string> eggyesuletek = new HashSet<string>();

            foreach (var e in eredmenyek)
            {
                eggyesuletek.Add(e.Egyesulet);
            }

            foreach(var egy in eggyesuletek)
            {
                int db = 0;
                foreach (var e in eredmenyek)
                {
                    if (e.Egyesulet == egy) db++;
                }

                if(db > 2 && egy != "n.a.")
                {
                    Console.WriteLine($"{egy} - {db}");
                }
            }
        }
    }
}

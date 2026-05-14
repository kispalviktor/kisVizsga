using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace epitmenyado
{
    internal class Program
    {
        class Epitmeny
        {
            public string AdoSzam { get; set; }
            public string Utca { get; set; }
            public string HSz { get; set; }
            public string Sav { get; set; }
            public int NM { get; set; }

            public Epitmeny(string sor)
            {
                string[] d = sor.Split(' ');
                AdoSzam = d[0];
                Utca = d[1];
                HSz = d[2];
                Sav = d[3];
                NM = int.Parse(d[4]);
            }
        }

        static List<Epitmeny> epitmenyek = new List<Epitmeny>();
        static string[] sorok = File.ReadAllLines("utca.txt");

        static string[] darabok = sorok[0].Split(' ');
        static int adoA = int.Parse(darabok[0]);
        static int adoB = int.Parse(darabok[1]);
        static int adoC = int.Parse(darabok[2]);

        static int Ado(string sav, int nm)
        {
            int fizetendo = 0;
            if (sav == "A")
            {
                fizetendo = nm * adoA;
            }
            if (sav == "B")
            {
                fizetendo = nm * adoB;
            }
            if (sav == "C")
            {
                fizetendo = nm * adoC;
            }

            if(fizetendo < 10000)
            {
                return 0;
            }
            else
            {
                return fizetendo;
            }
        }
        static void Main(string[] args)
        {
            for (int i = 1; i < sorok.Length; i++)
            {
                Epitmeny e = new Epitmeny(sorok[i]);
                epitmenyek.Add(e);
            }

            Console.WriteLine($"2. feladat. A mintában {epitmenyek.Count} telek szerepel.");
            Console.Write("3. feladat. Egy tulajdonos adószáma: ");
            string adosz = Console.ReadLine();

            bool van = false;
            foreach (var e in epitmenyek)
            {
                if(e.AdoSzam == adosz)
                {
                    Console.WriteLine($"{e.Utca} utca {e.HSz}");
                    van = true;
                }
            }

            if(van == false)
            {
                Console.WriteLine("Nem szerepel az adatállományban.");
            }

            Console.WriteLine("5. feladat");

            int dbA = 0;
            int dbB = 0;
            int dbC = 0;

            int osszA = 0;
            int osszB = 0;
            int osszC = 0;

            foreach(var e in epitmenyek)
            {
                if(e.Sav == "A")
                {
                    dbA++;
                    osszA += Ado(e.Sav, e.NM);
                }

                if (e.Sav == "B")
                {
                    dbB++;
                    osszB += Ado(e.Sav, e.NM);
                }

                if (e.Sav == "C")
                {
                    dbC++;
                    osszC += Ado(e.Sav, e.NM);
                }
            }

            Console.WriteLine($"A sávba {dbA} telek esik, az adó {osszA} Ft.");
            Console.WriteLine($"A sávba {dbB} telek esik, az adó {osszB} Ft.");
            Console.WriteLine($"A sávba {dbC} telek esik, az adó {osszC} Ft.");

            HashSet<string> savok = new HashSet<string>();
            for(int i = 0; i < epitmenyek.Count - 1; i++)
            {
                savok.Add(epitmenyek[i].Sav);
                if (epitmenyek[i].Utca != epitmenyek[i + 1].Utca)
                {
                    if(savok.Count > 1)
                    {
                        Console.WriteLine(epitmenyek[i].Utca);
                    }
                    savok.Clear();
                }
            }

            HashSet<string> tulajok = new HashSet<string>();
            foreach(var e in epitmenyek)
            {
                tulajok.Add(e.AdoSzam);
            }

            StreamWriter sw = new StreamWriter("fizetendo.txt");
            foreach (var t in tulajok)
            {
                int ado = 0;
                foreach(var e in epitmenyek)
                {
                    if (e.AdoSzam == t)
                        ado += Ado(e.Sav, e.NM);
                }
                sw.WriteLine($"{t} {ado}");
            }
            
            sw.Close();
        }
    }
}

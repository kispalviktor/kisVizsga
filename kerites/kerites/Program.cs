using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace kerites
{
    internal class Program
    {
        class Telek
        {
            public int Hsz { get; set; }
            public int Szeles { get; set; }
            public string Szin { get; set; }

            public Telek(int hsz, int szeles, string szin)
            {
                Hsz = hsz;
                Szeles = szeles;
                Szin = szin;
            }
        }
        static void Main(string[] args)
        {
            string[] sorok = File.ReadAllLines("kerites.txt");
            List<Telek> paros = new List<Telek>();
            List<Telek> paratlan = new List<Telek>();

            int paroshsz = 2;
            int paratlanhsz = 1;

            foreach (string s in sorok)
            {
                string[] darabok = s.Split(' ');
                if (darabok[0] == "0")
                {
                    Telek t = new Telek(paroshsz, int.Parse(darabok[1]), darabok[2]);
                    paros.Add(t);
                    paroshsz += 2;
                }
                else
                {
                    Telek t = new Telek(paratlanhsz, int.Parse(darabok[1]), darabok[2]);
                    paratlan.Add(t);
                    paratlanhsz += 2;
                }
            }

            Console.WriteLine("2. feladat");
            Console.WriteLine($"Az eladott telkek száma: {sorok.Length}");

            Console.WriteLine();

            Console.WriteLine("3. feladat");
            if (sorok[sorok.Length - 1].StartsWith("0"))
            {
                Console.WriteLine("A páros oldalon adták el az utolsó telket.");
                Console.WriteLine($"Az utolsó telek házszáma: {paroshsz - 2}");
            }
            else
            {
                Console.WriteLine("A páratlan oldalon adták el az utolsó telket.");
                Console.WriteLine($"Az utolsó telek házszáma: {paratlanhsz - 2}");
            }

            Console.WriteLine();

            Console.WriteLine("4. feladat");
            for (int i = 0; i < paratlan.Count - 1; i++)
            {
                if (paratlan[i].Szin == paratlan[i + 1].Szin && paratlan[i].Szin != ":" && paratlan[i].Szin != "#")
                {
                    Console.WriteLine($"A szomszédossal egyezik a kerítés színe: {paratlan[i].Hsz}");
                    break;
                }
            }

            Console.WriteLine();

            Console.WriteLine("5. feladat");
            Console.Write("Adjon meg egy házszámot! ");
            int hsz = int.Parse(Console.ReadLine());

            if (hsz % 2 == 0)
            {
                int hanyadik = 0;
                for (int i = 0; i < paros.Count; i++)
                {
                    if (paros[i].Hsz == hsz)
                    {
                        hanyadik = i;
                        Console.WriteLine($"A kerítés színe / állapota: {paros[i].Szin}");
                        break;
                    }
                }

                string paletta = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
                for (int i = 0; i < paletta.Length; i++)
                {
                    if (Convert.ToString(paletta[i]) != paros[hanyadik].Szin && Convert.ToString(paletta[i]) != paros[hanyadik - 1].Szin && Convert.ToString(paletta[i]) != paros[hanyadik + 1].Szin)
                    {
                        Console.WriteLine($"Egy lehetséges festési szín: {paletta[i]}");
                        break;
                    }
                }
            }
            else
            {
                int hanyadik = 0;
                for (int i = 0; i < paratlan.Count; i++)
                {
                    if (paratlan[i].Hsz == hsz)
                    {
                        hanyadik = i;
                        Console.WriteLine($"A kerítés színe / állapota: {paratlan[i].Szin}");
                        break;
                    }
                }

                string paletta = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
                for (int i = 0; i < paletta.Length; i++)
                {
                    if (Convert.ToString(paletta[i]) != paratlan[hanyadik].Szin && Convert.ToString(paletta[i]) != paratlan[hanyadik - 1].Szin && Convert.ToString(paletta[i]) != paratlan[hanyadik + 1].Szin)
                    {
                        Console.WriteLine($"Egy lehetséges festési szín: {paletta[i]}");
                        break;

                    }
                }
            }

            StreamWriter sw = new StreamWriter("utcakep.txt");
            foreach(var p in paratlan)
            {
                for (int i = 0; i < p.Szeles; i++)
                {
                    sw.Write(p.Szin);
                }
            }

            sw.WriteLine();
            foreach(var p in paratlan)
            {
                sw.Write(p.Hsz);
                for (int i = 0; i < p.Szeles - Convert.ToString(p.Hsz).Length; i++)
                {
                    sw.Write(" ");
                }
            }

            sw.Close();
        }
    }
}

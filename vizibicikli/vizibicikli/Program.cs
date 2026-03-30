using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace vizibicikli
{
    internal class Program
    {
        class Kolcsonzes
        {
            public string Nev { get; set; }
            public string Azon { get; set; }
            public int EOra { get; set; }
            public int EPerc { get; set; }
            public int VOra { get; set; }
            public int VPerc { get; set; }

            public Kolcsonzes(string sor)
            {
                string[] darabok = sor.Split(';');
                Nev = darabok[0];
                Azon = darabok[1];
                EOra = int.Parse(darabok[2]);
                EPerc = int.Parse(darabok[3]);
                VOra = int.Parse(darabok[4]);
                VPerc = int.Parse(darabok[5]);
            }

        }
        static void Main(string[] args)
        {
            string[] sorok = File.ReadAllLines("kolcsonzesek.txt");
            List<Kolcsonzes> kolcsonzesek = new List<Kolcsonzes>();

            for (int i = 1; i < sorok.Length; i++)
            {
                Kolcsonzes k = new Kolcsonzes(sorok[i]);
                kolcsonzesek.Add(k);
            }

            Console.WriteLine($"5. feladat: Napi kölcsönzések száma {kolcsonzesek.Count}");

            Console.Write("6. feladat: Kérek egy nevet: ");
            string nev = Console.ReadLine();
            bool van = false;

            foreach(var k in kolcsonzesek)
            {
                if(nev == k.Nev)
                {
                    van = true;
                    Console.WriteLine($"\t{k.EOra}:{k.EPerc} - {k.VOra}:{k.VPerc}");
                }
            }

            if(van == false)
            {
                Console.WriteLine("Nincs ilyen nevű kölcsönző!");
            }

            Console.Write("7. feladat: Adjon meg egy időpontot: ");
            string ido = Console.ReadLine();
            string[] idodb = ido.Split(':');
            int idoperc = int.Parse(idodb[0]) * 60 + int.Parse(idodb[1]);

            foreach(var k in kolcsonzesek)
            {
                if(k.EOra * 60 + k.VPerc <= idoperc && k.VOra * 60 + k.VPerc >= idoperc)
                {
                    Console.WriteLine($"{k.EOra}:{k.EPerc} - {k.VOra}:{k.VPerc}: {k.Nev}");
                }
            }

            int bevetel = 0;
            foreach(var k in kolcsonzesek)
            {
                int eido = k.EOra * 60 + k.EPerc;
                int vido = k.VOra * 60 + k.VPerc;
                int eltelt = vido - eido;
                int felorak = 0;

                if(eltelt % 30 == 0)
                {
                    felorak = eltelt / 30;
                }
                else
                {
                    felorak = eltelt / 30 + 1;
                }

                bevetel += felorak * 2400;
            }

            Console.WriteLine($"8. feladat: A napi bevétel: {bevetel} Ft");

            StreamWriter sw = new StreamWriter("F.txt");
            foreach(var k in kolcsonzesek)
            {
                if(k.Azon == "F")
                {
                    sw.WriteLine($"{k.EOra}:{k.EPerc}-{k.VOra}:{k.VPerc} : {k.Nev}");
                }
            }

            sw.Close();

            SortedSet<string> azonositok = new SortedSet<string>();
            foreach(var k in kolcsonzesek)
            {
                azonositok.Add(k.Azon);
            }

            foreach(var a in azonositok)
            {
                int db = 0;
                foreach(var k in kolcsonzesek)
                {
                    if(k.Azon == a)
                    {
                        db++;
                    }
                }
            }
        }
    }
}

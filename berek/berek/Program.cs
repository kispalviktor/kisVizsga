using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace berek
{
    internal class Program
    {
        class Dolgozo
        {
            public string Nev {  get; set; }
            public string Reszleg {  get; set; }
            public string Nem {  get; set; }
            public int Belepes {  get; set; }
            public int Ber {  get; set; }
        }
        static void Main(string[] args)
        {
            string[] sorok = File.ReadAllLines("berek2020.txt");
            List<Dolgozo> dolgozok = new List<Dolgozo>();

            for (int i = 1; i < sorok.Length; i++)
            {
                string[] darabok = sorok[i].Split(';');
                Dolgozo d = new Dolgozo();
                d.Nev = darabok[0];
                d.Reszleg = darabok[1];
                d.Nem = darabok[2];
                d.Belepes = int.Parse(darabok[3]);
                d.Ber = int.Parse(darabok[4]);
                dolgozok.Add(d);
            }

            Console.WriteLine($"3. feladat: Dolgozók száma {dolgozok.Count} db");
            int osszeg = 0;
            foreach (var d in dolgozok)
            {
                osszeg += d.Ber;
            }

            double atlag = (double) osszeg / dolgozok.Count;
            Console.WriteLine($"4. feladat: Bérek átlaga {atlag / 1000:0.0} eFt");

            Console.Write("5. feladat: Kérem egy részleg nevét: ");
            string reszleg = Console.ReadLine();

            Dolgozo max = dolgozok[0];
            foreach(var d in dolgozok)
            {
                if(d.Ber > max.Ber && d.Reszleg == reszleg)
                {
                    max = d;
                }
            }

            Console.WriteLine("6. feladat: A legtöbbet keres");
            Console.WriteLine($"\tNév: {max.Nev}");
            Console.WriteLine($"\tNeme: {max.Nem}");
            Console.WriteLine($"\tBelepes éve: {max.Belepes}");
            Console.WriteLine($"\tBéer: {max.Ber}");

            HashSet<string> reszlegek = new HashSet<string>();
            foreach(var d in dolgozok)
            {
                reszlegek.Add(d.Reszleg);
            }

            foreach(var r in reszlegek)
            {
                int db = 0;
                foreach(var d in dolgozok)
                {
                    if(d.Reszleg == r)
                    {
                        db++;
                    }
                }
                Console.WriteLine($"{r} - {db} fő");
            }

            
        }
    }
}

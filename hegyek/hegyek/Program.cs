using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace hegyek
{
    internal class Program
    {
        class Hegy
        {
            public string Nev { get; set; }
            public string Hegyseg { get; set; }
            public int Magas { get; set; }

            public Hegy(string n, string h, int m)
            {
                Nev = n;
                Hegyseg = h;
                Magas = m;
            }
        }
        static void Main(string[] args)
        {
            string[] sorok = File.ReadAllLines("hegyekMo.txt");
            List<Hegy> hegyek = new List<Hegy>();

            for(int i = 1; i < sorok.Length; i++)
            {
                string[] darabok = sorok[i].Split(';');
                Hegy h = new Hegy(darabok[0], darabok[1], int.Parse(darabok[2]));
                hegyek.Add(h);
            }

            Console.WriteLine($"3. feladat: Hegycsúcsok száma: {hegyek.Count} db");

            int osszeg = 0;
            
            for(int i = 0; i < hegyek.Count; i++)
            {
                osszeg += hegyek[i].Magas;
            }

            double atlag = (double) osszeg / hegyek.Count;
            Console.WriteLine($"4. feladat: Hegycsúcsok átlag magassága: {atlag:0.00} m");

            Hegy max = hegyek[0];
            foreach(var h in hegyek)
            {
                if(h.Magas > max.Magas)
                {
                    max = h;
                }
            }

            Console.WriteLine("5. feladat: A legmagasabb hegycsúcs adatai:");
            Console.WriteLine($"\tNév: {max.Nev}");
            Console.WriteLine($"\tHegység: {max.Hegyseg}");
            Console.WriteLine($"\tMagasság: {max.Magas} m");

            Console.Write("6. feladat: Kérek egy magasságaot: ");
            int magas = int.Parse(Console.ReadLine());

            bool van = false;
            foreach(var h in hegyek)
            {
                if(h.Magas > magas && h.Hegyseg == "Börzsöny")
                {
                    van = true;
                    break;
                }
            }

            if (van)
            {
                Console.WriteLine($"\tVan {magas}m-nél magasabb hegycsúcs a Börzsönyben!");
            }
            else
            {
                Console.WriteLine($"\tNincs {magas}m-nél magasabb hegycsúcs a Börzsönyben!");
            }

            int db = 0;
            double lab = 3.280839895;
            foreach(var h in hegyek)
            {
                if(h.Magas * lab > 3000)
                {
                    db++;
                }
            }
            Console.WriteLine($"7. feladat: 3000 lábnál magasabb hegycsúcsok száma: {db}");

            HashSet<string> hegysegek = new HashSet<string>();

            foreach(var h in hegyek)
            {
                hegysegek.Add(h.Hegyseg);
            }

            Console.WriteLine("8. feladat: Hegység statisztika: ");
            foreach(var hegyseg in hegysegek)
            {
                db = 0;
                foreach(var h in hegyek)
                {
                    if(h.Hegyseg == hegyseg)
                    {
                        db++;
                    }
                }
                Console.WriteLine($"\t{hegyseg} - {db} db");
            }

            Console.WriteLine("9. feladat: bukk-videk.txt");
            StreamWriter sw = new StreamWriter("bukk-videk.txt");
            sw.WriteLine("Hegycsúcs neve; Magasság láb");
            foreach (var h in hegyek)
            {
                if(h.Hegyseg == "Bükk-vidék")
                {
                    sw.WriteLine($"{h.Nev};{h.Magas * lab:0.0}");
                }
            }
            sw.Close();
        }
    }
}

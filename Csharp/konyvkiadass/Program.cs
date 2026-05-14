using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace konyvkiadass
{
    internal class Program
    {
        public class Kiadas
        {
            public int Ev { get; set; }
            public int NegyedEv { get; set; }
            public string Eredet { get; set; }
            public string LeIras { get; set; }
            public int Peldany { get; set; }

            public Kiadas(string sor)
            {
                string[] darabok = sor.Split(';');
                Ev = int.Parse(darabok[0]);
                NegyedEv = int.Parse(darabok[1]);
                Eredet = darabok[2];
                LeIras = darabok[3];
                Peldany = int.Parse(darabok[4]);
            }

            public void KiIr()
            {
                Console.WriteLine($"|{Ev}|{NegyedEv}|{Eredet}|{LeIras}|{Peldany}|");
            }

        }
        static void Main(string[] args)
        {
            List<Kiadas> kiadasok = new List<Kiadas>();
            string[] sorok = File.ReadAllLines("kiadas.txt");
            for (int i = 0; i < sorok.Length; i++)
            {
                Kiadas k = new Kiadas(sorok[i]);
                kiadasok.Add(k);
            }

            Console.WriteLine("Írja be a szerző nevét: ");
            string szerzo = Console.ReadLine();

            int db = 0;

            foreach (var k in kiadasok)
            {
                if (k.LeIras.Contains(szerzo))
                {
                    db++;
                }
            }

            if (db == 0)
            {
                Console.WriteLine("Nincs ilyen nevű szerző");
            }
            else
            {
                Console.WriteLine($"{db} könyvkiadás");
            }

            Kiadas max = kiadasok[0];

            foreach (var k in kiadasok)
            {
                if (k.Peldany > max.Peldany)
                {
                    max = k;
                }
            }

            Console.WriteLine($"A legnagyobb példányú könyv: ");
            max.KiIr();

            HashSet<int> evek = new HashSet<int>();

            foreach (var k in kiadasok)
            {
                evek.Add(k.Ev);
            }
            Console.WriteLine(" __________________");
            Console.WriteLine("|Év  |Darab|Példány|");
            Console.WriteLine("|____|_____|_______|");

            foreach(var e in evek)
            {
                db = 0;
                int pld = 0;
                foreach (var k in kiadasok)
                {
                    if(k.Ev == e)
                    {
                        db++;
                        pld += k.Peldany;
                    }
                }
                Console.WriteLine($"|{e}|{db,-5}|{pld}|");
            }
            Console.WriteLine(" -----------------");

            StreamWriter sw = new StreamWriter("leiner.md", false, Encoding.UTF8);
            sw.WriteLine("|Év|Könvy|Példány|");
            sw.WriteLine("|:---:|:---|---:|");
            foreach(var k in kiadasok)
            {
                if(k.LeIras.Contains("Leiner Laura"))
                {
                    sw.WriteLine($"|{k.Ev}|{k.LeIras}|{k.Peldany}|");
                }
            }
            sw.Close();
        }
    }
}

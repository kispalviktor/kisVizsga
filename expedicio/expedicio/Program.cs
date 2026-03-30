using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace expedicio
{
    internal class Program
    {
        class Vetel
        {
            public int Nap { get; set; }
            public int Amator { get; set; }
            public string Uzenet { get; set; }

            public Vetel(string sor1, string sor2)
            {
                string[] darabok = sor1.Split(' ');
                Nap = int.Parse(darabok[0]);
                Amator = int.Parse(darabok[1]);
                Uzenet = sor2;
            }
        }

        static bool Szame(string szo)
        {
            bool valasz = true;
            for(int i = 0; i < szo.Length; i++)
            {
                if(szo[i] < '0' || szo[i] > '9')
                {
                    valasz = false;
                }
            }
            return valasz;
        }

        static void Main(string[] args)
        {
            string[] sorok = File.ReadAllLines("veetel.txt");
            List<Vetel> vetelek = new List<Vetel>();
            for (int i = 0; i < sorok.Length; i += 2)
            {
                Vetel v = new Vetel(sorok[i], sorok[i + 1]);
                vetelek.Add(v);
            }

            Console.WriteLine($"Az első üzenet rögzítője {vetelek[0].Amator}");
            Console.WriteLine($"Az utolsó üzenet rögzítője {vetelek[vetelek.Count - 1].Amator}");

            foreach(var v in vetelek)
            {
                if (v.Uzenet.Contains("farkas"))
                {
                    Console.WriteLine($"{v.Nap}. nap: {v.Amator}. amatőr");
                }
            }

            for (int i = 1; i <= 11; i++)
            {
                int db = 0;
                foreach(var v in vetelek)
                {
                    if(v.Nap == i)
                    {
                        db++;
                    }

                }

                if(db != 0)
                {
                    Console.WriteLine($"{i}. nap: {db} amatőr");
                }
            }

            StreamWriter sw = new StreamWriter("adas.txt");


            for (int i = 1; i < 11; i++)
            {
                char[] alap = new char[90];
                for (int j = 0; j < 90; j++)
                {
                    alap[j] = '#';
                }

                foreach (var v in vetelek)
                {
                    if (v.Nap == i)
                    {
                        for (int j = 0; j < v.Uzenet.Length; j++)
                        {
                            if (v.Uzenet[j] != '#')
                            {
                                alap[j] = v.Uzenet[j];
                            }
                        }
                    }
                }
                sw.WriteLine(new string(alap));

            }
            sw.Close();

            Console.WriteLine("Nap sorszáma: ");
            int nap = int.Parse(Console.ReadLine());
            Console.WriteLine("Amatőr sorszáma: ");
            int amator = int.Parse(Console.ReadLine());

            string uzenet = "";
            foreach(var v in vetelek)
            {
                if(v.Nap == nap && v.Amator == amator)
                {
                    uzenet = v.Uzenet;
                }
            }

            if(uzenet == "")
            {
                Console.WriteLine("Nincs ilyen feljegyzés!");
            }
            else
            {
                string eleje = uzenet.Split(' ')[0];
                if (eleje.Contains("/"))
                {
                    string[] darabok = eleje.Split('/');
                    if (Szame(darabok[0]) && Szame(darabok[1]))
                    {
                        Console.WriteLine($"A megfigyelt egyedek száma {int.Parse(darabok[0]) + int.Parse(darabok[1])}");
                    }
                    else
                    {
                        Console.WriteLine("Nem megállapítható");
                    }
                }
                else
                {
                    Console.WriteLine("Nem megállapítható");
                }
            }
        }
    }
}

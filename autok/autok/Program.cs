using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace autok
{
    internal class Program
    {
        class Mozgas
        {
            public int Nap { get; set; }
            public string Ido { get; set; }
            public string Rsz { get; set; }
            public int Azon { get; set; }
            public int Km { get; set; }
            public int KiBe { get; set; }

            public Mozgas(string sor)
            {
                string[] darabok = sor.Split(' ');
                Nap = int.Parse(darabok[0]);
                Ido = darabok[1];
                Rsz = darabok[2];
                Azon = int.Parse(darabok[3]);
                Km = int.Parse(darabok[4]);
                KiBe = int.Parse(darabok[5]);
            }

        }
        static void Main(string[] args)
        {
            List<Mozgas> mozgasok = new List<Mozgas>();
            string[] sorok = File.ReadAllLines("autok.txt");

            foreach (string s in sorok)
            {
                Mozgas m = new Mozgas(s);
                mozgasok.Add(m);
            }


            #region 2. feladat
            Console.WriteLine("2. feladat: ");
            for (int i = mozgasok.Count - 1; i >= 0; i--)
            {
                if(mozgasok[i].KiBe == 0)
                {
                    Console.WriteLine($"{mozgasok[i].Nap}. nap rendszám: {mozgasok[i].Rsz}");
                    break;
                }
            }
            #endregion

            #region 3. feladat
            Console.WriteLine("3. feladat: ");
            Console.Write("Nap: ");
            int nap = int.Parse(Console.ReadLine());
            foreach(var m in mozgasok)
            {
                if(m.Nap == nap)
                {
                    string valasz = m.KiBe == 0 ? "ki" : "be";
                    Console.WriteLine($"{m.Ido} {m.Rsz} {m.Azon} {valasz}");
                }
            }
            #endregion

            #region 4. feladat
            Console.WriteLine("4. feladat: ");
            int ki = 0;
            int be = 0;

            foreach(var m in mozgasok)
            {
                if(m.KiBe == 0)
                {
                    ki++;
                }
                else
                {
                    be++;
                }
            }
            Console.WriteLine($"A hónap végén {ki - be} autót nem hosztak vissza.");
            #endregion

            #region 5 .feladat
            Console.WriteLine("5. feladat: ");
            HashSet<string> rendszamok = new HashSet<string>();
            foreach(var m in mozgasok)
            {
                rendszamok.Add(m.Rsz);
            }

            foreach(var r in rendszamok)
            {
                int elso = 0;
                int utolso = 0;
                foreach (var m in mozgasok)
                {
                    if (m.Rsz == r)
                    {
                        elso = m.Km;
                        break;
                    }
                }

                foreach (var m in mozgasok)
                {
                    if (m.Rsz == r)
                    {
                        utolso = m.Km;
                    }
                }

                Console.WriteLine($"{r} {utolso - elso} km");
            }
            #endregion

            #region 6. feladat
            Console.WriteLine("6. feladat: ");
            int max = 0;
            int maxazon = 0;
            for (int i = 0; i < mozgasok.Count; i++)
            {
                if (mozgasok[i].KiBe == 0)
                {
                    for(int j = i + 1; j  < mozgasok.Count; j++)
                    {
                        if (mozgasok[j].Azon == mozgasok[i].Azon)
                        {
                            int ut = mozgasok[j].Km - mozgasok[i].Km;
                            if (ut > max)
                            {
                                max = ut;
                                maxazon = mozgasok[i].Azon;
                            }
                            break;
                        }
                    }
                }
            }
            Console.WriteLine($"Leghosszabb út: {max} km, személy: {maxazon}");
            #endregion

            #region 7. feladat
            Console.WriteLine("7. feladat: ");
            Console.WriteLine("Rendszám: ");
            string rsz = Console.ReadLine();
            StreamWriter sw = new StreamWriter(rsz + "_menetlevel.txt");
            foreach(var m in mozgasok)
            {
                if(m.Rsz == rsz)
                {
                    if(m.KiBe == 0)
                    {
                        sw.Write($"{m.Azon}\t{m.Nap}. {m.Ido}\t{m.Km} km");
                    }
                    else
                    {
                        sw.WriteLine($"\t{m.Nap}. {m.Ido}\t{m.Km} km");
                    }
                }
            }

            sw.Close();
            #endregion
        }
    }
}

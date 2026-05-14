using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace legyenonismilliomos
{
    class Kerdes
    {
        public string Sor { get; set; }
        public string Szoveg { get; set; }
        public string A { get; set; }
        public string B { get; set; }
        public string C { get; set; }
        public string D { get; set; }
        public string Helyes { get; set; }

        public Kerdes(string sor, string szoveg, string a, string b, string c, string d, string helyes)
        {
            Sor = sor;
            Szoveg = szoveg;
            A = a;
            B = b;
            C = c;
            D = d;
            Helyes = helyes;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("--- [[[ LEGYEN ÖN IS MILLIMOS ]]] ---");

            string[] sorok = File.ReadAllLines("legyenonismilliomos.txt");

            List<Kerdes> kerdesek = new List<Kerdes>();

            foreach (string sor in sorok)
            {
                string[] darabok = sor.Split(';');
                Kerdes k = new Kerdes(
                    darabok[0],
                    darabok[1],
                    darabok[2],
                    darabok[3],
                    darabok[4],
                    darabok[5],
                    darabok[6]
                );
                kerdesek.Add(k);
            }

            int helyesPontok = 0;

            for (int i = 0; i < kerdesek.Count; i++)
            {
                Console.WriteLine(" ");
                Console.WriteLine(kerdesek[i].Sor);
                Console.WriteLine(kerdesek[i].Szoveg);
                Console.WriteLine(" ");
                Console.WriteLine(kerdesek[i].A);
                Console.WriteLine(kerdesek[i].B);
                Console.WriteLine(kerdesek[i].C);
                Console.WriteLine(kerdesek[i].D);
                Console.WriteLine(" ");

                Console.Write("Válasz: ");
                string valasz = Console.ReadLine();

                if (valasz != kerdesek[i].Helyes)
                {
                    Console.WriteLine(" ");
                    Console.WriteLine($"Helytelen válasz. A(z) {kerdesek[i].Helyes}) válasz volt a helyes.");
                    Console.WriteLine($"Köszönjük hogy velünk játszott. Ön nyert {helyesPontok} Ft-ot.");
                    Console.WriteLine(" ");
                    Console.WriteLine("---[[[ VÉGE A JÁTÉKNAK ]]]---");
                    break;
                }
                else
                {
                    helyesPontok += 5000;
                    Console.WriteLine(" ");
                    Console.WriteLine($"Helyes válasz. Ön nyert {helyesPontok} Ft-ot.");

                    string again;
                    while (true)
                    {
                        Console.Write("Ki szeretne lépni? (y/n): ");
                        again = Console.ReadLine();
                        if (again == "y" || again == "n")
                            break;
                        Console.WriteLine(" ");
                        Console.WriteLine("huh?");
                    }

                    if (again == "y")
                    {
                        Console.WriteLine(" ");
                        Console.WriteLine($"Köszönjük hogy velünk játszott. Ön nyert {helyesPontok} Ft-ot.");
                        Console.WriteLine(" ");
                        Console.WriteLine("---[[[ VÉGE A JÁTÉKNAK ]]]---");
                        break;
                    }
                }
            }
        }
    }
}
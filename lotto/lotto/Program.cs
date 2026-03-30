using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lotto
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                int lottok = 0;

                for (int i = 5; i < 6; i++)
                {
                    Console.WriteLine(" ");
                    Console.Write("Írja be hogy 7-es, 6-os vagy 5-ös lottót akar-e játszani: ");
                    lottok = int.Parse(Console.ReadLine());
                }

                // 5-ÖS LOTTÓ
                if (lottok == 5)
                {
                    Console.WriteLine(" ");
                    Console.WriteLine("--- 5-ÖS LOTTÓ ---");

                    List<int> szamok = new List<int>();
                    Random random = new Random();

                    for (int i = 0; i < 90; i++)
                    {
                        szamok.Add(random.Next(1, 91));
                        if (i == 4)
                        {
                            break;
                        }
                    }

                    List<int> felhszamok;


                    while (true)
                    {
                        Console.WriteLine("írjon be 5db számot 1-től 90-ig:");
                        felhszamok = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
                        if (felhszamok.Count != 5)
                        {
                            Console.WriteLine(" ");
                            Console.WriteLine("5db számot kell megadni");
                        }
                        break;
                    }

                    if(felhszamok.Count == 5)
                    {
                        Console.WriteLine(" ");
                        Console.WriteLine($"A kihúzott számok: " + string.Join(" ", szamok));
                    }

                    List<int> kihuzottSzamok = szamok.ToList();
                    List<int> felhasznaloSzamai = felhszamok.ToList();

                    int points = 0;
                    foreach (int number in felhasznaloSzamai)
                    {
                        if (kihuzottSzamok.Contains(number))
                        {
                            points += 1;
                        }
                    }

                    if(felhszamok.Count == 5) 
                    {
                        if (points <= 0)
                        {
                            Console.WriteLine("nem nyert xd");
                        }
                        if (points == 1 || points == 2)
                        {
                            Console.WriteLine("nyertél 5ft-ot");
                        }
                        if (points == 3)
                        {
                            Console.WriteLine("nyertél 200ft-ot");
                        }
                        if (points == 4)
                        {
                            Console.WriteLine("nyertél 500ft-ot");
                        }
                        if (points == 5)
                        {
                            Console.WriteLine("nyertél 1 googolplex ft-ot");
                        }
                    }
                }

                // 6-OS LOTTÓ
                if (lottok == 6)
                {
                    Console.WriteLine(" ");
                    Console.WriteLine("--- 6-OS LOTTÓ ---");

                    List<int> szamok = new List<int>();
                    Random random = new Random();

                    for (int i = 0; i < 45; i++)
                    {
                        szamok.Add(random.Next(1, 46));
                        if (i == 5)
                        {
                            break;
                        }
                    }

                    List<int> felhszamok;


                    while (true)
                    {
                        Console.WriteLine("írjon be 6db számot 1-től 45-ig:");
                        felhszamok = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
                        if (felhszamok.Count != 6)
                        {
                            Console.WriteLine(" ");
                            Console.WriteLine("6db számot kell megadni");
                        }
                        break;
                    }

                    if (felhszamok.Count == 6)
                    {
                        Console.WriteLine("");
                        Console.WriteLine($"A kihúzott számok: " + string.Join(" ", szamok));
                    }

                    List<int> kihuzottSzamok = szamok.ToList();
                    List<int> felhasznaloSzamai = felhszamok.ToList();

                    int points = 0;
                    foreach (int number in felhasznaloSzamai)
                    {
                        if (kihuzottSzamok.Contains(number))
                        {
                            points += 1;
                        }
                    }

                    if (felhszamok.Count == 6)
                    {
                        if (points <= 0)
                        {
                            Console.WriteLine("nem nyert xd");
                        }
                        if (points == 1 || points == 2)
                        {
                            Console.WriteLine("nyertél 5ft-ot");
                        }
                        if (points == 3)
                        {
                            Console.WriteLine("nyertél 200ft-ot");
                        }
                        if (points == 4)
                        {
                            Console.WriteLine("nyertél 500ft-ot");
                        }
                        if (points == 5)
                        {
                            Console.WriteLine("nyertél 1000 ft-ot");
                        }
                        if(points == 6)
                        {
                            Console.WriteLine("nyertél 1 googolplex ft-ot");
                        }
                    }
                }

                // 7-ES LOTTÓ
                if (lottok == 7)
                {
                    Console.WriteLine(" ");
                    Console.WriteLine("--- 7-ES LOTTÓ ---");

                    List<int> szamok = new List<int>();
                    Random random = new Random();

                    for (int i = 0; i < 35; i++)
                    {
                        szamok.Add(random.Next(1, 36));
                        if (i == 6)
                        {
                            break;
                        }
                    }

                    List<int> felhszamok;

                    while (true)
                    {
                        Console.WriteLine("írjon be 7db számot 1-től 35-ig:");
                        felhszamok = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
                        if (felhszamok.Count != 7)
                        {
                            Console.WriteLine(" ");
                            Console.WriteLine("7db számot kell megadni");
                        }
                        break;
                    }

                    if (felhszamok.Count == 7)
                    {
                        Console.WriteLine(" ");
                        Console.WriteLine($"A kihúzott számok: " + string.Join(" ", szamok));
                    }

                    List<int> kihuzottSzamok = szamok.ToList();
                    List<int> felhasznaloSzamai = felhszamok.ToList();

                    int points = 0;
                    foreach (int number in felhasznaloSzamai)
                    {
                        if (kihuzottSzamok.Contains(number))
                        {
                            points += 1;
                        }
                    }

                    if (felhszamok.Count == 7)
                    {
                        if (points <= 0)
                        {
                            Console.WriteLine("nem nyert xd");
                        }
                        if (points == 1 || points == 2)
                        {
                            Console.WriteLine("nyertél 5ft-ot");
                        }
                        if (points == 3)
                        {
                            Console.WriteLine("nyertél 100ft-ot");
                        }
                        if (points == 4)
                        {
                            Console.WriteLine("nyertél 200ft-ot");
                        }
                        if (points == 5)
                        {
                            Console.WriteLine("nyertél 500ft-ot");
                        }
                        if (points == 6)
                        {
                            Console.WriteLine("nyertél 1000 ft-ot");
                        }
                        if (points == 7)
                        {
                            Console.WriteLine("nyertél 1 googolplex ft-ot");
                        }
                    }
                }

                string again;
                while (true)
                {
                    Console.WriteLine(" ");
                    Console.Write("újrakezdi? (y/n): ");
                    again = Console.ReadLine();
                    if (again == "y" || again == "n")
                    {
                        break;
                    }
                    Console.WriteLine("huh?");
                }

                if (again == "y")
                {
                    continue;
                }
                else
                {
                    Console.WriteLine("viszlát");
                    break;
                }

            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lotto2
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
                    Console.Write("Írja be hogy 7-es, 6-os vagy 5-ös lottót akar-e játszani: ");
                    lottok = int.Parse(Console.ReadLine());
                }

                if (lottok == 5)
                {
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

                    Console.WriteLine("írjon be 5db számot 1-től 90-ig:");
                    List<int> felhszamok = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

                    Console.WriteLine($"A kihúzott számok: " + string.Join(" ", szamok));

                    List<int> tl = szamok.ToList();
                    List<int> ti = felhszamok.ToList();

                    int points = 0;
                    foreach (int number in ti)
                    {
                        if (tl.Contains(number))
                        {
                            points += 1;
                        }
                    }

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

                string again;
                while (true)
                {
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

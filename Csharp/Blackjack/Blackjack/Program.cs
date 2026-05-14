using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blackjack
{
    internal class Program
    {
        static int[] pakli = new int[52];
        static int huzas()
        {
            Random r = new Random();
            int sors = r.Next(0, 52);
            while (pakli[sors] == 0)
            {
                sors = r.Next(0, 52);
            }

            int huzott = pakli[sors];
            pakli[sors] = 0;
            return huzott;
        }

        static void Main(string[] args)
        {
           
            int kartya = 2;
            int db10 = 1;
            for (int i = 0; i < pakli.Length; i++)
            {
                pakli[i] = kartya;
                if(kartya < 10)
                {
                    kartya++;
                }
                else if(kartya == 10 && db10 < 4)
                {
                    db10++;
                }
                else if(db10 == 4)
                {
                    kartya++;
                    db10 = 1;
                }
                else if (kartya == 11)
                {
                    kartya = 2;
                }

            }

            int bank = 0;
            int jatekos = 0;

            int banklapja = huzas();
            Console.WriteLine($"A bank húzott: {banklapja}");
            bank += banklapja;

            int jatekoslapja = huzas();
            Console.WriteLine($"A játékos húzott: {jatekoslapja}");
            jatekos += jatekoslapja;

            banklapja = huzas();
            Console.WriteLine($"A bank húzott: {banklapja}");
            bank += banklapja;

            jatekoslapja = huzas();
            Console.WriteLine($"A játékos húzott: {jatekoslapja}");
            jatekos += jatekoslapja;

            Console.WriteLine($"A banknak van: {bank}");
            Console.WriteLine($"A játékosnak van: {jatekos}");

            Console.Write("Kérsz még lapot? (i/n): ");
            string valasz = Console.ReadLine().ToLower();
            while (valasz == "i")
            {
                jatekoslapja = huzas();
                Console.WriteLine($"A játékos húzott: {jatekoslapja}");
                if (jatekoslapja == 11 && jatekos + 11 > 21)
                {
                    jatekos++;
                }
                else
                {
                    jatekos += jatekoslapja;
                }
                Console.WriteLine($"A játékosnak van: {jatekos}");
                Console.Write("Kérsz még lapot? (i/n): ");
                valasz = Console.ReadLine().ToLower();
            }

            if (jatekos > 21)
            {
                Console.WriteLine("Vesztettél!");
            }
            else
            {
                while(bank < jatekos)
                {
                    banklapja = huzas();
                    Console.WriteLine($"A bank húzott: {banklapja}");
                    if (banklapja == 11 && bank + 11 > 21)
                    {
                        bank++;
                    }
                    else
                    {
                        bank += banklapja;
                    }
                    Console.WriteLine($"A banknak van: {bank}");
                }

                if(bank > 21)
                {
                    Console.WriteLine("Nyertél!");
                }
                else if(jatekos > bank)
                {
                    Console.WriteLine("Nyertél!");
                }
                else if(jatekos == bank)
                {
                    Console.WriteLine("Döntetlen!");
                }
                else
                {
                    Console.WriteLine("Vesztettél!");
                }
            }
        }
    }
}
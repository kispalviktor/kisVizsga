using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tombok_gyakorlas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] seb = new int[100];
            int i = 0;
            int s = 0;
            do
            {
                Console.Write("Írjon be egy sebességet: ");
                s = Convert.ToInt32(Console.ReadLine());
                seb[i] = s;
                i++;
            } while (s != 0 && i < seb.Length);

            int dbkkmet = 0;
            int dbkkf = 0;
            for(i = 0; seb[i] != 0; i++)
            {
                if (seb[i] > 90)
                {
                    dbkkmet++;
                }
                if(seb[i] < -90)
                {
                    dbkkf++;
                }
            }

            Console.WriteLine($"Kecskemét felé {dbkkmet} db, Kiskunfélegyháza felé {dbkkf} db gyorshajtó volt.");

            int osszegkkmet = 0;
            int osszegkkf = 0;
            int dbkmet = 0;
            int dbkf = 0;

            for(i = 0; seb[i] != 0; i++)
            {
                if(seb[i] > 0)
                {
                    osszegkkmet += seb[i];
                    dbkkf++;
                }
                else
                {
                    osszegkkf += seb[i];
                    dbkf++;
                }
            }

            double atlagkmet = (double) osszegkkmet / dbkmet;
            double atlagkf = (double) -osszegkkf / dbkf;

            Console.WriteLine($"Kecskemét felé {atlagkmet:0.00}, Kiskunfélegyháza felé {atlagkf:0.00} volt az átlagsebesség");

            int maxkkmet = 0;
            int kkmeti = 0;
            int maxkkf = 0;
            int ikkf = 0;

            for(i = 0; seb[i] != 0; i++)
            {
                if (seb[i] > maxkkmet)
                {
                    maxkkmet = seb[i];
                    kkmeti = i + 1;
                }
                if (seb[i] < maxkkf)
                {
                    maxkkf = seb[i];
                    ikkf = i + 1;
                }
            }

            Console.WriteLine($"A leggyorsabban Kecskemét felé az {kkmeti}. autós, {maxkkmet} km/h-val");
            Console.WriteLine($"A leggyorsabban Kiskunfélegyháza felé az {ikkf}. autós, {maxkkf} km/h-val ment.");
        }
    }
}

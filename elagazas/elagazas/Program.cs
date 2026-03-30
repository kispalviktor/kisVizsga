using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace elagazas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Két beolvasott számból döntsük el, hogy melyik a nagyobb:

            Console.Write("Egyik szám: ");
            int egyik = Convert.ToInt32(Console.ReadLine());

            Console.Write("Másik szám: ");
            int masik = Convert.ToInt32(Console.ReadLine());

            if (egyik > masik)
            {
                Console.WriteLine("Az első szám a nagyobb.");
            }
            else if (egyik < masik)
            {
                Console.WriteLine("A második szám a nagyobb");
            }
            else
            {
                Console.WriteLine("A két szám egyenlő");
            }

            //Döntsük el egy beolvasott számról, hogy pozitív vagy negatív:

            Console.Write("Egyik szám: ");
            int szam = Convert.ToInt32(Console.ReadLine());

            if (szam > 0)
            {
                Console.WriteLine("A szám pozitív.");
            }
            else if (szam < 0)
            {
                Console.WriteLine("A szám negatív.");
            }
            else {
                Console.WriteLine("A szám a 0.");
            }

            //Olvassunk be egy órát (0 - 23), és köszönjünk a napszaknak megfelelően:

            Console.Write("Írja be hány óra van: ");
            int ido = Convert.ToInt32(Console.ReadLine());

            if(ido >= 6 && ido <= 10)
            {
                Console.WriteLine("Jó reggelt!");
            }
            else if(ido >= 11 && ido <= 16)
            {
                Console.WriteLine("Jó napot!");
            }
            else if(ido >= 17 && ido <= 22)
            {
                Console.WriteLine("Jó estét!");
            }
            else if(ido < 0 || ido > 23)
            {
                Console.WriteLine("Ilyen óra nincs!");
            }
            else
            {
                Console.WriteLine("Jó éjszakát");
            }

            //Olvassuk be egy dolgozat pontszámát, számoljuk ki, hogy hány százalék lett, és írjuk ki a jegyet!

            Console.Write("Írja be a dolgozat pontszámát: ");
            int pont = Convert.ToInt32(Console.ReadLine());

            double szazalek = (double) pont / 50 * 100;
            
           if(szazalek >= 0 && szazalek < 40)
            {
                Console.WriteLine("1-es lett.");
            }
           if(szazalek >= 40 && szazalek < 50)
            {
                Console.WriteLine("2-es lett.");
            }
           if(szazalek >= 50 && szazalek < 60)
            {
                Console.WriteLine("3-as lett.");
            }
           if(szazalek >= 60 && szazalek < 80)
            {
                Console.WriteLine("4-es lett.");
            }
           else
            {
                Console.WriteLine("5-ös lett.");
            }

            //Olvassuk be egy háromszög 3 oldalát, és döntsük el, hogy szerkezthető-e?

            Console.Write("Írja be az 'a' oldalát: ");
            int sideA = Convert.ToInt32(Console.ReadLine());

            Console.Write("Írja be az 'b' oldalát: ");
            int sideB = Convert.ToInt32(Console.ReadLine());

            Console.Write("Írja be az 'c' oldalát: ");
            int sideC = Convert.ToInt32(Console.ReadLine());

            if(sideA + sideB > sideC && sideA + sideC > sideB && sideB + sideC > sideA)
            {
                Console.WriteLine("A háromszög szerkezthető.");
            }
            else
            {
                Console.WriteLine("A háromszög nem szerkezthető.");
            }

            //Olvassuk be egy téglalap két oldalát és egy kör sugarát.
            //Írjuk ki a kerületüket és területüket.
            //Írjuk ki, hogy melyik a nagyobb.

            Console.Write("Írja be a téglalap eggyik oldalát: ");
            int a = Convert.ToInt32(Console.ReadLine());
            Console.Write("Írja be a téglalap másik oldalát: ");
            int b = Convert.ToInt32(Console.ReadLine());
            Console.Write("Írja be a kör sugarát: ");
            int r = Convert.ToInt32(Console.ReadLine());

            int teglalapK = 2 * (a + b);
            int teglalapT = a * b;
            int korK = 2 * r;
            double korT = r * r * 3.14;

            Console.WriteLine($"A téglalap kerülete: {teglalapK}");
            Console.WriteLine($"A téglalap területe: {teglalapT}");
            Console.WriteLine($"A kör kerülete: {korK}");
            Console.WriteLine($"A kör területe: {korT}");

            if (teglalapK > korK)
            {
                Console.WriteLine("A téglalap kerülete a nagyobb.");
            }
            else
            {
                Console.WriteLine("A kör kerülete a nagyobb.");
            }

            if(teglalapT > korT)
            {
                Console.WriteLine("A téglalap területe a nagyobb.");
            }
            else
            {
                Console.WriteLine("A kör területe a nagyobb.");
            }

        }
    }
}


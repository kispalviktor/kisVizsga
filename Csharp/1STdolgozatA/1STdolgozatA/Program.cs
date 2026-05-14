using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1STdolgozatA
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Írja be a labda átmérőjét: ");
            int atmero = Convert.ToInt32(Console.ReadLine());

            Console.Write("Írja be a labdák számát: ");
            int db = Convert.ToInt32(Console.ReadLine());

            Console.Write("Írja be a rendelkezésre álló szalag hosszúságát: ");
            int szalag = Convert.ToInt32(Console.ReadLine());




            double korK = 2 * (atmero / 2) * 3.14;

            double kellszalag = (korK * 2) + 60;
            Console.WriteLine($"{kellszalag * db}m szalagra van szügség.");



            if(kellszalag < szalag)
            {
                Console.WriteLine("Van elegendő szalag.");
            }
            else
            {
                Console.WriteLine("Nince elegendő szalag.");
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace tictactoe
{
    internal class Program
    {
        static string[,] tabla = new string[3, 3]
        {
            {"_", "_", "_" },
            {"_", "_", "_" },
            {"_", "_", "_" },
        };

        static string jatekos = "X";

        static void Kirajzol()
        {
            Console.WriteLine("  1 2 3");
            for (int i = 0; i < tabla.GetLength(0); i++)
            {
                Console.Write($"{i + 1}|");
                for (int j = 0; j < tabla.GetLength(1); j++)
                {
                    Console.Write($"{tabla[i,j]}|");
                }
                Console.WriteLine();
            }
        }

        static void Lepes()
        {
            Kirajzol();
            Console.WriteLine($"{jatekos} következik!");
            Console.WriteLine("Hova szeretnel lépni?");
            Console.Write("Sor: ");
            int sor = Convert.ToInt32(Console.ReadLine()) - 1;
            Console.Write("Oszlop: ");
            int oszl = Convert.ToInt32(Console.ReadLine()) - 1;

            while(tabla[sor, oszl] != "_")
            {
                Console.WriteLine("Oda nem léphetsz!");
                Console.Write("Sor: ");
                sor = Convert.ToInt32(Console.ReadLine()) - 1;
                Console.Write("Oszlop: ");
                oszl = Convert.ToInt32(Console.ReadLine()) - 1;
            }

            tabla[sor, oszl] = jatekos;
            if(jatekos == "X")
            {
                jatekos = "O";
            }
            else
            {
                jatekos = "X";
            }
        }
        
        static bool Gyozelem()
        {
            if (tabla[0,0] != "_" && tabla[0,0] == tabla[0,1] && tabla[0,1] == tabla[0, 2])
            {
                return true;
            }
            if (tabla[1, 0] != "_" && tabla[1, 0] == tabla[1, 1] && tabla[1, 1] == tabla[1, 2])
            {
                return true;
            }
            if (tabla[2, 0] != "_" && tabla[2, 0] == tabla[2, 1] && tabla[2, 1] == tabla[2, 2])
            {
                return true;
            }
            if (tabla[0, 0] != "_" && tabla[0, 0] == tabla[1, 0] && tabla[1, 0] == tabla[2, 0])
            {
                return true;
            }
            if (tabla[0, 1] != "_" && tabla[0, 1] == tabla[1, 1] && tabla[1, 1] == tabla[2, 1])
            {
                return true;
            }
            if (tabla[0, 2] != "_" && tabla[0, 2] == tabla[1, 2] && tabla[1, 2] == tabla[2, 2])
            {
                return true;
            }
            if (tabla[0, 0] != "_" && tabla[0, 0] == tabla[1, 1] && tabla[1, 1] == tabla[2, 2])
            {
                return true;
            }
            if (tabla[0, 2] != "_" && tabla[0, 2] == tabla[1, 1] && tabla[1, 1] == tabla[2, 0])
            {
                return true;
            }
            else
            {
                return false;
            }
        }



        static void Main(string[] args)
        {
            while (true)
            {
                Lepes();
                if (Gyozelem())
                {
                    Console.WriteLine("Vége a játéknak!");
                    break;
                }
            }
            Kirajzol();
        }
    }
}

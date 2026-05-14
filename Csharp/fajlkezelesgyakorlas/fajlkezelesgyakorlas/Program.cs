using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace fajlkezelesgyakorlas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] szamok = File.ReadAllLines("03_000.txt");
            StreamWriter sw = new StreamWriter("megoldas.txt");

            for (int i = 0; i < szamok.Length; i++)
            {
                szamok[i] = 
            }
        }
    }
}

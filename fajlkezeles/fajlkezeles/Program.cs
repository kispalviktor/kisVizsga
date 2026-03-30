using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace fajlkezeles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FileStream fs = new FileStream("be.txt", FileMode.Open);
            StreamReader sr = new StreamReader(fs);

            int a = Convert.ToInt32(sr.ReadLine());
            int b = Convert.ToInt32(sr.ReadLine());

            sr.Close();
            fs.Close();

            int osszeg = a + b;

            StreamWriter sw = new StreamWriter("ki.txt");
            sw.WriteLine(osszeg);
            sw.Close();

            //Palindrom

            string[] sorok = File.ReadAllLines("palindrom.txt");

            sw = new StreamWriter("eredmeny.txt");
            for(int i = 0; i < sorok.Length; i++)
            {
                sorok[i] = sorok[i].ToLower();
                sorok[i] = sorok[i].Replace(" ", "");
                sorok[i] = sorok[i].Replace(",", "");
                sorok[i] = sorok[i].Replace(".", "");

                string forditott = "";
                foreach(char c in sorok[i].Reverse())
                {
                    forditott += c;
                }

                if (sorok[i] == forditott)
                {
                    sw.WriteLine("igen");
                }
                else
                {
                    sw.WriteLine("nem");
                }
            }

            sw.Close();


            //Számológép

            string[] feladatok = File.ReadAllLines("muveletek.txt");

            sw = new StreamWriter("megoldas.txt");
            for(int i = 0;i < feladatok.Length; i++)
            {
                string[] darabok = feladatok[i].Split(' ');
                int egyik = Convert.ToInt32(darabok[0]);
                int masik = Convert.ToInt32(darabok[2]);

                int eredmeny = 0;

                if(darabok[1] == "+")
                {
                    eredmeny = egyik + masik;
                }
                else if (darabok[1] == "-")
                {
                    eredmeny = egyik - masik;
                }
                else if(darabok[1] == "×")
                {
                    eredmeny = egyik * masik;
                }
                else if (darabok[1] == "÷")
                {
                    eredmeny = egyik / masik;
                }

                sw.WriteLine(eredmeny);
            }

            sw.Close();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop
{
    internal class Program
    {
        class Etel
        {
            public string Nev { get; set; }
            public int Kaloria { get; set; }

            public Etel(string nev, int kaloria)
            {
                Nev = nev;
                Kaloria = kaloria;
            }
        class Ember
        {
            public string nev;
            public string szulido;
            public string taj;
            public bool nem;
            public int magas;
            public int telitettseg;

            public Ember(string nev, string szulido, string taj, bool nem, int magas)
            {
                this.nev = nev;
                this.szulido = szulido;
                this.taj = taj;
                this.nem = nem;
                this.magas = magas;
                this.telitettseg = 0;
            }

            public void Eves(Etel mit)
            {
                if(telitettseg >= 2000)
                {
                    Console.WriteLine("Nem bírok többet enni!");
                }
                else
                {
                    Console.WriteLine($"Megettem egy {mit.Nev}-et");
                    telitettseg += mit.Kaloria;
                }
                        
            }

            public void Kozsones()
            {
                Console.WriteLine($"Hello! {nev} vagyok.");
            }
        }

        static void Main(string[] args)
        {
            Ember e = new Ember("Nagy Géza", "1991-09-09", "123456789", true, 178);
            e.Kozsones();
            Etel gyros = new Etel("Gyros pitában", 400);
            e.Eves(gyros);
            e.Eves(gyros);
            e.Eves(gyros);
            e.Eves(gyros);
            e.Eves(gyros);
            e.Eves(gyros);
            e.Eves(gyros);
    }
}

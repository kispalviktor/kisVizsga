using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kolcsonzo
{
    internal class Program
    {
        static MySqlConnection conn = new MySqlConnection("Server=localhost; User ID=root; Password=mysql; Database=kolcsonzo");
        static void autoLista()
        {
            try
            {
                conn.Open();
                var command = conn.CreateCommand();
                command.CommandText = "SELECT * FROM auto";
                var r = command.ExecuteReader();
                while (r.Read())
                {
                    Console.WriteLine($"{r.GetString("marka")}, {r.GetString("tipus")}, {r.GetInt32("evjarat")}, {r.GetString("szin")}, {r.GetUInt32("teljesitmeny")} LE");
                }
                r.Close();
                conn.Close();
                ListazasMenu();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        static void kliensLista()
        {
            try
            {
                conn.Open();
                var command = conn.CreateCommand();
                command.CommandText = "SELECT * FROM kliens";
                var r = command.ExecuteReader();
                while (r.Read())
                {
                    Console.WriteLine($"{r.GetString("nev")}, {r.GetDateTime("szido")}, {r.GetString("telszam")}");
                }
                r.Close();
                conn.Close();
                ListazasMenu();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void kolcsonzesLista()
        {
            try
            {
                conn.Open();
                var command = conn.CreateCommand();
                command.CommandText = "SELECT nev, marka, tipus, evjarat, mettol, meddig, ar" +
                                      " FROM kliens INNER JOIN kolcsonzes ON kliens.id = kliens_id" +
                                      " INNER JOIN auto ON auto.id = auto_id";
                var r = command.ExecuteReader();
                while (r.Read())
                {
                    Console.WriteLine($"{r.GetString("nev")}: {r.GetString("marka")} {r.GetString("tipus")}, {r.GetInt32("evjarat")}, {r.GetDateTime("mettol")} - {r.GetDateTime("meddig")}, {r.GetInt32("ar")} Ft/nap");
                }
                r.Close();
                conn.Close();
                ListazasMenu();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void AutoHozzaad()
        {
            Console.Write("Autó gyártója: ");
            string marka = Console.ReadLine();
            Console.Write("Autó típusa: ");
            string tipus = Console.ReadLine();
            Console.Write("Autó évjárata: ");
            int evjarat = int.Parse(Console.ReadLine());
            Console.Write("Autó színe: ");
            string szin = Console.ReadLine();
            Console.Write("Autó teljesítménye: ");
            int telj = int.Parse(Console.ReadLine());

            try
            {
                conn.Open();
                var command = conn.CreateCommand();
                command.CommandText = "INSER INTO auto(marka, tipus, evjarat, szin, teljesitmeny) " +
                                      "VALUES(@marka, @tipus, @evjarat, @szin, @telj)";
                command.Parameters.AddWithValue("marka", marka);
                command.Parameters.AddWithValue("tipus", tipus);
                command.Parameters.AddWithValue("evjarat", evjarat);
                command.Parameters.AddWithValue("szin", szin);
                command.Parameters.AddWithValue("telj", telj);

                int eredmeny = command.ExecuteNonQuery();
                Console.WriteLine($"{eredmeny} sor hozzáadva!");
                conn.Close();
                HozzaadasMenu();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void KliensKolcsonzesek()
        {
            Console.Write("Kliens neve: ");
            string kliens = Console.ReadLine();
            try
            {
                conn.Open();
                var command = conn.CreateCommand();
                command.CommandText = "SELECT marka, tipus, DATEDIFF(mettol, meddig) * ar AS fizet " +
                                      "FROM kliens INNER JOIN kolcsonzes ON kliens.id = kliens_id " +
                                      "INNER JOIN auto ON auto.id = auto_id " +
                                      "WHERE nev = @nev";
                command.Parameters.AddWithValue("nev", kliens);
                var r = command.ExecuteReader();
                while (r.Read())
                {
                    Console.WriteLine($"{r.GetString("marka")} {r.GetString("tipus")} {r.GetInt32("fizet")} Ft");
                }
                conn.Close();
                LekerdezesMenu();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void ListazasMenu()
        {
            Console.WriteLine("Válasz lehetőséget: ");
            Console.WriteLine("(1) Autók listázása");
            Console.WriteLine("(2) Kliensek listázása");
            Console.WriteLine("(3) Kölcsönzések listázása");
            Console.WriteLine("(4) Vissza a főmenübe");
            int valasz = int.Parse(Console.ReadLine());
            if (valasz == 1)
            {
                autoLista();
            }
            else if (valasz == 2)
            {
                kliensLista();
            }
            else if (valasz == 3)
            {
                kolcsonzesLista();
            }
            else if (valasz == 4)
            {
                FoMenu();
            }
            else
            {
                Console.WriteLine("Ilyen lehetőség nincs!");
                ListazasMenu();
            }

        }

        static void HozzaadasMenu()
        {
            Console.WriteLine("Válasz lehetőséget: ");
            Console.WriteLine("(1) Autó hozzáadása");
            Console.WriteLine("(2) Kliens hozzáadása");
            Console.WriteLine("(3) Kölcsönzés hozzáadása");
            Console.WriteLine("(4) Vissza a főmenübe");
            int valasz = int.Parse(Console.ReadLine());
            if (valasz == 1)
            {
                AutoHozzaad();
            }
            else if (valasz == 2)
            {
                
            }
            else if (valasz == 3)
            {
                
            }
            else if (valasz == 4)
            {
                FoMenu();
            }
            else
            {
                Console.WriteLine("Ilyen lehetőség nincs!");
                HozzaadasMenu();
            }
        }

        static void LekerdezesMenu()
        {
            Console.WriteLine("Válasz lehetőséget: ");
            Console.WriteLine("(1) Kliens kölcsönzései");
            Console.WriteLine("(2) Vissza a főmenübe");
            int valasz = int.Parse(Console.ReadLine());
            if (valasz == 1)
            {
                KliensKolcsonzesek();
            }
            else if (valasz == 2)
            {
                FoMenu();
            }
            else
            {
                Console.WriteLine("Ilyen lehetőség nincs!");
                LekerdezesMenu();
            }
        }

        static void FoMenu()
        {
            Console.WriteLine("Válasz lehetőséget: ");
            Console.WriteLine("(1) Adatok listázása");
            Console.WriteLine("(2) Adatok hozzáadása");
            Console.WriteLine("(3) Lekérdezések");
            int valasz = int.Parse(Console.ReadLine());
            if(valasz == 1)
            {
                ListazasMenu();
            }
            else if(valasz == 2)
            {
                HozzaadasMenu();
            }
            else if(valasz == 3)
            {
                LekerdezesMenu();
            }
            else
            {
                Console.WriteLine("Ilyen lehetőség nincs!");
                FoMenu();
            }
        }


        static void Main(string[] args)
        {
            FoMenu();
        }
    }
}

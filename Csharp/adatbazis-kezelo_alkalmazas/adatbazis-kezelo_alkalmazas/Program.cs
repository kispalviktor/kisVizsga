using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adatbazis_kezelo_alkalmazas
{
    internal class Program
    {
        static MySqlConnection conn = new MySqlConnection("Server=localhost; User ID=root; Password=mysql; Database=konyvtar");

        static void konyvekLista()
        {
            try
            {
                conn.Open();
                var command = conn.CreateCommand();
                command.CommandText = "SELECT * FROM konyvek";
                var r = command.ExecuteReader();
                while (r.Read())
                {
                    Console.WriteLine($"{r.GetInt32("konyv_id")}, {r.GetString("cim")}, {r.GetString("szerzo")}, {r.GetInt32("kiadas_eve")}");
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

        static void tagokLista()
        {
            try
            {
                conn.Open();
                var command = conn.CreateCommand();
                command.CommandText = "SELECT * FROM tagok";
                var r = command.ExecuteReader();
                while (r.Read())
                {
                    Console.WriteLine($"{r.GetInt32("tag_id")}, {r.GetString("nev")}, {r.GetString("email")}");
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

        static void kolcsonzesekLista()
        {
            try
            {
                conn.Open();
                var command = conn.CreateCommand();
                command.CommandText = "SELECT t.tag_id, t.nev, t.email, k.cim, ko.kolcsonzes_datuma FROM kolcsonzesek ko JOIN tagok t ON ko.tag_id = t.tag_id JOIN konyvek k ON ko.konyv_id = k.konyv_id;";
                var r = command.ExecuteReader();
                while (r.Read())
                {
                    Console.WriteLine($"{r.GetInt32(0)}, {r.GetString(1)}, {r.GetString(2)}, {r.GetString(3)}, {r.GetDateTime(4)}");
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

        static void konyvekHozzaad()
        {
            Console.Write("Könyv címe: ");
            string cim = Console.ReadLine();
            Console.Write("Könyv szerzője: ");
            string szerzo = Console.ReadLine();
            Console.Write("Könyv kiadási éve: ");
            int kiadas_eve = int.Parse(Console.ReadLine());
            try
            {
                conn.Open();
                var command = conn.CreateCommand();
                command.CommandText = @"INSERT INTO konyvek (cim, szerzo, kiadas_eve) VALUES (@cim, @szerzo, @kiadas_eve);";
                command.Parameters.AddWithValue("@cim", cim);
                command.Parameters.AddWithValue("@szerzo", szerzo);
                command.Parameters.AddWithValue("@kiadas_eve", kiadas_eve);

                int eredmeny = command.ExecuteNonQuery();
                Console.WriteLine($"{eredmeny} sor hozzáadva!");
                conn.Close();
                HozzaadasMenu();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void tagokHozzaad() { 
            Console.Write("Tag neve: "); 
            string nev = Console.ReadLine(); 
            Console.Write("Tag e-mail címe: "); 
            string email = Console.ReadLine(); 
            try { 
                conn.Open(); 
                var command = conn.CreateCommand(); 
                command.CommandText = @"INSERT INTO tagok (nev, email) VALUES (@nev, @email);"; 
                command.Parameters.AddWithValue("@nev", nev); 
                command.Parameters.AddWithValue("@email", email); 
                int eredmeny = command.ExecuteNonQuery(); 
                Console.WriteLine($"{eredmeny} sor hozzáadva!"); 
                conn.Close(); HozzaadasMenu(); } 
            catch (Exception ex) { 
                Console.WriteLine(ex.Message); 
                } 
            }

        static void kolcsonzesHozzaad()
        {
            try
            {
                Console.Write("Tag ID: ");
                int tag_id = int.Parse(Console.ReadLine());
                Console.Write("Könyv ID: ");
                int konyv_id = int.Parse(Console.ReadLine());
                Console.Write("Kölcsönzés dátuma (YYYY-MM-DD): ");
                DateTime kolcsonzes_datuma = DateTime.Parse(Console.ReadLine());
                Console.Write("Visszaadás dátuma (YYYY-MM-DD) vagy üres, ha nincs: ");
                string visszaadasInput = Console.ReadLine();
                DateTime? visszaadasDatuma = null;

                if (!string.IsNullOrEmpty(visszaadasInput))
                {
                    visszaadasDatuma = DateTime.Parse(visszaadasInput);
                }

                conn.Open();
                var command = conn.CreateCommand();
                command.CommandText = "INSERT INTO kolcsonzesek (tag_id, konyv_id, kolcsonzes_datuma, visszaadas_datuma) VALUES (@tag_id, @konyv_id, @kolcsonzes_datuma, @visszaadas_datuma);";
                command.Parameters.AddWithValue("@tag_id", tag_id);
                command.Parameters.AddWithValue("@konyv_id", konyv_id);
                command.Parameters.AddWithValue("@kolcsonzes_datuma", kolcsonzes_datuma);

                if (visszaadasDatuma.HasValue)
                    command.Parameters.AddWithValue("@visszaadas_datuma", visszaadasDatuma.Value);
                else
                    command.Parameters.AddWithValue("@visszaadas_datuma", DBNull.Value);

                int eredmeny = command.ExecuteNonQuery();
                Console.WriteLine($"{eredmeny} sor hozzáadva!");
                conn.Close();
                HozzaadasMenu();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void kolcsonzesekHozzaad()
        {
            Console.Write("Kolcsonző neve: ");
            string nev = Console.ReadLine();
            Console.Write("Tag e-mail címe: ");
            string email = Console.ReadLine();
            try
            {
                conn.Open();
                var command = conn.CreateCommand();
                command.CommandText = @"INSERT INTO tagok (nev, email) VALUES (@nev, @email);";
                command.Parameters.AddWithValue("@nev", nev);
                command.Parameters.AddWithValue("@email", email);

                int eredmeny = command.ExecuteNonQuery();
                Console.WriteLine($"{eredmeny} sor hozzáadva!");
                conn.Close();
                HozzaadasMenu();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void HozzaadasMenu()
        {
            Console.WriteLine("Válasz lehetőséget: ");
            Console.WriteLine("(1) Könyv hozzáadása");
            Console.WriteLine("(2) Tag hozzáadása");
            Console.WriteLine("(3) Kölcsönzés hozzáadása");
            Console.WriteLine("(4) Vissza a főmenübe");
            int valasz = int.Parse(Console.ReadLine());
            if (valasz == 1)
            {
                konyvekHozzaad();
            }
            else if (valasz == 2)
            {
                tagokHozzaad();
            }
            else if (valasz == 3)
            {
                kolcsonzesHozzaad();
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

        static void ListazasMenu()
        {
            Console.WriteLine("Válasz lehetőséget: ");
            Console.WriteLine("(1) Könyvek listázása");
            Console.WriteLine("(2) Tagok listázása");
            Console.WriteLine("(3) Kölcsönzések listázása");
            Console.WriteLine("(4) Vissza a főmenübe");
            int valasz = int.Parse(Console.ReadLine());
            if (valasz == 1)
            {
                konyvekLista();
            }
            else if (valasz == 2)
            {
                tagokLista();
            }
            else if (valasz == 3)
            {
                kolcsonzesekLista();
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

        static void tagsKolcsonzesek()
        {
            Console.Write("Tag neve: ");
            string tag = Console.ReadLine();
            try
            {
                conn.Open();
                var command = conn.CreateCommand();
                command.CommandText = "SELECT t.tag_id, t.nev, t.email, k.cim, ko.kolcsonzes_datuma FROM kolcsonzesek ko JOIN tagok t ON ko.tag_id = t.tag_id JOIN konyvek k ON ko.konyv_id = k.konyv_id WHERE t.nev = @nev";
                command.Parameters.AddWithValue("@nev", tag);

                var r = command.ExecuteReader();
                while (r.Read())
                {
                    Console.WriteLine($"{r.GetString("cim")} - {r.GetDateTime("kolcsonzes_datuma"):yyyy-MM-dd}");
                }

                r.Close();
                conn.Close();
                LekerdezesMenu();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void kolcsonzottKonyv()
        {
            Console.Write("Könyv neve: ");
            string konyv = Console.ReadLine();
            try
            {
                conn.Open();
                var command = conn.CreateCommand();
                command.CommandText = "SELECT t.tag_id, t.nev, t.email, k.cim, ko.kolcsonzes_datuma FROM kolcsonzesek ko JOIN tagok t ON ko.tag_id = t.tag_id JOIN konyvek k ON ko.konyv_id = k.konyv_id WHERE k.cim = @cim AND ko.visszaadas_datuma IS NULL";
                command.Parameters.AddWithValue("@cim", konyv);

                var r = command.ExecuteReader();
                while (r.Read())
                {
                    Console.WriteLine($"{r.GetString("nev")} - {r.GetDateTime("kolcsonzes_datuma"):yyyy-MM-dd}");
                }

                r.Close();
                conn.Close();
                LekerdezesMenu();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void LekerdezesMenu()
        {
            Console.WriteLine("Válasz lehetőséget: ");
            Console.WriteLine("(1) Tag kölcsönzései");
            Console.WriteLine("(2) Kikölcsönzött könyv");
            Console.WriteLine("(3) Vissza a főmenübe");
            
            int valasz = int.Parse(Console.ReadLine());
            if (valasz == 1)
            {
                tagsKolcsonzesek();
            }
            else if (valasz == 2)
            {
                kolcsonzottKonyv();
            }
            else if (valasz == 3)
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
            if (valasz == 1)
            {
                ListazasMenu();
            }
            else if (valasz == 2)
            {
                HozzaadasMenu();
            }
            else if (valasz == 3)
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

using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adatbazis_kezelo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var connection = new MySqlConnection("Server=localhost; User ID=root; Password=mysql; Database=kiralyok");
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText = "SELECT nev, szul, hal FROM uralkodo;";
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine($"{reader.GetString("nev")} {reader.GetInt32("szul")} {reader.GetInt32("hal")}");
                }

                Console.Write("Írja be egy király nevét: ");
                string nev = Console.ReadLine();

                reader.Close();
                command.CommandText = "SELECT uralkodohaz.nev FROM uralkodohaz INNER JOIN uralkodo ON uhaz_az = uralkodohaz.azon WHERE uralkodo.nev = @nev;";
                command.Parameters.AddWithValue("nev", nev);
                
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine(reader.GetString("nev"));
                }
                reader.Close();

                Console.Write("Melyik hivatalt szeretnéd törölni? ");
                int melyik = int.Parse(Console.ReadLine());

                command.CommandText = "DELETE FROM hivatal WHERE azon = @azon";
                command.Parameters.Clear();
                command.Parameters.AddWithValue("azon", melyik);

                int sorok = command.ExecuteNonQuery();
                Console.WriteLine($"Töröltünk {sorok} sort.");

                Console.WriteLine("Új uralkodoház hozzáadása:");
                Console.Write("Új uralkodoház neve: ");
                string ujNev = Console.ReadLine();
                Console.Write("Új uralkodoház azonosítója: ");
                int ujAzon = int.Parse(Console.ReadLine());

                command.CommandText = "INSERT INTO uralkodohaz(azon. nev) VALUES(@azon, @nev);";
                command.Parameters.Clear();
                command.Parameters.AddWithValue("azon", ujAzon);
                command.Parameters.AddWithValue("nev", ujNev);
                sorok = command.ExecuteNonQuery();
                Console.WriteLine($"{sorok} uj sor beszúrva!");


                connection.Close();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
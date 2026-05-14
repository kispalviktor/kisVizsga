using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpS
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("WELCOME TO ROCK-PAPER-SCISSORS 3000!");
            Console.WriteLine("____________________________________");
            Console.Write("CHOOOSE YOUR DESTINY! (ROCK/PAPER/SCISSORS): ");
            string player = Console.ReadLine();
            player = player.ToLower();
            if(player != "rock" && player != "paper" && player != "scissors")
            {
                Console.WriteLine("There is no such choise, moron!");
            }
            else
            {
                Random rnd = new Random(); //véletlenszám objektum
                int comp = rnd.Next(1, 4); //1 és 3 közötti véletlen szám

                string computer = "";
                if(comp == 1)
                {
                    computer = "rock";
                }
                else if(comp == 2)
                {
                    computer = "paper";
                }
                else
                {
                    computer = "scissors";
                }

                if(player == computer)
                {
                    Console.WriteLine("DRAW!!!");
                }
                else if(player == "rock" && computer == "scissors")
                {
                    Console.WriteLine("YOU WIN!! FATALITY!!");
                }
                else if (player == "paper" && computer == "rock")
                {
                    Console.WriteLine("YOU WIN!! FATALITY!!");
                }
                else if (player == "scissors" && computer == "paper")
                {
                    Console.WriteLine("YOU WIN!! FATALITY!!");
                }
                else
                {
                    Console.WriteLine("COMPUTER WINS!! FATALITY!!");
                }
            }
        }
    }
}
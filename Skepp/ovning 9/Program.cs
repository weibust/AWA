using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SinkShip
{
    class Program
    {
        static string[,] gamePlan;

        static int gamePlanXSize, gamePlanYSize;
        static void Main(string[] args)
        {
            InitStuff();

            PrintGamePlan();

            PlayGame();

            // Ships();
        }

        static void PlayGame()
        {

            Random random = new Random();
            int randomX = random.Next(gamePlanXSize);
            int randomY = random.Next(gamePlanYSize);



            bool done = false;
            do
            {
                int guessX = GetInt("Ange X-koordinat ", 1, gamePlanXSize);
                guessX--;

                int guessY = GetInt("Ange Y-koordinat ", 1, gamePlanYSize);
                guessY--;

                if (guessX == randomX && guessY == randomY)
                {
                    Console.WriteLine("Grattis! Jollen befann sig på X:" + (randomX + 1) + " Y:" + (randomY + 1));
                    //Console.Clear();
                    PlayAgain();
                    done = true;
                }
                else
                {
                    gamePlan[guessX, guessY] = " x ";
                    Console.WriteLine("Fel, gissa igen!");
                    PrintGamePlan();
                }


            } while (!done);







        }





        static void PrintGamePlan()
        {
            Console.Clear();
            Console.Write("   |");
            for (int i = 0; i < gamePlanXSize; i++)
            {
                Console.Write($" {i + 1} |");
            }
            Console.WriteLine(" (X)");

            for (int i = 0; i < gamePlan.GetLength(0); i++)
            {
                Console.Write($" {i + 1} |");

                for (int j = 0; j < gamePlan.GetLength(1); j++)
                {
                    Console.Write(gamePlan[j, i] + " ");
                }
                Console.WriteLine("");
            }
            Console.WriteLine(Environment.NewLine + "(Y)" + Environment.NewLine);
        }

        static void InitStuff()
        {
            gamePlanXSize = getNumberFromUser(2, 10);
            gamePlanYSize = getNumberFromUser(2, 10);
            gamePlan = new string[gamePlanXSize, gamePlanYSize];

            for (int i = 0; i < gamePlanXSize; i++)
            {
                for (int j = 0; j < gamePlanYSize; j++)
                {
                    gamePlan[i, j] = "   ";
                }
            }
        }

        static int getNumberFromUser(int minNumber, int maxNumber)
        {
            int tmpNumber = minNumber - 1;
            bool numberNotValid = true;
            while (numberNotValid)
            {
                Console.Write($"Ange storlek på spelplanen, ange ett tal mellan {minNumber} och {maxNumber}: ");
                try
                {
                    tmpNumber = Convert.ToInt32(Console.ReadLine());
                    if (tmpNumber >= minNumber && tmpNumber <= maxNumber)
                        numberNotValid = false;
                    else
                        Console.WriteLine("Felaktig inmatning, försök igen");
                }
                catch (Exception)
                {
                    Console.WriteLine("Felaktig inmatning, försök igen");
                }
            }

            return tmpNumber;
        }

        static int GetInt(string message, int min, int max)
        {
            int input;
            bool done = false;
            do
            {
                do
                {
                    Console.Write(message + "(" + min + "-" + max + "): ");
                } while (!int.TryParse(Console.ReadLine(), out input));

                done = input >= min && input <= max;
                //if (!done)
                //    Console.WriteLine("Felaktig inmatning");
            } while (!done);
            return input;
        }




        static void PlayAgain()
        {
            Console.WriteLine("Vill du spela igen? (j/n)");
            string inputAgain = Console.ReadLine().ToLower();

            if (inputAgain == "j")
            {
                PlayGame();
            }
            else
            {
            }
        }





    }
}

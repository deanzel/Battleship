using System;
using BattleShip.BLL.Requests;
using BattleShip.BLL.Responses;
using BattleShip.BLL.Ships;
using BattleShip.BLL.GameLogic;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.UI
{
    internal class Program
    {
        //Converting Coordinate Method

        public static Coordinate Convert(string InputCoordinate)
        {
            int x = 0;
            int y;
            
            switch (InputCoordinate.Substring(0, 1).ToUpper())
            {
                case "A":
                    x = 1;
                    break;
                case "B":
                    x = 2;
                    break;
                case "C":
                    x = 3;
                    break;
                case "D":
                    x = 4;
                    break;
                case "E":
                    x = 5;
                    break;
                case "F":
                    x = 6;
                    break;
                case "G":
                    x = 7;
                    break;
                case "H":
                    x = 8;
                    break;
                case "I":
                    x = 9;
                    break;
                case "J":
                    x = 10;
                    break;
            }

            y = int.Parse(InputCoordinate.Substring(1));


            //Coordinate ConvertedCoordinate = new Coordinate(x, y);

            return new Coordinate(x, y);
        }


        private static void Main(string[] args)
        {
            //Console.WriteLine("Weclome to Battleship!!\nDo you want to play Battleship? Yes (Y) or No (N)?");
            //string UserResponse = Console.ReadLine().ToUpper();
            //bool WantToPlay = false;
          
            //string Player1Name = "";
            //string Player2Name = "";

            //while (WantToPlay == false)
            //{

            //    if (UserResponse == "N")
            //    {
            //        Console.Clear();
            //        Console.WriteLine("Goodbye :(");
            //        Console.ReadLine();
            //        WantToPlay = true;
            //    }

            //    if (UserResponse == "Y")
            //    {
            //        WantToPlay = true;



                    //PromptName() method


                    //bool player1NameOK = false;
                    //bool player2NameOK = false;


                    //Console.Clear();
                    //Console.WriteLine("Player 1, please enter your desired name.");
                    //Player1Name = Console.ReadLine();

                    //while (player1NameOK == false)
                    //{
                    //    Console.WriteLine("{0} is what we will call Player 1. Continue? Y or N.", Player1Name);
                    //    string NameResponse1 = Console.ReadLine().ToUpper();

                    //    while (NameResponse1 != "N" && NameResponse1 != "Y")
                    //    {
                    //        Console.Clear();
                    //        Console.WriteLine("Didn't get that. Is {0} what we will call Player 1? Y or N.", Player1Name);
                    //        NameResponse1 = Console.ReadLine().ToUpper();
                    //    }

                    //    while (NameResponse1 == "N")
                    //    {
                    //        Console.Clear();
                    //        Console.WriteLine("Player 1, please enter your new desired name.");
                    //        Player1Name = Console.ReadLine();
                    //        Console.WriteLine("{0} is what we will call Player 1. Continue? Y or N.", Player1Name);
                    //        NameResponse1 = Console.ReadLine().ToUpper();
                    //    }

                    //    if (NameResponse1 == "Y")
                    //    {
                    //        player1NameOK = true;
                    //    }
                    //}

                    //Console.Clear();
                    //Console.WriteLine("Player 2, please enter your desired name.");
                    //Player2Name = Console.ReadLine();

                    //while (player2NameOK == false)
                    //{
                    //    Console.WriteLine("{0} is what we will call Player 2. Continue? Y or N.", Player2Name);
                    //    string NameResponse2 = Console.ReadLine().ToUpper();

                    //    while (NameResponse2 != "N" && NameResponse2 != "Y")
                    //    {
                    //        Console.Clear();
                    //        Console.WriteLine("Didn't get that. Is {0} what we will call Player 2? Y or N.", Player2Name);
                    //        NameResponse2 = Console.ReadLine().ToUpper();
                    //    }

                    //    while (NameResponse2 == "N")
                    //    {
                    //        Console.Clear();
                    //        Console.WriteLine("Player 2, please enter your new desired name.");
                    //        Player2Name = Console.ReadLine();
                    //        Console.WriteLine("{0} is what we will call Player 2. Continue? Y or N.", Player2Name);
                    //        NameResponse2 = Console.ReadLine().ToUpper();
                    //    }

                    //    if (NameResponse2 == "Y")
                    //    {
                    //        player2NameOK = true;
                    //    }
                    //}




                    //Go into SetBoard method
                    Console.Clear();

                    Console.WriteLine("The BATTLESHIP board looks something like this,\n" +

                                      "so please enter any coordinates in the form of letter number pairs,\n" +

                                      "such as B8, or G3...");

                    string[] yaxis = new string[]

                    {

                        "A", "B", "C", "D", "E", "F", "G", "H", "I", "J"

                    };


                    Console.WriteLine("\t1\t2\t3\t4\t5\t6\t7\t8\t9\t10\n\n");

                    for (int i = 0; i < 10; i++)

                    {

                        Console.WriteLine("{0}\t _|\t _|\t _|\t _|\t _|\t _|\t _|\t _|\t _|\t _|\n\n", yaxis[i]);

                    }

                    Console.WriteLine("When you think you've got it, press enter to continue...");

                    Console.ReadLine();

                    Console.WriteLine("{0}, Get ready to place your DESTROYER...", "Dean");

                    Console.WriteLine("Choose a beginning coordinate, and remember, it is a 10x10 grid,\n" +

                                      "so don't let it fall off the ocean!");

                    string destroyerPlayer1String = Console.ReadLine();
                    Coordinate destroyerPlayer1Coordinate = Convert(destroyerPlayer1String);


                    Console.WriteLine("Now choose a direction to place your DESTROYER:\n" +

                                      "(U)p, (D)own, (L)eft, or (R)ight...");

                    string destroyerPlayer1Direction = Console.ReadLine();








                }



                //Exiting Option
                //else

                //{
                //    Console.Clear();
                //    Console.WriteLine("Invalid Reponse. Do you want to play Battleship? Type Y or N.");
                //    UserResponse = Console.ReadLine();
                }
            }

        
    



        

    


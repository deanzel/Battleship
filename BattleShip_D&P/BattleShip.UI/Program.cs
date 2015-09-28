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
            int y = 0;
            bool ValidX = false;
            bool ValidY = false;
            while (!ValidX || !ValidY)
            {
                switch (InputCoordinate.Substring(0, 1).ToUpper())
                {
                    case "A":
                        x = 1;
                        ValidX = true;
                        break;
                    case "B":
                        x = 2;
                        ValidX = true;
                        break;
                    case "C":
                        x = 3;
                        ValidX = true;
                        break;
                    case "D":
                        x = 4;
                        ValidX = true;
                        break;
                    case "E":
                        x = 5;
                        ValidX = true;
                        break;
                    case "F":
                        x = 6;
                        ValidX = true;
                        break;
                    case "G":
                        x = 7;
                        ValidX = true;
                        break;
                    case "H":
                        x = 8;
                        ValidX = true;
                        break;
                    case "I":
                        x = 9;
                        ValidX = true;
                        break;
                    case "J":
                        x = 10;
                        ValidX = true;
                        break;
                    default:
                        Console.WriteLine("Sorry, that was not a valid coordinate... Please enter it again.");
                        InputCoordinate = Console.ReadLine();
                        break;
                }

               ValidY = int.TryParse(InputCoordinate.Substring(1), out y);
                if (y < 1 || y > 10)
                {
                    ValidY = false;
                    Console.WriteLine("Sorry,  that was not a valid coordinate...  Please enter it again.");
                    InputCoordinate = Console.ReadLine();
                }
            }

            return new Coordinate(x, y);
        }


        private static void Main(string[] args)
        {
            Console.WriteLine("Weclome to Battleship by Dean & Patrick!!\nDo you want to play Battleship? Yes (Y) or No (N)?");
            string UserResponse = Console.ReadLine().ToUpper();
            bool WantToPlay = false;

            string Player1Name = "";
            string Player2Name = "";

            Board Player1Board = new Board();
            Board Player2Board = new Board();

            while (WantToPlay == false)
            {

                if (UserResponse == "N")
                {
                    Console.Clear();
                    Console.WriteLine("Goodbye :(");
                    Console.ReadLine();
                    WantToPlay = true;
                }

                if (UserResponse == "Y")
                {
                    WantToPlay = true;



                    //PromptName() method


                    bool player1NameOK = false;
                    bool player2NameOK = false;


                    Console.Clear();
                    Console.WriteLine("Player 1, please enter your desired name.");
                    Player1Name = Console.ReadLine();

                    while (player1NameOK == false)
                    {
                        Console.WriteLine("{0} is what we will call Player 1. Continue? Y or N.", Player1Name);
                        string NameResponse1 = Console.ReadLine().ToUpper();

                        while (NameResponse1 != "N" && NameResponse1 != "Y")
                        {
                            Console.Clear();
                            Console.WriteLine("Didn't get that. Is {0} what we will call Player 1? Y or N.", Player1Name);
                            NameResponse1 = Console.ReadLine().ToUpper();
                        }

                        while (NameResponse1 == "N")
                        {
                            Console.Clear();
                            Console.WriteLine("Player 1, please enter your new desired name.");
                            Player1Name = Console.ReadLine();
                            Console.WriteLine("{0} is what we will call Player 1. Continue? Y or N.", Player1Name);
                            NameResponse1 = Console.ReadLine().ToUpper();
                        }

                        if (NameResponse1 == "Y")
                        {
                            player1NameOK = true;
                        }
                    }

                    Console.Clear();
                    Console.WriteLine("Player 2, please enter your desired name.");
                    Player2Name = Console.ReadLine();

                    while (player2NameOK == false)
                    {
                        Console.WriteLine("{0} is what we will call Player 2. Continue? Y or N.", Player2Name);
                        string NameResponse2 = Console.ReadLine().ToUpper();

                        while (NameResponse2 != "N" && NameResponse2 != "Y")
                        {
                            Console.Clear();
                            Console.WriteLine("Didn't get that. Is {0} what we will call Player 2? Y or N.", Player2Name);
                            NameResponse2 = Console.ReadLine().ToUpper();
                        }

                        while (NameResponse2 == "N")
                        {
                            Console.Clear();
                            Console.WriteLine("Player 2, please enter your new desired name.");
                            Player2Name = Console.ReadLine();
                            Console.WriteLine("{0} is what we will call Player 2. Continue? Y or N.", Player2Name);
                            NameResponse2 = Console.ReadLine().ToUpper();
                        }

                        if (NameResponse2 == "Y")
                        {
                            player2NameOK = true;
                        }
                    }




                    //Go into SetBoard method
                    Console.Clear();

                    Console.WriteLine("The BATTLESHIP board looks something like this,\n" +

                                      "so please enter any coordinates in the form of letter number pairs,\n" +

                                      "from A to J and 1 to 10, such as B8, or G3...");

                    string[] yaxis = new string[]

                    {

                        "A", "B", "C", "D", "E", "F", "G", "H", "I", "J"

                    };


                    Console.WriteLine("\t1\t2\t3\t4\t5\t6\t7\t8\t9\t10\n\n");

                    for (int i = 0; i < 10; i++)

                    {

                        Console.WriteLine("{0}\t _|\t _|\t _|\t _|\t _|\t _|\t _|\t _|\t _|\t _|\n\n", yaxis[i]);

                    }

                    Console.WriteLine("When you think you've got it, press enter to continue on to placing your battleships...");
                    Console.ReadLine();


                    //Player 1 setting his or her battleships

                    Console.Clear();
                    Console.WriteLine("{0}, you will now place your 5 battleships: Destroyer (2 coordinates), Submarine (3), Cruiser (3), Battleship (4), Carrier (5).", Player1Name);
                    Console.ReadLine();


                    //P1 Destroyer
                    ShipPlacement destroyer1IsValid = new ShipPlacement();

                    do
                    {
                        Console.Clear();
                        Console.WriteLine("{0}, get ready to place your DESTROYER (2 coordinates)", Player1Name);
                        Console.WriteLine(
                            "First, choose an initial coordinate (alphanumeric) within the 10x10 grid for your ship.\nWe will ask for the direction/orientation of the ship in the next step.");

                        string destroyerP1CoordString = Console.ReadLine();
                        Coordinate destroyerP1BaseCoord = Convert(destroyerP1CoordString);

                        PlaceShipRequest requestVarDestroyer1 = new PlaceShipRequest();
                        requestVarDestroyer1.Coordinate = destroyerP1BaseCoord;
                        requestVarDestroyer1.ShipType = ShipType.Destroyer;

                        Console.WriteLine("{0}, now choose a direction to place your DESTROYER (2 coordinates):\n" +

                                          "(U)p, (D)own, (L)eft, or (R)ight.", Player1Name);

                        bool validDestroyer1Direction = false;

                        string destroyerP1Direction = Console.ReadLine().ToUpper();
                        while (!validDestroyer1Direction)
                        {
                            switch (destroyerP1Direction)
                            {
                                case "R":
                                    requestVarDestroyer1.Direction = ShipDirection.Right;
                                    validDestroyer1Direction = true;
                                    break;
                                case "L":
                                    requestVarDestroyer1.Direction = ShipDirection.Left;
                                    validDestroyer1Direction = true;
                                    break;
                                case "U":
                                    requestVarDestroyer1.Direction = ShipDirection.Up;
                                    validDestroyer1Direction = true;
                                    break;
                                case "D":
                                    requestVarDestroyer1.Direction = ShipDirection.Down;
                                    validDestroyer1Direction = true;
                                    break;
                                default:
                                    Console.WriteLine(
                                        "That is not a valid direction. Please choose (U)p, (D)own, (L)eft or (R)ight.");
                                    destroyerP1Direction = Console.ReadLine().ToUpper();
                                    break;
                            }
                        }

                        


                        destroyer1IsValid = Player1Board.PlaceShip(requestVarDestroyer1);
                        Console.WriteLine(destroyer1IsValid);
                        Console.ReadLine();
                    } while (destroyer1IsValid != ShipPlacement.Ok);

                    Console.WriteLine("Congratulations, {0}! You have placed your Destroyer. Press enter to continue...", Player1Name);
                    Console.ReadLine();


                    //P1 Submarine

                    ShipPlacement sub1IsValid = new ShipPlacement();
                    do
                    {

                        Console.Clear();
                    //Display array of ships
                    Console.WriteLine("{0}, get ready to place your SUBMARINE (3 coordinates)", Player1Name);
                    Console.WriteLine("First, choose an initial coordinate (alphanumeric) within the 10x10 grid for your ship.\nRemember that ships cannot overlap!!!\nWe will ask for the direction/orientation of the ship in the next step.");

                    string subP1CoordString = Console.ReadLine();
                    Coordinate subP1BaseCoord = Convert(subP1CoordString);

                    PlaceShipRequest requestVarSub1 = new PlaceShipRequest();
                    requestVarSub1.Coordinate = subP1BaseCoord;
                    requestVarSub1.ShipType = ShipType.Submarine;

                    Console.WriteLine("{0}, now choose a direction to place your SUBMARINE (3 coordinates):\n" +

                                      "(U)p, (D)own, (L)eft, or (R)ight.", Player1Name);

                    bool validSub1Direction = false;
                    string subP1Direction = Console.ReadLine().ToUpper();
                    while (!validSub1Direction)
                    {
                        switch (subP1Direction)
                        {
                            case "R":
                                requestVarSub1.Direction = ShipDirection.Right;
                                validSub1Direction = true;
                                break;
                            case "L":
                                requestVarSub1.Direction = ShipDirection.Left;
                                validSub1Direction = true;
                                break;
                            case "U":
                                requestVarSub1.Direction = ShipDirection.Up;
                                validSub1Direction = true;
                                break;
                            case "D":
                                requestVarSub1.Direction = ShipDirection.Down;
                                validSub1Direction = true;
                                break;
                            default:
                                Console.WriteLine(
                                    "That is not a valid direction. Please choose (U)p, (D)own, (L)eft or (R)ight.");
                                subP1Direction = Console.ReadLine().ToUpper();
                                break;
                        }
                    }
                    
                        sub1IsValid = Player1Board.PlaceShip(requestVarSub1);
                        Console.WriteLine(sub1IsValid);
                        Console.ReadLine();
                    } while (sub1IsValid != ShipPlacement.Ok);
                    
                    Console.WriteLine("Congratulations, {0}! You have placed your Submarine. Press enter to continue...", Player1Name);
                    Console.ReadLine();

                    //P1 Cruiser

                    ShipPlacement cruiser1IsValid = new ShipPlacement();
                    do
                    {
                        Console.Clear();
                    //Display array of ships
                    Console.WriteLine("{0}, get ready to place your CRUISER (3 coordinates)", Player1Name);
                    Console.WriteLine("First, choose an initial coordinate (alphanumeric) within the 10x10 grid for your ship." +
                                      "\nRemember that ships cannot overlap!!!" +
                                      "\nWe will ask for the direction/orientation of the ship in the next step.");

                    string cruiserP1CoordString = Console.ReadLine();
                    Coordinate cruiserP1BaseCoord = Convert(cruiserP1CoordString);

                    PlaceShipRequest requestVarCruiser1 = new PlaceShipRequest();
                    requestVarCruiser1.Coordinate = cruiserP1BaseCoord;
                    requestVarCruiser1.ShipType = ShipType.Cruiser;

                    Console.WriteLine("{0}, now choose a direction to place your CRUISER (3 coordinates):\n" +

                                      "(U)p, (D)own, (L)eft, or (R)ight.", Player1Name);

                    bool validCruiser1Direction = false;
                    string cruiserP1Direction = Console.ReadLine().ToUpper();
                    while (!validCruiser1Direction)
                    {
                        switch (cruiserP1Direction)
                        {
                            case "R":
                                requestVarCruiser1.Direction = ShipDirection.Right;
                                validCruiser1Direction = true;
                                break;
                            case "L":
                                requestVarCruiser1.Direction = ShipDirection.Left;
                                validCruiser1Direction = true;
                                break;
                            case "U":
                                requestVarCruiser1.Direction = ShipDirection.Up;
                                validCruiser1Direction = true;
                                break;
                            case "D":
                                requestVarCruiser1.Direction = ShipDirection.Down;
                                validCruiser1Direction = true;
                                break;
                            default:
                                Console.WriteLine(
                                    "That is not a valid direction. Please choose (U)p, (D)own, (L)eft or (R)ight.");
                                cruiserP1Direction = Console.ReadLine().ToUpper();
                                break;
                        }
                    }

                    
                        cruiser1IsValid = Player1Board.PlaceShip(requestVarCruiser1);
                        Console.WriteLine(cruiser1IsValid);
                        Console.ReadLine();
                    } while (cruiser1IsValid != ShipPlacement.Ok);
                    
                    Console.WriteLine("Congratulations, {0}! You have placed your Cruiser. Press enter to continue...", Player1Name);
                    Console.ReadLine();

                    
                }

                

                //Exiting Option
                else

                {
                    Console.Clear();
                    Console.WriteLine("Invalid Reponse. Do you want to play Battleship? Type Y or N.");
                    UserResponse = Console.ReadLine();
                }
            }
        }
    }
}

        
    



        

    


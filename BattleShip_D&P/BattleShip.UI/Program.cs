using System;
using BattleShip.BLL.Requests;
using BattleShip.BLL.Responses;
using BattleShip.BLL.Ships;
using BattleShip.BLL.GameLogic;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Battleship.Tests;

namespace BattleShip.UI
{
    internal class Program
    {
        //Converting Coordinate Method
        public static Player Player1 { get; set; }
        public static Player Player2 { get; set; }


        public static Coordinate Convert(string InputCoordinate)
        {
            int x = 0;
            int y = 0;
            bool ValidX = false;
            bool ValidY = false;


            while (!ValidX || !ValidY)
            {
                while (InputCoordinate == "")
                {
                    Console.WriteLine("Sorry, that was not a valid coordinate... Please enter it again.");
                    InputCoordinate = Console.ReadLine();
                }
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
                while (InputCoordinate == "")
                {
                    Console.WriteLine("Sorry, that was not a valid coordinate... Please enter it again.");
                    InputCoordinate = Console.ReadLine();
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


        public static void Main(string[] args)
        {
            string UserResponse = "";
            Console.WriteLine(
                "Weclome to Battleship by Dean & Patrick!!\nDo you want to play Battleship? Yes (Y) or No (N)?");
            UserResponse = Console.ReadLine().ToUpper();
            bool WantToPlay = false;

            Player1 = new Player();
            Player2 = new Player();

            bool keepPlaying = true;

            Player[] playersArray = new Player[]
            {
                Player1,
                Player2
            };

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

                    PromptName(playersArray);


                    while (keepPlaying)
                    {
                        //New SetBoard method
                        SetBoard(playersArray);

                        //STARTING THE GAME!!!!!!!
                        StartGame(playersArray);


                        //Play a new game loop conditions

                        Console.WriteLine("\nDo you want to play another game? Enter (Y)es or (N)o.");
                        string wantToPlay = Console.ReadLine().ToUpper();
                        bool validWantToPlayResponse = false;

                        while (!validWantToPlayResponse)
                        {
                            switch (wantToPlay)
                            {
                                case "Y":
                                    Console.WriteLine("You will now play a new game. Get ready to set your new boards.");
                                    Console.ReadLine();
                                    validWantToPlayResponse = true;
                                    break;
                                case "N":
                                    Console.WriteLine("OK. Goodbye.");
                                    Console.ReadLine();
                                    validWantToPlayResponse = true;
                                    keepPlaying = false;
                                    break;
                                default:
                                    Console.WriteLine(
                                        "That is not a valid response. Do you want to play another game? (Y)es or (N)o.");
                                    wantToPlay = Console.ReadLine().ToUpper();
                                    break;
                            }
                        }
                    }

                }



                //Exiting Option
                else

                {
                    Console.Clear();
                    Console.WriteLine("Invalid Reponse. Do you want to play Battleship? Type Y or N.");
                    UserResponse = Console.ReadLine().ToUpper();
                }
            }
        }

        //PromptName method
        public static void PromptName(Player[] players)
        {
            bool player1NameOK = false;
            bool player2NameOK = false;


            Console.Clear();
            Console.WriteLine("Player 1, please enter your desired name.");
            Player1.Name = Console.ReadLine();

            while (player1NameOK == false)
            {
                Console.WriteLine("{0} is what we will call Player 1. Continue? Y or N.", Player1.Name);
                string NameResponse1 = Console.ReadLine().ToUpper();

                while (NameResponse1 != "N" && NameResponse1 != "Y")
                {
                    Console.Clear();
                    Console.WriteLine("Didn't get that. Is {0} what we will call Player 1? Y or N.",
                        Player1.Name);
                    NameResponse1 = Console.ReadLine().ToUpper();
                }

                while (NameResponse1 == "N")
                {
                    Console.Clear();
                    Console.WriteLine("Player 1, please enter your new desired name.");
                    Player1.Name = Console.ReadLine();
                    Console.WriteLine("{0} is what we will call Player 1. Continue? Y or N.", Player1.Name);
                    NameResponse1 = Console.ReadLine().ToUpper();
                }

                if (NameResponse1 == "Y")
                {
                    player1NameOK = true;
                }
            }

            Console.Clear();
            Console.WriteLine("Player 2, please enter your desired name.");
            Player2.Name = Console.ReadLine();

            while (player2NameOK == false)
            {
                Console.WriteLine("{0} is what we will call Player 2. Continue? Y or N.", Player2.Name);
                string NameResponse2 = Console.ReadLine().ToUpper();

                while (NameResponse2 != "N" && NameResponse2 != "Y")
                {
                    Console.Clear();
                    Console.WriteLine("Didn't get that. Is {0} what we will call Player 2? Y or N.",
                        Player2.Name);
                    NameResponse2 = Console.ReadLine().ToUpper();
                }

                while (NameResponse2 == "N")
                {
                    Console.Clear();
                    Console.WriteLine("Player 2, please enter your new desired name.");
                    Player2.Name = Console.ReadLine();
                    Console.WriteLine("{0} is what we will call Player 2. Continue? Y or N.", Player2.Name);
                    NameResponse2 = Console.ReadLine().ToUpper();
                }

                if (NameResponse2 == "Y")
                {
                    player2NameOK = true;
                }
            }
        }

        //New SetBoard Method
        public static void SetBoard(Player[] players)
        {
            Console.Clear();

            for (int p = 0; p < players.Length; p++)
            {
                Console.Clear();
                Console.WriteLine(
                    "{0}, you will now place your 5 battleships: Destroyer (2 coordinates), Submarine (3), Cruiser (3), Battleship (4), Carrier (5)." +
                    "\nPress Enter to continue."
                    ,
                    players[p].Name);
                Console.ReadLine();
                for (int s = 0; s < 5; s++)
                {
                    ShipPlacement placementIsValid = new ShipPlacement();
                    ShipType shipType = (ShipType) s;

                    int shipLength = 0;
                    switch (s)
                    {
                        case 0:
                            shipLength = 2;
                            break;
                        case 1:
                        case 2:
                            shipLength = 3;
                            break;
                        case 3:
                            shipLength = 4;
                            break;
                        case 4:
                            shipLength = 5;
                            break;
                    }

                    do
                    {
                        Console.Clear();
                        DrawShipPlacement(players[p]);
                        Console.WriteLine("\n\n\n{0}, get ready to place your {1} ({2} coordinates)", players[p].Name,
                            shipType.ToString(), shipLength);
                        Console.WriteLine(
                            "\nFirst, choose an initial coordinate (alphanumeric) within the 10x10 grid for your ship.\n\nWe will ask for the direction/orientation of the ship afterward.");

                        string coordString = Console.ReadLine();
                        Coordinate baseCoord = Convert(coordString);

                        PlaceShipRequest requestShip = new PlaceShipRequest();
                        requestShip.Coordinate = baseCoord;
                        requestShip.ShipType = (ShipType) s;

                        Console.WriteLine("{0}, now choose a direction to place your {1} ({2} coordinates):\n" +

                                          "(U)p, (D)own, (L)eft, or (R)ight.", players[p].Name, shipType.ToString(),
                            shipLength);

                        bool validShipDirection = false;

                        string shipDirection = Console.ReadLine().ToUpper();
                        while (!validShipDirection)
                        {
                            switch (shipDirection)
                            {
                                case "R":
                                    requestShip.Direction = ShipDirection.Right;
                                    validShipDirection = true;
                                    break;
                                case "L":
                                    requestShip.Direction = ShipDirection.Left;
                                    validShipDirection = true;
                                    break;
                                case "U":
                                    requestShip.Direction = ShipDirection.Up;
                                    validShipDirection = true;
                                    break;
                                case "D":
                                    requestShip.Direction = ShipDirection.Down;
                                    validShipDirection = true;
                                    break;
                                default:
                                    Console.WriteLine(
                                        "That is not a valid direction. Please choose (U)p, (D)own, (L)eft or (R)ight.");
                                    shipDirection = Console.ReadLine().ToUpper();
                                    break;
                            }
                        }
                        placementIsValid = players[p].PlayerBoard.PlaceShip(requestShip);

                        switch (placementIsValid)
                        {
                            case ShipPlacement.NotEnoughSpace:
                                Console.WriteLine("There is not enough space to place the ship there. Try again.");
                                break;
                            case ShipPlacement.Overlap:
                                Console.WriteLine("The ship is overlapping with a previously placed ship. Try again.");
                                break;
                            default:
                                Console.WriteLine("That ship placement is OK!!");
                                break;
                        }

                        //Console.WriteLine(placementIsValid);
                        Console.ReadLine();


                    } while (placementIsValid != ShipPlacement.Ok);

                    //Adding ship to ShipBoard Dictionary
                    Ship shipToDraw = players[p].PlayerBoard._ships[s];

                    foreach (Coordinate shipCoord in shipToDraw.BoardPositions)
                    {
                        players[p].PlayerBoard.ShipBoard.Add(shipCoord, shipToDraw.ShipType);
                    }

                    Console.Clear();
                    DrawShipPlacement(players[p]);

                    Console.WriteLine("\n\nCongratulations, {0}! You have placed your {1}. Press enter to continue...",
                        players[p].Name, shipType.ToString());
                    Console.ReadLine();
                }
            }
        }


        //DrawShipPlacement Method

        public static void DrawShipPlacement(Player player)
        {
            Console.WriteLine("     A   B   C   D   E   F   G   H   I   J\n");
            for (int y = 1; y < 10; y++)
            {
                Console.Write("{0} ", y);
                for (int x = 1; x < 11; x++)
                {
                    Coordinate coord = new Coordinate(x, y);
                    ShipType boardVar;
                    if (player.PlayerBoard.ShipBoard.TryGetValue(coord, out boardVar))
                    {
                        switch (boardVar)
                        {
                            case ShipType.Destroyer:
                                Console.Write("   D");
                                break;
                            case ShipType.Submarine:
                                Console.Write("   S");
                                break;
                            case ShipType.Cruiser:
                                Console.Write("   R");
                                break;
                            case ShipType.Battleship:
                                Console.Write("   B");
                                break;
                            case ShipType.Carrier:
                                Console.Write("   C");
                                break;
                            default:
                                Console.Write("  .");
                                break;
                        }
                    }
                    else
                    {
                        Console.Write("   .");
                    }
                }
                Console.WriteLine("\n");
            }

            //Insert y = 10 line

            Console.Write("10");
            for (int x = 1; x < 11; x++)
            {
                Coordinate coord = new Coordinate(x, 10);
                ShipType boardVar;
                if (player.PlayerBoard.ShipBoard.TryGetValue(coord, out boardVar))
                {
                    switch (boardVar)
                    {
                        case ShipType.Destroyer:
                            Console.Write("   D");
                            break;
                        case ShipType.Submarine:
                            Console.Write("   S");
                            break;
                        case ShipType.Cruiser:
                            Console.Write("   R");
                            break;
                        case ShipType.Battleship:
                            Console.Write("   B");
                            break;
                        case ShipType.Carrier:
                            Console.Write("   C");
                            break;
                        default:
                            Console.Write("   .");
                            break;
                    }
                }
                else
                {
                    Console.Write("   .");
                }
            }
        }




        //GameWorkFlow Start Methods
        public static void StartGame(Player[] players)
        {
            //bool Player1Turn = true;

            //while loop no ShotStatus.Victory

            //for cycling through players turns from 1 to 2
            // for (int i = 0; i < players.Length; i++)
            //put in turns
            Console.Clear();

            bool player1Turn = false;

            FireShotResponse playerShotFired = new FireShotResponse();

            while (playerShotFired.ShotStatus != ShotStatus.Victory)
            {
                for (int i = 0; i < players.Length; i++)
                {
                    do
                    {
                        if (i == 0)
                        {
                            DrawBoard(players[1]);
                        }
                        else
                        {
                            DrawBoard(players[0]);
                        }

                        Console.WriteLine("{0}, get ready to fire your shot?\n", players[i].Name);
                        Console.WriteLine("Enter a coordinate to fire your missile!\n");
                        string shotFired = Console.ReadLine();
                        Coordinate missle = Convert(shotFired);
                        //FireShotResponse playerShotFired = new FireShotResponse();

                        if (i == 0)
                        {
                            playerShotFired = Player2.PlayerBoard.FireShot(missle);
                            player1Turn = false;
                        }
                        else
                        {
                            playerShotFired = Player1.PlayerBoard.FireShot(missle);
                            player1Turn = true;
                        }
                        if (playerShotFired.ShotStatus == ShotStatus.Duplicate)
                        {
                            Console.WriteLine("\nThat is a duplicate shot. We will have to take in a new coordinate.\nPress Enter to continue...");
                            Console.ReadLine();
                            Console.Clear();
                        }
                    } while (playerShotFired.ShotStatus == ShotStatus.Duplicate);


                    switch (playerShotFired.ShotStatus)
                    {
                        case ShotStatus.Hit:
                            Console.WriteLine("\nYou hit something!");
                            break;
                        case ShotStatus.Miss:
                            Console.WriteLine("\nYour projectile splashes into the ocean, you missed!");
                            break;
                        case ShotStatus.HitAndSunk:
                            Console.WriteLine("\nYou sank your opponent's {0}!", playerShotFired.ShipImpacted);
                            break;
                    }

                    if (playerShotFired.ShotStatus == ShotStatus.Victory)
                        break;

                    Console.WriteLine("\nIt is now the next player's turn. Press enter to clear the screen and continue to the next turn.");
                    Console.ReadLine();
                    Console.Clear();

                }


            }

            if (player1Turn == false)
            {
                Console.WriteLine("\n\n{0} has won the game!! Congratulations.", players[0].Name);
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("\n\n{0} has won the game!! Congratulations.", players[1].Name);
                Console.ReadLine();
            }

            Console.ReadLine();
        }

        //DrawBoard
        public static void DrawBoard(Player player)
        {

            Console.WriteLine("     A   B   C   D   E   F   G   H   I   J\n");
            for (int y = 1; y < 10; y++)
            {
                Console.Write("{0} ", y);
                for (int x = 1; x < 11; x++)
                {
                    Coordinate coord = new Coordinate(x, y);
                    ShotHistory history;
                    if (player.PlayerBoard.ShotHistory.TryGetValue(coord, out history))
                    {
                        switch (history)
                        {
                            case ShotHistory.Hit:
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write("   H");
                                Console.ResetColor();
                                break;
                            case ShotHistory.Miss:
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write("   M");
                                Console.ResetColor();
                                break;
                            default:
                                Console.Write("   .");
                                break;
                        }
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write("   ~");
                        Console.ResetColor();
                    }

                }
                Console.WriteLine("\n");
            }

            Console.Write("10");
            for (int x = 1; x < 11; x++)
            {
                Coordinate coord = new Coordinate(x, 10);
                ShotHistory history;
                if (player.PlayerBoard.ShotHistory.TryGetValue(coord, out history))
                {
                    switch (history)
                    {
                        case ShotHistory.Hit:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("   H");
                            Console.ResetColor();
                            break;
                        case ShotHistory.Miss:
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("   M");
                            Console.ResetColor();
                            break;
                        default:
                            Console.Write("   .");
                            break;
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("   ~");
                    Console.ResetColor();
                }
            }
            Console.WriteLine("\n\n");
        }
    }
}
    


        
    



        

    


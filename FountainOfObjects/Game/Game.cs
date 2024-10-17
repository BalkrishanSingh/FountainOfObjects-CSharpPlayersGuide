using FountainOfObjects.Game.Grid.Generator;
using FountainOfObjects.Game.Grid.Rooms;
using FountainOfObjects.Game.Player;
using FountainOfObjects.Game.Player.Commands;
namespace FountainOfObjects.Game;

public class Game
{
    public Player.Player Player { get; }
    public Grid.Grid Grid { get; }
    public bool IsRunning { get; private set; } = true;

    public Game(IGridGenerator generator)
    {
        Grid = generator.GenerateGrid();
        Player = new Player.Player(Grid);
    }

    public void Run()
    {

        Console.WriteLine(GameInstructions.GamePlayInstructions());
        Console.WriteLine(GameInstructions.CommandInstructions());
        while (IsRunning)
        {
            Turn();

        }
        
    }

    private void Turn()
        {
            Console.WriteLine("----------------------------------------------------------------------------------");
            Console.WriteLine(Player.PositionString());
            
            Room currentRoom = Grid[Player.PlayerPosition];
            Console.WriteLine(currentRoom.RoomDescription());
            
            
            HandleUserInput();
        }

    private void HandleUserInput()
    {
        while(true)
        {
            Console.Write("What do you want to do?");
            string[] playerCommandStrings = (Console.ReadLine() ?? string.Empty).ToLower().Split(' ');
            switch (playerCommandStrings[0]) 
            {
                case "move":
                    if (playerCommandStrings.Length > 1)
                    {
                        if (Enum.TryParse(playerCommandStrings[1], out Direction direction))
                        {
                          Player.Move(direction);
                          return;
                        }
                        Console.WriteLine("Invalid direction");
                    }
                    else
                    {
                        Console.WriteLine("Enter Direction as well.");
                    }
                    break;
                case "exit":
                    Console.WriteLine("Thank you for playing Fountain Of Objects.");
                    IsRunning = false;
                    break;
                default:
                    Console.WriteLine("Invalid command");
                    Console.WriteLine(GameInstructions.CommandInstructions());
                    break;
            }

        }
    }

    }


using FountainOfObjects.Game.Grid.Generator;
using FountainOfObjects.Game.Grid.Room;
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
    //TODO Handle victory condition. 
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
        while (true)
        {
            Console.Write("What do you want to do?");
            string[] playerCommandStrings = (Console.ReadLine() ?? string.Empty).ToLower().Split(' ');
            switch (playerCommandStrings[0])
            {
                case "move":
                    if (playerCommandStrings.Length > 1)
                    {
                        //This tries to parse input command to direction and then returns if the movement was sucessful or not.
                        if (Enum.TryParse(playerCommandStrings[1], true, out Direction direction)&&  new MoveCommand(Player, direction).Execute())
                            return;

                        Console.WriteLine("Invalid Direction");
                    }
                    else
                    {
                        Console.WriteLine("Enter Direction as well.");
                    }
                    break;
                case "toggle":

                    if (playerCommandStrings.Length > 1 && playerCommandStrings[1]=="fountain")
                    {
                        if (new ToggleFountainCommand(Player,Grid).Execute())
                        {
                            return;
                        }
                        Console.WriteLine("You aren't in the fountain room.");
                    }
                    break;

                case "exit":
                    Console.WriteLine("Thank you for playing Fountain Of Objects.");
                    IsRunning = false;
                    return;
                default:
                    Console.WriteLine("Invalid Command");
                    break;
            }
        }
    }
}
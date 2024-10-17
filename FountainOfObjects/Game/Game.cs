using FountainOfObjects.Game.Grid.Generator;
using FountainOfObjects.Game.Grid.Room;
using FountainOfObjects.Game.Player.Commands;
using Spectre.Console;

namespace FountainOfObjects.Game;

public class Game
{
    public Player.Player Player { get; }
    public Grid.Grid Grid { get; }
    public bool IsRunning { get; private set; } = true;
    public int TurnNumber { get; private set; } = 1;

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
        
        var turnIndicator = new Rule($"[bold purple]Turn{TurnNumber}[/]");
        AnsiConsole.Write(turnIndicator.RuleStyle("red bold"));
        
        AnsiConsole.MarkupLine($"[bold]{Player.PositionString()}");

      
        Room currentRoom = Grid[Player.PlayerPosition];
        AnsiConsole.MarkupLineInterpolated($"[bold]{currentRoom.RoomDescription()}");
        HandleUserInput();
        TurnNumber++;
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

                        AnsiConsole.MarkupLine("[red bold]Invalid Direction[/]");
                    }
                    else
                    {
                        AnsiConsole.MarkupLine("[red bold]Enter Direction as well[/]");
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
                    AnsiConsole.MarkupLine("[green bold]Thank you for playing Fountain Of Objects.[/]");
                    IsRunning = false;
                    return;
                default:
                    AnsiConsole.MarkupLine("[red bold]Invalid Command[/]");
                    break;
            }
        }
    }
}
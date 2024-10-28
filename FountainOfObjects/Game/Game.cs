
using FountainOfObjects.Game.Grid.Generator;
using FountainOfObjects.Game.Grid.Room;
using FountainOfObjects.Game.Grid.Room.Event;
using FountainOfObjects.Game.Player;
using FountainOfObjects.Game.Player.Commands;

namespace FountainOfObjects.Game;

public class Game
{
    public Player.Player Player { get; }
    public Grid.Grid Grid { get; }
    public GameState GameState { get; set; } = GameState.Ongoing;

    public event Action OnVictory;
    public event Action OnDefeat;
    public event Action OnExit;
    
    private Room CurrentRoom 
    {
        get
        {
            Room currentRoom = Grid[Player.PlayerPosition];
            return currentRoom;
        }
    }

    private Dictionary<Type,Type> RoomToEventHandlerMappings { get; } = new Dictionary<Type, Type>()
    {
        { typeof(EntranceRoom), typeof(EntranceRoomEvent) },
    };

    // public event Action<Room> ChangedRoom = (room) => { };

    public Game(IGridGenerator generator)
    {
        Grid = generator.GenerateGrid();
        Player = new Player.Player(Grid);
    }

    public void Run()
    {
        Console.WriteLine(GameInstructions.GamePlayInstructions());
        Console.WriteLine(GameInstructions.CommandInstructions());
        while (GameState == GameState.Ongoing)
        {
            Turn();
        }

        switch (GameState)
        {
            case GameState.Victory:
                OnVictory?.Invoke();
                break;
            case GameState.Defeat:
                OnDefeat?.Invoke();
                break;
            case GameState.Exited:
                OnExit?.Invoke();
                break;
        }
        
    }
    //TODO Handle victory condition. 
    private void Turn()
    {
        Console.WriteLine("----------------------------------------------------------------------------------");
        Console.WriteLine(Player.PositionString());
        Console.WriteLine(CurrentRoom.RoomDescription());
        HandleUserInput();
    }

    /// <summary>
    /// This tries to parse input command to direction and then returns if the movement was sucessful or not.
    /// It also invokes the ChangedRoom event.
    /// </summary>
    /// <param name="commandDirectionString"></param>
    /// <returns>bool representing success of operation.</returns>
    private bool MovePlayer(String commandDirectionString)
    {
        if (Enum.TryParse(commandDirectionString, true, out Direction direction) &&
            new MoveCommand(Player, direction).Execute())
        {
            TriggerRoomEvent();
            return true;
        }
        return false;

    }
    private void TriggerRoomEvent()
    {
        if (RoomToEventHandlerMappings.TryGetValue(CurrentRoom.GetType(), out Type? eventHandlerType))
        {
            if (Activator.CreateInstance(eventHandlerType) is IRoomEventHandler eventHandler)
            {
                eventHandler.TriggerEvent();
            }
        } 
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
                       
                        if (MovePlayer(playerCommandStrings[1]))
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
                    GameState = GameState.Exited;
                    return;
                default:
                    Console.WriteLine("Invalid Command");
                    break;
            }
        }
    }
}
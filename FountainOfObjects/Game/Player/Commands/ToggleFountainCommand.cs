using FountainOfObjects.Game.Grid.Room;

namespace FountainOfObjects.Game.Player.Commands;

public class ToggleFountainCommand(Player player, Grid.Grid grid) :IPlayerCommand
{

    public bool Execute()
    {
        if (grid[player.PlayerPosition].GetType() == typeof(FountainRoom))
        {
            FountainRoom fountainRoom = (FountainRoom) grid[player.PlayerPosition];
            fountainRoom.FountainState = fountainRoom.FountainState ==FountainState.Off ? FountainState.On : FountainState.Off;
            return true;

        }
        return false;
    }
}
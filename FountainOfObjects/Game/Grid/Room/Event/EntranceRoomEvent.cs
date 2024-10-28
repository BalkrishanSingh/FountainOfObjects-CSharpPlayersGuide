using FountainOfObjects.Game.Player;

namespace FountainOfObjects.Game.Grid.Room.Event;

public class EntranceRoomEvent(Game game) :IRoomEventHandler
{
    public void TriggerEvent()
    {
        if (((FountainRoom)game.Grid[typeof(FountainRoom)]).FountainState == FountainState.On)
        {
            game.GameState = GameState.Victory;
        }

    }
}
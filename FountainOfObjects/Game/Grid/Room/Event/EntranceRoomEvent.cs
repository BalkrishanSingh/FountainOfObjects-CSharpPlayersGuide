namespace FountainOfObjects.Game.Grid.Room.Event;

public class EntranceRoomEvent(Grid grid) :IRoomEventHandler
{

    public void TriggerEvent()
    {
        if (((FountainRoom)grid[typeof(FountainRoom)]).FountainState == FountainState.On){
            
        }

    }
}
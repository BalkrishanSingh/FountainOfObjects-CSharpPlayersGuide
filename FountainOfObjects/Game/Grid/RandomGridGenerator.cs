using FountainOfObjects.Game.Grid.Rooms;

namespace FountainOfObjects.Game.Grid;

public class RandomGridGenerator : IGridGenerator
{
    
    public Grid GenerateGrid(int rows, int columns)
    {

        Room[,] rooms = new Room[rows, columns];
        Random random = new Random();
        
        Dictionary<string,double> roomProbablities= new Dictionary<string, double>();

        rooms[0, 0] = new EntranceRoom(new Coordinate(0, 0)); 
        rooms
        
        for (int row = 0; row < rooms.GetLength(0); row++)
        {
            for (int column = 0; column < rooms.GetLength(1); column++)
            {
                if (row == 0 && column == 0)
                {
                   
                }
                else
                {
                    rooms[row, column] = new EmptyRoom(new Coordinate(row, column));
                }
                
            }
        }
        return new Grid(rooms);
    }
}
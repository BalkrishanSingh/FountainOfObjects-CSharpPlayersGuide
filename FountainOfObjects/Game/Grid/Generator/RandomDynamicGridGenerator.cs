using FountainOfObjects.Game.Grid.Rooms;

namespace FountainOfObjects.Game.Grid.Generator;

public class RandomDynamicGridGenerator(int rows, int columns) : IGridGenerator
{
    private int Rows { get; } = rows;
    private int Columns { get; } = columns;
    
    public Grid GenerateGrid()
    {

        Room[,] rooms = new Room[Rows, Columns];
        
        // Random random = new Random();
        // Dictionary<string,double> roomProbablities= new Dictionary<string, double>();
        
        
        for (int row = 0; row < rooms.GetLength(0); row++)
        {
            for (int column = 0; column < rooms.GetLength(1); column++)
            {
                if (rooms[row, column].GetType() == typeof(Room))
                {
                    if (row == 0 && column == 0)
                    {
                        rooms[row, column] = new EntranceRoom(new Coordinate(row, column));
                    }
                    else
                    {
                        rooms[row, column] = new EmptyRoom(new Coordinate(row, column));
                    }
                  
                }
            }
        }
        return new Grid(rooms);
    }


}
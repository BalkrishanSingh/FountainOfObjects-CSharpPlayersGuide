namespace FountainOfObjects.Game;

public static class GameInstructions
{
    public static string CommandInstructions()
    {
        return """
               Control the game with the following commands:
                move north
                move west
                move south
                move east
                exit
               """;
    }

    public static string GamePlayInstructions()
    {
        string instructions = """
                              You enter the Cavern of Objects, a maze of rooms filled with dangerous pits in search of the Fountain of Objects.
                              Light is visible only in the entrance, and no other light is seen anywhere in the caverns. You must navigate the Caverns with your other senses.
                              Find the Fountain of Objects, activate it, and return to the entrance.
                              """;
        if (GameSettings.EnabledExpansions != null)
        {
            foreach (Type type in GameSettings.EnabledExpansions)
            {
                instructions += type.ToString() switch
                {
                    _ => ""
                };
            }
        }

        return instructions;
    }
}
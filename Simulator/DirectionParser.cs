namespace Simulator;

public static class DirectionParser
{
    public static Direction[] Parse(string input)
    {
        if (string.IsNullOrEmpty(input))
            return new Direction[0];

        var directions = new List<Direction>();

        foreach (char c in input)
        {
            switch (char.ToUpper(c))
            {
                case 'U':
                    directions.Add(Direction.Up);
                    break;
                case 'R':
                    directions.Add(Direction.Right);
                    break;
                case 'D':
                    directions.Add(Direction.Down);
                    break;
                case 'L':
                    directions.Add(Direction.Left);
                    break;
            }
        }

        return directions.ToArray();
    }
}
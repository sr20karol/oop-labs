namespace Simulator;

public abstract class Creature
{
    private string name = "Unknown";
    private int level = 1;
    public string Name
    {
        get => name;
        init
        {
            if (value == null)
            {
                return;
            }

            var trimmed = value.Trim();

            if (trimmed.Length > 25)
            {
                trimmed = trimmed.Substring(0, 25).TrimEnd();
            }

            if (trimmed.Length < 3)
            {
                trimmed = trimmed.PadRight(3, '#');
            }

            if (char.IsLower(trimmed[0]))
            {
                trimmed = char.ToUpper(trimmed[0]) + trimmed.Substring(1);
            }
            name = trimmed;
        }
    }

    public int Level
    {
        get => level;
        init
        {
            if (value < 1)
            {
                level = 1;
            }
            else if (value > 10)
            {
                level = 10;
            }
            else
            {
                level = value;
            }
        }
    }

    public Creature()
    {
    }

    public Creature(string name, int level = 1)
    {
        this.Name = name;
        this.Level = level;
    }

    public void Upgrade()
    {
        if (level < 10)
        {
            level++;
        }
    }

    public abstract void SayHi();

    public string Info => $"{Name} [{Level}]";

    public void Go(Direction direction)
    {
        string directionStr = direction.ToString().ToLower();
        Console.WriteLine($"{Name} goes {directionStr}.");
    }

    public void Go(Direction[] directions)
    {
        foreach (var dir in directions)
        {
            Go(dir);
        }
    }

    public abstract int Power { get; }

    public void Go(string input)
    {
        var directions = DirectionParser.Parse(input);
        Go(directions);
    }
}
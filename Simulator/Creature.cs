namespace Simulator;

public abstract class Creature
{
    private string name = "Unknown";
    private int level = 1;
    public string Name
    {
        get => name;
        init => name = Validator.Shortener(value, 3, 25, '#');
    }

    public int Level
    {
        get => level;
        init => level = Validator.Limiter(value, 1, 10);
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

    public abstract string Info { get; }

    public override string ToString()
    {
        return $"{GetType().Name.ToUpper()}: {Info}";
    }

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
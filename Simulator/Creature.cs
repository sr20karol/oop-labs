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

    public abstract string Greeting();

    public abstract string Info { get; }

    public override string ToString()
    {
        return $"{GetType().Name.ToUpper()}: {Info}";
    }

    public string Go(Direction direction) => $"{direction.ToString().ToLower()}";

    public string[] Go(Direction[] directions)
    {
        var result = new string[directions.Length];

        for (int i = 0; i < directions.Length; i++)
        {
            result[i] = Go(directions[i]);
        }
        return result;
    }

    public abstract int Power { get; }

    public string[] Go(string input)
    {
        return Go(DirectionParser.Parse(input));
    }
}
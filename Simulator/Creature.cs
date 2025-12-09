namespace Simulator;

using Simulator.Maps;

public abstract class Creature
{
    private string name = "Unknown";
    private int level = 1;
    private Map? map;
    private Point point;
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

    public Point Position => point;

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

    public void InitMapAndPosition(Map map, Point startingPosition)
    {
        if (map == null)
            throw new ArgumentNullException(nameof(map));
        if (!map.Exist(startingPosition))
            throw new ArgumentOutOfRangeException(nameof(startingPosition));
        if (this.map != null)
            throw new InvalidOperationException("Creature is already placed on the map.");

        this.map = map;
        point = startingPosition;
        map.Add(this, startingPosition);
    }

    public void Go(Direction direction)
    {
        if (map is null)
            return;

        Point nextPoint = map.Next(point, direction);

        map.Move(this, point, nextPoint);

        point = nextPoint;
    }

    //public string[] Go(List<Direction> directions)
    //{
    //    var result = new string[directions.Count];

    //    for (int i = 0; i < directions.Count; i++)
    //    {
    //        result[i] = Go(directions[i]);
    //    }
    //    return result;
    //}

    public abstract int Power { get; }

    //public string[] Go(string input)
    //{
    //    List<Direction> dirs = DirectionParser.Parse(input);
    //    return Go(dirs);
    //}
}
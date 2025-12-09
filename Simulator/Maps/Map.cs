using Simulator;

/// <summary>
/// Map of points.
/// </summary>
public abstract class Map
{

    public readonly int SizeX;
    public readonly int SizeY;
    private readonly Rectangle area;
    private readonly Dictionary<Point, List<Creature>> creatures = new();
    protected Map(int sizeX, int sizeY)
    {
        if (sizeX < 5)
            throw new ArgumentOutOfRangeException(nameof(sizeX), "Size must be greater than 5");
        if (sizeY < 5)
            throw new ArgumentOutOfRangeException(nameof(sizeY), "Size must be greater than 5");

        SizeX = sizeX;
        SizeY = sizeY;
        area = new Rectangle(0, 0, SizeX - 1, SizeY - 1);
    }
    /// <summary>
    /// Check if give point belongs to the map.
    /// </summary>
    /// <param name="p">Point to check.</param>
    /// <returns></returns>
    public virtual bool Exist(Point p)
    {
        return area.Contains(p);
    }

    public void Add(Creature c, Point p)
    {
        if (!creatures.TryGetValue(p, out var list))
        {
            list = new List<Creature>();
            creatures[p] = list;
        }
        list.Add(c);
    }

    public void Remove(Creature c, Point p)
    {
        if (creatures.TryGetValue(p, out var list))
        {
            list.Remove(c);
            if (list.Count == 0)
                creatures.Remove(p);
        }
    }

    public void Move(Creature c, Point from, Point to)
    {
        Remove(c, from);
        Add(c, to);
    }

    public IEnumerable<Creature> At(Point p)
    {
        if (creatures.TryGetValue(p, out var list))
            return list;
        return Array.Empty<Creature>();
    }

    public IEnumerable<Creature> At(int x, int y)
    => At(new Point(x, y));



    /// <summary>
    /// Next position to the point in a given direction.
    /// </summary>
    /// <param name="p">Starting point.</param>
    /// <param name="d">Direction.</param>
    /// <returns>Next point.</returns>
    public abstract Point Next(Point p, Direction d);

    /// <summary>
    /// Next diagonal position to the point in a given direction
    /// rotated 45 degrees clockwise.
    /// </summary>
    /// <param name="p">Starting point.</param>
    /// <param name="d">Direction.</param>
    /// <returns>Next point.</returns>
    public abstract Point NextDiagonal(Point p, Direction d);
}
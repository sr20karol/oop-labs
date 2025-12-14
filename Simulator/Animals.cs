namespace Simulator;

using Simulator.Maps;

public class Animals : Imappable
{
    private string description = "Unknown";
    protected Map? map;
    protected Point point;
    public required string Description
    {
        get => description;
        init
        {
            if (value == null)
            {
                return;
            }

            var trimmed = value.Trim();

            if (trimmed.Length > 15)
            {
                trimmed = trimmed.Substring(0, 15).TrimEnd();
            }

            if (trimmed.Length < 3)
            {
                trimmed = trimmed.PadRight(3, '#');
            }

            if (char.IsLower(trimmed[0]))
            {
                trimmed = char.ToUpper(trimmed[0]) + trimmed.Substring(1);
            }

            description = trimmed;
        }
    }

    public uint Size { get; set; } = 3;

    public virtual string Info => $"{Description} <{Size}>";

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
            throw new InvalidOperationException("Animal is already placed on the map.");

        this.map = map;
        point = startingPosition;
        map.Add(this, startingPosition);
    }

    public virtual void Go(Direction direction)
    {
        if (map is null)
            return;

        Point nextPoint = map.Next(point, direction);

        map.Move(this, point, nextPoint);

        point = nextPoint;
    }

    public virtual char MapSymbol => 'A';
    public Point Position => point;
    public Map? Map => map;
}
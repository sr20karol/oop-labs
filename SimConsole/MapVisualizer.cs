using Simulator;
using Simulator.Maps;

namespace SimConsole;

public class MapVisualizer
{
    private readonly Map _map;

    public MapVisualizer(Map map)
    {
        _map = map;
    }

    public void Draw()
    {
        Console.Clear();

        int width = _map.SizeX;
        int height = _map.SizeY;

        DrawBorder(Box.TopLeft, Box.TopMid, Box.TopMid, Box.TopRight, width);

        for (int y = 0; y < height; y++)
        {
            DrawRow(y, width);

            if (y < height - 1)
                DrawBorder(Box.MidLeft, Box.Cross, Box.Cross, Box.MidRight, width);
        }

        DrawBorder(Box.BottomLeft, Box.BottomMid, Box.BottomMid, Box.BottomRight, width);
    }

    private void DrawBorder(char left, char mid, char cross, char right, int width)
    {
        Console.Write(left);
        for (int x = 0; x < width; x++)
        {
            Console.Write(new string(Box.Horizontal, 3));
            if (x < width - 1)
                Console.Write(cross);
        }
        Console.WriteLine(right);
    }

    private char GetCellSymbol(int x, int y)
    {
        var creatures = _map.At(x, y).ToList();
        if (creatures.Count == 1) return creatures[0].MapSymbol;
        if (creatures.Count > 1) return 'X';
        return ' ';
    }

    private void DrawRow(int y, int width)
    {
        Console.Write(Box.Vertical);
        for (int x = 0; x < width; x++)
        {
            Console.Write($" {GetCellSymbol(x, y)} {Box.Vertical}");
        }
        Console.WriteLine();
    }
}

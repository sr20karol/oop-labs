using Simulator;
using System;
using System.Drawing;
using System.Linq;

namespace SimConsole;

internal class LogVisualizer
{
    private readonly SimulationLog _log;

    public LogVisualizer(SimulationLog log)
    {
        _log = log ?? throw new ArgumentNullException(nameof(log));
    }

    /// <summary>
    /// Rysuje mapę w podanej turze (turnIndex).
    /// </summary>
    public void Draw(int turnIndex)
    {
        Console.Clear();

        if (turnIndex < 0 || turnIndex >= _log.TurnLogs.Count)
        {
            Console.WriteLine("Nieprawidłowy indeks tury.");
            return;
        }



        var turn = _log.TurnLogs[turnIndex];
        int width = _log.SizeX;
        int height = _log.SizeY;

        DrawBorder(Box.TopLeft, Box.TopMid, Box.TopMid, Box.TopRight, width);

        for (int y = 0; y < height; y++)
        {
            DrawRow(y, width, turn.Symbols);

            if (y < height - 1)
                DrawBorder(Box.MidLeft, Box.Cross, Box.Cross, Box.MidRight, width);
        }

        DrawBorder(Box.BottomLeft, Box.BottomMid, Box.BottomMid, Box.BottomRight, width);

        Console.WriteLine($"\nTura {turnIndex}: {turn.Mappable} wykonał ruch {turn.Move}");
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

    private void DrawRow(int y, int width, Dictionary<Point, char> symbols)
    {
        Console.Write(Box.Vertical);
        for (int x = 0; x < width; x++)
        {
            char c = ' ';
            if (symbols.TryGetValue(new Point(x, y), out var symbol))
            {
                c = symbol;
            }
            Console.Write($" {c} {Box.Vertical}");
        }
        Console.WriteLine();
    }


}

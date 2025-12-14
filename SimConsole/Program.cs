using Simulator;
using Simulator.Maps;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace SimConsole;

class Program
{
    static void Main()
    {

        Console.OutputEncoding = Encoding.UTF8;

        SmallSquareMap map = new SmallSquareMap(5);

        List<Imappable> creatures = new()
        {
            new Orc("Gorbag"),
            new Elf("Elandor")
        };

        List<Point> points = new()
        {
            new Point(2, 2),
            new Point(3, 1)
        };

        string moves = "dlrludl";

        Simulation simulation = new Simulation(map, creatures, points, moves);
        MapVisualizer visualizer = new MapVisualizer(simulation.Map);

        Console.WriteLine("Initial map:");
        visualizer.Draw();

        while (!simulation.Finished)
        {
            simulation.Turn();
            Console.WriteLine();
            visualizer.Draw();
            System.Threading.Thread.Sleep(500);
        }

        Console.WriteLine("Simulation finished.");
    }
}

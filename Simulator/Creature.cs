using System;
using System.Reflection.Emit;
using System.Xml.Linq;

namespace Simulator;

internal class Creature
{
    public string Name { get; set; }
    public int Level { get; set; }
    public Creature()
    {
    }

    public Creature(string name, int level = 1)
    {
        this.Name = name;
        this.Level = level;
    }

    public void SayHi()
    {
        Console.WriteLine($"Hi, I'm {Name}, my level is {Level}.");
    }

    public string Info => $"{Name} [{Level}]";
}
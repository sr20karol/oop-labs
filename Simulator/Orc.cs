namespace Simulator;

public class Orc : Creature
{
    private int rage = 1;
    private int huntCounter = 0;

    public int Rage
    {
        get => rage;
        init
        {
            if (value < 0) rage = 0;
            else if (value > 10) rage = 10;
            else rage = value;
        }
    }

    public void Hunt()
    {
        Console.WriteLine($"{Name} is hunting.");
        huntCounter++;

        if (huntCounter % 2 == 0 && rage < 10)
        {
            rage++;
            Console.WriteLine($"{Name}'s rage increased to {rage}!");
        }
    }

    public override int Power => 7 * Level + 3 * Rage;

    public Orc(string name, int level = 1, int rage = 1)
        : base(name, level)
    {
        Rage = rage;
    }

    public Orc() : base("Unknown", 1)
    {
        Rage = 1;
    }

    public override void SayHi() =>
        Console.WriteLine($"Hi, I'm {Name}, my level is {Level}, my rage is {Rage}.");
}
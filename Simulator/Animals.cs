using System;

namespace Simulator;

public class Animals
{
    private string description = "Unknown";

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

    public string Info => $"{Description} <{Size}>";
}
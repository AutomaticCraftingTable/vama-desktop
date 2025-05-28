using System;

namespace VamaDesktop.Utils;

public enum ConsoleColor
{
    Black = 30,
    Red = 31,
    Green = 32,
    Yellow = 33,
    Blue = 34,
    Magenta = 35,
    Cyan = 36,
    White = 37,
    BrightBlack = 90,
    BrightRed = 91,
    BrightGreen = 92,
    BrightYellow = 93,
    BrightBlue = 94,
    BrightMagenta = 95,
    BrightCyan = 96,
    BrightWhite = 97
}

public static class ConsoleExtensions
{
    public static void Print(this ConsoleColor color, object? obj)
    {
        Console.WriteLine($"\x1b[{(int)color}m{obj}\x1b[0m");
    }
}

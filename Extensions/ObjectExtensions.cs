using System;

namespace VamaDesktop.Extensions;
public enum Colors
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

public static class ObjectExtensions
{
    public static string ToStringColor(this object obj, Colors color)
    {
        return $"\x1b[{(int)color}m{obj}\x1b[0m";
    }
    
    public static void PrintWithColor(this object obj, Colors color)
    {
        Console.WriteLine($"\x1b[{(int)color}m{obj}\x1b[0m");
    }

}
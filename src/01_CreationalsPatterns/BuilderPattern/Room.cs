using System;
using System.Collections.Generic;

namespace BuilderPattern;

public class Room
{
    public int Width { get; private set; }
    public int Height { get; private set; }
    public List<Wall> Walls { get; private set; }
    public Ceiling Ceiling { get; private set; }
    
    public Room(int width, int height, List<Wall> walls, Ceiling ceiling)
    {
        Width = width;
        Height = height;
        Walls = walls;
        Ceiling = ceiling;        
    }

    public override string ToString()
    {
        return $"Room [Width: {Width}, Height: {Height}, Walls: {Walls.Count}, Ceiling: {Ceiling}, \n\r Walls: {string.Join("\n\r\t", Walls)}]";
    }
}

public class Wall
{    
    public int Width { get; private set; }
    public int Height { get; private set; }
    public string Color { get; private set; }
    public WallPosition Position { get; private set; }

    public Wall(string color, int width, int height, WallPosition position)
    {
        Color = color;
        Width = width;
        Height = height;
        Position = position;
    }

    public override string ToString()
    {
        return $"Wall [Color: {Color}, Width: {Width}, Height: {Height}, Position: {Position}]";
    }
}

// Nowa klasa reprezentująca sufit
public class Ceiling
{
    public int Width { get; private set; }
    public int Height { get; private set; }
    public string Color { get; private set; }

    public Ceiling(int width, int height)
    {
        Width = width;
        Height = height;
    }

    public override string ToString()
    {
        return $"Ceiling [Width: {Width}, Height: {Height}]";
    }
}


[Flags]
public enum WallPosition
{
    None = 0,
    North = 1 << 0,
    East = 1 << 1,
    South = 1 << 2,
    West = 1 << 3
}
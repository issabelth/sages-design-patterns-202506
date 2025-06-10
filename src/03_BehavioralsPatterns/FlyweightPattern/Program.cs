using System;
using System.Collections.Generic;

Console.WriteLine("Hello Flyweight Pattern!");

PointService pointService = new PointService();

var points = pointService.GetAll();

foreach (var point in points)
{
    point.Draw();
}

public class Point
{
    public int X { get; } // 4 bytes
    public int Y { get; } // 4 bytes
    public PointType PointType { get; }
    public byte[] Icon { get; }

    public Point(int x, int y, PointType type, byte[] icon)
    {
        this.X = x;
        this.Y = y;
        this.Icon = icon;
    }

    public void Draw() => Console.WriteLine($"{PointType} at ({X},{Y}) {Icon.Length} bytes");
}



public enum PointType
{
    Cafe,
    Hotel
}


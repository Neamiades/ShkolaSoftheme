﻿using static System.Console;
using System.Collections.Generic;

namespace ConsoleShapeDesc
{
    class ShapeDescriptor
    {
        private readonly List<Point> _points;

        public ShapeDescriptor(Point p)
        {
            _points = new List<Point> { p };
            ShapeType = "Point";
        }

        public ShapeDescriptor(Point p1, Point p2)
        {
            _points = new List<Point> { p1, p2 };
            ShapeType = "Line";
        }

        public ShapeDescriptor(Point p1, Point p2, Point p3)
        {
            _points = new List<Point> { p1, p2, p3 };
            ShapeType = "Triangle";
        }

        public ShapeDescriptor(Point p1, Point p2, Point p3, Point p4)
        {
            _points = new List<Point> { p1, p2, p3, p4 };
            ShapeType = "Rectangle";
        }

        public string ShapeType { get; }

        public void TellAbout()
        {
            Write($"I'm a {ShapeType} and i have these points: ");
            foreach (var p in _points)
            {
                Write($"(X:{p.X}, Y:{p.Y}) ");
            }
            WriteLine();
        }
    }

    class Point
    {
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
        public int X { get; set; }
        public int Y { get; set; }
    }

    class Program
    {
        static void Main()
        {
            var shapes = new[]
            {
                new ShapeDescriptor(new Point(1, 1)),
                new ShapeDescriptor(new Point(1, 1), new Point(2, 2)),
                new ShapeDescriptor(new Point(1, 1), new Point(2, 2), new Point(3, 9)),
                new ShapeDescriptor(new Point(1, 1), new Point(2, 2), new Point(3, 9), new Point(0, 0))
            };
            foreach(var shape in shapes)
            {
                shape.TellAbout();
            }
        }
    }
}

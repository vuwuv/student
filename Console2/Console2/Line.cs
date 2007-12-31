using System;

class Line
{
    private double a;
    private double c;

    public Line(double a, double c)
    {
        this.a = a;
        this.c = c;
    }

    public Line(Point2 a, Point2 b)
    {
        this.a = Math.Abs(a.Y - b.Y) / Math.Abs(a.X - b.X);
        this.c = a.X - this.a * a.Y;
    }

    public static Point2 Intersection(Line a, Line b)
    {
        double x = 0;
        double y = 0;

        x = (b.c - a.c) / (a.a - b.a);
        y = a.a * x + a.c;

        return new Point2(x, y);
    }
}
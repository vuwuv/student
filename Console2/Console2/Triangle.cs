using System;
class Triangle
{
    private Point2 a;
    private Point2 b;
    private Point2 c;

    private void InitTriangle(Point2 a, Point2 b, Point2 c)
    {
        this.a = a;
        this.b = b;
        this.c = c;
    }

    /* public Triangle(Point2 a, Point2 b, double x, double y)
    {
        Point2 c = a;
        InitTriangle(a, b, c);
    }
    */

    public Triangle(Point2 a, Point2 b, Point2 c)
    {
        InitTriangle(a, b, c);
    }

    public Point2 A
    {
        get { return this.a; }
        set { this.a = value; }
    }

    public Point2 B
    {
        get { return this.b; }
        set { this.b = value; }
    }

    public Point2 C
    {
        get { return this.c; }
        set { this.c = value; }
    }

    private double[] Sides()
    {
        double[] x = new double[3];

        x[0] = Point2.Distance(this.A, this.B);
        x[1] = Point2.Distance(this.A, this.C);
        x[2] = Point2.Distance(this.B, this.C);

        return x;

    }
    public double Square()
    {

        double p = this.Perimeter() / 2;
        double[] x = this.Sides();

        return Math.Sqrt(p * (p - x[0]) * (p - x[1]) * (p - x[2]));
    }

    public double Perimeter()
    {
        double P = 0;
        double[] x = this.Sides();

        return P = x[0] + x[1] + x[2];
    }

    public Point2 Median()
    {
        Point2 k = new Point2(this.b.X + (this.c.X - this.b.X) / 2, this.b.Y + (this.c.Y - this.b.Y) / 2);
        Point2 l = new Point2(this.a.X + (this.b.X - this.a.X) / 2, this.a.Y + (this.b.Y - this.a.Y) / 2);

        return Line.Intersection(new Line(this.a, k), new Line(this.c, l));
    }
}
using System;
class Point2
{
    private double x;
    private double y;

    public double X
    {
        get
        {
            return this.x;
        }
        set
        {
            this.x = value;
        }
    }
    public double Y
    {
        get
        {
            return this.y;
        }
        set
        {
            this.y = value;
        }
    }

    public Point2(double x, double y)
    {
        this.x = x;
        this.y = y;
    }

    public double DistanceToZero
    {
        get
        {
            return Math.Sqrt(x * x + y * y);
        }
    }
    public double DistanceToZeroM()
    {
        return Math.Sqrt(x * x + y * y);
    }
    public static double DistanceToZeroM(double x, double y)
    {
        return Math.Sqrt(x * x + y * y);
    }
    public static double DistanceToZeroM(Point2 P)
    {
        return Math.Sqrt(P.x * P.x + P.y * P.y);
    }
    public static double Distance(Point2 A, Point2 B)
    {
        return Math.Sqrt(Math.Pow(2, (B.x - A.x)) + Math.Pow(2, (B.y - A.y)));
    }

}
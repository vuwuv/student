using System;
public class Rectangle
{
    private double x;
    private double y;
    private double h;
    private double w;

    public Rectangle(double x, double y, double h, double w)
    {
        this.x = x;
        this.y = y;
        this.h = h;
        this.w = w;
    }

    public double MoveRectangleX
    {
        get { return this.x; }
        set { this.x = value; }
    }
    public double MoveRectangleY
    {
        get { return this.y; }
        set { this.y = value; }
    }
    public void Resize(double h, double w)
    {
        this.h = h;
        this.w = w;
    }
    public static Rectangle Min(Rectangle a, Rectangle b)
    {
        double Cx = 0;
        double Cy = 0;
        double Ch = 0;
        double Cw = 0;

        if (a.x < b.x) Cx = a.x;
        else Cx = b.x;

        if (a.y < b.y) Cy = a.y;
        else Cy = b.y;

        if ((a.x + a.w) < (b.x + b.w)) Cw = (b.x + b.w) - Cx;
        else Cw = (a.x + a.w) - Cx;

        if ((a.y + a.h) < (b.y + b.h)) Ch = (b.y + b.h) - Cy;
        else Ch = (a.y + a.h) - Cy;

        return new Rectangle(Cx, Cy, Ch, Cw);
    }

    public static Rectangle Intersection(Rectangle a, Rectangle b)
    {
        double Cx = 0;
        double Cy = 0;
        double Ch = 0;
        double Cw = 0;
        Rectangle Min = null;
        Rectangle Max = null;

        if (a.y < b.y)
        {
            Min = a;
            Max = b;
        }
        else
        {
            Min = b;
            Max = a;
        }
        if ((Min.y + Min.h) > Max.y)
        {
            if (Min.y + Min.h > Max.y + Max.h) Ch = Max.h;
            else Ch = (Min.y + Min.h) - Max.y;
            Cy = Max.y;
        }
        else throw new Exception("No intersection");

        if (a.x < b.x)
        {
            Min = a;
            Max = b;
        }
        else
        {
            Min = b;
            Max = a;
        }
        if ((Min.x + Min.w) > Max.x)
        {
            if (Min.x + Min.w > Max.x + Max.w) Cw = Max.w;
            else Cw = (Min.x + Min.w) - Max.x;
            Cx = Max.x;
        }
        else throw new Exception("No intersection");

        return new Rectangle(Cx, Cy, Ch, Cw);
    }

    public void Print()
    {
        Console.WriteLine("Rectangle(" + this.x + ", " + this.y + ", " + this.h + ", " + this.w + ")");
    }
}
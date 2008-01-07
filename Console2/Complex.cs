using System;
class Complex
{
    public double r;
    public double i;

    public Complex(double r, double i)
    {
        this.r = r;
        this.i = i;
    }

    public Complex(Complex c)
    {
        this.r = c.r;
        this.r = c.i;
    }
    public static Complex operator +(Complex z1, Complex z2)
    {
        return new Complex((z1.r + z2.r), (z1.i + z2.i));
    }
    public static Complex operator *(Complex z1, Complex z2)
    {
        return new Complex((z1.r * z2.r - z1.i * z2.i), (z1.r * z2.i + z1.i * z2.r));
    }
    public static Complex operator /(Complex z1, Complex z2)
    {
        return new Complex(((z1.r * z2.r + z1.i * z2.i) / (z2.r * z2.r + z2.i * z2.i)), ((z1.i * z2.r - z1.r * z2.i) / (z2.r * z2.r + z2.i * z2.i)));
    }
    public static Complex Add(Complex z1, Complex z2)
    {
        return z1 + z2;
    }
    public Complex Conjugate()
    {
        return new Complex(this.r, -this.i);
    }

    public static Complex Conjugate(Complex c)
    {
        return new Complex(c.r, -c.i);
    }
    public void Add(Complex z)
    {
        Complex n = this + z;
        this.r = n.r;
        this.i = n.i;
    }

}
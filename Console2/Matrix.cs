using System;
public class Matrix
{
    private double[,] matrix;

    private Matrix(double[,] matrix)
    {

        this.matrix = matrix;
    }
    private double this[int i, int j]
    {
        get { return this.matrix[i, j]; }
        set { this.matrix[i, j] = value; }
    }
    public static Matrix InputMatrix(int x, int y)
    {
        double[,] matrix = new double[x, y];

        for (int i = 0; i < x; i++)
        {
            for (int j = 0; j < y; j++)
            {
                Console.Write("Enter the element matrix[" + i + ", " + j + "]: ");
                while (!double.TryParse(Console.ReadLine(), out matrix[i, j])) Console.Write("Bad number. Try again: ");
            }
        }
        return new Matrix(matrix);
    }
    public static Matrix InputMatrix()
    {
        int x = 0;
        int y = 0;
        double[,] matrix = new double[x, y];

        Console.Write("Enter the number of elements x: ");
        while (!int.TryParse(Console.ReadLine(), out x)) Console.Write("Bad number. Try again: ");

        Console.Write("Enter the number of elements y: ");
        while (!int.TryParse(Console.ReadLine(), out y)) Console.Write("Bad number. Try again: ");

        return Matrix.InputMatrix(x, y);
    }

    public static Matrix Copy(double[,] matrix)
    {
        Matrix x = new Matrix(new double[matrix.GetLength(0), matrix.GetLength(1)]);
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                x[i, j] = matrix[i, j];
            }
        }
        return x;
    }
    public static Matrix Copy(Matrix a)
    {
        return Matrix.Copy(a.matrix);
    }
    public static Matrix operator +(Matrix a, Matrix b)
    {
        Matrix c = new Matrix(new double[a.matrix.GetLength(0), a.matrix.GetLength(1)]);

        if (a.matrix.GetLength(0) == b.matrix.GetLength(0) && a.matrix.GetLength(1) == b.matrix.GetLength(1))
        {
            for (int i = 0; i < a.matrix.GetLength(0); i++)
            {
                for (int j = 0; j < a.matrix.GetLength(1); j++)
                {
                    c.matrix[i, j] = a.matrix[i, j] + b.matrix[i, j];
                }
            }
        }
        else throw new Exception("Matrices' sizes do not match");
        return c;
    }

    public static bool operator ==(Matrix a, Matrix b)
    {

        if (a.matrix.GetLength(0) == b.matrix.GetLength(0) && a.matrix.GetLength(1) == b.matrix.GetLength(1))
        {
            for (int i = 0; i < a.matrix.GetLength(0); i++)
            {
                for (int j = 0; j < a.matrix.GetLength(1); j++)
                {
                    if (a.matrix[i, j] != b.matrix[i, j]) return false;
                }
            }
        }
        else return false;
        return true;
    }

    public static bool operator !=(Matrix a, Matrix b)
    {
        return !(a == b);
    }
    public static Matrix operator *(Matrix a, Matrix b)
    {
        Matrix c = new Matrix(new double[a.matrix.GetLength(0), b.matrix.GetLength(1)]);

        if (a.matrix.GetLength(1) == b.matrix.GetLength(0))
        {
            for (int k = 0; k < b.matrix.GetLength(1); k++)
            {
                for (int i = 0; i < a.matrix.GetLength(0); i++)
                {
                    c[i, k] = 0;

                    for (int j = 0; j < b.matrix.GetLength(0); j++)
                    {
                        c[i, k] += b[j, k] * a[i, j];
                    }
                }
            }
        }
        else throw new Exception("Matrices' sizes do not match");
        return c;
    }

    public Matrix Minor(int k, int l)
    {
        if (this.matrix.GetLength(0) != this.matrix.GetLength(1)) throw new Exception("Bad matrix");

        Matrix r = new Matrix(new double[this.matrix.GetLength(0) - 1, this.matrix.GetLength(1) - 1]);

        for (int i = 0; i < this.matrix.GetLength(0); i++)
        {
            for (int j = 0; j < this.matrix.GetLength(1); j++)
            {

                int a = i;
                int b = j;

                if (j > l) b = j - 1;
                if (i > k) a = i - 1;

                if (i == k || j == l) continue;

                r[a, b] = this.matrix[i, j];
            }
        }
        return r;
    }

    public double Determinant()
    {
        if (this.matrix.GetLength(0) == 1) return this.matrix[0, 0];

        double sum = 0;

        for (int i = 0; i < this.matrix.GetLength(0); i++)
        {
            sum += Math.Pow(-1, i) * this.matrix[0, i] * this.Minor(0, i).Determinant();
        }

        return sum;
    }
    public Matrix DivideBy(double x)
    {
        Matrix a = new Matrix(new double[this.matrix.GetLength(0), this.matrix.GetLength(1)]);
        for (int i = 0; i < this.matrix.GetLength(0); i++)
        {
            for (int j = 0; j < this.matrix.GetLength(1); j++)
            {
                a[i, j] = this.matrix[i, j] / x;
            }
        }
        return a;
    }

    public Matrix Invertible()
    {
        return this.DivideBy(this.Determinant());
    }

    public static Matrix IndentityMatrix(int x)
    {
        Matrix a = new Matrix(new double[x, x]);

        for (int i = 0; i < x; i++)
        {
            for (int j = 0; j < x; j++)
            {
                if (i == j) a[i, j] = 1;
                else a[i, j] = 0;
            }
        }
        return a;
    }

    public Matrix Transpose()
    {
        Matrix a = new Matrix(new double[this.matrix.GetLength(1), this.matrix.GetLength(0)]);

        for (int i = 0; i < this.matrix.GetLength(0); i++)
        {
            for (int j = 0; j < this.matrix.GetLength(1); j++)
            {
                a[j, i] = this.matrix[i, j];
            }
        }
        return a;
    }

    public static Matrix Snake(int x, int y)
    {
        Matrix a = new Matrix(new double[x, y]);

        int i = 0;
        int j = 0;
        int k = 1;
        bool s = true;

        while (i < x && j < y)
        {
            a[i, j] = k;

            if (s)
            {
                if (i == x - 1)
                {
                    j++;
                    s = false;
                }
                else if (j == 0)
                {
                    i++;
                    s = false;
                }
                else
                {
                    i++;
                    j--;
                }
            }
            else
            {
                if (j == y - 1)
                {
                    i++;
                    s = true;
                }
                else if (i == 0)
                {
                    j++;
                    s = true;
                }
                else
                {
                    i--;
                    j++;
                }
            }

            k++;
        }
        return a;
    }

    public void Print()
    {
        for (int i = 0; i < this.matrix.GetLength(0); i++)
        {
            for (int j = 0; j < this.matrix.GetLength(1); j++)
            {
                Console.Write("\t" + this.matrix[i, j]);
            }
            Console.WriteLine();
        }
    }

    public int Rank()
    {
        Matrix a = new Matrix(new double[this.matrix.GetLength(0), this.matrix.GetLength(1)]);

        return 0;
    }
}
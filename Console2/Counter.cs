using System;
public class Counter
{
    private int x;

    public Counter(int x)
    {
        this.x = x;
    }

    public Counter()
    {
        this.x = 0;
    }

    public int State
    {
        get { return this.x; }
    }

    public void Inc()
    {
        this.x++;
    }
    public void Dec()
    {
        this.x--;
    }
}
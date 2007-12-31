using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Set<T>
{
    private Dictionary<T, int> set;

    public Set()
    {
        this.set = new Dictionary<T, int>();
    }

    public Set(T[] x)
    {
        this.set = new Dictionary<T, int>();
        this.Add(x);
    }

    public void Add(IEnumerable<T> x)
    {
        foreach (T key in x)
        {
            this.set[key] = 1;
        }
    }

    public void Add(T x)
    {
        this.set[x] = 1;
    }

    public static Set<T> Copy(Set<T> a)
    {
        Set<T> b = new Set<T>();

        foreach (T key in a.set.Keys)
        {
            b.Add(key);
        }
        return b;
    }

    public void Remove(IEnumerable<T> x)
    {
        foreach (T key in x)
        {
            this.set.Remove(key);
        }
    }

    public void Remove(T x)
    {
        this.set.Remove(x);
    }

    public static Set<T> Intersection(Set<T> a, Set<T> b)
    {
        Set<T> c = new Set<T>();

        foreach (T keya in a.set.Keys)
        {
            foreach (T keyb in b.set.Keys)
            {
                if (keya.Equals(keyb)) c.Add(keya);
            }
        }
        return c;
    }

    public static Set<T> Union(Set<T> a, Set<T> b)
    {
        Set<T> c = new Set<T>();

        foreach (T key in a.set.Keys)
        {
            c.Add(key);
        }

        foreach (T key in b.set.Keys)
        {
            c.Add(key);
        }

        c.Add(a.set.Keys);
        c.Add(b.set.Keys);

        return c;
    }

    public static Set<T> Minus(Set<T> a, Set<T> b)
    {
        Set<T> c = Set<T>.Copy(a);

        foreach (T keya in a.set.Keys)
        {
            foreach (T keyb in b.set.Keys)
            {
                if (keya.Equals(keyb)) c.Remove(keya);
            }
        }
        return c;
    }
}
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class SubjectIndex
{
    private Dictionary<string, List<int>> index;

    public SubjectIndex()
    {
        this.index = new Dictionary<string, List<int>>();
    }

    public static SubjectIndex ConsoleInput()
    {
        SubjectIndex a = new SubjectIndex();
        Console.WriteLine("Print numbers of elements:");
        int x = int.Parse(Console.ReadLine());


        for (int i = 0; i < x; i++)
        {
            Console.WriteLine("Print subject: ");
            string key = Console.ReadLine();
            Console.WriteLine("Print numbers of pages:");

            List<int> pages = new List<int>();
            int y = int.Parse(Console.ReadLine());

            for (int j = 0; j < y; j++)
            {
                Console.WriteLine("Print number of page:");
                int page = int.Parse(Console.ReadLine());
                pages.Add(page);
            }
            a.index[key] = pages;
        }

        return a;
    }

    public static SubjectIndex FileInput(string filename)
    {
        SubjectIndex list = new SubjectIndex();
        List<string> text = new List<string>();

        StreamReader f = new StreamReader(filename);

        string s;

        while ((s = f.ReadLine()) != null)
            text.Add(s);

        foreach (string a in text)
        {
            string[] b = a.Split('\t');
            List<int> pages = new List<int>();
            string key = b[0];

            for (int i = 1; i < b.GetLength(0); i++)
            {
                int page = int.Parse(b[i]);
                pages.Add(page);
            }

            list.index[key] = pages;
        }
        return list;
    }
    public void FileOutput(string filename)
    {
        StreamWriter f = new StreamWriter(filename);

        foreach (string key in this.index.Keys)
        {
            f.WriteLine(key + '\t' + string.Join<int>("\t", this.index[key]));
        }
        f.Close();
    }

    public void ConsoleOutput(string keyname = null)
    {
        if (keyname == null)
        {
            foreach (string key in this.index.Keys) Console.WriteLine(key + ": " + string.Join<int>(", ", this.index[key]));
        }
        else Console.WriteLine(keyname + ": " + string.Join<int>(", ", this.index[keyname]));
    }

    public int[] GetPages(string keyname)
    {
        if (this.index[keyname] == null) return new int[] { };
        else return this.index[keyname].ToArray();
    }

    public void RemoveElement(string keyname)
    {
        this.index.Remove(keyname);
    }

}
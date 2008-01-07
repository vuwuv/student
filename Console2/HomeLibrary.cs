using System;
using System.Collections;
using System.Collections.Generic;
class HomeLibrary
{
    public class Book
    {
        private string author;
        private int issueyear;
        private string category;

        public Book(string author, int issueyear, string category)
        {
            this.author = author;
            this.issueyear = issueyear;
            this.category = category;
        }

        public string Author
        {
            get { return this.author; }
            set { this.author = value; }
        }
        public int Issueyear
        {
            get { return this.issueyear; }
            set { this.issueyear = value; }
        }
        public string Category
        {
            get { return this.category; }
            set { this.category = value; }
        }
        public int CompareByAutor(Book x, Book y)
        {
            return x.author.CompareTo(y.author);
        }
        public int CompearByIssueYear(Book x, Book y)
        {
            if (x.issueyear < y.issueyear) return -1;
            else if (x.issueyear == y.issueyear) return 0;
            else return 1;
        }
    }

    public void AddBook(Book a)
    {
        this.books.Add(a);
    }

    public void RemoveBook(Book a)
    {
        this.books.Remove(a);
    }

    public List<Book> this[string author]
    {
        get
        {
            return this.SearchByAutor(author);
        }
        set
        {
            foreach (Book a in this.books)
                if (a.Author == author) this.RemoveBook(a);
            /* for (int i = 0; i <= value.Count; i++)
             {
                 this.AddBook(value[i]);
             }
             */
            foreach (Book a in value) this.AddBook(a);
        }
    }

    public List<Book> SearchByAutor(string autor)
    {
        List<Book> A = new List<Book>();
        foreach (Book a in books)
            if (a.Author == autor) A.Add(a);
        return A;
    }
    public List<Book> SeachByIssueyear(int issueyear)
    {
        List<Book> A = new List<Book>();
        foreach (Book a in books)
            if (a.Issueyear == issueyear) A.Add(a);
        return A;
    }

    public List<Book> SearchByCategory(string category)
    {
        List<Book> A = new List<Book>();
        foreach (Book a in books)
            if (a.Author == category) A.Add(a);
        return A;
    }
    private Book this[int i, string a]
    {
        get { return this.books[i]; }
        set { this.books[i] = value; }
    }

    private List<Book> books;

    public HomeLibrary(List<Book> books)
    {
        this.books = books;
    }

}

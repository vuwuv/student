using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    class Store
    {
        public class Product
        {
            public string Name;
            public string Shop;
            public double Price;
            public Product(string name, string shop, double price)
            {
                this.Name = name;
                this.Shop = shop;
                this.Price = price;
            }

            public static void Print(Product a)
            {
                Console.WriteLine(a.Name + '\t' + a.Shop + '\t' + a.Price);
            }

            public static double operator +(Product a, Product b)
            {
                return a.Price + b.Price;
            }

        }

        public Product[] Stuff;

        public Store(int size)
        {
            this.Stuff = new Product[size];
        }

        public Product this[int i]
        {
            get { return Stuff[i]; }
            set { this.Stuff[i] = value; }
        }

        public void OutputProduct()
        {
            Dictionary<string, Product> stuff = this.Stuff.ToDictionary(product => product.Name);
            Product a = stuff[Console.ReadLine()];
            //foreach (KeyValuePair<string, Product> ab in stuff)
            if (a == null) Console.WriteLine("No Product");
            else Product.Print(a);
        }

        public Product[] SortByName()
        {
            Product[] a = this.Stuff.OrderBy(product => product.Name).ToArray();
            return a;
        }

        public Product[] SortByPrice()
        {
            Product[] a = this.Stuff.OrderBy(product => product.Price).ToArray();
            return a;
        }

        public Product[] SortByShop()
        {
            Product[] a = this.Stuff.OrderBy(product => product.Shop).ToArray();
            return a;
        }

    }
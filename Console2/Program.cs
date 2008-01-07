using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console2
{
    class LinkedList<T> : IEnumerable<T>
    {
        private Block first;
        private Block last;
        private int count = 0;

        public LinkedList(IEnumerable<T> list)
        {
            foreach (T element in list) this.Add(element);
        }

        class Enumerator : IEnumerator<T>
        {
            private Block first;
            private Block current;

            public Enumerator(Block first)
            {
                this.first = first;
                this.current = null;
            }
            object IEnumerator.Current
            {
                get
                {
                    return current.Data;
                }
            }

            T IEnumerator<T>.Current
            {
                get
                {
                    return current.Data;
                }
            }

            void IDisposable.Dispose()
            {
              
            }

            bool IEnumerator.MoveNext()
            {
                if(current == null)
                {
                    current = first;
                    return current != null;
                }
                if (current.Next == null) return false;
                current = current.Next;
                return true;
            }

            void IEnumerator.Reset()
            {
                current = null;
            }
        }
        class Block
        {
            public T Data;
            public Block Next;          

            public Block(T Data, Block Next)
            {
                this.Data = Data;
                this.Next = Next;
            }
            
            public Block(T Data)
            {
                this.Data = Data;
                this.Next = null;
            }
        }

        private Block GetBlock(int i)
        {
            if (this.count <= i) throw new Exception("Out of bounds");

            int j = 0;
            Block block = this.first;
            while (j < i)
            {
                j++;
                block = block.Next;
            }
            return block;
        }

        public T this[int i]
        {
            get
            {
                return this.GetBlock(i).Data; 
            }
            set
            {
                this.GetBlock(i).Data = value;
            }
        }



        public void Add(T data)
        {
            Block newBlock = new Block(data);
            this.count += 1;
            if (this.last != null)
            {
                this.last.Next = newBlock;
                this.last = newBlock;
            }
            else
            {
                this.first = newBlock;
                this.last = newBlock;
            }
        }

       private Enumerator GetEnumerator()
        {
            return new Enumerator(first);
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator() ;
        }

        public void InsertRange(int index, IEnumerable<T> range)
        {
            if (index < 0) throw new Exception("Bad index");
            if (index > count) throw new Exception("Out of bounds");

            Block before = (index > 0) ? this.GetBlock(index - 1) : null;
            Block after = (index == this.count) ? null: (before == null) ? this.GetBlock(index) : before.Next;

            foreach(T data in range)
            {
                Block a = new Block(data);
                if (before == null) this.first = a;
                else before.Next = a;
                before = a;
                this.count ++;
            }

            if (after == null) this.last = before;
            before.Next = after;
        }

        public void RemoveRange(int index, int count)
        {
            if (index < 0) throw new Exception("Bad index");
            if (count > this.count - index) throw new Exception("Out of bounds");

            Block after = (index + count == this.count) ? null : GetBlock(index + count);
            Block before = null;

            if (index == 0)
            {
                this.first = after;
            }
            else
            {
                before = this.GetBlock(index - 1);
                before.Next = after;
            }

            if (index + count == this.count) this.last = before;
            this.count -= count;
        }
        public void RemoveAll(Predicate<T> match)
        {
            if (this.first == null) return;

            Block current = this.first;
            this.first = null;
            Block previous = null;
            this.count = 0;

            do
            {
                if(!match.Invoke(current.Data))
                {
                    if (previous != null) previous.Next = current;
                    if (first == null) first = current;
                    previous = current;  
                    this.count++;
                }
                current = current.Next;
            }
            while (current != null);

            if(previous != null) previous.Next = null;
            this.last = previous;
        }
    }




   



    class Program
    {
        static void Main(string[] args)
        {
            LinkedList<int> a = new LinkedList<int>(new int[] {1, 5, 7, 6, 5, 6, 8 });
            //a.RemoveRange(6, 3);
            a.RemoveAll(element => element >= 1);
            foreach(int e in a)
            {
                Console.WriteLine(e);
            }

            Console.ReadLine();

            /* SubjectIndex.ConsoleInput().FileOutput(@"C:\Users\admin\Desktop\index.txt");
            SubjectIndex a = SubjectIndex.FileInput(@"C:\Users\admin\Desktop\index.txt");
            a.ConsoleOutput();
            Console.ReadLine();*/
        }






       /* static int[] EnterArray(string Welcome)
        {
            Console.WriteLine(Welcome);
            // Array size input. 
            int a;
            Console.Write("Enter the number of elements: ");
            while (!int.TryParse(Console.ReadLine(), out a)) Console.Write("Bad number. Try again: ");

            // Array input
            int[] Massiv = new int[a];

            for (int i = 0; i < a; i++)
            {
                Console.Write("Enter element[" + i + "]: ");
                while (!int.TryParse(Console.ReadLine(), out Massiv[i])) Console.Write("Bad number. Ty again: ");
            }
            return Massiv;
        }
       
        static void Main(string[] args)
        {
            Rectangle A = new Rectangle(1, 1, 1, 1);
            Rectangle B = new Rectangle(2, 3, 1, 1);
            Rectangle C = Rectangle.Intersection(A, B);
            C.Print();
            Console.ReadLine();
            

            //Matrix A = Matrix.InputMatrix(3, 3);

           /* Matrix C = Matrix.InputMatrix();
            Console.WriteLine(C.Determinant());
            Console.ReadLine();
            Matrix B = Matrix.Snake(3, 3);
            Console.WriteLine(B.Determinant());
            B.Invertible().Print();
            Console.ReadLine();
            

    

           /* int[] array = Program.EnterArray("Enter array");

            //Calculate sum and average
            int sum = 0;

            for(int i = 0; i < array.Length; i++)
            {
                sum += array[i];
            }

            double Average = (double)sum / array.Length;

            Console.WriteLine("Sum = " + sum);
            Console.WriteLine("Average = " + Average);
            Console.ReadLine();
            

        



           /* Point2 a = new Point2(1, 1);
            Complex z1 = new Complex(1, 2);
            Complex z2 = new Complex(3, 4);
            Complex z3 = z1 + z2;
            z3 = Complex.Add(z1, z2);
            z2.Add(z1);
            Complex Cz1 = z1.Conjugate();
            Complex Cr = Complex.Conjugate(z1);
            Complex D1 = new Complex(3, 4);
            Complex D2 = new Complex(D1);

            z2 = null;
            z2.Add(z1);

            Console.WriteLine("Distance to zero" + " = " + a.DistanceToZero);
            Console.WriteLine("Distans to zero" + " = " + Point2.DistanceToZeroM(a));
            Console.ReadLine();
        }*/
    }
}

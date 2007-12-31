using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                if (current == null)
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
            public Block Previous;

            public Block(T Data, Block Next, Block Previous)
            {
                this.Data = Data;
                this.Next = Next;
                this.Previous = Previous;
            }

            public Block(T Data)
            {
                this.Data = Data;
                this.Next = null;
                this.Previous = null;
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
                newBlock.Previous = this.last;
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
            return this.GetEnumerator();
        }
    }
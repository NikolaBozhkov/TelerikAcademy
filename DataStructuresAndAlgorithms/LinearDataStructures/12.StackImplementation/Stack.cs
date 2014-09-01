namespace StackImplementation
{
    public class Stack<T>
    {
        private const int InitialCapacity = 4;

        private T[] elements = new T[InitialCapacity];
        private int index = 0;

        public int Count
        {
            get
            {
                return index;
            }
        }

        public void Push(T value)
        {
            this.elements[this.index] = value;
            this.index++;

            if (this.index == this.Capacity())
            {
                this.Resize();
            }
        }

        public T Pop()
        {
            index--;
            return this.elements[this.index];
        }

        private void Resize()
        {
            var resized = new T[this.Capacity() * 2];
            for (int i = 0; i < this.index; i++)
            {
                resized[i] = this.elements[i];
            }

            this.elements = resized;
        }

        private int Capacity()
        {
            return this.elements.Length;
        }
    }
}

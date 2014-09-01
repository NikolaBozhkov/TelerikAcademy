namespace ImplementationOfQueue
{
    public class Queue<T>
    {
        private int count = 0;

        private QueueItem<T> FirstItem { get; set; }
        private QueueItem<T> LastItem { get; set; }

        public int Count
        {
            get
            {
                return this.count; 
            }
            private set
            {
                this.count = value;
            }
        }

        public void Enqueue(T value)
        {
            var newItem = new QueueItem<T>()
            {
                Value = value
            };

            if (this.FirstItem == null && this.LastItem == null)
            {
                this.FirstItem = newItem;
                this.LastItem = newItem;
            }
            else
            {
                this.LastItem.NextItem = newItem;
                this.LastItem = newItem;
            }

            this.Count++;
        }

        public T Dequeue()
        {
            var returnValue = this.FirstItem.Value;
            this.FirstItem = this.FirstItem.NextItem;
            this.Count--;

            return returnValue;
        }
    }
}

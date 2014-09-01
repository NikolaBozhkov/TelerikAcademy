namespace ImplementationOfQueue
{
    public class QueueItem<T>
    {
        public T Value { get; set; }
        public QueueItem<T> NextItem { get; set; }
    }
}

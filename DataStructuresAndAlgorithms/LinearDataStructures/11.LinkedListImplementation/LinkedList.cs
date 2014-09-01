namespace LinkedListImplementation
{
    public class LinkedList<T>
    {
        public ListItem<T> FirstItem { get; set; }
        private ListItem<T> LastItem { get; set; }

        public void Add(T value)
        {
            var newItem = new ListItem<T>()
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
        }
    }
}

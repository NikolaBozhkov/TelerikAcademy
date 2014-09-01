namespace TreeTraversal
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Node<T>
    {
        public T Value { get; set; }

        public ICollection<Node<T>> Children { get; set; }

        public bool HasParent { get; set; }

        public Node()
        {
            this.Children = new HashSet<Node<T>>();
        }

        public Node(T value)
            : this()
        {
            this.Value = value;
        }
    }
}

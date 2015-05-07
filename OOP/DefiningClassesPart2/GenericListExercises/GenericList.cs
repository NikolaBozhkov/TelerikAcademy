using System;
using System.Text;

public class GenericList<T>
{
    // Fields
    private T[] list;
    private int index = 0;

    // Constructors
    public GenericList(int capacity)
    {
        this.list = new T[capacity];
    }

    // Properties
    public int Count
    {
        get { return this.index; }
    }

    public int Capacity
    {
        get { return this.list.Length; }
    }

    public T this[int index]
    {
        get
        {
            if (index >= 0 && index < this.list.Length)
            {
                return this.list[index];
            }
            else
            {
                throw new ArgumentOutOfRangeException(string.Format("Index {0} is invalid", index));
            }
        }

        set
        {
            if (index >= 0 && index < this.list.Length)
            {
                this.list[index] = value;
            }
            else
            {
                throw new ArgumentOutOfRangeException(string.Format("Index {0} is invalid", index));
            }
        }
    }

    // Methods
    public void Add(T item)
    {
        this.AutoGrow();
        this.list[this.index] = item;
        this.index++;
    }

    public void RemoveAt(int index)
    {
        // this is how the real list works, it checks the working index not the length
        if (index >= 0 && index <= this.index)
        {
            T[] newList = new T[this.list.Length - 1];
            Array.Copy(this.list, newList, index);
            Array.Copy(this.list, index + 1, newList, index, this.list.Length - index - 1);
            this.list = newList;
            this.index--;
        }
        else
        {
            throw new ArgumentOutOfRangeException(string.Format("Index {0} is invalid", index));
        }
    }

    public void Insert(int index, T item)
    {
        if (index >= 0 && index <= this.index)
        {
            T[] newList = new T[this.list.Length + 1];
            Array.Copy(this.list, newList, index);
            newList[index] = item;
            Array.Copy(this.list, index, newList, index + 1, this.list.Length - index);
            this.list = newList;
            this.index++;
        }
        else
        {
            throw new ArgumentOutOfRangeException(string.Format("Index {0} is invalid", index));
        }
    }

    public void Clear()
    {
        this.list = new T[0];
    }

    public int IndexOf(T item)
    {
        for (int index = 0; index < this.list.Length; index++)
        {
            if (this.list[index].Equals(item))
            {
                return index;
            }
        }

        return -1;
    }

    public override string ToString()
    {
        return string.Format("[{0}]", string.Join(", ", this.list));
    }

    private void AutoGrow()
    {
        if (this.index == this.list.Length)
        {
            T[] newList = new T[this.list.Length * 2];
            Array.Copy(this.list, newList, this.list.Length);
            this.list = newList;
        }
    }
}
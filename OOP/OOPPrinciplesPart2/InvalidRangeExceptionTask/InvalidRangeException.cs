namespace InvalidRangeExceptionTask
{
    using System;

    public class InvalidRangeException<T> : ApplicationException
        where T : struct, IComparable, IFormattable, IConvertible, IComparable<T>, IEquatable<T>
    {
        // The fields(properties)
        public T Start { get; private set; }

        public T End { get; private set; }

        public T Value { get; private set; }

        // Constructors
        public InvalidRangeException(T value, T start, T end)
            : this(null, value, start, end, null)
        {
        }

        public InvalidRangeException(string msg, T value, T start, T end)
            : this(msg, value, start, end, null)
        {
        }

        public InvalidRangeException(string msg, T value, T start, T end, Exception innerException)
            : base(msg, innerException)
        {
            this.Start = start;
            this.End = end;
            this.Value = value;
        }
    }
}
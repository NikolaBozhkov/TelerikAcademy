namespace BitArray64Task
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class BitArray64 : IEnumerable<int>
    {
        // Fields
        private ulong bits;

        // Constructors
        public BitArray64(ulong bits = 0)
        {
            this.bits = bits;
        }

        // Property
        public ulong Value
        {
            get
            {
                return this.bits;
            }
        }

        // Indexer
        public int this[int index]
        {
            get
            {
                if (index < 0 || index > 63)
                {
                    throw new IndexOutOfRangeException("Index must be in the range [0:63].");
                }

                return ((bits >> index) & 1) == 0 ? 0 : 1;
            }
            set
            {
                if (index < 0 || index > 63)
                {
                    throw new IndexOutOfRangeException("Index must be in the range [0:63].");
                }

                if (value != 0 && value != 1)
                {
                    throw new ArgumentException("The value must be 0 or 1.");
                }

                if (value == 0)
                {
                    this.bits &= ~((ulong)1 << index);
                }
                else
                {
                    this.bits |= ((ulong)1 << index);
                }
            }
        }

        // IEnumerable
        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < 64; i++)
            {
                yield return this[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        // Override
        public override bool Equals(object obj)
        {
            BitArray64 other = obj as BitArray64;
            if (other == null)
            {
                return false;
            }

            return this.bits == other.bits;
        }

        public override int GetHashCode()
        {
            return this.bits.GetHashCode();
        }

        public static bool operator ==(BitArray64 first, BitArray64 second)
        {
            return BitArray64.Equals(first, second);
        }

        public static bool operator !=(BitArray64 first, BitArray64 second)
        {
            return !(BitArray64.Equals(first, second));
        }
    }
}
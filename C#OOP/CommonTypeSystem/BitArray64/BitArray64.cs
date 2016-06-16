namespace BitArray64
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Represent 64 bit array with hold it in ulong
    /// </summary>
    public class BitArray64 : IEnumerable<int>
    {
        private ulong arr;

        public BitArray64(ulong num = 0)
        {
            this.arr = num;
        }

        public int this[int index]
        {
            get
            {
                if (index < 0 || index > 63)
                {
                    throw new IndexOutOfRangeException();
                }

                return (int)((this.arr >> index) & 1);
            }
            set
            {
                if (index < 0 || index > 63)
                {
                    throw new IndexOutOfRangeException();
                }

                if (value != 0 && value != 1)
                {
                    throw new InvalidOperationException();
                }

                this.arr ^= 1ul << index;
            }
        }

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

        public override string ToString()
        {
            var builder = new StringBuilder();
            var number = this.arr;
            while (number != 0)
            {
                builder.Insert(0, ((number >>= 1) & 1));
            }

            builder.Remove(0, 1);
            return builder.ToString();
        }

        public override bool Equals(object bitArray)
        {
            if (!(bitArray is BitArray64))
            {
                return false;
            }

            var other = bitArray as BitArray64;
            return this.arr.Equals(other.arr);
        }

        public override int GetHashCode()
        {
            return this.arr.GetHashCode();
        }

        public static bool operator ==(BitArray64 first, BitArray64 second)
        {
            return first.Equals(second);
        }

        public static bool operator !=(BitArray64 first, BitArray64 second)
        {
            return !first.Equals(second);
        }
    }
}

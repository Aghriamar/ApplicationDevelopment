using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5138_OOP_Lesson2
{
    public interface IBits
    {
        bool GetBit(int i);
        void SetBit(bool bit, int index);
    }


    public class Bits : IBits
    {
        Bits bitsFromLong = 12345L;
        Bits bitsFromInt = 6789;
        Bits bitsFromShort = (short)123;
        Bits bitsFromByte = (byte)45;

        public Bits(byte b)
        {
            this.Value = b;
            MaxBitsCount = sizeof(byte) * 8;
        }

        public Bits(short b)
        {
            this.Value = b;
            MaxBitsCount = sizeof(short) * 8;
        }

        public Bits(int b)
        {
            this.Value = b;
            MaxBitsCount = sizeof(int) * 8;
        }

        public Bits(long b)
        {
            this.Value = b;
            MaxBitsCount = sizeof(long) * 8;
        }

        public static implicit operator Bits(long value)
        {
            return new Bits(value);
        }

        public static implicit operator Bits(int value)
        {
            return new Bits(value);
        }

        public static implicit operator Bits(short value)
        {
            return new Bits(value);
        }

        public static implicit operator Bits(byte value)
        {
            return new Bits(value);
        }

        public long Value { get; set; } = 0;
        private int MaxBitsCount { get; set; }



        public bool GetBit(int index)
        {
            if (index > MaxBitsCount || index < 0)
            {
                Console.WriteLine($"Выход за пределы от 0 до {MaxBitsCount}");
                return false;
            }

            return ((Value >> index) & 1) == 1;
        }

        public void SetBit(bool bit, int index)
        {
            if (index > MaxBitsCount || index < 0)
            {
                Console.WriteLine($"Выход за пределы от 0 до {MaxBitsCount}");
                return;
            }
            if (bit == true)
                Value = (byte)(Value | (1 << index));
            else
            {
                var mask = (byte)(1 << index);
                mask = (byte)(0xff ^ mask);
                Value &= (byte)(Value & mask);
            }
        }
    }
}

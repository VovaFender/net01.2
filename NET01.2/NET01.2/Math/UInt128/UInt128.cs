using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace NET01._2.Math.UInt128
{
    public struct UInt128
    {
        public ulong Lower { get; set; }
        public ulong Upper { get; set; }

        public static UInt128 operator +(UInt128 a, UInt128 b)
        {
            ulong carryBit = 0;

            ulong lowerResult = a.Lower + b.Lower;
            if (lowerResult < a.Lower)
            {
                carryBit = 1;                
            }

            ulong upperResult = a.Upper + b.Upper + carryBit;

            return new UInt128
            {
                Lower = lowerResult,
                Upper = upperResult
            };
        }

        public static UInt128 operator -(UInt128 a, UInt128 b)
        {
            ulong carryBit = 0;

            ulong lowerResult = a.Lower - b.Lower;

            if (lowerResult > a.Lower)
            {
                carryBit = 1;
            }

            ulong upperResult = a.Upper - b.Upper - carryBit;

            return new UInt128
            {
                Lower = lowerResult,
                Upper = upperResult
            };
        }

        public static bool operator == (UInt128 a, UInt128 b)
        {
            return (a.Lower == b.Lower && a.Upper == b.Upper);
        }

        public static bool operator != (UInt128 a, UInt128 b)
        {
            return !(a == b);
        }

        public static implicit operator UInt128(ulong src)
        {
            return new UInt128
            {
                Lower = src
            };
        }

        public static explicit operator ulong(UInt128 src)
        {
            if (src.Upper != 0)
            {
                throw new InvalidCastException("too big for ulong");
            }
            return src.Lower;
        }

    }
}

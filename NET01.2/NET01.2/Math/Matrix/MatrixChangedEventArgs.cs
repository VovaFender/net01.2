using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET01._2.Math.Matrix
{
    /// <summary>
    /// generic class for storing additional info about changed element in OnChange event
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class MatrixChangedEventArgs<T> : EventArgs
    {
        private readonly int i;
        
        public int Row { get { return i; } }
        
        private readonly int j;        
        
        public int Column { get { return j; } }

        private readonly T newValue;

        public T Value { get { return newValue; } }

        public MatrixChangedEventArgs (int i, int j, T newValue)
        {
            this.i = i;
            this.j = j;
            this.newValue = newValue;
        }
    }
}

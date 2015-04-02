using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET01._2.Math.Matrix
{
    public class DiagonalMatrix<T> : SquareMatrix<T>
    {
        public T this[int i, int j]
        {
            get
            {
                if (i == j)
                    return data[i];
                return default(T);
            }
            set
            {
                if (i != j)
                    throw new ArgumentException("only main diagonal elements can be accessed");
                
                if (!data[i].Equals(value))
                {
                    data[i] = value;
                    OnMatrixChange(new MatrixChangedEventArgs<T>(i, j, value));
                }
            }
        }

        public DiagonalMatrix(int size)
        {
            if (size <= 0)
            {
                throw new ArgumentException("size cannot be zero or negative");
            }

            this.size = size;
            data = new T[size];
        } 

        public DiagonalMatrix(int size, T initialValue) : this(size)
        {
            for (int i = 0; i < size; i++)                
                data[i] = initialValue;
        } 
    }
}

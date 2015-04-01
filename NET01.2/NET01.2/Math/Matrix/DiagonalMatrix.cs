using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET01._2.Math.Matrix
{
    class DiagonalMatrix<T> : SquareMatrix<T>
    {
        public T this[int i, int j]
        {
            get
            {
                if (i == j)
                {
                    return this.data[size*i + j];
                }
                return default(T);
            }
            set
            {
                if (i != j)
                {
                    throw new ArgumentException("only main diagonal elements can be accessed");
                }
                if (data[size * i + j] != value)
                {
                    data[size * i + j] = value;
                    OnMatrixChange(new MatrixChangedEventArgs<T>(i, j, value));
                }
            }
        }

        public DiagonalMatrix(int size)
        {
            if (size <= 0)
            {
                throw new ArgumentException("size cannot be null or negative");
            }

            data = new T[size];
        } 

    }
}

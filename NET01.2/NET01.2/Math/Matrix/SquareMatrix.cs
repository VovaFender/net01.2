using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET01._2.Math.Matrix
{
    public class SquareMatrix<T>
    {
        protected T[] data;
        protected int size;

        public event EventHandler<MatrixChangedEventArgs<T>> MatrixChanged;

        public T this[int i, int j]
        {            
            get { return data[size*i + j]; }

            set
            {
                if (data[size*i + j] != value)
                {
                    data[size * i + j] = value;
                    OnMatrixChange(new MatrixChangedEventArgs<T>(i, j, value));
                }
            }
        }

        public SquareMatrix(int size)
        {
            if (size <= 0)
            {
                throw new ArgumentException("size cannot be zero or negative");
            }
            data = new T[size*size];
        }

        protected SquareMatrix()
        {
        }

        protected virtual void OnMatrixChange(MatrixChangedEventArgs<T> e)
        {
            MatrixChanged(this, e);
        }
    }
}

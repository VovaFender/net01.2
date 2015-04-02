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

        public int Size
        {
            get
            {
                return size;
            }            
        }

        public event EventHandler<MatrixChangedEventArgs<T>> MatrixChanged;

        public T this[int i, int j]
        {
            get
            {
                return data[size*i + j];
            }

            set
            {                
                if (!data[size*i + j].Equals(value))
                {
                    data[size * i + j] = value;
                    OnMatrixChange(new MatrixChangedEventArgs<T>(i, j, value));
                }
            }
        }

        public SquareMatrix(int size)
        {
            if (size <= 0)
                throw new ArgumentException("size cannot be zero or negative");

            this.size = size;
            data = new T[size*size];
        }

        public SquareMatrix(int size, T initialValue) : this(size)
        {
            for (int i = 0; i < size * size; i++)                
                data[i] = initialValue;
        } 

        protected SquareMatrix()
        {
        }

        protected virtual void OnMatrixChange(MatrixChangedEventArgs<T> e)
        {
            if (MatrixChanged != null) 
                MatrixChanged(this, e);
        }
    }
}

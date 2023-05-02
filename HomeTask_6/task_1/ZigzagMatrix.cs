using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task2._1_sigma_
{
    public class ZigzagMatrixException : Exception
    {
        public ZigzagMatrixException(Exception exception)
        {
            throw exception;
        }

        public ZigzagMatrixException(ZigzagMatrix matrixObj, int[,] matrix)
        {
            if (matrixObj == null || matrix == null)
            {
                throw new ArgumentNullException("matrix");
            }
        }
        public ZigzagMatrixException(int[,] matrix)
        {
            if (matrix == null)
            {
                throw new ArgumentNullException("matrix");
            }
        }
    }

// Здійсніть перевірку виконання для парного і непарного значення розміру масиву!!!
    public class ZigzagMatrix
    {
        private int[,] _matrix;
        private int _size;

        public ZigzagMatrix(int size)
        {
            if(size > 0)
            {
                _size = size;
                _matrix = new int[_size, _size];
                FillMatrix();
            }
            else throw new ArgumentException("Invalid size of matrix.");
        }

        public ZigzagMatrix(int[,] matrix)
        {
            _size = matrix.GetLength(0);
            if(_size > 0 && matrix.GetLength(0) == matrix.GetLength(1))
            {
                _matrix = new int[_size, _size];

                for (int i = 0; i < _size; i++)
                {
                    for (int j = 0; j < _size; j++)
                    {
                        _matrix[i, j] = matrix[i, j];
                    }
                }
            }
            else throw new ArgumentException("Invalid matrix.");
        }

        private void FillMatrix()
        {
            int count = 0;
            for (int i = 0; i < _size; i++)
            {
                for (int j = 0; j < _size; j++)
                {
                    _matrix[i, j] = ++count;
                }
            }
        }

        public IEnumerator GetEnumerator()
        {
            //first part (elements above the diagonal)
            for (int i = 0; i < _size; i++)
            {
                //down direction
                if (i % 2 == 0)
                {
                    int temp = 0;
                    for (int j = i; j >= 0; j--)
                    {
                        yield return _matrix[temp++, j];
                    }
                }
                //up direction
                else
                {
                    int temp = i;
                    for (int j = 0; j <= i; j++)
                    {
                        yield return _matrix[temp--, j];
                    }
                }
            }

            //second part (elements under the diagonal)
            for (int i = 1; i < _size; i++)
            {
                int temp = _size - 1;
                //down direction
                if ((_size - i) % 2 != 0)
                {
                    for (int j = i; j < _size; j++)
                    {
                        yield return _matrix[j, temp--];
                    }
                }
                //up direction
                else
                {
                    for (int j = i; j < _size; j++)
                    {
                        yield return _matrix[temp--, j];
                    }
                }
            }
        }
    }
}

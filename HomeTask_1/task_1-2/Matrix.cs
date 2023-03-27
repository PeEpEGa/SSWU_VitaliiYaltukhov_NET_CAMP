public class MatrixException : Exception
{
    public MatrixException(Exception exception)
    {
        throw exception;
    }

    public MatrixException(Matrix matrix, int[,] arr)
    {
        if (matrix == null || arr == null)
        {
            throw new ArgumentNullException("matrix");
        }
    }
    public MatrixException(int[,] arr)
    {
        if (arr == null)
        {
            throw new ArgumentNullException("matrix");
        }
    }
}


public class Matrix
{
    public int Rows { get; set; }

    public int Columns { get; set; }

    public int[,] Array { get; set; }

    public Matrix(int rows, int columns)
    {
        if (rows > 0 && columns > 0)
        {
            Array = new int[rows, columns];
            Columns = columns;
            Rows = rows;
        }
        else throw new ArgumentOutOfRangeException("rows");
    }

    public Matrix(int[,] array)
    {
        try
        {
            Rows = array.GetLength(0);
            Columns = array.GetLength(1);
            Array = array;
        }
        catch
        {
            throw new ArgumentNullException("array");
        }
    }

    public void Fill()
    {
        try
        {
            Random random = new Random();
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    Array[i, j] = random.Next(0, 17);
                }
            }
        }
        catch
        {
            throw new MatrixException(Array);
        }
    }

    public void FillSpirally()
    {
        try
        {
            int count = 0;
            int i = 0;
            while (count < Rows * Columns)
            {
                //down
                for (int j = i; j < Rows - i; j++)
                {
                    Array[j, i] = ++count;
                }
                //right
                for (int j = 1 + i; j < Columns - i; j++)
                {
                    Array[Rows - i - 1, j] = ++count;
                }
                //up
                for (int j = Rows - i - 2; j >= i; j--)
                {
                    Array[j, Columns - i - 1] = ++count;
                }
                //left
                for (int j = Columns - i - 2; j >= i + 1; j--)
                {
                    Array[i, j] = ++count;
                }
                ++i;
            }
        }
        catch
        {
            throw new MatrixException(Array);
        }
    }

    public (int first, int last, int count, int rowNumber) LongestSequence()
    {
        try
        {
            int first = 0;
            int last = 0;
            int count = 1;
            int rowNumber = 0;

            for (int i = 0; i < Array.GetLength(0); i++)
            {
                int temp = 1;
                for (int j = 0; j < Array.GetLength(1) - 1; j++)
                {
                    if (Array[i, j] != Array[i, j + 1])
                    {
                        temp = 1;
                        continue;
                    }

                    else if (++temp >= count)
                    {
                        count = temp;
                        last = j + 1;
                        first = (j + 1) - temp + 1;
                        rowNumber = i;
                    }
                }
            }
            return (first, last, count, rowNumber);
        }
        catch
        {
            throw new MatrixException(Array);
        }
    }

    public void Print()
    {
        try
        {
            for (int i = 0; i < Array.GetLength(0); i++)
            {
                for (int j = 0; j < Array.GetLength(1); j++)
                {
                    Console.Write(Array[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
        catch
        {
            throw new MatrixException(Array);
        }
    }
}
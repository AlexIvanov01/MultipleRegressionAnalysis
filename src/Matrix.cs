
namespace VVPS_project.src
{
    public class Matrix
    {
        private double[,] _dataArray;
        private int _columns = 0;
        private int _rows = 0;

        public double[,] DataArray
        {
            get { return _dataArray; }
            set 
            { 
                _dataArray = value;
                _rows = value.GetLength(0);
                _columns = value.GetLength(1);
            }
        }

        public int Columns
        {
            get { return _columns; }
            set { _columns = value; }
        }

        public int Rows
        {
            get { return _rows; }
            set { _rows = value; }
        }

        public Matrix(double[,] data)
        {
            DataArray = data;
            if (_rows == 0 || _columns == 0)
            {
                throw new ArgumentException("Matrix has no values.");
            }
        }

        //Flips a matrix over its diagonal, it switches
        //the row and column indices of the matrix
        public void Transpose()
        {
            double[,] transposed = new double[_columns, _rows];

            for (int i = 0; i < _rows; i++)
            {
                for (int j = 0; j < _columns; j++)
                {
                    transposed[j, i] = _dataArray[i, j];
                }
            }
            DataArray = transposed;
        }

        // Multiply value from every row from first matrix with
        // the value from every column from the second matrix
        public void Multiply(Matrix other)
        {
            if (_columns != other.Rows)
            {
                throw new ArgumentException("Number of columns in the" +
                    " first matrix must be equal to the number of rows" +
                    " in the second matrix.");
            }

            double[,] result = new double[_rows, other.Columns];
            for (int i = 0; i < _rows; i++)
            {
                for (int j = 0; j < other.Columns; j++)
                {
                    double sum = 0;
                    for (int k = 0; k < _columns; k++)
                    {
                        sum += _dataArray[i, k] * other.DataArray[k, j];
                    }
                    result[i, j] = Math.Round(sum,5);
                }
            }
            DataArray = result;
        }

        public void AddFirstColumnWithValue1()
        {
            double[,] modifiedMatrix = new double[_rows, _columns + 1];

            // Fill the first column with the specified value
            for (int i = 0; i < _rows; i++)
            {
                modifiedMatrix[i, 0] = 1;
            }

            // Copy the original matrix to the modified matrix
            for (int i = 0; i < _rows; i++)
            {
                for (int j = 0; j < _columns; j++)
                {
                    modifiedMatrix[i, j + 1] = _dataArray[i, j];
                }
            }
            DataArray = modifiedMatrix;
        }

        public void RemoveLastRow()
        {
            double[,] modifiedMatrix = new double[_rows - 1, _columns];

            // Copy all rows except the last one
            for (int i = 0; i < _rows - 1; i++)
            {
                for (int j = 0; j < _columns; j++)
                {
                    modifiedMatrix[i, j] = _dataArray[i, j];
                }
            }
            DataArray = modifiedMatrix;
        }

        //Find a solution of a valid matrix
        //(not inconsistent or overdetermined system
        //with a single solution)
        public double[] UseGaussianElemination()
        {
            Console.WriteLine("Input matrix for Gaussian elemination:\n");
            PrintMatrix();
            Console.WriteLine("-------------------------------");

            // Check for zero rows (inconsistent system)
            CheckForZeroRows();

            // Check for overdetermined system
            if (_rows > _columns - 1)
            {
                throw new InvalidOperationException("System of equations" +
                    " is overdetermined. No unique solution exists.");
            }

            // Forward elimination
            for (int i = 0; i < _rows - 1; i++)
            {
                // Choose a pivot element in the matrix and use it to
                // eliminate other elements in the same column.
                int maxRow = i;
                for (int k = i + 1; k < _rows; k++)
                {
                    if (Math.Abs(_dataArray[k, i]) > Math.Abs(_dataArray[maxRow, i]))
                    {
                        maxRow = k;
                    }
                }

                // Swap rows to bring zeros to the bottom.
                if (maxRow != i)
                {
                    for (int j = 0; j < _columns; j++)
                    {
                        (_dataArray[maxRow, j], _dataArray[i, j]) =
                        (_dataArray[i, j], _dataArray[maxRow, j]);
                    }
                }

                // Using the pivot element to perform row operations
                // to eliminateall elements below the pivot
                // in the same column, making them zero.
                for (int k = i + 1; k < _rows; k++)
                {
                    double factor = _dataArray[k, i] / _dataArray[i, i];
                    for (int j = i; j < _columns; j++)
                    {
                        _dataArray[k, j] -= factor * _dataArray[i, j];
                    }
                }

                Console.WriteLine($"Itteration {i+1}:\n");
                PrintMatrix();
                Console.WriteLine("-------------------------------");
            }

            // Check for zero rows (inconsistent system)
            CheckForZeroRows();

            // Back substitution
            double[] solution = new double[_rows];
            for (int i = _rows - 1; i >= 0; i--)
            {
                double sum = 0;
                for (int j = i + 1; j < _columns - 1; j++)
                {
                    sum += _dataArray[i, j] * solution[j];
                }
                solution[i] = (_dataArray[i, _columns - 1] - sum)
                              / _dataArray[i, i];
            }
            return solution;
        }

        public void PrintMatrix()
        {
            for (int i = 0; i < _rows; i++)
            {
                for (int j = 0; j < _columns; j++)
                {
                    Console.Write(_dataArray[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }

        public void CheckForZeroRows()
        {
            for (int row = 0; row < _rows; row++)
            {
                bool isZeroRow = true;
                for (int col = 0; col < _columns - 1; col++)
                {
                    if (Math.Abs(_dataArray[row, col]) > 0)
                    {
                        isZeroRow = false;
                        break;
                    }
                }

                if (isZeroRow && Math.Abs(_dataArray[row, _columns-1]) > 0)
                {
                    throw new InvalidOperationException("System of " +
                        "equations is inconsistent. No solution exists.");
                }
            }
        }

    }
}

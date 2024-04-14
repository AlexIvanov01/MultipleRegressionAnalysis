
namespace VVPS_project.src
{
    public class RegressionModel
    {
        private Matrix _augmentedMatrix;
        private double[] _coefficients;

        public Matrix AugmentedMatrix
        {
            get { return _augmentedMatrix; }
            set { _augmentedMatrix = value; }
        }

        public double[] Coefficients
        {
            get { return _coefficients; }
            set { _coefficients = value; }
        }

        public RegressionModel(Matrix inputMatrix, int variableCount)
        {
            _augmentedMatrix = inputMatrix;
            _coefficients = new double[inputMatrix.Rows];
            CheckValidRequest(variableCount);
        }

        public void Execute()
        {
            Console.WriteLine("\nHistoric data:\n");
            AugmentedMatrix.PrintMatrix();
            Console.WriteLine("-------------------------------");

            AugmentedMatrix.AddFirstColumnWithValue1();

            Matrix matrix = new Matrix(AugmentedMatrix.DataArray);

            AugmentedMatrix.Transpose();

            AugmentedMatrix.Multiply(matrix);

            // Remove extra row to create valid matrix for
            // Gaussuian elemination and make solution
            AugmentedMatrix.RemoveLastRow();

            Coefficients = AugmentedMatrix.UseGaussianElemination();
        }

        public void PrintResult()
        {
            Console.WriteLine("Coefficients:\n");
            for (int i = 0; i < Coefficients.Length; i++)
            {
                Console.WriteLine($"B{i} = {(Coefficients[i])}");
            }
            Console.WriteLine("-------------------------------");
        }

        public void CheckValidRequest(int variableCount)
        {
            if (variableCount != AugmentedMatrix.Columns - 1)
                throw new InvalidOperationException("Invalid number of " +
                    "unknown variables in the historic data.");
        }
    }
}

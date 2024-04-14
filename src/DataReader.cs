using System.Globalization;

namespace VVPS_project.src
{
    public static class DataReader
    {
        public static double[,] ReadCSVToMatrix(string filePath)
        {
            string[] lines = File.ReadAllLines(filePath);

            // Determine matrix dimensions
            int rows = lines.Length;
            int cols = lines[0].Split(',').Length;

            double[,] matrix = new double[rows, cols];

            //Fill matrix with values
            for (int i = 0; i < rows; i++)
            {
                string[] values = lines[i].Split(',');
                for (int j = 0; j < cols; j++)
                {
                    if (!double.TryParse(values[j], NumberStyles.Float, 
                        CultureInfo.InvariantCulture, out matrix[i, j]))
                    {
                        throw new FormatException("Unable to parse value at " +
                            $"row {i + 1}, column {j + 1} as a double.");
                    }
                }
            }
            return matrix;
        }
    }
}


namespace VVPS_project.src
{
    static class Program
    {
        static void Main()
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("\nNumber of unknown variables (0 to exit):");
                    int variableCount = Convert.ToInt32(Console.ReadLine());
                    if (variableCount == 0) break;

                    Console.WriteLine("\nFile path of the historic data:");
                    string filePath = Console.ReadLine() ?? String.Empty;

                    //Read from file
                    Matrix InputMatrix = new Matrix(DataReader.ReadCSVToMatrix(@filePath));

                    RegressionModel regressionModel = new RegressionModel(InputMatrix, variableCount);

                    regressionModel.Execute();

                    regressionModel.PrintResult();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
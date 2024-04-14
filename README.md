# Multiple Regression Analysis with Gaussian Elimination

## Description
This C# application performs multiple regression analysis to analyze the influence of two or more independent variables on one dependent variable. The application uses the
Gaussian elimination method to solve the regression equation and generate regression results.

## Features
- Read historical data from a CSV file.
- Perform multiple regression analysis using the Gaussian elimination method.
- Display regression results, including input historical data, inpuit augmented matrix passed onto the Gaussian elemination algorythm, iterations of the Gaussian elemination and the regression coefficients.

## Installation Instructions
1. Clone this repository to your local machine.
2. Open the project in Visual Studio or any other C# development environment.
3. Build the project to compile the application.

## Usage
1. Launch the application by running the "VVPS_project.sln" file using Visual Studio 2022.
2. Specify the number of independent variables present in the historical data.
3. Specify the file path of the historic data.
4. View the regression results displayed on the screen.

## Input Data Format
The input data should be provided in CSV format, with each row representing a data point and each column representing a variable. 
The first row should contain column headers. The CSV file should include columns for independent variables and one column for the dependent variable.

Example CSV format:
IndependentVar1,IndependentVar2,DependentVar
10,20,30
15,25,35
20,30,40

## Output Format
The application displays regression results, including input historical data, inpuit augmented matrix passed onto the Gaussian elemination algorythm, iterations of the Gaussian elemination and the regression coefficients.

## Examples
Example usage scenarios and sample input data are provided in the "bin\Debug\net8.0" folder of this repository, labeled input1.csv and input2.csv.


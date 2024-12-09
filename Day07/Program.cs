using Day07;
using System.Data;
using Tools;

string[] fileContent = FileReader.TxtReadAllLines("input.txt");

double[] answers = fileContent
    .Select(str => double.Parse(str.Split(":")[0]))
    .ToArray();

double[][] numberSequences = fileContent
    .Select(str => str.Split(": ")[1].Split(" ")
        .Select(number => double.Parse(number))
        .ToArray()
    )
    .ToArray();

string[] operators = { "+", "*", "||" };

Equation[] Equations = answers
    .Zip(numberSequences, (answer, sequence) => new Equation(answer, sequence, operators)).
    ToArray();

double partOneResult = Equations
    .Where(Equation => Equation.Evaluate())
    .Select(Equation => Equation.trueExpression)
    .Sum();


Console.WriteLine(partOneResult);


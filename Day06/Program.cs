using System.Data;
using Tools;

char[][] matrix = FileReader.TxtReadAllLines("input.txt")
    .Select(str => str.ToCharArray())
    .ToArray();


//part 1
GuardedMatrix guardedMatrix = new(matrix);
guardedMatrix.simulateMovement();

int sumGuardedFields = guardedMatrix.simulatedGuardedMatrix
    .Select(row => row
        .Count(x => x == 'X')
    )
    .Sum();



static void WriteCharMatrixToFile(char[][] matrix, string filePath)
{
    using (StreamWriter writer = new StreamWriter(filePath))
    {
        foreach (var row in matrix)
        {
            writer.WriteLine(new string(row));
        }
    }
}

WriteCharMatrixToFile(guardedMatrix.simulatedGuardedMatrix, "output.txt");
Console.WriteLine(sumGuardedFields);


GuardedMatrixScenarioSimulator guardedMatrixScenarioSimulator = new(guardedMatrix);

int loopsCreated = guardedMatrixScenarioSimulator.detectGuardLoopingOpportunities();

Console.WriteLine(loopsCreated);
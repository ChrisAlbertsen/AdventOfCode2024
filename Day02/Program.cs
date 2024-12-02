using Tools;
using System.Collections.Generic;


string[] fileContent = FileReader.TxtReadAllLines("input.txt");


int[][] reports = fileContent
    .Select(content => content.Split(" "))
    .Select(subArray => subArray.Select(int.Parse).ToArray())
    .ToArray();


//part 1
bool[] isIncreasing(int[] array) => array.Zip(array.Skip(1), (a, b) => (a < b) && (b - a) <= 3).ToArray();
bool[] isDecreasing(int[] array) => array.Zip(array.Skip(1), (a, b) => (a > b) && (a - b) <= 3).ToArray();


int[][] safeReports = reports
    .Where(array => isDecreasing(array).All(x => x) || isIncreasing(array).All(x => x))
    .ToArray();

Console.WriteLine(safeReports.Length);





//part 2
bool dampenerMotor(int[] array, Func<int[], bool[]> evaluator)
{
    List<int> list = array.ToList();
    List<int> tempList;
    for(int i = 0; i < array.Length; i++)
    {
        tempList = new List<int>(list);
        tempList.RemoveAt(i);
        if (evaluator(tempList.ToArray()).All(x => x)) return true;
    }
    return false;
}

bool isIncreasingDampened(int[] array) {
    bool[] evaluatedArray = isIncreasing(array);
    int numberOfErrors = evaluatedArray.Count(x => !x);
    if (numberOfErrors == 0) return true;
    else
    {
        return dampenerMotor(array, isIncreasing);
    }
};

bool isDecreasingDampened(int[] array)
{
    bool[] evaluatedArray = isDecreasing(array);
    int numberOfErrors = evaluatedArray.Count(x => !x);
    if (numberOfErrors == 0) return true;
    else
    {
        return dampenerMotor(array, isDecreasing);
    }
};

int[][] safeReportsDampened = reports
    .Where(array => isDecreasingDampened(array) || isIncreasingDampened(array))
    .ToArray();

Console.WriteLine(safeReportsDampened.Length);
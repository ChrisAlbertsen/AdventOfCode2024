using System.Text.RegularExpressions;
using Tools;

//prep
string[] fileContent = FileReader.TxtReadAllLines("input.txt");

string[][] nestedFileContent = fileContent
    .Select(s => s.Split("   "))
    .ToArray();

int[] column1 = nestedFileContent.Select(row => int.Parse(row[0])).Order().ToArray();
int[] column2 = nestedFileContent.Select(row => int.Parse(row[1])).Order().ToArray();

//part 1
int sum = column1
    .Zip(column2, (c1, c2) => Math.Abs(c1 - c2))
    .Sum();

Console.WriteLine(sum);


int similarityScore2 = column1
    .Distinct()
    .Intersect(column2)
    .Sum();

Console.WriteLine(similarityScore2);

// part 2
int[] intersectionValues = column1
    .Intersect(column2)
    .ToArray();

int similarityScore = column2
    .Where(x => intersectionValues.Contains(x))
    .GroupBy(value => value)
    .Select(group => group.Count() * group.Key)
    .Sum();

Console.WriteLine(similarityScore);
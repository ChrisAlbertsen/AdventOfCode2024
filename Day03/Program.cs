using System.Text.RegularExpressions;
using Tools;

string fileContent = String.Join("", FileReader.TxtReadAllLines("input.txt"));
//string fileContent = "<mul(401,458)-from()+mul(92,705)\r\n}?/,(~+^mul(398,379)why()-!why(){}mul(618,341)how(818,559)'%}~+}'";

//part 1
Regex mulRegex = new Regex(@"mul\(([0-9]{1,3}),([0-9]{1,3})\)");

MatchCollection mulMatches = mulRegex.Matches(fileContent);

Regex numberRegex = new Regex(@"\d{1,3}| [1 - 9]");

int mulSum = mulMatches
    .Select(match =>
    {
        int[] numbers = numberRegex.Matches(match.Value)
            .Select(numberMatch => int.Parse(numberMatch.Value))
            .ToArray();
        return numbers[0] * numbers[1];
    }
    )
    .Sum();

Console.WriteLine(mulSum.ToString());

//part 2
Regex doDontRegex = new Regex(@"don't\(\)(.*?)do\(\)");
string doDontFilteredString = doDontRegex.Replace(fileContent, "");

MatchCollection mulMatchesDoDontFiltered = mulRegex.Matches(doDontFilteredString);
int mulSumDoDontFiltered = mulMatchesDoDontFiltered
    .Select(match =>
    {
        int[] numbers = numberRegex.Matches(match.Value)
            .Select(numberMatch => int.Parse(numberMatch.Value))
            .ToArray();
        return numbers[0] * numbers[1];
    }
    )
    .Sum();


Console.WriteLine(mulSumDoDontFiltered.ToString());
using System.Text.RegularExpressions;
using Tools;

string[] fileContent = FileReader.TxtReadAllLines("input.txt");


// part 1
static int CountWordOccurrences(string[] matrix, string word)
{
    int n = matrix.Length;
    int m = matrix[0].Length;
    int wordLength = word.Length;
    int count = 0;

    int[][] directions = {
            new int[] { 0, 1 },
            new int[] { 1, 0 },
            new int[] { 1, 1 },
            new int[] { 1, -1 },
            new int[] { -1, 0 },
            new int[] { -1, 1 },
            new int[] { -1, -1 },
            new int[] { 0, -1 }

        };

    for (int row = 0; row < n; row++)
    {
        for (int col = 0; col < m; col++)
        {
            foreach (var direction in directions)
            {
                if (SearchFrom(matrix, word, row, col, direction[0], direction[1], n, m, wordLength))
                {
                    count++;
                }
            }
        }
    }

    return count;
}

static bool SearchFrom(string[] matrix, string word, int row, int col, int dx, int dy, int n, int m, int wordLength)
{
    for (int i = 0; i < wordLength; i++)
    {
        int newRow = row + i * dx;
        int newCol = col + i * dy;

        if (newRow < 0 || newRow >= n || newCol < 0 || newCol >= m)
            return false;

        if (matrix[newRow][newCol] != word[i])
            return false;
    }

    return true;
}

Console.WriteLine(CountWordOccurrences(fileContent, "XMAS"));


// part 2

static int CountMasOccurrences(string[] matrix, string word)
{
    int n = matrix.Length;
    int m = matrix[0].Length;
    int wordLength = word.Length;
    char leftUpperDiagonal;
    char leftLowerDiagonal;
    char rightUpperDiagonal;
    char rightLowerDiagonal;
    string leftDiagonal;
    string rightDiagonal;
    bool leftDiagonalResult;
    bool rightDiagonalResult;
    int[][] directions = {
            new int[] { 1, 1 },
            new int[] { 1, -1 },
            new int[] { -1, 1 },
            new int[] { -1, -1 },
        };
    int counter = 0;

    for (int row = 0; row < n; row++)
    {
        for (int col = 0; col < m; col++)
        {
            if (matrix[row][col] == word[1])
            {
                leftUpperDiagonal = FindChar(matrix, row, col, -1, -1, n, m);
                leftLowerDiagonal = FindChar(matrix, row, col, -1, 1, n, m);
                rightUpperDiagonal = FindChar(matrix, row, col, 1 ,-1, n, m);
                rightLowerDiagonal = FindChar(matrix, row, col, 1, 1, n, m);
                
                leftDiagonal = "" + leftLowerDiagonal + word[1] + rightUpperDiagonal;
                rightDiagonal = "" + rightLowerDiagonal + word[1] + leftUpperDiagonal;

                leftDiagonalResult = leftDiagonal == "MAS" || leftDiagonal == "SAM";
                rightDiagonalResult = rightDiagonal == "MAS" || rightDiagonal == "SAM";

                if (leftDiagonalResult && rightDiagonalResult) counter++;
            }

        }
    }
    return counter;
}

static char FindChar(string[] matrix, int row, int col, int dx, int dy, int n, int m)
{
    int newRow = row + dx;
    int newCol = col + dy;

    if (newRow < 0 || newRow >= n || newCol < 0 || newCol >= m)
        return '?';

    return matrix[newRow][newCol];

}

Console.WriteLine(CountMasOccurrences(fileContent, "MAS"));

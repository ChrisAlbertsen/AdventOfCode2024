
namespace Tools;

public static class FileReader
{
    public static string[] TxtReadAllLines(string fileName) => File.ReadAllLines(fileName);
}
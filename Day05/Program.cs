using Tools;

string[] fileContent = FileReader.TxtReadAllLines("input.txt");

int[][] fileContentSeries = fileContent
    .Where(str => str.Contains(","))
    .Select(str => str.Split(",").Select(splitStr => int.Parse(splitStr)).ToArray())
    .ToArray();


string[] orderFileContent = fileContent
    .Where(str => str.Contains("|"))
    .ToArray();

Dictionary<int,List<int>> orderLogicAll = new Dictionary<int, List<int>>();

foreach (string item in orderFileContent) {
    int[] parts = item.Split("|").Select(int.Parse).ToArray();
    if(!orderLogicAll.ContainsKey(parts[0])) {
        orderLogicAll[parts[0]] = new List<int>();
    }
    orderLogicAll[parts[0]].Add(parts[1]);
}


//part 1

static bool validateNumberSeriesOrder(int[] numberSeries, Dictionary<int, List<int>> orderLogicAll) {
    for (int i = numberSeries.Length - 1; i >= 0; i--) {
        if(!orderLogicAll.ContainsKey(numberSeries[i])) continue;
        List<int> orderLogic = orderLogicAll[numberSeries[i]];
        for (int j = i - 1; j >= 0; j--) {
            if(orderLogic.Contains(numberSeries[j])) return false;
        }
    }
    return true;
}

int[][] validatedFileContentSeries = fileContentSeries.
    Where(series => validateNumberSeriesOrder(series, orderLogicAll))
    .ToArray();

int middleValuesSum = validatedFileContentSeries
    .Select(series => series[series.Length / 2])
    .Sum();


Console.WriteLine(middleValuesSum);


//part 2

int[][] incorrectNumberSeriesOrder = fileContentSeries.
    Where(series => !validateNumberSeriesOrder(series, orderLogicAll))
    .ToArray();

static int[] fixNumberSeriesOrder(int[] numberSeries, Dictionary<int, List<int>> orderLogicAll) {
    List<int> fixedNumberSeries = new List<int>();
    foreach (var number in numberSeries)
    {
        if (orderLogicAll.ContainsKey(number))
        {
            List<int> orderLogic = orderLogicAll[number];
            int insertIndex = fixedNumberSeries.FindIndex(x => orderLogic.Contains(x));
            if (insertIndex >= 0)
                fixedNumberSeries.Insert(insertIndex, number);
            else
                fixedNumberSeries.Add(number);
        }
        else
        {
            fixedNumberSeries.Add(number);
        }
    }
    return fixedNumberSeries.ToArray();
}



int correctedMiddleValuesSum = incorrectNumberSeriesOrder
    .Select(series => fixNumberSeriesOrder(series, orderLogicAll))
    .Select(series => series[series.Length / 2])
    .Sum();


Console.WriteLine(correctedMiddleValuesSum);

// foreach (int numberSeries in middleValuesValidatedFileContentSeries) {
//     Console.WriteLine(numberSeries);
// }

// foreach(string str in orderLogicAll) {
//     Console.WriteLine(str);
// }
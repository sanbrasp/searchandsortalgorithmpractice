namespace SortingAlgorithmPractice.SortHelpers;

public static class SortHelpers
{
    public static void PrintResult(string name, int[] sortedArray, long ms)
    {
        bool isSorted = IsSorted(sortedArray);
        Console.WriteLine($"{name,-15} {ms,5} ms    sorted: {isSorted}    first: {sortedArray[0]}    last: {sortedArray[^1]}");
    }
    
    public static bool IsSorted(int[] arr)
    {
        for (int i = 1; i < arr.Length; i++)
        {
            if (arr[i] < arr[i - 1]) return false;
        }
        return true;
    }
}
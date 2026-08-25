using SortingAlgorithmPractice;
using System.Diagnostics;

// int[] original = [14,3,27,8,19,5]; 
// int[] numbers = [14,3,27,8,19,5];
const int arraySize = 5000;
var rng = new Random();
int[] original = new int[arraySize];
for (int i = 0; i < arraySize; i++)
{
    original[i] = rng.Next(0, 100000);
}

var stopWatch = new Stopwatch();

int[] bubbleData = (int[])original.Clone();
int[] quickSortData = (int[])original.Clone();
int[] mergeSortData = (int[])original.Clone();
int[] insertionSortData = (int[])original.Clone();
int[] selectionSortData = (int[])original.Clone();
int[] heapSortData = (int[])original.Clone();
int[] radixSortData = (int[])original.Clone();

// Bubblesort:
stopWatch.Restart();
Bubblesort.Sort(bubbleData);
stopWatch.Stop();
PrintResult("BubbleSort", bubbleData, stopWatch.ElapsedMilliseconds);
// Console.WriteLine($"BubbleSorted array: {string.Join(", ", bubbleData)}");
// Console.WriteLine($"Time BubbleSort: {stopWatch.ElapsedMilliseconds} milliseconds\n");

// QuickSort:
stopWatch.Restart();
QuickSort.Sort(quickSortData);
stopWatch.Stop();
PrintResult("QuickSort", quickSortData, stopWatch.ElapsedMilliseconds);
// Console.WriteLine($"QuickSorted array: {string.Join(", ", quickSortData)}");
// Console.WriteLine($"Time QuickSort: {stopWatch.ElapsedMilliseconds} milliseconds\n");

// MergeSort:
stopWatch.Restart();
MergeSort.Sort(mergeSortData, 0, mergeSortData.Length -1);
stopWatch.Stop();
PrintResult("MergeSort", mergeSortData, stopWatch.ElapsedMilliseconds);
// Console.WriteLine($"MergeSorted array: {string.Join(", ", mergeSortData)}");
// Console.WriteLine($"Time MergeSort: {stopWatch.ElapsedMilliseconds} milliseconds\n");

// InsertionSort:
stopWatch.Restart();
InsertionSort.Sort(insertionSortData);
stopWatch.Stop();
PrintResult("InsertionSort", insertionSortData, stopWatch.ElapsedMilliseconds);
// Console.WriteLine($"InsertionSorted array: {string.Join(", ", insertionSortData)}");
// Console.WriteLine($"Time InsertionSort: {stopWatch.ElapsedMilliseconds} milliseconds\n");

// SelectionSort
stopWatch.Restart();
SelectionSort.Sort(selectionSortData);
stopWatch.Stop();
PrintResult("SelectionSort", selectionSortData, stopWatch.ElapsedMilliseconds);
// Console.WriteLine($"SelectionSorted array: {string.Join(", ", selectionSortData)}");
// Console.WriteLine($"Time SelectionSort: {stopWatch.ElapsedMilliseconds} milliseconds\n");

// HeapSort:
stopWatch.Restart();
HeapSort.Sort(heapSortData);
stopWatch.Stop();
PrintResult("HeapSort", heapSortData, stopWatch.ElapsedMilliseconds);
// Console.WriteLine($"HeapSorted array: {string.Join(", ", heapSortData)}");
// Console.WriteLine($"Time HeapSort: {stopWatch.ElapsedMilliseconds} milliseconds\n");

// RadixSort:
stopWatch.Restart();
RadixSort.Sort(radixSortData);
stopWatch.Stop();
PrintResult("RadixSort", radixSortData, stopWatch.ElapsedMilliseconds);
// Console.WriteLine($"RadixSorted array: {string.Join(", ", radixSortData)}");
// Console.WriteLine($"Time RadixSort: {stopWatch.ElapsedMilliseconds} milliseconds\n");



// Local helpers
void PrintResult(string name, int[] sortedArray, long ms)
{
    bool isSorted = IsSorted(sortedArray);
    Console.WriteLine($"{name,-15} {ms,5} ms    sorted: {isSorted}    first: {sortedArray[0]}    last: {sortedArray[^1]}");
}

bool IsSorted(int[] arr)
{
    for (int i = 1; i < arr.Length; i++)
    {
        if (arr[i] < arr[i - 1]) return false;
    }
    return true;
}
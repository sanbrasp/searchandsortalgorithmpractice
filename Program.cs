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
Console.WriteLine($"BubbleSorted array: {string.Join(", ", bubbleData)}");
Console.WriteLine($"Time BubbleSort: {stopWatch.ElapsedMilliseconds} milliseconds\n");

// QuickSort:
stopWatch.Restart();
QuickSort.Sort(quickSortData);
stopWatch.Stop();
Console.WriteLine($"QuickSorted array: {string.Join(", ", quickSortData)}");
Console.WriteLine($"Time QuickSort: {stopWatch.ElapsedMilliseconds} milliseconds\n");

// MergeSort:
stopWatch.Restart();
MergeSort.Sort(mergeSortData, 0, mergeSortData.Length -1);
stopWatch.Stop();
Console.WriteLine($"MergeSorted array: {string.Join(", ", mergeSortData)}");
Console.WriteLine($"Time MergeSort: {stopWatch.ElapsedMilliseconds} milliseconds\n");

// InsertionSort:
stopWatch.Restart();
InsertionSort.Sort(insertionSortData);
stopWatch.Stop();
Console.WriteLine($"InsertionSorted array: {string.Join(", ", insertionSortData)}");
Console.WriteLine($"Time InsertionSort: {stopWatch.ElapsedMilliseconds} milliseconds\n");

// SelectionSort
stopWatch.Restart();
SelectionSort.Sort(selectionSortData);
stopWatch.Stop();
Console.WriteLine($"SelectionSorted array: {string.Join(", ", selectionSortData)}");
Console.WriteLine($"Time SelectionSort: {stopWatch.ElapsedMilliseconds} milliseconds\n");

// HeapSort:
stopWatch.Restart();
HeapSort.Sort(heapSortData);
stopWatch.Stop();
Console.WriteLine($"HeapSorted array: {string.Join(", ", heapSortData)}");
Console.WriteLine($"Time HeapSort: {stopWatch.ElapsedMilliseconds} milliseconds\n");

// RadixSort:
stopWatch.Restart();
RadixSort.Sort(radixSortData);
stopWatch.Stop();
Console.WriteLine($"RadixSorted array: {string.Join(", ", radixSortData)}");
Console.WriteLine($"Time RadixSort: {stopWatch.ElapsedMilliseconds} milliseconds\n");
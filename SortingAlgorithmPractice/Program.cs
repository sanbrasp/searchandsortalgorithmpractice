using SortingAlgorithmPractice;
using System.Diagnostics;
using SortingAlgorithmPractice.SortHelpers;

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
SortHelpers.PrintResult("BubbleSort", bubbleData, stopWatch.ElapsedMilliseconds);

// QuickSort:
stopWatch.Restart();
QuickSort.Sort(quickSortData);
stopWatch.Stop();
SortHelpers.PrintResult("QuickSort", quickSortData, stopWatch.ElapsedMilliseconds);

// MergeSort:
stopWatch.Restart();
MergeSort.Sort(mergeSortData, 0, mergeSortData.Length -1);
stopWatch.Stop();
SortHelpers.PrintResult("MergeSort", mergeSortData, stopWatch.ElapsedMilliseconds);

// InsertionSort:
stopWatch.Restart();
InsertionSort.Sort(insertionSortData);
stopWatch.Stop();
SortHelpers.PrintResult("InsertionSort", insertionSortData, stopWatch.ElapsedMilliseconds);

// SelectionSort
stopWatch.Restart();
SelectionSort.Sort(selectionSortData);
stopWatch.Stop();
SortHelpers.PrintResult("SelectionSort", selectionSortData, stopWatch.ElapsedMilliseconds);

// HeapSort:
stopWatch.Restart();
HeapSort.Sort(heapSortData);
stopWatch.Stop();
SortHelpers.PrintResult("HeapSort", heapSortData, stopWatch.ElapsedMilliseconds);

// RadixSort:
stopWatch.Restart();
RadixSort.Sort(radixSortData);
stopWatch.Stop();
SortHelpers.PrintResult("RadixSort", radixSortData, stopWatch.ElapsedMilliseconds);
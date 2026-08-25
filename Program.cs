using SortingAlgorithmPractice;
using System.Diagnostics;

int[] original = [14,3,27,8,19,5]; 
// int[] numbers = [14,3,27,8,19,5];
var stopWatch = new Stopwatch();

int[] bubbleData = (int[])original.Clone();
int[] quickSortData = (int[])original.Clone();
int[] mergeSortData = (int[])original.Clone();

// Bubblesort:
stopWatch.Restart();
Bubblesort.Sort(bubbleData);
stopWatch.Stop();
Console.WriteLine($"BubbleSorted array: {string.Join(", ", bubbleData)}");
Console.WriteLine($"Time BubbleSort: {stopWatch.ElapsedTicks} ticks\n");

// QuickSort:
stopWatch.Restart();
QuickSort.Sort(quickSortData);
stopWatch.Stop();
Console.WriteLine($"QuickSorted array: {string.Join(", ", quickSortData)}");
Console.WriteLine($"Time QuickSort: {stopWatch.ElapsedTicks} ticks\n");

// MergeSort:
stopWatch.Restart();
MergeSort.Sort(mergeSortData, 0, mergeSortData.Length -1);
stopWatch.Stop();
Console.WriteLine($"MergeSorted array: {string.Join(", ", mergeSortData)}");
Console.WriteLine($"Time MergeSort: {stopWatch.ElapsedTicks} ticks\n");
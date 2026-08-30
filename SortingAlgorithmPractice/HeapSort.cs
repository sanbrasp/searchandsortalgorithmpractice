namespace SortingAlgorithmPractice;

public static class HeapSort
{
    public static void Sort(int[] arr)
    {
        int n = arr.Length;
        
        // Build Max Heap
        for (int i = n / 2 - 1; i >= 0; i--)
        {
            Heapify(arr, n, i);
        }
        
        // Extract elements one by one
        for (int i = n - 1; i > 0; i--)
        {
            (arr[0], arr[i]) = (arr[i], arr[0]);
            Heapify(arr, i, 0);
        }
    }

    private static void Heapify(int[] arr, int heapSize, int rootIndex)
    {
        int largest = rootIndex;
        int left = 2 * rootIndex + 1;
        int right = 2 * rootIndex + 2;

        if (left < heapSize && arr[left] > arr[largest])
            largest = left;
        
        if (right < heapSize && arr[right] > arr[largest])
            largest = right;

        if (largest != rootIndex)
        {
            (arr[rootIndex], arr[largest]) = (arr[largest], arr[rootIndex]);
            Heapify(arr, heapSize, largest);
        }
    }
}
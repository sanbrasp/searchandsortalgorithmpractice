namespace SortingAlgorithmPractice;

public static class QuickSort
{
    public static void Sort(int[] arr)
    {
        Sort(arr, 0, arr.Length - 1);
    }

    private static void Sort(int[] arr, int low, int high)
    {
        if (low < high)
        {
            int pivotIndex = Partition(arr, low, high);
            Sort(arr, low, pivotIndex - 1);
            Sort(arr, pivotIndex + 1, high);
        }
    }

    private static int Partition(int[] arr, int low, int high)
    {
        int pivot = arr[high];
        int boundary = low - 1; // last index known to hold a value smaller than pivot

        for (int current = low; current < high; current++)
        {
            if (arr[current] < pivot)
            {
                boundary++;
                (arr[boundary], arr[current]) = (arr[current], arr[boundary]);
            }
        }

        (arr[boundary + 1], arr[high]) = (arr[high], arr[boundary + 1]);
        return boundary + 1;
    }
}
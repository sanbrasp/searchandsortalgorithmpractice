namespace SortingAlgorithmPractice;

public static class RadixSort
{
    public static void Sort(int[] arr)
    {
        if (arr.Length == 0) return;
        
        int max = arr[0];
        foreach (int value in arr)
        {
            if (value > max)
                max = value;
        }

        for (int exp = 1; max / exp > 0; exp *= 10)
        {
            CountingSortByDigit(arr, exp);
        }
    }

    private static void CountingSortByDigit(int[] arr, int exp)
    {
        int n = arr.Length;
        int[] output = new int[n];
        int[] count = new int[10];

        foreach (int value in arr)
        {
            int digit = (value / exp) % 10;
            count[digit]++;
        }
        
        for (int i = 1; i < 10; i++)
        {
            count[i] += count[i - 1];
        }

        for (int i = n - 1; i >= 0; i--)
        {
            int digit = (arr[i] / exp) % 10;
            output[count[digit] - 1] = arr[i];
            count[digit]--;
        }

        for (int i = 0; i < n; i++)
        {
            arr[i] = output[i];
        }
    }
}
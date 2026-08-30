namespace SortingAlgorithmPractice;

/// <summary>
/// The Bubblesort sorting algorithm - Do not use in real code! Only for learning.
/// </summary>
public static class Bubblesort
{
    public static void Sort(int[] number)
    {
        for (int round = 0; round < number.Length; round++)
        {
            for (int i = 0; i < number.Length -1; i++)
            {
                if (number[i] > number[i + 1])
                {
                    (number[i], number[i + 1]) = (number[i + 1], number[i]);

                    //Console.WriteLine($"Switching numbers: {string.Join(", ", number)}");
                }
            }
        }
    }
}
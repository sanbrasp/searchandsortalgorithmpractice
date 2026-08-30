using SearchAlgorithmPractice.Models;

namespace SearchAlgorithmPractice.Helpers;

internal static class SearchHelpers
{
    internal static SearchResult<T> LinearSearch<T>(T target, IEnumerable<T> array)
    {
        var comparer = EqualityComparer<T>.Default;
        int index = 0;

        foreach (var item in array)
        {
            if (comparer.Equals(item, target))
            {
                return new SearchResult<T>(true, index, item);
            }
            index++;
        }

        return new SearchResult<T>(false, -1, default);
    }

    internal static SearchResult<T> BinarySearch<T>(T target, IReadOnlyList<T> array)
    {
        var comparer = Comparer<T>.Default;

        int left = 0;
        int right = array.Count - 1; // because array indices start at 0, so you need the - 1 to get the valid end indice

        while (left <= right)
        {
            int mid = (right + left) / 2;
            
            int comparison = comparer.Compare(array[mid], target);
            
            if (comparison == 0)
            {
                return new SearchResult<T>(true, mid, array[mid]);
            }
            if (comparison < 0)
            {
                left = mid + 1; // target is to the right of mid (smaller than target)
            }

            if (comparison > 0)
            {
                right = mid - 1; // target is to the left of mid (bigger than target)
            }
        }
        return new SearchResult<T>(false, -1, default);
    }
}
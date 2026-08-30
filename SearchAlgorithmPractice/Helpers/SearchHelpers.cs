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
        throw new NotImplementedException();
    }
}
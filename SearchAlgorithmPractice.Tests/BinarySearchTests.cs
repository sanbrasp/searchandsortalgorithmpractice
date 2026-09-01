using SearchAlgorithmPractice.Search;
using Xunit;

namespace SearchAlgorithmPractice.Tests;

public class BinarySearchTests
{
    [Fact]
    public void BinarySearchTest_FindsExistingElement()
    {
        int[] numbers = { 3, 7, 12, 19, 25 };

        var result = SearchAlgorithms.BinarySearch(12, numbers);

        Assert.True(result.Found);
        Assert.Equal(2, result.Index);
        Assert.Equal(12, result.Value);
    }

    [Fact]
    public void BinarySearchTest_ReturnsNotFound_WhenElementMissing()
    {
        int[] numbers = { 3, 7, 12, 19, 25 };
        
        var result = SearchAlgorithms.BinarySearch(99, numbers);
        
        Assert.False(result.Found);
        Assert.Equal(-1, result.Index);
    }
    
    [Fact]
    public void BinarySearchTest_ReturnsNotFound_WhenEmptyCollection()
    {
        int[] numbers = { };
        
        var result = SearchAlgorithms.BinarySearch(5, numbers);
        
        Assert.False(result.Found);
        Assert.Equal(-1, result.Index);
    }

    [Fact]
    public void BinarySearchTest_FindsElement_AtFirstIndex()
    {
        int[] numbers = { 3, 7, 12, 19, 25 };
        
        var result = SearchAlgorithms.BinarySearch(3, numbers);
        
        Assert.True(result.Found);
        Assert.Equal(0, result.Index);
    }

    [Fact]
    public void BinarySearchTest_FindsElement_AtLastIndex()
    {
        int[] numbers = { 3, 7, 12, 19, 25 };
        
        var result = SearchAlgorithms.BinarySearch(25, numbers);
        
        Assert.True(result.Found);
        Assert.Equal(4, result.Index);
    }

    [Fact]
    public void BinarySearchTest_MayAccidentallySucceed_OnCertainUnsortedArrays()
    {
        int[] luckyArray = { 3, 25, 7, 19, 12 };
        
        var result = SearchAlgorithms.BinarySearch(7, luckyArray);
        
        Assert.True(result.Found); // works here, but only by coincidence
    }

    [Fact]
    public void BinarySearchTest_MayFail_OnDifferentUnsortedArray_WithSameTarget()
    {
        int[] unLuckyArray = { 25, 3, 19, 7, 12 };
        
        var result = SearchAlgorithms.BinarySearch(7, unLuckyArray);
        
        Assert.False(result.Found); // fails here, due to violated precondition of sorted array
    }
}
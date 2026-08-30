using SearchAlgorithmPractice.Helpers;
using Xunit;

namespace SearchAlgorithmPractice.Tests;

public class LinearSearchTests
{
    [Fact]
    public void LinearSearchTest_FindsExistingElement()
    {
        int[] numbers = { 3, 7, 12, 19, 25 };

        var result = SearchHelpers.LinearSearch(12, numbers);
        
        Assert.True(result.Found);
        Assert.Equal(2, result.Index);
        Assert.Equal(12, result.Value);
    }

    [Fact]
    public void LinearSearchTest_ReturnsNotFound_WhenElementMissing()
    {
        int[] numbers = { 3, 7, 12, 19, 25 };
        
        var result = SearchHelpers.LinearSearch(99, numbers);
        
        Assert.False(result.Found);
        Assert.Equal(-1, result.Index);
    }

    [Fact]
    public void LinearSearchTest_ReturnsNotFound_WhenEmptyCollection()
    {
        int[] numbers = { };
        
        var result = SearchHelpers.LinearSearch(5, numbers);
        
        Assert.False(result.Found);
        Assert.Equal(-1, result.Index);
    }

    [Fact]
    public void LinearSearchTest_FindsElement_AtFirstIndex()
    {
        int[] numbers = { 3, 7, 12, 19, 25 };
        
        var result = SearchHelpers.LinearSearch(3, numbers);
        
        Assert.True(result.Found);
        Assert.Equal(0, result.Index);
    }

    [Fact]
    public void LinearSearchTest_FindsElement_AtLastIndex()
    {
        int[] numbers = { 3, 7, 12, 19, 25 };
        
        var result = SearchHelpers.LinearSearch(25, numbers);
        
        Assert.True(result.Found);
        Assert.Equal(4, result.Index);
    }

    [Fact]
    public void LinearSearchTest_FindsExistingElement_WhenArrayIsUnsorted()
    {
        int[] numbers = { 25, 3, 19, 7, 12 }; // deliberately unsorted for the test
        
        var result = SearchHelpers.LinearSearch(7, numbers);
        
        Assert.True(result.Found);
        Assert.Equal(3, result.Index); // sits at index 3
        Assert.Equal(7, result.Value);
    }
}
using SearchAlgorithmPractice.Search;

namespace SearchAlgorithmPractice.Tests;

public class DfsTests
{
    [Fact]
    public void Dfs_EmptyGraph_ReturnsEmptyList()
    {
        // Arrange
        var graph = new Dictionary<string, List<string>>(); // empty list

        // Act
        var result = SearchAlgorithms.Dfs(graph, "A");

        // Assert
        Assert.Empty(result); // empty list, no results.
    }

    [Fact]
    public void Dfs_StartNodeNotInGraph_ReturnsEmptyList()
    {
        // Arrange
        var graph = new Dictionary<string, List<string>>
        {
            { "A", new List<string> { "B", "C" } },
            { "B", new List<string> { "D" }}
        };
        
        // Act
        var result = SearchAlgorithms.Dfs(graph, "E");
        
        // Assert
        Assert.Empty(result);
    }

    [Fact]
    public void Dfs_SingleNodeNoEdges_ReturnsOnlyThatNode()
    {
        // Arrange
        var graph = new Dictionary<string, List<string>>
        {
            { "A", new List<string>() } // key = A, empty value list
        };
        
        // Act
        var result = SearchAlgorithms.Dfs(graph, "A");
        
        // Assert
        Assert.Single(result);
    }

    [Fact]
    public void Dfs_GraphWithCycle_TerminatesAndVisitsEachNodeOnce()
    {
        // Arrange
        var graph = new Dictionary<string, List<string>>
        {
            { "A", new List<string> { "B", "C" } },
            { "B", new List<string> { "A" } },
            { "C", new List<string> { "A", "B" } }
        };

        // Act
        var result = SearchAlgorithms.Dfs(graph, "A");

        // Assert
        Assert.Equal(new List<string> { "A", "B", "C" }, result);
    }

    [Fact]
    public void Dfs_NodeWithMultipleNeighbors_ReturnsExpectedOrder()
    {
        // Arrange
        var graph = new Dictionary<string, List<string>>
        {
            { "A", new List<string> { "B", "C" } },
            { "B", new List<string> { "D" } },
            { "C", new List<string> { "D" } },
            { "D", new List<string> { "E" } }
        };

        // Act
        var result = SearchAlgorithms.Dfs(graph, "A");

        // Assert
        Assert.Equal(new List<string> { "A", "B", "D", "E", "C" }, result);
    }

    [Fact]
    public void Dfs_DisconnectedGraph_OnlyReachesStartingComponent()
    {
        // Arrange
        var graph = new Dictionary<string, List<string>>
        {
            { "A", new List<string> { "B" } }, // disconnected components
            { "X", new List<string> { "Y" } }
        };

        // Act
        var result = SearchAlgorithms.Dfs(graph, "A");

        // Assert
        Assert.Equal(new List<string> { "A", "B" }, result);
    }
}
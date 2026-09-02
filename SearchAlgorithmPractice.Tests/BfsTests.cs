using SearchAlgorithmPractice.Search;

namespace SearchAlgorithmPractice.Tests;

public class BfsTests
{
    [Fact]
    public void Bfs_EmptyGraph_ReturnsEmptyList()
    {
        // Arrange
        var graph = new Dictionary<string, List<string>>(); // empty list

        // Act
        var result = SearchAlgorithms.Bfs(graph, "A"); // target result list
        
        // Assert
        Assert.Empty(result); // asert the list to be empty
    }
    
    [Fact]
    public void Bfs_StartNodeNotInGraph_ReturnsEmptyList()
    {
        // Arrange
        var graph = new Dictionary<string, List<string>>
        {
            { "A", new List<string> { "B", "C" } },
            { "B", new List<string> { "D" }}
        };

        // Act
        var result = SearchAlgorithms.Bfs(graph, "E");

        // Assert
        Assert.Empty(result);
    }

    [Fact]
    public void Bfs_SingleNodeNoEdges_ReturnsOnlyThatNode()
    {
        // Arrange
        var graph = new Dictionary<string, List<string>>
        {
            { "A", new List<string>() } // key value pair, key A, with an empty value list
        };

        // Act
        var result = SearchAlgorithms.Bfs(graph, "A");

        // Assert
        Assert.Single(result);
    }

    [Fact]
    public void Bfs_GraphWithCycle_TerminatesAndVisitsEachNodeOnce()
    {
        // Arrange
        var graph = new Dictionary<string, List<string>>
        {
            { "A", new List<string> { "B" } }, // directed edges: A -> B, B -> A form a cycle
            { "B", new List<string> { "A" } }
        };

        // Act
        var result = SearchAlgorithms.Bfs(graph, "A");

        // Assert
        Assert.Equal(new List<string> { "A", "B" }, result);
    }

    [Fact]
    public void Bfs_NodeWithMultipleNeighbors_ReturnsExpectedOrder()
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
        var result = SearchAlgorithms.Bfs(graph, "A");

        // Assert
        Assert.Equal(new List<string> { "A", "B", "C",  "D", "E" }, result);
    }

    [Fact]
    public void Bfs_DisconnectedGraph_OnlyReachesStartingComponent()
    {
        // Arrange
        var graph = new Dictionary<string, List<string>>
        {
            { "A", new List<string> { "B" }}, // two entirely disconnected components
            { "X", new List<string> { "Y" }}
        };

        // Act
        var result = SearchAlgorithms.Bfs(graph, "A");

        // Assert
        Assert.Equal(new List<string> { "A", "B" }, result);
    }
}
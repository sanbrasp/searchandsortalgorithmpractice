namespace GraphPractice.Models;

/// <summary>
/// Generic graph blueprint for testability in this practice project.
/// </summary>
/// <typeparam name="T">Generic collection type.</typeparam>
internal class Graph<T> where T : notnull // dictionary key can never be null
{
    private readonly Dictionary<T, List<T>> _adjacencyList = new();


    internal void AddNode(T node)
    {
        if (!_adjacencyList.ContainsKey(node))
        {
            _adjacencyList[node] = new List<T>();
        }
    }
    
    internal void AddEdge(T from, T to)
    {
        AddNode(from);
        AddNode(to);
        
        _adjacencyList[from].Add(to); // Directed - one-directional
    }

    internal List<T> GetNeighbors(T node)
    {
        return _adjacencyList.TryGetValue(node, out var neighbors)
            ? new List<T>(neighbors)
            : new List<T>();
    }

    internal bool ContainsNode(T node)
    {
        return _adjacencyList.ContainsKey(node);
    }
}
using GraphPractice.Models;
using SearchAlgorithmPractice.Search;

namespace GraphPractice;

class Program
{
    static void Main(string[] args)
    {
        var graph = new Graph<string>();
        graph.AddEdge("A", "B");
        graph.AddEdge("A", "C");
        graph.AddEdge("B", "D");
        graph.AddEdge("C", "D");
        graph.AddEdge("D", "E");

        var bfsResult = SearchAlgorithms.Bfs(graph.GetAdjacencyList(), "A");
        var dfsResult = SearchAlgorithms.Dfs(graph.GetAdjacencyList(), "A");

        Console.WriteLine("BFS:" + string.Join(", ", bfsResult));
        Console.WriteLine("DFS:" + string.Join(", ", dfsResult));

        // Console.WriteLine(string.Join(", ", graph.GetNeighbors("A"))); // Returns B and C
        // Console.WriteLine(graph.ContainsNode("D")); // Returns true
        // Console.WriteLine(graph.ContainsNode("Z")); // Returns false
    }
}
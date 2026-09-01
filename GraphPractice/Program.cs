using GraphPractice.Models;

namespace GraphPractice;

class Program
{
    static void Main(string[] args)
    {
        var graph = new Graph<string>();
        graph.AddEdge("A", "B");
        graph.AddEdge("A", "C");
        graph.AddEdge("B", "D");

        Console.WriteLine(string.Join(", ", graph.GetNeighbors("A"))); // Returns B and C
        Console.WriteLine(graph.ContainsNode("D")); // Returns true
        Console.WriteLine(graph.ContainsNode("Z")); // Returns false
    }
}
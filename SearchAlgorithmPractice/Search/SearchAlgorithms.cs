namespace SearchAlgorithmPractice.Search;

internal static class SearchAlgorithms
{
    /// <summary>
    /// Runs a linear search on any array (sorted or unsorted). Searches for a specific target, and is
    /// written to also return the index of that target since that does not come built-in.
    /// </summary>
    /// <param name="target">The element to search for.</param>
    /// <param name="array">The array to search for the element in.</param>
    /// <typeparam name="T">Generic type.</typeparam>
    /// <returns>Search result if found, -1 if not found.</returns>
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

    /// <summary>
    /// Runs a binary search on a sorted array. Searches for specific target and gives the index if found.
    /// </summary>
    /// <param name="target">The element to search for.</param>
    /// <param name="array">The array to search for the target in.</param>
    /// <typeparam name="T">Generic type.</typeparam>
    /// <returns>Target and index if found, -1 if not found.</returns>
    internal static SearchResult<T> BinarySearch<T>(T target, IReadOnlyList<T> array)
    {
        var comparer = Comparer<T>.Default;

        int left = 0;
        int right = array.Count - 1; // because array indices start at 0, so you need the - 1 to get the valid end indice

        while (left <= right)
        {
            int mid = (right + left) / 2;
            
            int comparison = comparer.Compare(array[mid], target);
            
            switch (comparison)
            {
                case 0:
                    return new SearchResult<T>(true, mid, array[mid]);
                case < 0:
                    left = mid + 1; // target is to the right of mid (smaller than target)
                    break;
                case > 0:
                    right = mid - 1; // target is to the left of mid (bigger than target)
                    break;
            }
        }
        return new SearchResult<T>(false, -1, default);
    }

    /// <summary>
    /// Runs a breadth-first search starting from a given node, exploring the graph
    /// layer by layer using a FIFO queue. Returns nodes in the order they were visited.
    /// </summary>
    /// <param name="adjacencyList">The graph, represented as a dictionary mapping each node to its neighbors.</param>
    /// <param name="startNode">The node to begin traversal from.</param>
    /// <typeparam name="T">Generic type.</typeparam>
    /// <returns>A list of nodes in the order they were visited. Empty if startNode isn't in the graph.</returns>
    internal static List<T> Bfs<T>(Dictionary<T, List<T>> adjacencyList, T startNode) where T : notnull
    {
        if (!adjacencyList.ContainsKey(startNode))
        {
            return new List<T>();
        }

        var visited = new HashSet<T>(); // for storing visited nodes
        var queue = new Queue<T>(); // for queueing nodes
        var result = new List<T>(); // for storing the result

        visited.Add(startNode);
        queue.Enqueue(startNode);

        while (queue.Count > 0) // keep going as long as someone is waiting in the queue
        {
            var current = queue.Dequeue(); // gives you the first node, removes it from the queue
            result.Add(current); // "current" has been processed, and is added to result list which stores visit order
            
            if (adjacencyList.TryGetValue(current, out var neighbors))
            {
                foreach (var neighbor in neighbors) // look up "current"s neighbors. 
                {
                    if (!visited.Contains(neighbor)) // if it hasn't been visited, it's added. if it has, it's skipped.
                    {
                        visited.Add(neighbor); // new neighbors are marked as visited immediately
                        queue.Enqueue(neighbor); // new neighbors are added to the back of the queue
                    }
                }
            }
        }
        return result;
    }

    /// <summary>
    /// Runs a depth-first search starting from a given node, exploring as far down as possible on each branch
    /// before backtracking. Returns nodes in the order they were visited.
    /// </summary>
    /// <param name="adjacencyList">The graph, represented as a dictionary mapping each node to its neighbors.</param>
    /// <param name="startNode">The node to begin traversal from.</param>
    /// <typeparam name="T">Generic type.</typeparam>
    /// <returns>A list of nodes in the order they were visited. Empty if startNode isn't in the graph.</returns>
    internal static List<T> Dfs<T>(Dictionary<T, List<T>> adjacencyList, T startNode) where T : notnull
    {
        if (!adjacencyList.ContainsKey(startNode))
        {
            return new List<T>();
        }

        var visited = new HashSet<T>();
        var result = new List<T>();
        
        DfsVisit(adjacencyList, startNode, visited, result);
        
        return result;
    }

    /// <summary>
    /// Recursive helper for Dfs. Visits a single node, records it, then recurses into each
    /// unvisited neighbor.
    /// </summary>
    private static void DfsVisit<T>(Dictionary<T, List<T>> adjacencyList, T node, HashSet<T> visited,
        List<T> result) where T : notnull
    {
        visited.Add(node);
        result.Add(node);

        if (adjacencyList.TryGetValue(node, out var neighbors))
        {
            foreach (var neighbor in neighbors)
            {
                if (!visited.Contains(neighbor))
                {
                    DfsVisit(adjacencyList, neighbor, visited, result);
                }
            }
        }
    }
}
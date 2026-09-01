# Notes about this project

---

This is just a practice project for the course in Backend Programming at `Gokstad Akademiet`, year 2, semester 1.

Its purpose is practicing search algorithms.

---

## SearchHelper.SearchHelpers
- `LinearSearch()`
- `BinarySearch()`

---

## Notes about the methods

**`LinearSearch()` and `BinarySearch` parameters**  

`LinearSearch()` method takes `IEnumerable<T>` as it doesn't _need_ indexing (but it can be added manually with a counter).   
This was chosen to better signal the differences between Linear and Binary Search, even though it could also have taken 
`IReadOnlyList<T>` like `BinarySearch()`.


**`Dfs()`**  
The example from the lecture used an elegant and short version:  
```csharp
void DFS(Graf graf, string node, HashSet<string> besøkt)
{
    besøkt.Add(node);
    Console.WriteLine(node);
    
    foreach(var nabo in graf[node])
        if (!besøkt.Contains(nabo))
            DFS(graf, nabo, besøkt);
}

// Call
DFS(graf, "A", new HashSet<string>());
```

The version in this project uses a private recursive helper method for the traversal, and a public
entry point (Dfs) that handles setup.  
The reasoning for this is that the example from the lecture requires every caller to remember to 
pass in a fresh `HashSet` at the call site.  
Writing and using the helper method removes that requirement, making it easier to call, and it also 
removes the risk of reusing an old `HashSet` if the caller forgets to pass in a new one.

The end result is the same, it's just a choice between remembering the new `HashSet`, or writing a helper 
method that allows you to omit that part of the call.

---

## About search results

Search results are point-in-time snapshots, and not live references.  
The search's job is to find the item at the index where it lived at the time of the search.  
This might change if the array has been updated _after_ the search, and is something to consider 
during design.

---


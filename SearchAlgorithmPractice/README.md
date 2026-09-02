# SearchAlgorithmPractice

Implementations of `Linear Search` and `Binary Search` in C#, built as part of Week 35
(Search Algorithms) coursework. (`Gokstad Akademiet, backend programming year 2`)

**_For algorithm theory, analogies, etc., see [notes.md](notes.md)_**

---

## `SearchResult<T>`

Both `linear` and `binary` algorithms return a shared `record`:

```csharp
public record SearchResult<T>(bool Found, int Index, T? Value);
```

**Why a record, not a class or struct:**  
a search result is a point-in-time snapshot —
"where was the target when I searched," not a live reference to the collection. Records
give value-based equality and easy immutability for free, which fits a snapshot's
semantics better than a mutable class. A struct was considered but rejected: structs suit
small, simple, copy-like data (e.g. `Point(x, y)`) rather than a result type meant to be
returned and passed around like a distinct object.

**Not-found convention:**  
`Found = false`, `Index = -1`, `Value = default`. `-1` matches
the common .NET convention (`Array.IndexOf`, etc.). `T?` lets `default` mean "no value" in
a type-safe way for both reference types (`null`) and value types (`Nullable<T>`), instead
of risking confusion with a legitimately found value of `0` or similar.

**Important caveat:** a `SearchResult<T>` is only accurate as of the moment the search ran.
If the underlying collection is mutated afterward (e.g. an item is moved to a different
index), the stored `Index` can become stale. The record doesn't track or protect against
this — that responsibility sits with the calling code.

---

## LinearSearch

```csharp
internal static SearchResult<T> LinearSearch<T>(T target, IEnumerable<T> array)
```

- Takes `IEnumerable<T>` — deliberately minimal, since Linear Search only ever needs to
  iterate once, in order. It never needs to index or jump around, so the extra
  capabilities of `IReadOnlyList<T>` would go unused (YAGNI).
- Compares elements using `EqualityComparer<T>.Default`, so it works correctly for any
  `T` — value types, strings, and custom classes (as long as `Equals` is implemented
  sensibly for the latter).
- Does not require sorted input — order is irrelevant to how it searches, which is the
  whole trade-off against Binary Search's speed.

---

## BinarySearch

```csharp
internal static SearchResult<T> BinarySearch<T>(T target, IReadOnlyList<T> array)
```

- Takes `IReadOnlyList<T>`, not `IEnumerable<T>` — Binary Search needs to jump directly to
  an arbitrary index (`array[mid]`) at every step, which `IEnumerable<T>` alone can't
  provide efficiently.
- Compares elements using `Comparer<T>.Default.Compare(a, b)`, which returns negative /
  zero / positive to indicate ordering — the generic equivalent of `<`, `==`, `>` for any
  comparable `T`.
- **Requires the array to be sorted in ascending order.** The algorithm halves the search
  range each step by trusting that "smaller than mid" means "must be to the left" — this
  assumption only holds if the data is actually sorted that way.

**What happens on unsorted input:**  
Binary Search does **not** fail loudly or predictably on unsorted data — it fails
*silently and inconsistently*. Whether it happens to find the target or not depends
entirely on where the target happens to land relative to the pivot points the algorithm
chooses — pure coincidence of array arrangement, not a property you can rely on.

Two tests in `BinarySearchTests.cs` demonstrate this directly: the same target searched
in two differently-arranged (both unsorted) versions of the same values produces one
"success" and one "failure" — proving the algorithm offers no real guarantee either way
once the sorted precondition is violated.

---

## BFS - Breadth-First Search
```csharp
internal static List<T> Bfs<T>(Dictionary<T, List<T>> adjacencyList, T startNode) where T : notnull
```

- Takes the graph as a plain `Dictionary<T, List<T>>` rather than a custom `Graph<T>` type.
  This keeps `SearchAlgorithmPractice` independent of `GraphPractice`, avoiding a circular project reference.
  (GraphPractice depends on SearchAlgorithmPractice, not the other way).
- Returns nodes in the order visited using a `Queue<T>` (FIFO) and a `HashSet<T>` visited set.
- Guards against a missing start node (returns empty list), and against neighbor lookups on nodes 
  with no adjacency-list entry (e.g., dead-end nodes) using `TryGetValue` instead of the dictionary
  indexer to avoid a `KeyNotFoundException`

---

## DFS - Depth-First Search
```csharp
internal static List<T> Dfs<T>(Dictionary<T, List<T>> adjacencyList, T startNode) where T : notnull
```

- Same parameter shape and guard as `Bfs()` for consistency.
- Recursive: entry point (`Dfs()`) sets up `visited / result` then delegates to a private helper (`DfsVisit`)
  that performs the actual depth-first recursion.

**Design Note**  
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

## Testing

Both algorithms are tested against the same four edge cases:
- A value that exists (hit)
- A value that doesn't exist (miss)
- An empty collection
- The first and last valid indices (boundary conditions)

`BinarySearch` has an additional pair of tests demonstrating unreliable behavior on
unsorted input (see above).

---

**_This document was generated by Claude.ai from my instructions and then tweaked and confirmed by me._**
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

---

## About search results

Search results are point-in-time snapshots, and not live references.  
The search's job is to find the item at the index where it lived at the time of the search.  
This might change if the array has been updated _after_ the search, and is something to consider 
during design.

---


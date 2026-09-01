namespace SearchAlgorithmPractice.Search;

public record SearchResult<T>(bool Found, int Index, T? Value);
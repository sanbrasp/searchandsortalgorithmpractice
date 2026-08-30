namespace SearchAlgorithmPractice.Models;

public record SearchResult<T>(bool Found, int Index, T? Value);
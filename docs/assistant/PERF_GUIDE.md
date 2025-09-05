# Performance Guidelines (Safe for .NET 4.7.1)

- Use StringBuilder for repeated concatenations in loops.
- Pre-size List<T> if count is known.
- Cache dictionary/indexer lookups to local vars.
- Prefer TryParse over try/catch parsing.
- Reuse objects when possible; avoid unnecessary allocations.
- Use foreach unless index-based for loops are faster in hot paths.
- Avoid LINQ in tight loops if allocations become costly.
- Do not use Span<T>, ValueTask, or newer .NET APIs (not supported).

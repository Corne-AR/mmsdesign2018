# Safe Refactoring Rules

## Always Safe
- Add argument guards (null, empty string, invalid IDs).
- Rename private/local variables for clarity.
- Extract private helper methods (no public API changes).
- Use early returns to reduce nesting.
- Replace try/catch parse with TryParse if equivalent.
- Use using() blocks for disposables.

## Needs User Approval
- Changing algorithms.
- Modifying public APIs (class/method/parameters).
- Changing exception types/messages.
- Altering file IO or sync logic.
- Refactoring across multiple projects.

## Off-Limits
- Editing *.Designer.cs, Resources.Designer.cs, Settings.Designer.cs.
- Retargeting to .NET 4.8+ or adding new C# features.

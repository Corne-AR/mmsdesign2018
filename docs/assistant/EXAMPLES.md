Example: Argument guard (no logic change)

File: MMS Design/Services/InvoiceService.cs
Anchor: public Invoice GetById(int id)
Lines: ~42–70

Before (excerpt):
public Invoice GetById(int id)
{
    return _repo.Load(id);
}

After:
public Invoice GetById(int id)
{
    // ChatGPT: argument guard to prevent meaningless DB lookup and clearer exception
    if (id <= 0) throw new ArgumentOutOfRangeException(nameof(id), "Id must be positive.");
    return _repo.Load(id);
}

Why:
- Prevents invalid calls early.
- No public API change; behaviour for valid inputs unchanged.

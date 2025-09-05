# MMS Design – Coding Style

## Language
- Target: **C# 7.3 max** (.NET Framework 4.7.1)
- No C# 8+ features (switch expressions, nullable refs, records, ranges, etc.)

## Naming
- Classes: PascalCase (InvoiceService)
- Methods: PascalCase (GetById)
- Private fields: underscore + camelCase (_cache)
- Local vars: camelCase
- Constants: PascalCase

## Error handling
- Use try/catch around external IO (file, network).
- Preserve exception messages unless clarified by user.
- Use `ArgumentNullException`, `ArgumentOutOfRangeException`, or `ArgumentException` for guards.

## Logging
- Prefer explicit exception messages.
- Keep existing log text unchanged unless clarified.

## Comments
- Changes from assistant must include `// ChatGPT:` explanation after modified lines.

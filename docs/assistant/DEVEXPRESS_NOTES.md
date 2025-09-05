# DevExpress & WinForms Notes

- Version: DevExpress v17 (only stable in VS2017).
- Designer files (*.Designer.cs) must not be edited manually.
- Safe changes:
  - Update label text, fonts, anchors, docking in Designer.
  - Adjust layout properties in forms.
- Risky changes:
  - Binding expressions.
  - Report definitions (must test in VS2017).
- Reports:
  - Keep DevExpress reports designed in VS2017.
  - Assistant may suggest code-based tweaks (e.g., parameter guards) but user validates in 2017.

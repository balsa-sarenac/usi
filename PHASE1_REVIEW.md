Phase 1 Review - WPF PDF -> LaTeX (structure preserved)

Goal
- Extract the existing PDF's structure and text into a maintainable LaTeX source.
- Do NOT rewrite content to Avalonia yet; just annotate what will change later.

What I produced
- AvaloniaMateriali/main.tex
  - Contains the original WPF text reorganized into LaTeX sections/subsections.
  - Each major section has a "Migration note (Phase 1)" indicating Keep/Rewrite/Replace.
  - All figures are placeholders pointing to AvaloniaMateriali/assets/slika-*.png.

What is intentionally NOT done yet
- No Avalonia/Rider rewrite.
- No screenshots extracted/imported.
- No new sample project referenced.

Open items to confirm in your review
- Document title: the file name says "Vezbe 4" but the PDF title page says "Vežbe 3"; main.tex uses "Vežbe 3" as in the PDF.
- Section ordering: kept to match the narrative flow in the PDF.
- Figures: placeholders only; we can either (1) re-capture in Rider, or (2) extract existing ones as temporary placeholders.

Next (Phase 2+)
- Replace WPF tooling chapters with Rider + Avalonia templates steps.
- Convert all code snippets to Avalonia equivalents.
- Update binding defaults notes (WPF vs Avalonia) and replace WPF docs links.

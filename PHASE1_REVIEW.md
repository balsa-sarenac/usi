Migration Review - WPF PDF -> Avalonia LaTeX

Phase 1 (done)
- Extracted the existing PDF's structure/text into a maintainable LaTeX source.
- Kept the original section ordering and narrative.
- Added migration notes and figure placeholders (assets/slika-*.png).

Phase 2 (in progress)
- Rewrote the tooling/setup parts to target Rider + cross-platform Avalonia.
- Updated:
  - Uvod u Avalonia
  - Kreiranje Avalonia projekta (Rider)
  - Markup i code-behind (Rider workflow, .axaml/.axaml.cs, preview via AvaloniaRider plugin)
- main.pdf is regenerated from main.tex after changes (pdflatex).

Still pending (next phases)
- Migrate the remaining WPF-specific content (events UI, XAML namespaces, code-behind APIs, MessageBox, docs links).
- Replace placeholders with Rider screenshots and update figure captions if needed.
- Update code snippets to match the new sample project you will provide.

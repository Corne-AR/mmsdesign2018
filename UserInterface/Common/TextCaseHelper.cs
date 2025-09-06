using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace UserInterface.Common
{
    /// <summary>
    /// Applies smart title casing with data-driven overrides and acronym handling.
    /// Rules are read from TextCaseLibrary.Data.
    /// Supported lines in the data file:
    ///   - "key:value"       => override token casing (match case-insensitively by token, apply value verbatim)
    ///   - "#ACRONYM:x"      => force-uppercase token "x" (after dot-removal, e.g., "p.o" -> "po")
    ///   - "#NOACRONYM:x"    => never force-uppercase token "x" (title-case or rule applies)
    /// Lines starting with "///" are comments.
    /// </summary>
    public static class TextCaseHelper
    {
        private static readonly object _sync = new object();
        private static volatile Dictionary<string, string> _rules;           // ChatGPT: lowercase token -> desired casing
        private static volatile HashSet<string> _acronyms;                   // ChatGPT: tokens to force UPPER
        private static volatile HashSet<string> _noAcronyms;                 // ChatGPT: tokens to never force UPPER
        private static volatile bool _loaded;

        private static readonly Regex _multiSpace = new Regex(@"\s+", RegexOptions.Compiled);

        public static string ApplySmartTitleCase(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return input;

            EnsureRulesLoaded();

            // ChatGPT: trim + collapse whitespace
            var normalized = _multiSpace.Replace(input.Trim(), " ");
            var tokens = normalized.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < tokens.Length; i++)
            {
                // ChatGPT: remove dots inside token for acronym handling (e.g., "P.O" -> "PO", "a.b.c" -> "abc")
                var raw = tokens[i];
                var work = RemoveDots(raw);
                var lower = work.ToLowerInvariant();

                // 1) Exact rule override always wins (e.g., "de" -> "de", "(pty)" -> "(Pty)")
                string overrideValue;
                if (_rules.TryGetValue(lower, out overrideValue))
                {
                    tokens[i] = overrideValue;
                    continue;
                }

                // 2) Explicit acronym directive (e.g., "#ACRONYM:po" -> "PO")
                if (_acronyms.Contains(lower))
                {
                    tokens[i] = work.ToUpperInvariant();
                    continue;
                }

                // 3) Explicit no-acronym directive (e.g., "#NOACRONYM:van") -> title case
                if (_noAcronyms.Contains(lower))
                {
                    tokens[i] = TitleCaseToken(work);
                    continue;
                }

                // 4) Fallback: short alphabetic tokens (<=3) become uppercase (e.g., "abc" -> "ABC")
                //    ONLY if not blocked by rule or #NOACRONYM
                if (work.Length <= 3 && work.All(char.IsLetter))
                {
                    tokens[i] = work.ToUpperInvariant();
                    continue;
                }

                // 5) Default: title-case (handles hyphenated parts)
                tokens[i] = TitleCaseToken(work);
            }

            return string.Join(" ", tokens);
        }

        /// <summary>
        /// Returns true if a token (case-insensitive) has a direct rule override.
        /// </summary>
        public static bool HasOverride(string token)
        {
            if (string.IsNullOrWhiteSpace(token))
                return false;

            EnsureRulesLoaded();
            return _rules != null && _rules.ContainsKey(token.ToLowerInvariant());
        }

        /// <summary>
        /// Forces the helper to reload rules on next use.
        /// </summary>
        public static void ReloadRules()
        {
            lock (_sync)
            {
                _loaded = false; // ChatGPT: next EnsureRulesLoaded will re-read the file
            }
        }

        private static void EnsureRulesLoaded()
        {
            if (_loaded)
                return;

            lock (_sync)
            {
                if (_loaded)
                    return;

                var rules = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
                var acronyms = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
                var noAcronyms = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

                try
                {
                    var dataPath = ResolveDataPath(); // ChatGPT: robustly resolve file path (handles your absolute location too)

                    if (!string.IsNullOrEmpty(dataPath) && File.Exists(dataPath))
                    {
                        var lines = File.ReadAllLines(dataPath, Encoding.UTF8);
                        for (int li = 0; li < lines.Length; li++)
                        {
                            var line = lines[li];
                            if (line == null)
                                continue;

                            line = line.Trim();
                            if (line.Length == 0 || line.StartsWith("///"))
                                continue;

                            // Directives first
                            if (line.StartsWith("#ACRONYM:", StringComparison.OrdinalIgnoreCase))
                            {
                                var val = line.Substring(9).Trim();
                                if (val.Length > 0)
                                    acronyms.Add(val.ToLowerInvariant());
                                continue;
                            }

                            if (line.StartsWith("#NOACRONYM:", StringComparison.OrdinalIgnoreCase))
                            {
                                var val = line.Substring(11).Trim();
                                if (val.Length > 0)
                                    noAcronyms.Add(val.ToLowerInvariant());
                                continue;
                            }

                            // key:value override
                            var parts = line.Split(new[] { ':' }, 2);
                            if (parts.Length != 2)
                                continue;

                            var key = parts[0].Trim().ToLowerInvariant();
                            var value = parts[1].Trim();
                            if (key.Length == 0 || value.Length == 0)
                                continue;

                            rules[key] = value; // ChatGPT: last one wins
                        }
                    }
                }
                catch
                {
                    // ChatGPT: swallow and fall back to empty rule sets
                }

                _rules = rules ?? new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
                _acronyms = acronyms ?? new HashSet<string>(StringComparer.OrdinalIgnoreCase);
                _noAcronyms = noAcronyms ?? new HashSet<string>(StringComparer.OrdinalIgnoreCase);
                _loaded = true;
            }
        }

        // ChatGPT: try multiple candidate locations to find TextCaseLibrary.Data in your environment
        // 1) Environment variable TEXTCASELIB_PATH (full file path)
        // 2) Environment variable TEXTCASELIB_DIR + "TextCaseLibrary.Data"
        // 3) Known absolute path you mentioned: C:\Dropbox\MMS Design\Data\TextCaseLibrary.Data
        // 4) BaseDirectory + ..\Data (and also climbing a few levels)
        private static string ResolveDataPath()
        {
            // 1) Explicit full path via env var
            var envPath = Environment.GetEnvironmentVariable("TEXTCASELIB_PATH");
            if (!string.IsNullOrEmpty(envPath) && File.Exists(envPath))
                return envPath;

            // 2) Directory via env var
            var envDir = Environment.GetEnvironmentVariable("TEXTCASELIB_DIR");
            if (!string.IsNullOrEmpty(envDir))
            {
                var p = Path.Combine(envDir, "TextCaseLibrary.Data");
                if (File.Exists(p))
                    return p;
            }

            // 3) Your stated absolute path
            var dropboxPath = @"C:\Dropbox\MMS Design\Data\TextCaseLibrary.Data";
            if (File.Exists(dropboxPath))
                return dropboxPath;

            // 4) Relative to app base directory (try a few parent levels)
            var baseDir = AppDomain.CurrentDomain.BaseDirectory;
            string[] candidates = new[]
            {
                Path.Combine(baseDir, @"..\Data\TextCaseLibrary.Data"),
                Path.Combine(baseDir, @"..\..\Data\TextCaseLibrary.Data"),
                Path.Combine(baseDir, @"..\..\..\Data\TextCaseLibrary.Data"),
                Path.Combine(baseDir, @"..\..\..\..\Data\TextCaseLibrary.Data")
            };

            for (int i = 0; i < candidates.Length; i++)
            {
                var full = Path.GetFullPath(candidates[i]);
                if (File.Exists(full))
                    return full;
            }

            // 5) Walk up a few parents and look for a "Data\TextCaseLibrary.Data"
            try
            {
                var dir = new DirectoryInfo(baseDir);
                for (int depth = 0; depth < 6 && dir != null; depth++, dir = dir.Parent)
                {
                    var probe = Path.Combine(dir.FullName, "Data", "TextCaseLibrary.Data");
                    if (File.Exists(probe))
                        return probe;
                }
            }
            catch
            {
                // ignore
            }

            // Not found
            return null;
        }

        private static string RemoveDots(string s)
        {
            return string.IsNullOrEmpty(s) ? s : s.Replace(".", string.Empty);
        }

        private static string TitleCaseToken(string token)
        {
            // ChatGPT: handle hyphenated words by title-casing each segment
            var parts = token.Split(new[] { '-' }, StringSplitOptions.None);
            for (int i = 0; i < parts.Length; i++)
            {
                parts[i] = TitleCaseSingle(parts[i]);
            }
            return string.Join("-", parts);
        }

        private static string TitleCaseSingle(string s)
        {
            if (string.IsNullOrEmpty(s))
                return s;

            var textInfo = CultureInfo.CurrentCulture.TextInfo;
            var lower = s.ToLowerInvariant();
            return textInfo.ToTitleCase(lower);
        }
    }
}

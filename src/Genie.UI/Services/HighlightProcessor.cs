using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using GenieClient.Genie;
using GenieClient.Services;

namespace GenieClient.UI.Services;

/// <summary>
/// Processes text to apply highlight patterns and returns styled segments.
/// </summary>
public class HighlightProcessor
{
    private readonly Globals _globals;

    public HighlightProcessor(Globals globals)
    {
        _globals = globals;
    }

    /// <summary>
    /// Processes text and returns a list of styled segments based on highlight rules.
    /// </summary>
    public List<StyledTextSegment> Process(string text, GenieColor defaultFg, GenieColor defaultBg)
    {
        var result = new List<StyledTextSegment>();
        
        if (string.IsNullOrEmpty(text))
        {
            return result;
        }

        // Check if we should highlight the whole line
        var lineHighlight = GetLineHighlight(text);
        if (lineHighlight != null)
        {
            // Whole line gets the highlight color
            var fg = lineHighlight.Foreground != GenieColor.Transparent ? lineHighlight.Foreground : defaultFg;
            var bg = lineHighlight.Background != GenieColor.Transparent ? lineHighlight.Background : defaultBg;
            result.Add(new StyledTextSegment(text, fg, bg, false, lineHighlight.SoundFile));
            return result;
        }

        // Process inline string highlights
        var stringMatches = GetStringHighlightMatches(text);
        
        if (stringMatches.Count == 0)
        {
            // No highlights, return the text as-is
            result.Add(new StyledTextSegment(text, defaultFg, defaultBg));
            return result;
        }

        // Sort matches by position
        stringMatches.Sort((a, b) => a.Start.CompareTo(b.Start));

        // Build segments, handling overlapping matches
        int currentPos = 0;
        foreach (var match in stringMatches)
        {
            // Skip if this match overlaps with already processed text
            if (match.Start < currentPos)
                continue;

            // Add text before this match (if any)
            if (match.Start > currentPos)
            {
                string beforeText = text.Substring(currentPos, match.Start - currentPos);
                result.Add(new StyledTextSegment(beforeText, defaultFg, defaultBg));
            }

            // Add the highlighted match
            result.Add(new StyledTextSegment(
                match.Text,
                match.Highlight.Foreground,
                match.Highlight.Background,
                false,
                match.Highlight.SoundFile));

            currentPos = match.Start + match.Length;
        }

        // Add remaining text after the last match
        if (currentPos < text.Length)
        {
            string afterText = text.Substring(currentPos);
            result.Add(new StyledTextSegment(afterText, defaultFg, defaultBg));
        }

        return result;
    }

    /// <summary>
    /// Checks if the text should have a whole-line highlight applied.
    /// </summary>
    private Highlights.Highlight? GetLineHighlight(string text)
    {
        try
        {
            var regex = _globals.HighlightList?.RegexLine;
            if (regex == null || string.IsNullOrEmpty(regex.ToString()))
                return null;

            // For line highlights, we check if the pattern matches anywhere in the line
            var match = regex.Match(text);
            if (match.Success && _globals.HighlightList!.Contains(match.Value))
            {
                var highlight = _globals.HighlightList[match.Value] as Highlights.Highlight;
                if (highlight?.IsActive == true)
                {
                    return highlight;
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[HighlightProcessor] Line highlight error: {ex.Message}");
        }

        return null;
    }

    /// <summary>
    /// Gets all string (inline) highlight matches for the text.
    /// </summary>
    private List<HighlightMatch> GetStringHighlightMatches(string text)
    {
        var matches = new List<HighlightMatch>();

        try
        {
            var regex = _globals.HighlightList?.RegexString;
            if (regex == null || string.IsNullOrEmpty(regex.ToString()))
                return matches;

            var regexMatches = regex.Matches(text);
            foreach (Match match in regexMatches)
            {
                if (_globals.HighlightList!.Contains(match.Value))
                {
                    var highlight = _globals.HighlightList[match.Value] as Highlights.Highlight;
                    if (highlight?.IsActive == true)
                    {
                        matches.Add(new HighlightMatch(match.Index, match.Length, match.Value, highlight));
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[HighlightProcessor] String highlight error: {ex.Message}");
        }

        return matches;
    }

    /// <summary>
    /// Helper record for highlight matches.
    /// </summary>
    private record HighlightMatch(int Start, int Length, string Text, Highlights.Highlight Highlight);
}


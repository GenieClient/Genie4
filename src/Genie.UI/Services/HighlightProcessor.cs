using System;
using System.Collections.Generic;
using System.Linq;
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
    /// Handles volatile highlights (monsterbold/presets), string highlights, and line highlights.
    /// </summary>
    /// <param name="text">The text to process</param>
    /// <param name="defaultFg">Default foreground color</param>
    /// <param name="defaultBg">Default background color</param>
    /// <param name="volatileHighlightSnapshot">Optional snapshot of VolatileHighlights captured before async dispatch</param>
    public List<StyledTextSegment> Process(string text, GenieColor defaultFg, GenieColor defaultBg, 
        List<GenieClient.Genie.VolatileHighlight>? volatileHighlightSnapshot = null)
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

        // Collect all matches from different sources
        var allMatches = new List<GenericMatch>();
        
        // 1. Get volatile highlights (monsterbold, presets like creatures, roomdesc, etc.)
        // Use the snapshot if provided, otherwise fall back to globals (for backward compatibility)
        allMatches.AddRange(GetVolatileHighlightMatches(text, volatileHighlightSnapshot));
        
        // 2. Get string highlights (user-defined patterns)
        allMatches.AddRange(GetStringHighlightMatches(text));
        
        if (allMatches.Count == 0)
        {
            // No highlights, return the text as-is
            result.Add(new StyledTextSegment(text, defaultFg, defaultBg));
            return result;
        }

        // Sort matches by position, prefer volatile highlights over string highlights
        allMatches = allMatches
            .OrderBy(m => m.Start)
            .ThenByDescending(m => m.IsVolatile) // Volatile highlights have priority
            .ToList();

        // Build segments, handling overlapping matches
        int currentPos = 0;
        foreach (var match in allMatches)
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
                match.FgColor,
                match.BgColor,
                match.IsBold,
                match.SoundFile));

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
    /// Gets volatile highlight matches (monsterbold, presets) for the text.
    /// These are position-based highlights set by the game parser.
    /// Each VolatileHighlight has a StartIndex indicating its position in the text.
    /// </summary>
    /// <param name="text">The text to search for matches</param>
    /// <param name="volatileHighlightSnapshot">Optional snapshot of VHs captured before async dispatch</param>
    private List<GenericMatch> GetVolatileHighlightMatches(string text, 
        List<GenieClient.Genie.VolatileHighlight>? volatileHighlightSnapshot = null)
    {
        var matches = new List<GenericMatch>();
        
        try
        {
            // Use snapshot if provided, otherwise fall back to globals
            var vhList = volatileHighlightSnapshot ?? _globals.VolatileHighlights?.ToList();
            
            // Process volatile highlights (like creatures/monsterbold)
            // These have position-based StartIndex set by the game parser
            if (vhList?.Count > 0)
            {
                foreach (var vh in vhList)
                {
                    var preset = GetPreset(vh.Preset);
                    if (preset == null) continue;
                    
                    // Use the stored StartIndex for position-based matching
                    // Verify the text actually matches at that position
                    if (vh.StartIndex >= 0 && vh.StartIndex + vh.Length <= text.Length)
                    {
                        var textAtPosition = text.Substring(vh.StartIndex, vh.Length);
                        if (textAtPosition == vh.Text)
                        {
                            matches.Add(new GenericMatch(
                                vh.StartIndex, 
                                vh.Length, 
                                vh.Text, 
                                preset.Foreground,
                                preset.Background,
                                true,  // is volatile
                                true,  // is bold (monsterbold)
                                null));
                            continue;
                        }
                    }
                    
                    // Fallback: if position-based matching fails (e.g., text was modified),
                    // find ALL occurrences of the text instead of just the first
                    int searchStart = 0;
                    while (searchStart < text.Length)
                    {
                        var idx = text.IndexOf(vh.Text, searchStart, StringComparison.Ordinal);
                        if (idx < 0) break;
                        
                        matches.Add(new GenericMatch(
                            idx, 
                            vh.Length, 
                            vh.Text, 
                            preset.Foreground,
                            preset.Background,
                            true,  // is volatile
                            true,  // is bold (monsterbold)
                            null));
                        
                        searchStart = idx + vh.Length;
                    }
                }
            }
            
            // Also process room objects (creatures in "You also see" lines)
            if (_globals.RoomObjects?.Count > 0 && text.Contains("You also see"))
            {
                foreach (var ro in _globals.RoomObjects.ToArray())
                {
                    var preset = GetPreset(ro.Preset);
                    if (preset == null) continue;
                    
                    // Use position-based matching first
                    if (ro.StartIndex >= 0 && ro.StartIndex + ro.Length <= text.Length)
                    {
                        var textAtPosition = text.Substring(ro.StartIndex, ro.Length);
                        if (textAtPosition == ro.Text)
                        {
                            matches.Add(new GenericMatch(
                                ro.StartIndex,
                                ro.Length,
                                ro.Text,
                                preset.Foreground,
                                preset.Background,
                                true,
                                true,
                                null));
                            continue;
                        }
                    }
                    
                    // Fallback: find ALL occurrences
                    int searchStart = 0;
                    while (searchStart < text.Length)
                    {
                        var idx = text.IndexOf(ro.Text, searchStart, StringComparison.Ordinal);
                        if (idx < 0) break;
                        
                        matches.Add(new GenericMatch(
                            idx,
                            ro.Length,
                            ro.Text,
                            preset.Foreground,
                            preset.Background,
                            true,
                            true,
                            null));
                        
                        searchStart = idx + ro.Length;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[HighlightProcessor] Volatile highlight error: {ex.Message}");
        }
        
        return matches;
    }
    
    /// <summary>
    /// Gets the preset by name from Globals.
    /// </summary>
    private Globals.Presets.Preset? GetPreset(string presetName)
    {
        try
        {
            if (_globals.PresetList?.ContainsKey(presetName) == true)
            {
                return _globals.PresetList[presetName] as Globals.Presets.Preset;
            }
        }
        catch
        {
            // Ignore preset lookup errors
        }
        return null;
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
    private List<GenericMatch> GetStringHighlightMatches(string text)
    {
        var matches = new List<GenericMatch>();

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
                        matches.Add(new GenericMatch(
                            match.Index, 
                            match.Length, 
                            match.Value, 
                            highlight.Foreground,
                            highlight.Background,
                            false,  // not volatile
                            false,  // not bold
                            highlight.SoundFile));
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
    /// Generic match record that works for both volatile highlights and string highlights.
    /// </summary>
    private record GenericMatch(
        int Start, 
        int Length, 
        string Text, 
        GenieColor FgColor, 
        GenieColor BgColor,
        bool IsVolatile,
        bool IsBold,
        string? SoundFile);
}


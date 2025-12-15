using GenieClient.Services;
using System.Collections.Generic;

namespace GenieClient.UI.Services;

/// <summary>
/// Represents a segment of text with styling information.
/// </summary>
public record StyledTextSegment(
    string Text, 
    GenieColor ForegroundColor, 
    GenieColor BackgroundColor,
    bool IsBold = false,
    string? SoundFile = null);

/// <summary>
/// Represents a complete line of styled text.
/// </summary>
public class StyledTextLine
{
    public List<StyledTextSegment> Segments { get; } = new();
    
    public void Add(string text, GenieColor fg, GenieColor bg, bool bold = false, string? sound = null)
    {
        Segments.Add(new StyledTextSegment(text, fg, bg, bold, sound));
    }
    
    public void Add(StyledTextSegment segment)
    {
        Segments.Add(segment);
    }
}


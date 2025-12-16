using GenieClient.Genie;
using GenieClient.Services;
using GenieClient.UI.Services;
using Xunit;

namespace Genie.UI.Tests;

/// <summary>
/// Tests for HighlightProcessor, focusing on volatile highlights (monsterbold/creatures).
/// </summary>
public class HighlightProcessorTests
{
    /// <summary>
    /// Creates a Globals instance with a "creatures" preset configured.
    /// </summary>
    private static Globals CreateGlobalsWithCreaturesPreset()
    {
        var globals = new Globals();
        
        // Set up the creatures preset with a recognizable color (Red)
        var creaturesPreset = new Globals.Presets.Preset(
            "creatures",                        // sKey
            GenieColor.FromRgb(255, 0, 0),      // Foreground (Red)
            GenieColor.Transparent,             // Background
            "red",                              // sColorName
            "true",                             // bSaveToFile
            false                               // highlightLine
        );
        globals.PresetList["creatures"] = creaturesPreset;
        
        return globals;
    }

    [Fact]
    public void Process_WithSingleVolatileHighlight_HighlightsCorrectly()
    {
        // Arrange
        var globals = CreateGlobalsWithCreaturesPreset();
        var processor = new HighlightProcessor(globals);
        
        var text = "    *****IMPORTANT!*****";
        var vhSnapshot = new List<VolatileHighlight>
        {
            new VolatileHighlight("    *****IMPORTANT!*****", "creatures", 0)
        };
        
        var defaultFg = GenieColor.Silver;
        var defaultBg = GenieColor.Transparent;
        
        // Act
        var segments = processor.Process(text, defaultFg, defaultBg, vhSnapshot);
        
        // Assert
        Assert.Single(segments);
        Assert.Equal(text, segments[0].Text);
        Assert.Equal(255, segments[0].ForegroundColor.R);  // Red from creatures preset
        Assert.Equal(0, segments[0].ForegroundColor.G);
        Assert.Equal(0, segments[0].ForegroundColor.B);
    }

    [Fact]
    public void Process_WithMultipleVolatileHighlights_HighlightsAll()
    {
        // Arrange
        var globals = CreateGlobalsWithCreaturesPreset();
        var processor = new HighlightProcessor(globals);
        
        // Simulating a line like: "a goblin, a troll, and a dragon"
        // where each creature is highlighted
        var text = "a goblin, a troll, and a dragon";
        var vhSnapshot = new List<VolatileHighlight>
        {
            new VolatileHighlight("a goblin", "creatures", 0),
            new VolatileHighlight("a troll", "creatures", 10),
            new VolatileHighlight("a dragon", "creatures", 23)
        };
        
        var defaultFg = GenieColor.Silver;
        var defaultBg = GenieColor.Transparent;
        
        // Act
        var segments = processor.Process(text, defaultFg, defaultBg, vhSnapshot);
        
        // Assert
        // Should have segments for: "a goblin" (bold), ", " (normal), "a troll" (bold), 
        // ", and " (normal), "a dragon" (bold)
        Assert.Equal(5, segments.Count);
        
        // First segment: "a goblin" - should be highlighted
        Assert.Equal("a goblin", segments[0].Text);
        Assert.Equal(255, segments[0].ForegroundColor.R);
        
        // Second segment: ", " - should be default color
        Assert.Equal(", ", segments[1].Text);
        Assert.Equal(defaultFg.R, segments[1].ForegroundColor.R);
        
        // Third segment: "a troll" - should be highlighted
        Assert.Equal("a troll", segments[2].Text);
        Assert.Equal(255, segments[2].ForegroundColor.R);
        
        // Fourth segment: ", and " - should be default color
        Assert.Equal(", and ", segments[3].Text);
        Assert.Equal(defaultFg.R, segments[3].ForegroundColor.R);
        
        // Fifth segment: "a dragon" - should be highlighted
        Assert.Equal("a dragon", segments[4].Text);
        Assert.Equal(255, segments[4].ForegroundColor.R);
    }

    [Fact]
    public void Process_WithPositionMismatch_FallsBackToTextSearch()
    {
        // Arrange
        var globals = CreateGlobalsWithCreaturesPreset();
        var processor = new HighlightProcessor(globals);
        
        // VH has wrong StartIndex (simulating cross-row VH)
        var text = "You see a goblin here.";
        var vhSnapshot = new List<VolatileHighlight>
        {
            // StartIndex 100 is way beyond the text length, position check will fail
            new VolatileHighlight("a goblin", "creatures", 100)
        };
        
        var defaultFg = GenieColor.Silver;
        var defaultBg = GenieColor.Transparent;
        
        // Act
        var segments = processor.Process(text, defaultFg, defaultBg, vhSnapshot);
        
        // Assert - should still find "a goblin" via fallback text search
        Assert.Equal(3, segments.Count);
        Assert.Equal("You see ", segments[0].Text);
        Assert.Equal("a goblin", segments[1].Text);
        Assert.Equal(255, segments[1].ForegroundColor.R);  // Should be highlighted
        Assert.Equal(" here.", segments[2].Text);
    }

    [Fact]
    public void Process_WithDuplicateTextInVHList_DeduplicatesMatches()
    {
        // Arrange
        var globals = CreateGlobalsWithCreaturesPreset();
        var processor = new HighlightProcessor(globals);
        
        // Multiple VHs with the same text (from different rows)
        var text = "    *****IMPORTANT!*****";
        var vhSnapshot = new List<VolatileHighlight>
        {
            new VolatileHighlight("    *****IMPORTANT!*****", "creatures", 0),
            new VolatileHighlight("    *****IMPORTANT!*****", "creatures", 0),  // Duplicate
            new VolatileHighlight("    *****IMPORTANT!*****", "creatures", 0)   // Duplicate
        };
        
        var defaultFg = GenieColor.Silver;
        var defaultBg = GenieColor.Transparent;
        
        // Act
        var segments = processor.Process(text, defaultFg, defaultBg, vhSnapshot);
        
        // Assert - should only have one segment (deduplication)
        Assert.Single(segments);
        Assert.Equal(text, segments[0].Text);
        Assert.Equal(255, segments[0].ForegroundColor.R);
    }

    [Fact]
    public void Process_WithSameTextMultipleTimes_HighlightsAllOccurrences()
    {
        // Arrange
        var globals = CreateGlobalsWithCreaturesPreset();
        var processor = new HighlightProcessor(globals);
        
        // Text with "goblin" appearing twice
        var text = "a goblin attacks another goblin";
        var vhSnapshot = new List<VolatileHighlight>
        {
            // VH with wrong position - should trigger fallback that finds ALL occurrences
            new VolatileHighlight("goblin", "creatures", 999)
        };
        
        var defaultFg = GenieColor.Silver;
        var defaultBg = GenieColor.Transparent;
        
        // Act
        var segments = processor.Process(text, defaultFg, defaultBg, vhSnapshot);
        
        // Assert - should highlight both "goblin" occurrences
        Assert.Equal(4, segments.Count);
        Assert.Equal("a ", segments[0].Text);
        Assert.Equal("goblin", segments[1].Text);
        Assert.Equal(255, segments[1].ForegroundColor.R);
        Assert.Equal(" attacks another ", segments[2].Text);
        Assert.Equal("goblin", segments[3].Text);
        Assert.Equal(255, segments[3].ForegroundColor.R);
    }

    [Fact]
    public void Process_WithEmptySnapshot_ReturnsUnhighlightedText()
    {
        // Arrange
        var globals = CreateGlobalsWithCreaturesPreset();
        var processor = new HighlightProcessor(globals);
        
        var text = "Just some regular text.";
        var vhSnapshot = new List<VolatileHighlight>();  // Empty
        
        var defaultFg = GenieColor.Silver;
        var defaultBg = GenieColor.Transparent;
        
        // Act
        var segments = processor.Process(text, defaultFg, defaultBg, vhSnapshot);
        
        // Assert
        Assert.Single(segments);
        Assert.Equal(text, segments[0].Text);
        Assert.Equal(defaultFg.R, segments[0].ForegroundColor.R);
    }

    [Fact]
    public void Process_WithNullSnapshot_UsesGlobalsVolatileHighlights()
    {
        // Arrange
        var globals = CreateGlobalsWithCreaturesPreset();
        globals.VolatileHighlights.Add(new VolatileHighlight("test text", "creatures", 0));
        
        var processor = new HighlightProcessor(globals);
        var text = "test text";
        
        var defaultFg = GenieColor.Silver;
        var defaultBg = GenieColor.Transparent;
        
        // Act - pass null for snapshot
        var segments = processor.Process(text, defaultFg, defaultBg, null);
        
        // Assert - should use globals.VolatileHighlights
        Assert.Single(segments);
        Assert.Equal("test text", segments[0].Text);
        Assert.Equal(255, segments[0].ForegroundColor.R);
    }

    [Fact]
    public void Process_WithUnknownPreset_SkipsHighlight()
    {
        // Arrange
        var globals = CreateGlobalsWithCreaturesPreset();
        var processor = new HighlightProcessor(globals);
        
        var text = "some text";
        var vhSnapshot = new List<VolatileHighlight>
        {
            new VolatileHighlight("some text", "unknown_preset", 0)
        };
        
        var defaultFg = GenieColor.Silver;
        var defaultBg = GenieColor.Transparent;
        
        // Act
        var segments = processor.Process(text, defaultFg, defaultBg, vhSnapshot);
        
        // Assert - preset not found, so no highlighting applied
        Assert.Single(segments);
        Assert.Equal(text, segments[0].Text);
        Assert.Equal(defaultFg.R, segments[0].ForegroundColor.R);
    }

    [Fact]
    public void Process_WithEmptyText_ReturnsEmptyList()
    {
        // Arrange
        var globals = CreateGlobalsWithCreaturesPreset();
        var processor = new HighlightProcessor(globals);
        
        var vhSnapshot = new List<VolatileHighlight>
        {
            new VolatileHighlight("something", "creatures", 0)
        };
        
        var defaultFg = GenieColor.Silver;
        var defaultBg = GenieColor.Transparent;
        
        // Act
        var segments = processor.Process("", defaultFg, defaultBg, vhSnapshot);
        
        // Assert
        Assert.Empty(segments);
    }

    [Fact]
    public void Process_LoginScreenImportantLines_HighlightsAll()
    {
        // Arrange - simulates the login screen issue where multiple IMPORTANT lines
        // need to be highlighted
        var globals = CreateGlobalsWithCreaturesPreset();
        var processor = new HighlightProcessor(globals);
        
        // First IMPORTANT line
        var text1 = "    *************************IMPORTANT!*************************";
        var vh1 = new List<VolatileHighlight>
        {
            new VolatileHighlight(text1, "creatures", 0)
        };
        
        // Third IMPORTANT line (same text)
        var text3 = "    *************************IMPORTANT!*************************";
        var vh3 = new List<VolatileHighlight>
        {
            new VolatileHighlight(text3, "creatures", 0)
        };
        
        var defaultFg = GenieColor.Silver;
        var defaultBg = GenieColor.Transparent;
        
        // Act
        var segments1 = processor.Process(text1, defaultFg, defaultBg, vh1);
        var segments3 = processor.Process(text3, defaultFg, defaultBg, vh3);
        
        // Assert - both should be highlighted
        Assert.Single(segments1);
        Assert.Equal(255, segments1[0].ForegroundColor.R);
        
        Assert.Single(segments3);
        Assert.Equal(255, segments3[0].ForegroundColor.R);
    }

    [Fact]
    public void Process_PartialMatch_HighlightsOnlyMatchingPortion()
    {
        // Arrange
        var globals = CreateGlobalsWithCreaturesPreset();
        var processor = new HighlightProcessor(globals);
        
        var text = "You also see a massive goblin and some treasure.";
        var vhSnapshot = new List<VolatileHighlight>
        {
            new VolatileHighlight("a massive goblin", "creatures", 13)
        };
        
        var defaultFg = GenieColor.Silver;
        var defaultBg = GenieColor.Transparent;
        
        // Act
        var segments = processor.Process(text, defaultFg, defaultBg, vhSnapshot);
        
        // Assert
        Assert.Equal(3, segments.Count);
        Assert.Equal("You also see ", segments[0].Text);
        Assert.Equal("a massive goblin", segments[1].Text);
        Assert.Equal(255, segments[1].ForegroundColor.R);
        Assert.Equal(" and some treasure.", segments[2].Text);
    }
}


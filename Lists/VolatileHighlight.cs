using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenieClient.Genie
{
    public class VolatileHighlight
    {
        public string Text { get; set; }
        public string Preset { get; set; }
        public int StartIndex { get; set; }
        public int Length { get { return Text.Length; } }
        public int EndIndex { get { return StartIndex + Length; } }
        public VolatileHighlight(string HighlightText, string PresetLabel, int StartPosition)
        {
            Text = HighlightText;
            Preset = PresetLabel;
            StartIndex = StartPosition;
        }
        public static implicit operator string(VolatileHighlight highlight)
        {
            return highlight.Text;
        }
    }
}

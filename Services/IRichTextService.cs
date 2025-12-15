using System;

namespace GenieClient.Services
{
    /// <summary>
    /// Provides cross-platform rich text control operations.
    /// Abstracts Windows RichTextBox-specific Win32 calls (scroll, redraw suspension).
    /// </summary>
    public interface IRichTextService
    {
        /// <summary>
        /// Suspends redrawing for the control to improve performance during bulk updates.
        /// Must be paired with EndUpdate.
        /// </summary>
        /// <param name="controlHandle">Native handle of the rich text control.</param>
        void BeginUpdate(IntPtr controlHandle);

        /// <summary>
        /// Resumes redrawing for the control after bulk updates.
        /// Must be paired with BeginUpdate.
        /// </summary>
        /// <param name="controlHandle">Native handle of the rich text control.</param>
        void EndUpdate(IntPtr controlHandle);

        /// <summary>
        /// Gets the index of the first visible line in the control.
        /// </summary>
        /// <param name="controlHandle">Native handle of the rich text control.</param>
        /// <returns>Zero-based index of the first visible line.</returns>
        int GetFirstVisibleLine(IntPtr controlHandle);

        /// <summary>
        /// Scrolls the control by the specified number of lines.
        /// </summary>
        /// <param name="controlHandle">Native handle of the rich text control.</param>
        /// <param name="lineCount">Number of lines to scroll (positive = down, negative = up).</param>
        void ScrollByLines(IntPtr controlHandle, int lineCount);

        /// <summary>
        /// Gets the current vertical scroll position.
        /// </summary>
        /// <param name="controlHandle">Native handle of the rich text control.</param>
        /// <returns>Current scroll position value.</returns>
        int GetScrollPosition(IntPtr controlHandle);

        /// <summary>
        /// Sets the vertical scroll position.
        /// </summary>
        /// <param name="controlHandle">Native handle of the rich text control.</param>
        /// <param name="position">Target scroll position.</param>
        /// <returns>True if successful.</returns>
        bool SetScrollPosition(IntPtr controlHandle, int position);
    }
}


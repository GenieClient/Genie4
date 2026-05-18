using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace GenieClient
{
    internal static class FontHelper
    {
        // Win32 LOGFONTW and CHOOSEFONTW for direct ChooseFont call.
        // WinForms' FontDialog.ShowDialog() internally calls Font.FromHfont() on the
        // result, which throws ArgumentException for valid OpenType/TrueType fonts whose
        // GDI+ representation is unusual (e.g. non-standard charsets, ARM Windows 11).
        // By calling ChooseFont ourselves we get the LOGFONT face name and can construct
        // the Font using new Font(name, size, style) which handles these fonts correctly.

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        private struct LOGFONTW
        {
            public int lfHeight, lfWidth, lfEscapement, lfOrientation, lfWeight;
            public byte lfItalic, lfUnderline, lfStrikeOut, lfCharSet;
            public byte lfOutPrecision, lfClipPrecision, lfQuality, lfPitchAndFamily;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
            public string lfFaceName;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        private struct CHOOSEFONTW
        {
            public uint lStructSize;
            public IntPtr hwndOwner, hDC, lpLogFont;
            public int iPointSize;
            public uint Flags, rgbColors;
            public IntPtr lCustData, lpfnHook, lpTemplateName, hInstance, lpszStyle;
            public ushort nFontType, MISSING_ALIGNMENT;
            public int nSizeMin, nSizeMax;
        }

        private const uint CF_SCREENFONTS        = 0x00000001;
        private const uint CF_INITTOLOGFONTSTRUCT = 0x00000040;
        private const uint CF_FORCEFONTEXIST     = 0x00010000;
        private const uint CF_NOVERTFONTS        = 0x01000000;

        [DllImport("comdlg32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        private static extern bool ChooseFontW(ref CHOOSEFONTW pcf);

        /// <summary>
        /// Shows the system font picker. Returns the selected Font, or
        /// <paramref name="currentFont"/> if the user cancelled or an error occurred.
        /// Handles OpenType/TrueType fonts that cause Font.FromHfont() to fail in GDI+.
        /// </summary>
        public static Font PickFont(IWin32Window owner, Font currentFont)
        {
            var lf = new LOGFONTW
            {
                lfCharSet = 1, // DEFAULT_CHARSET
                lfWeight  = 400
            };

            if (currentFont != null)
            {
                lf.lfFaceName = currentFont.Name;
                lf.lfWeight   = currentFont.Bold   ? 700 : 400;
                lf.lfItalic   = currentFont.Italic ? (byte)1 : (byte)0;
            }

            IntPtr pLf = Marshal.AllocHGlobal(Marshal.SizeOf<LOGFONTW>());
            try
            {
                Marshal.StructureToPtr(lf, pLf, false);

                var cf = new CHOOSEFONTW
                {
                    lStructSize = (uint)Marshal.SizeOf<CHOOSEFONTW>(),
                    hwndOwner   = owner?.Handle ?? IntPtr.Zero,
                    lpLogFont   = pLf,
                    Flags       = CF_SCREENFONTS | CF_INITTOLOGFONTSTRUCT |
                                  CF_FORCEFONTEXIST | CF_NOVERTFONTS
                };

                if (!ChooseFontW(ref cf))
                    return currentFont; // user cancelled

                LOGFONTW result = Marshal.PtrToStructure<LOGFONTW>(pLf);

                float  pointSize = cf.iPointSize / 10.0f; // ChooseFont returns 1/10 points
                FontStyle style  = FontStyle.Regular;
                if (result.lfWeight   >= 700) style |= FontStyle.Bold;
                if (result.lfItalic   != 0)   style |= FontStyle.Italic;
                if (result.lfUnderline != 0)  style |= FontStyle.Underline;
                if (result.lfStrikeOut != 0)  style |= FontStyle.Strikeout;

                // First try normal GDI+ path; fall back to by-name if it throws
                // (known to fail for some OpenType fonts on Windows 11 ARM / .NET 6+).
                try
                {
                    IntPtr hfont = CreateFontIndirectW(ref result);
                    if (hfont != IntPtr.Zero)
                    {
                        try   { return Font.FromHfont(hfont); }
                        catch (ArgumentException) { /* fall through */ }
                        finally { DeleteObject(hfont); }
                    }
                }
                catch { /* fall through */ }

                // Fallback: construct by family name — always works for installed fonts
                return new Font(result.lfFaceName, pointSize, style);
            }
            finally
            {
                Marshal.FreeHGlobal(pLf);
            }
        }

        [DllImport("gdi32.dll", CharSet = CharSet.Unicode)]
        private static extern IntPtr CreateFontIndirectW(ref LOGFONTW lplf);

        [DllImport("gdi32.dll")]
        private static extern bool DeleteObject(IntPtr ho);
    }
}

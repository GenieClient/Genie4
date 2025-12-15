# Cross-Platform Migration Guide

## Overview

**UI Framework:** Avalonia UI  
**Target:** Make Genie run on Windows, macOS, and Linux  
**Current Status:** Phase 1 - Making Genie.Core truly platform-agnostic

---

## Architecture Goal

```
Genie5.sln
├── src/Genie.Core/                    # net10.0 (platform-agnostic)
│   └── Services/
│       ├── Interfaces/                # Service contracts
│       │   ├── ISoundService.cs       ✅ EXISTS
│       │   ├── IWindowAttentionService.cs
│       │   ├── IRichTextService.cs
│       │   ├── IImageService.cs
│       │   └── IWindowChromeService.cs
│       └── GenieColor.cs              ✅ EXISTS
│
├── src/Genie.Windows/                 # net10.0-windows (Windows Forms)
│   └── Services/
│       ├── WindowsSoundService.cs     # winmm.dll P/Invoke
│       ├── WindowsAttentionService.cs # FlashWindow P/Invoke
│       ├── WindowsRichTextService.cs  # RichTextBox scroll/redraw
│       ├── WindowsImageService.cs     # System.Drawing
│       └── WindowsChromeService.cs    # Custom skinning
│
├── src/Genie.Avalonia/                # net10.0 (cross-platform)
│   └── Services/
│       ├── AvaloniaSoundService.cs    # Cross-platform audio
│       ├── AvaloniaAttentionService.cs # Per-platform attention
│       ├── AvaloniaRichTextService.cs # Avalonia text control
│       ├── AvaloniaImageService.cs    # SkiaSharp
│       └── AvaloniaChromeService.cs   # Avalonia window chrome
│
└── Plugin/Plugins.vbproj              # Plugin interfaces
```

---

## Service-Based Architecture

### Design Principles
1. **Interfaces in Core** - All service contracts live in `Genie.Core/Services/`
2. **Implementations per Platform** - Each platform project implements its services
3. **Dependency Injection** - Services registered at startup, injected where needed
4. **No `#if WINDOWS` in Core** - Core stays 100% platform-agnostic
5. **Graceful Degradation** - Services can return no-op if feature unavailable

---

## Service Interfaces to Create

### ISoundService ✅ EXISTS
**Location:** `Services/ISoundService.cs`
```csharp
public interface ISoundService
{
    void PlayWaveFile(string filePath);
    void PlayWaveResource(string resourceName);
    void PlaySystemSound(string soundAlias);
    void StopPlaying();
    bool IsEnabled { get; set; }
}
```
**Windows:** winmm.dll PlaySound P/Invoke  
**Cross-platform:** NAudio, OpenAL, or platform-specific APIs

---

### IWindowAttentionService 🆕
**Purpose:** Flash window/taskbar to get user attention
```csharp
public interface IWindowAttentionService
{
    void RequestAttention(bool critical = false);
    void CancelAttention();
    bool IsAttentionRequested { get; }
}
```
**Windows:** FlashWindowEx P/Invoke  
**macOS:** NSApplication.requestUserAttention  
**Linux:** _NET_WM_STATE_DEMANDS_ATTENTION

---

### IRichTextService 🆕
**Purpose:** Control rich text display (scroll, suspend redraw)
```csharp
public interface IRichTextService
{
    void BeginUpdate(object control);
    void EndUpdate(object control);
    int GetFirstVisibleLine(object control);
    void ScrollToLine(object control, int line);
    int GetScrollPosition(object control);
    void SetScrollPosition(object control, int position);
}
```
**Windows:** SendMessage for EM_*, WM_SETREDRAW  
**Avalonia:** Native Avalonia TextBox/ScrollViewer APIs

---

### IImageService 🆕
**Purpose:** Cross-platform image loading and manipulation
```csharp
public interface IImageService
{
    Task<IGenieImage> LoadFromFileAsync(string path);
    Task<IGenieImage> LoadFromStreamAsync(Stream stream);
    Task<IGenieImage> LoadFromUrlAsync(string url);
    IGenieImage CreateEmpty(int width, int height);
}

public interface IGenieImage : IDisposable
{
    int Width { get; }
    int Height { get; }
    void Save(string path, ImageFormat format);
    Stream ToStream(ImageFormat format);
}
```
**Windows:** System.Drawing.Image (legacy)  
**Cross-platform:** SkiaSharp SKBitmap/SKImage

---

### IWindowChromeService 🆕 (Optional)
**Purpose:** Custom window skinning/chrome
```csharp
public interface IWindowChromeService
{
    void EnableCustomChrome(object window);
    void DisableCustomChrome(object window);
    void StartWindowDrag(object window);
    void StartWindowResize(object window, ResizeEdge edge);
}
```
**Windows:** Win32 WM_NCHITTEST, ReleaseCapture  
**Avalonia:** Built-in ExtendClientAreaToDecorationsHint

---

### IColorParsingService 🆕
**Purpose:** Parse color names/hex to GenieColor
```csharp
public interface IColorParsingService
{
    GenieColor ParseColor(string colorString);
    string ColorToString(GenieColor color);
    string ColorToHex(GenieColor color);
    bool TryParseColor(string colorString, out GenieColor color);
    IReadOnlyList<string> GetKnownColorNames();
}
```
**Note:** Core implementation can be cross-platform, but known color names come from System.Drawing.KnownColor on Windows

---

## Phase 1: Make Genie.Core Platform-Agnostic

### 1.1 Project File Changes
- [ ] Change `Genie.Core.csproj` target from `net10.0-windows` to `net10.0`
- [ ] Remove `<UseWindowsForms>true</UseWindowsForms>`
- [ ] Conditionally reference Windows-specific packages

### 1.2 Windows Dependencies Audit

#### Service Migration Plan

| Current File | Target Service | Implementation |
|--------------|----------------|----------------|
| `Utility/Sound.cs` | `ISoundService` | ✅ Interface exists, `SoundService.Windows.cs` exists |
| `Utility/WindowFlash.cs` | `IWindowAttentionService` | ✅ Interface + `WindowsAttentionService` created |
| `Utility/Win32Utility.cs` | `IRichTextService` + `IWindowChromeService` | ✅ Interfaces + Windows implementations created |
| `Utility/FileHandler.cs` (images) | `IImageService` | ✅ Interface + `WindowsImageService` created |
| `Utility/ColorCode.cs` | `IColorParsingService` | ✅ Interface + `WindowsColorParsingService` created |
| `Services/ColorConverter.cs` | N/A | ⏳ Still to move to `Genie.Windows` |

#### Color Migration (System.Drawing.Color → GenieColor)

| File | Status | Notes |
|------|--------|-------|
| `Core/Game.cs` | ⚠️ NEEDS WORK | Change delegates to use `GenieColor` |
| `Core/Command.cs` | ⚠️ PARTIAL | Uses `Color.FromKnownColor`, `Color.Empty` |
| `Lists/Globals.cs` | ✅ MOSTLY DONE | Uses `GenieColor` internally |
| `Lists/Highlights.cs` | ✅ MOSTLY DONE | Uses `GenieColor` internally |
| `Lists/Names.cs` | ✅ MOSTLY DONE | Uses `GenieColor` internally |
| `Lists/Config.cs` | ⚠️ NEEDS WORK | Uses `ColorToColorref` (Win32 specific) |
| `Script/Script.cs` | ⚠️ NEEDS WORK | Color conversion for PresetList |
| `Utility/ColorCode.cs` | ⚠️ NEEDS WORK | Add `GenieColor` methods |
| `Mapper/NodeList.cs` | ⚠️ NEEDS WORK | Map node colors |
| `Services/GameServiceAdapter.cs` | ⚠️ NEEDS WORK | Color conversion |

#### Files to Move to Genie.Windows

| File | Reason | New Location |
|------|--------|--------------|
| `Utility/WindowFlash.cs` | Windows P/Invoke | `Services/WindowsAttentionService.cs` |
| `Utility/Win32Utility.cs` | RichTextBox P/Invoke | `Services/WindowsRichTextService.cs` + `WindowsChromeService.cs` |
| `Utility/Sound.cs` | winmm.dll P/Invoke | `Services/WindowsSoundService.cs` |
| `Services/ColorConverter.cs` | System.Drawing bridge | `Services/ColorConverter.cs` |

#### Files Using Windows-Only APIs

| File | Status | Notes |
|------|--------|-------|
| `Utility/EnumWindows.cs` | ✅ DONE | Already wrapped in `#if WINDOWS` |
| `Core/PluginHost.cs` | 🪟 WINDOWS-ONLY | Keep in Genie.Windows |
| `Core/LegacyPluginHost.cs` | 🪟 WINDOWS-ONLY | Keep in Genie.Windows |

#### Already Cross-Platform ✅

| File | Notes |
|------|-------|
| `Services/GenieColor.cs` | Platform-agnostic color struct |
| `Utility/KeyCode.cs` | Platform-agnostic key enum |
| `Core/Connection.cs` | Network code |
| `Core/GenieError.cs` | Base error handling |
| `Script/Eval.cs` | Expression evaluation |
| `Script/JavaScript.cs` | Jint JavaScript engine |
| `Script/LUAScript.cs` | Lua scripting |
| `Script/MathEval.cs` | Math expression parser |
| `Lists/Aliases.cs` | No Windows deps |
| `Lists/Events.cs` | No Windows deps |
| `Lists/Macros.cs` | No Windows deps |

---

## Phase 1 Task Breakdown

### Task 1.0: Service Infrastructure Setup
**STATUS: ✅ COMPLETE**

Create the service abstraction layer:

```
src/Genie.Core/Services/
├── Interfaces/
│   ├── IWindowAttentionService.cs  🆕
│   ├── IRichTextService.cs         🆕
│   ├── IImageService.cs            🆕
│   ├── IWindowChromeService.cs     🆕
│   ├── IColorParsingService.cs     🆕
│   └── ISoundService.cs            ✅ EXISTS
├── ServiceProvider.cs              🆕 (DI container)
└── NullServices/                   🆕 (no-op implementations)
    ├── NullWindowAttentionService.cs
    ├── NullRichTextService.cs
    ├── NullImageService.cs
    ├── NullWindowChromeService.cs
    └── NullSoundService.cs

src/Genie.Windows/Services/
├── WindowsWindowAttentionService.cs  (from WindowFlash.cs)
├── WindowsRichTextService.cs         (from Win32Utility.cs)
├── WindowsSoundService.cs            (from Sound.cs)
├── WindowsImageService.cs            (System.Drawing.Image)
├── WindowsChromeService.cs           (from Win32Utility.cs)
└── WindowsColorParsingService.cs     (from ColorCode.cs)
```

Checklist:
- [x] Create `Services/Interfaces/` directory in Genie.Core
- [x] Create `IWindowAttentionService.cs` interface
- [x] Create `IRichTextService.cs` interface
- [x] Create `IImageService.cs` + `IGenieImage.cs` interfaces
- [x] Create `IWindowChromeService.cs` interface
- [x] Create `IColorParsingService.cs` interface
- [x] Create `GenieServices.cs` service locator
- [x] Create `NullServices.cs` null implementations for graceful degradation
- [x] Create Windows implementations in `Genie.Windows/Services/`:
  - [x] `WindowsAttentionService.cs`
  - [x] `WindowsRichTextService.cs`
  - [x] `WindowsChromeService.cs`
  - [x] `WindowsImageService.cs`
  - [x] `WindowsColorParsingService.cs`
  - [x] `WindowsServiceInitializer.cs`
- [ ] Register Windows services at app startup (wire up `WindowsServiceInitializer.Initialize()`)
- [ ] Remove old Windows-only files from `Genie.Core` (after migration)

---

### Task 1.1: Project File Changes
**STATUS: ❌ TODO** - After service infrastructure

- [ ] Change `Genie.Core.csproj` target from `net10.0-windows` to `net10.0`
- [ ] Remove `<UseWindowsForms>true</UseWindowsForms>` from Core
- [ ] Add SkiaSharp package to Core
- [ ] Update `Genie.Windows.csproj` to include moved files

---

### Task 1.2.1: Core/Game.cs - Color Migration
**STATUS: ❌ TODO**
**Decision:** ✅ Use GenieColor for all color settings (including delegates)

Changes needed:
- [ ] Change `EventPrintTextEventHandler` delegate to use `GenieColor` instead of `Color`
- [ ] Replace `Color.LightGray`, `Color.Black`, `Color.Transparent` with `GenieColor` equivalents
- [ ] Change `m_oLastFgColor` and `m_oEmptyColor` from `Color` to `GenieColor`
- [ ] Update all callers in `Game.cs` to use `GenieColor`
- [ ] Update Windows Forms subscribers to convert at the boundary

---

### Task 1.2.2: Move Windows-Only Files to Genie.Windows
**STATUS: ✅ COMPLETE (Partial)**

Windows-only P/Invoke utilities have been moved from Core to Windows:

| Source File | Status | Notes |
|-------------|--------|-------|
| `Utility/WindowFlash.cs` | ✅ Moved | Now in Genie.Windows only |
| `Utility/Win32Utility.cs` | ✅ Moved | Now in Genie.Windows only |
| `Utility/Sound.cs` | ✅ Moved | Now in Genie.Windows only |
| `Utility/EnumWindows.cs` | ✅ Moved | Now in Genie.Windows only |
| `Services/ColorConverter.cs` | ⏳ Kept in Core | Needed until color migration complete |
| `Core/PluginHost.cs` | ✅ Already in Windows | Was already Windows-only |
| `Core/LegacyPluginHost.cs` | ✅ Already in Windows | Was already Windows-only |

**Code updates made:**
- `Game.cs` and `Command.cs` now use `GenieServices.Sound` instead of static `Sound` class
- Windows services in `src/Genie.Windows/Services/` provide implementations

Checklist:
- [x] Create `Services/` folder in `Genie.Windows`
- [x] Windows service implementations created (Task 1.0)
- [x] Move `WindowFlash.cs`, `Win32Utility.cs`, `Sound.cs`, `EnumWindows.cs` to Genie.Windows
- [x] Update `Game.cs` and `Command.cs` to use `GenieServices.Sound`
- [ ] Move `ColorConverter.cs` to Genie.Windows (after color migration)

---

### Task 1.2.3: ColorCode.cs - Add GenieColor methods
**STATUS: ❌ TODO**

The `ColorCode` class has methods like:
- `StringToColor(string)` → returns `System.Drawing.Color`
- `ColorToString(Color)` → uses `Color`
- `ColorToColorref(Color)` → Win32 specific

Need to add parallel methods:
- [ ] `StringToGenieColor(string)` - already partially exists
- [ ] `GenieColorToString(GenieColor)`
- [ ] Make Win32-specific methods conditional

---

### Task 1.2.4: FileHandler.cs - Image handling
**STATUS: ❌ TODO**
**Decision:** Use cross-platform image library

#### Library Options:
| Library | Pros | Cons |
|---------|------|------|
| **SkiaSharp** | GPU-accelerated, used by Avalonia internally, powerful | Larger binary, native dependencies |
| **ImageSharp** | Pure managed code, no native deps, good for basic ops | Slower for complex operations |

**Recommendation:** SkiaSharp (since Avalonia uses it internally anyway)

Implementation:
- [ ] Add SkiaSharp NuGet package to Genie.Core
- [ ] Replace `System.Drawing.Image` with `SKBitmap` / `SKImage`
- [ ] Update image download/processing methods

---

### Task 1.2.5: Plugin System
**STATUS: 🪟 WINDOWS-ONLY (Acceptable)**

The plugin system (`PluginHost.cs`, `LegacyPluginHost.cs`) requires Windows Forms for backward compatibility with existing plugins. 

**Decision:** Let's discuss a truly cross-platform plugin system, after everything else is migrated.

---

## Phase 2: Create Avalonia UI Project

### 2.1 Project Setup
- [ ] Create `src/Genie.Avalonia/Genie.Avalonia.csproj`
- [ ] Add Avalonia NuGet packages
- [ ] Reference `Genie.Core`
- [ ] Create basic window structure

### 2.2 UI Components to Implement
- [ ] Main window with menu
- [ ] Rich text output pane (game text with colors)
- [ ] Command input box
- [ ] Vitals/status bars (health, mana, etc.)
- [ ] Roundtime indicator
- [ ] Map display panel
- [ ] Script explorer
- [ ] Configuration dialogs

### 2.3 Platform Services
- [ ] `ISoundService` - cross-platform implementation
- [ ] File dialogs
- [ ] System tray/notifications

---

## Phase 3: Feature Parity

- [ ] All game output display features
- [ ] Script execution
- [ ] Macro system
- [ ] Highlighting system
- [ ] Auto-mapper
- [ ] Configuration management

---

## Notes

### Color Strategy
The codebase has already started migrating to `GenieColor`:
- Core data structures store `GenieColor` internally
- Legacy `FgColor`/`BgColor` properties return `System.Drawing.Color` for UI compatibility
- `ColorConverter.cs` provides extension methods `.ToGenieColor()` and `.ToDrawingColor()`

**Migration path:**
1. Core uses only `GenieColor`
2. Windows Forms UI converts at the boundary using `ColorConverter`
3. Avalonia UI uses `GenieColor` directly (Avalonia has its own Color type that's easy to convert)

### Key Handling
`KeyCode.cs` already provides a platform-agnostic `Keys` enum that mirrors Windows virtual key codes.

---

## Decisions Made ✅

| Question | Decision |
|----------|----------|
| **UI Framework** | ✅ Avalonia UI |
| **Architecture** | ✅ Service-based abstraction - interfaces in Core, implementations per platform |
| **Game.cs colors** | ✅ Use `GenieColor` everywhere, including delegates |
| **Window flashing** | ✅ Create `IWindowAttentionService` with cross-platform implementations |
| **Win32Utility.cs** | ✅ Split: `IRichTextService` + `IWindowChromeService`, move implementations to Genie.Windows |
| **Sound handling** | ✅ Keep `ISoundService` interface, move Windows impl to Genie.Windows |
| **Image handling** | ✅ Create `IImageService`, use SkiaSharp for cross-platform |
| **Color parsing** | ✅ Create `IColorParsingService`, move Windows color name resolution to Genie.Windows |
| **Plugin System** | ⏸️ Keep Windows-only for now, discuss cross-platform later |
| **ColorConverter.cs** | ✅ Move to Genie.Windows (System.Drawing bridge, Windows-only) |

---

## Implementation Order

Recommended order for Phase 1:

1. ✅ **Task 1.0** - Create service interfaces in `Genie.Core/Services/`
2. ✅ **Task 1.0** - Create null implementations for graceful degradation
3. ✅ **Task 1.0** - Create service provider/registration infrastructure
4. ✅ **Task 1.2.2** - Move Windows-only files to `Genie.Windows/` (partial)
5. ✅ **Task 1.2.2** - Create Windows service implementations
6. ⏳ **Task 1.2.1** - Migrate Game.cs to GenieColor ← NEXT
7. ⏳ **Task 1.2.3** - Update ColorCode.cs with GenieColor methods
8. ⏳ **Task 1.2.4** - Add SkiaSharp image handling
9. ⏳ **Task 1.1** - Update project files (change target framework) ← LAST

---

*Last Updated: December 2024*


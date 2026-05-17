# Changelog

All notable changes to Genie Client 4 are documented here.

---

## [4.5.0.1] - 2026-05-17

### Fixed
- Updater: kill any running `Lamp.exe` process before overwriting the file — prevents `IOException` on force-update when Lamp is already running
- Updater: fetch Lamp release once in `UpdateUpdater` and reuse for version check and download — eliminates a redundant GitHub API call that contributed to rate limit exhaustion

---

## [4.5.0.0] - 2026-05-16

### Added
- `#ping` command — client-side connection check that reads `$connected` without sending anything to the game server
- Plugin security: strong-name (signed assembly) requirement — unsigned plugin DLLs are now silently skipped at load, examine, and instantiate stages
- Plugin loading: switched from `Assembly.Load(byte[])` to `Assembly.LoadFrom(path)` for proper dependency resolution
- Updater: SHA-256 integrity check for downloaded `Lamp.exe` — verifies against a `.sha256` release asset if present; deletes and throws on mismatch
- Updater: extracted shared async helpers (`GetGitHubStreamAsync`, `GetReleaseAsync`, `GetServerUpdaterVersionAsync`, `GetServerClientVersionAsync`)
- Updater: `LoadAssetsAsync` proper async implementation alongside synchronous wrapper
- Script debug output now routes to the Debug window via `WindowTarget` parameter on `EventPrintTextEventHandler`
- Plugin security guide added to `docs/Plugin-Security-Guide.md`
- Plugins menu: **Require Signed Plugins** checkbox toggle — off by default; when enabled, unsigned plugin DLLs are skipped at load; setting persists via `#config {requiresignedplugins}`

### Fixed
- Updater: kill any running `Lamp.exe` process before overwriting the file — prevents `IOException` when Lamp is locked by a previous run
- `ParseTriggers` re-entry guard (`m_bParseTriggers`) — prevents infinite trigger loops when `bTriggerOnInput` is enabled and a trigger action sends text back to the game
- `TriggerVariableChanged` depth guard (`m_iTriggerVariableChangedDepth`) — skips trigger/script processing on recursive calls (depth > 1) to prevent eval-trigger re-fire loops; hard cap at depth 20
- `ParseCommand` recursion depth guard (`m_iParseCommandDepth`) — returns early at depth ≥ 30 to prevent stack overflows in deeply nested trigger/script chains
- `TriggerVariableChanged` thread safety — added `InvokeRequired` / `BeginInvoke` marshal to UI thread
- `EventStreamWindow` thread safety — added `InvokeRequired` / `Invoke` guard
- `AddText` thread safety — added `InvokeRequired` / `Invoke` guard
- `AddImage` thread safety — added `InvokeRequired` / `Invoke` guard
- `AutoMapper.UpdateCurrentRoom` re-entry guard (`m_bUpdatingCurrentRoom`) — blocks external re-entry while allowing intentional `bMapChanged=true` restarts
- `AutoMapper`: reset `m_RoomUpdated` to `false` before entering `UpdateCurrentRoom` to prevent duplicate calls on the same prompt event
- `ComponentRichTextBox`: all Win32 interop calls (`BeginUpdate`, `EndUpdate`, `GetFirstLineVisible`, `LineScroll`) now check `IsHandleCreated` before invoking, preventing crashes during initialization or disposal
- `ComponentRichTextBox`: replaced `(IntPtr)Handle.ToInt32()` with direct `Handle` to avoid pointer truncation on 64-bit systems
- `DialogDownload`: combined separate `IsNothing` and `IsDisposed` null checks into a single condition
- Updater: `ServerUpdaterVersion` now falls back to `LocalUpdaterVersion` on network failure instead of throwing
- Updater: version strings from GitHub tags now strip leading `v` for consistent comparison

### Changed
- Updater: all blocking `.Result` calls replaced with proper `async`/`await` and `ConfigureAwait(false)` throughout

---

## [4.0.2.9] - 2024

### Added
- New config options integrating with Lamp updater

### Fixed
- `ServerUpdaterVersion` returns local version on network error rather than crashing
- `WindowStyle` `showWindow` ternary corrected (true/false were swapped)

### Changed
- Updated Contributing guide and acknowledgements

---

## [4.0.2.7] - 2024

### Added
- `automapper.class` — class-based automapper scripting support
- Hot reload for scripts — compares lines from old script against new to identify the closest matching jump point on reload
- Always On Top window setting
- Input bar sizing option to match game window width (defaults off)
- Tree view in ProfileConnect and ClassicConnect config
- Additional datetime global variables
- `oLineList` exposed for script access
- New parameter added to Lich execution
- Bool response for process execution success
- Lamp autoupdate toggle (re-enabled with toggle control)

### Fixed
- Script hot reload now correctly passes labels
- Bold linebreak abandonment handled when bold spans a line boundary
- Extension removal now handles extensions greater than 3 characters
- Global variables parsed correctly in `#script` commands

### Changed
- Automapper settings redesigned to fit updated layout
- Improved launching of external processes — shows Lamp and only closes if successfully launched
- Script reload reworked to identify closest match to a jump target

---

## [4.0.2.6] - 2024

### Added
- Portrait window — incoming portraits routed to a dedicated portrait window when open
- `#img` command — fetch and display images from Simu in a RichTextBox
- Art directory and repo config options; Art Update button to update via Lamp
- Windows Event Log error recording
- Column sorting in list views
- `$client` reserved variable returning the product name from assembly info
- Command line parameters for direct connect (character and key)
- UI Preset option
- Full color options for the automapper panel (background, grid, node colors)
- `roomnote` global variable from map XML
- `$unixtime` reserved variable (UTC Unix timestamp)
- Duplicate plugin detection — informs user and continues loading

### Fixed
- Portrait image direction corrected for target window
- Portrait window cleared before sending a new image
- Scrollbar state forced during resize and line additions
- Scrollbars on child windows set to display only when needed
- Art fetched from the correct game-specific URI and stored in game-specific directories
- Regex highlights: removed trimming which was throwing off the index; refactored to break nested loop
- StartIndex restored for `ParseLineHighlights` buffer position
- Volatile highlight parsing for preset start index corrected
- Preset colors nested within matching conditions, fixing color bleed
- Interface DLL compatibility issues resolved for some plugins

### Changed
- Default RegEx option switched to Multiline
- "Open User Data Directory" split into directory-specific menu options
- `ParseLineHighlights` moved off `AddToBuffer` into `ParseHighlights` for consistent ordering
- `ParseVolatileHighlights` now runs before `ParseLineHighlights`
- Alphabetized default preset add order

---

## [4.0.2.5] - 2024

### Added
- Script Repo config option and script update via Lamp
- `VolatileHighlight` class for precise highlight targeting without regex matching for room objects

### Fixed
- Automapper parse fixes
- Block value no longer changed after an else evaluates true — once true it stays true
- Room output correctly flagged in `PrintTextWithParse` overload
- Preset color bleed fixed by nesting application within matching conditions
- Duplicate entries from `VolatileHighlights` removed
- Automapper XML loading now uses `StreamReader` with inferred encoding
- Legacy Premium plugin compatibility restored
- `eval` substring fix
- Parsing of globals in substitutes

### Changed
- Parallel execution for Lamp launch calls where appropriate
- Updater moved to run in parallel to prevent hanging during version check
- Forced linebreaks at "You also see" in room description when using Condensed Mode
- Room objects refactored into `VolatileHighlights`
- Preset sub-parsing removed (was causing double-parsing)
- FE string set to `WRAYTH` due to XML feed restrictions

---

## [4.0.2.4] - 2024

### Added
- Room object highlights with persistence logic
- `promptbreak` and condensed display modes
- `PromptForce` config toggle
- `ScriptExtension` config option — default file extension for scripts
- Automapper state saving
- `@utc@` / `@unixtime@` global variable for UTC Unix timestamp

### Fixed
- Icons now display correctly
- Prompt display updated to feel more consistent with Genie 3.6
- Volatile highlights handle presets and bolding correctly
- `ArrayList` properties converted to `Genie.Collections.ArrayLists` for thread safety
- `SaveToFile` set to true on presets loaded from `presets.cfg`
- `ParseSubstitutions` named correctly; added to room object highlight persistence
- `FormMain` no longer created a second time during closing

### Changed
- Config `PromptForce` converted to a proper toggle
- Automapper settings redesigned
- `RoomObjectHighlights` renamed to `RoomObjects`

---

## [4.0.2.3] - 2024

### Fixed
- Minor stability fixes and build increment

---

## [4.0.2.2] - 2024

### Added
- `$connectscript` global variable
- `ConnectScript` config option
- Log directory config updates

### Changed
- Config cleanup — `System.Collections.ArrayLists` converted to `Genie.Collections.ArrayLists`
- `\n` now parsed as a newline without a preceding `\r`
- Removed `<c>` prefix from data sent to game server
- Input no longer split on `;` if a line starts with `;`

---

## [4.0.2.1] - 2024

### Added
- `#window Position` command
- Always On Top layout setting
- Tree view scrolls to top after populating
- Ctrl+PageUp/Down scrolls to top/bottom of text box

### Fixed
- Window color bug fixed
- Window position bugs fixed
- Window commands made thread-safe
- `percWindow` title reserved and corrected to "Active Spells"; Debug window loading fixed

### Changed
- Layout improvements for profile and connect dialogs

---

## [4.0.2.0] - 2024

### Added
- Lamp updater integration (`UpdaterUtility` class)
- Direct connection startup parameters (character and key) consistent with Wrayth
- Test Build option with auto-update disabled
- `$roomcolor` global variable
- Map and Plugin update options via Lamp
- `#lich Connect` error handling

### Fixed
- Progress bars reflect text from game rather than client-side assembly
- Threading tightened; timeouts added to lock acquisitions to prevent deadlocks
- `percWindow` capitalization corrected when loading from layout
- Authentication failure now returns a clear error message
- `TcpClient` state used to determine `$connected` value

### Changed
- Updater migrated from legacy tool to Lamp
- Check for Updates on Startup defaulted to enabled
- Connection configured to always authenticate on connect
- TLS 1.2 explicitly specified as SSL protocol
- Character name search made case-insensitive

---

## [4.0.1.5] - 2023

### Added
- `$destination` global variable set by automapper
- Web links open in browser from client output

### Fixed
- Resource issue with `#lc` command
- CS8983 struct error in `CommandRestrictions` for VS2022/C#10
- Writer lock error handling in `addscripts`
- Window menu checkboxes update correctly when using `#window` commands

---

## [4.0.1.3] - 2023

### Added
- Simu direct connection implementation (TcpClient-based)
- Character key authentication
- `$account` global variable exposing account name

### Fixed
- Connection string updated for Simu game server
- Null character (`\0`) trimmed from login key
- Default game port changed from 7900 to 7910
- Gemstone instances added; Hercules, Xena, and Modus Operandi removed

---

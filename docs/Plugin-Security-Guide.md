# Genie4 Plugin Security Guide

## Overview

Genie4 loads third-party plugins at runtime from `.dll` files. Recent security improvements
enforce that all plugins must be **strong-named (signed)** before they will be loaded or
instantiated. Unsigned plugins are silently skipped.

This guide explains what strong-naming is, why it is required, and how to sign your plugin
project so it loads correctly.

---

## What Changed

### 1. Strong-Name Requirement

`PluginServices` now calls `IsAssemblyStrongNamed()` before loading any plugin DLL. A plugin
without a public key token is rejected at three points:

| Stage | Method | Result if unsigned |
|---|---|---|
| Directory scan | `FindPlugins` | DLL skipped, not examined |
| Single file load | `FindPlugin` | Returns `default` (not found) |
| Instance creation | `CreateInstance` | Returns `null` |

### 2. `Assembly.LoadFrom` instead of `Assembly.Load(byte[])`

Previously, plugins were loaded by reading the raw bytes of the DLL into memory and calling
`Assembly.Load(bytes)`. This approach has two problems:

- The CLR cannot resolve the assembly's dependencies because it has no file path context.
  Any plugin that references another DLL would fail at runtime with a `FileNotFoundException`.
- The loaded assembly has no `Location`, which breaks any code that tries to find sibling files
  relative to the plugin.

Plugins are now loaded with `Assembly.LoadFrom(path)`, which gives the CLR the full file path
and allows normal dependency resolution.

---

## What Is a Strong-Named Assembly?

A strong-named assembly is signed with an RSA key pair. The public key is embedded in the
assembly manifest, and the private key is used to sign the assembly hash at build time.

Strong-naming provides:

- **Identity** — the assembly's identity includes its public key token, so two assemblies with
  the same name but different keys are treated as different assemblies.
- **Tamper detection** — the CLR verifies the signature on load. A modified DLL will fail
  verification.
- **Version binding** — strong-named assemblies participate in the GAC and can be bound by
  exact version.

A public key token is the last 8 bytes of the SHA-1 hash of the public key. You can see it
with `sn -T MyPlugin.dll`.

---

## How to Sign Your Plugin

### Step 1 — Generate a Key File

Open a **Developer Command Prompt** (or any terminal with `sn.exe` available) and run:

```
sn -k MyPlugin.snk
```

This creates a key file `MyPlugin.snk` containing a new 2048-bit RSA key pair. Keep this file
safe — losing it means you cannot issue updates with the same identity.

> You can also use a PKCS#12/PFX certificate, but an SNK file is simpler for plugin signing.

### Step 2 — Add the Key to Your Project

#### Visual Basic / C# (.NET SDK-style `.csproj`)

Add these two lines inside a `<PropertyGroup>` in your `.csproj`:

```xml
<PropertyGroup>
  <SignAssembly>true</SignAssembly>
  <AssemblyOriginatorKeyFile>MyPlugin.snk</AssemblyOriginatorKeyFile>
</PropertyGroup>
```

Place `MyPlugin.snk` in the same directory as your `.csproj`, or adjust the path accordingly.

#### Legacy `.vbproj` / `.csproj` (non-SDK style)

1. Right-click the project in Solution Explorer → **Properties**
2. Go to the **Signing** tab
3. Check **Sign the assembly**
4. In the dropdown, choose **Browse...** and select your `.snk` file
5. Uncheck **Delay sign only** (unless you are using delay-signing)

### Step 3 — Build and Verify

Build your project normally. Then verify the signature:

```
sn -v MyPlugin.dll
```

Expected output:

```
Assembly 'MyPlugin.dll' is valid
```

To see the public key token:

```
sn -T MyPlugin.dll
```

Example output:

```
Public key token is a1b2c3d4e5f6a7b8
```

If `sn -T` returns `Assembly 'MyPlugin.dll' is not strongly named`, the plugin **will not load**
in Genie4.

---

## Dependency Resolution

Because plugins are now loaded with `Assembly.LoadFrom`, any DLLs your plugin depends on
must be present in the same directory as your plugin DLL (or in a location the CLR can
find via normal probing rules).

If your plugin references a NuGet package or another DLL:

1. Copy the dependency DLLs into the same folder as your plugin.
2. Alternatively, merge dependencies into a single DLL using a tool like
   [ILMerge](https://github.com/dotnet/ILMerge) or [ILRepack](https://github.com/gluck/il-repack).

---

## Plugin Interface

Your plugin must implement one of two interfaces to be recognized by Genie4:

| Interface | Namespace |
|---|---|
| Legacy | `GeniePlugin.Interfaces.IPlugin` |
| Modern | `GeniePlugin.Plugins.IPlugin` |

The required members are defined in [Plugin/IPlugin.vb](../Plugin/IPlugin.vb):

```vb
Public Interface IPlugin
    ReadOnly Property Name()        As String
    ReadOnly Property Version()     As String
    ReadOnly Property Description() As String
    ReadOnly Property Author()      As String
    Sub Initialize(ByVal Host As IHost)
    Sub Show()
    Sub VariableChanged(ByVal Variable As String)
    Function ParseText(ByVal Text As String, ByVal Window As String) As String
    Function ParseInput(ByVal Text As String) As String
    Sub ParseXML(ByVal XML As String)
    Property Enabled() As Boolean
    Sub ParentClosing()
End Interface
```

The host interface ([Plugin/IHost.vb](../Plugin/IHost.vb)) provides:

```vb
Public Interface IHost
    Sub EchoText(ByVal Text As String)
    Sub SendText(ByVal Text As String)
    Property Variable(ByVal Var As String) As String
    ReadOnly Property ParentForm()         As System.Windows.Forms.Form
    ReadOnly Property IsVerified(ByVal key As String) As Boolean
    ReadOnly Property IsPremium(ByVal key As String)  As Boolean
    ReadOnly Property InterfaceVersion()   As Integer
    Property PluginKey()                   As String
End Interface
```

---

## Troubleshooting

### Plugin is not loading

1. Run `sn -v MyPlugin.dll` — if it fails, the assembly is not signed or the signature is broken.
2. Confirm the DLL is in the configured plugins directory Genie4 scans.
3. Check that all dependency DLLs are present next to your plugin DLL.
4. Ensure your class is `Public` and not `Abstract`, and that it implements `IPlugin`.

### Plugin loads but crashes on startup

- Verify all referenced DLLs are present in the plugin directory.
- Check that `Initialize(Host As IHost)` does not throw — exceptions here are swallowed by the
  host, so add logging via `Host.EchoText` during development.

### "Assembly is valid" but still rejected

- Delay-signed assemblies pass `sn -v` only after verification is skipped (`sn -Vr`). Genie4
  checks `GetPublicKeyToken()` at load time — delay-signed assemblies have an all-zero token
  and will be rejected. Always use full signing for distributed plugins.

---

## Security Notes

- **Keep your `.snk` file private.** Anyone with your private key can produce DLLs that appear
  to have your identity. Do not commit `.snk` files to public repositories.
- The strong-name check prevents unsigned DLLs from being loaded, but it does not validate
  that the key belongs to a trusted publisher. It is still the user's responsibility to
  obtain plugins from trusted sources.
- The MD5 hash of each plugin DLL is computed and stored as the plugin key. This provides
  change detection but MD5 is not cryptographically secure against deliberate collision attacks;
  it is used here for identity, not authentication.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace GenieClient.UI.Services;

/// <summary>
/// Represents a saved connection profile.
/// </summary>
public class ConnectionProfile
{
    public string Name { get; set; } = string.Empty;
    public string GameCode { get; set; } = "DR";
    public string Account { get; set; } = string.Empty;
    public string? EncryptedPassword { get; set; }
    public string? Character { get; set; }
    public DateTime LastUsed { get; set; }

    /// <summary>
    /// Display name combining character and game.
    /// </summary>
    public string DisplayName => string.IsNullOrEmpty(Character) 
        ? $"{Account} ({GameCode})" 
        : $"{Character} - {Account} ({GameCode})";
}

/// <summary>
/// Manages saving and loading connection profiles.
/// </summary>
public class ProfileManager
{
    private readonly string _profilesPath;
    private List<ConnectionProfile> _profiles = new();

    public IReadOnlyList<ConnectionProfile> Profiles => _profiles;

    public ProfileManager()
    {
        // Store profiles in user's local app data
        var appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        var geniePath = Path.Combine(appDataPath, "Genie");
        Directory.CreateDirectory(geniePath);
        _profilesPath = Path.Combine(geniePath, "profiles.json");
    }

    /// <summary>
    /// Load profiles from disk.
    /// </summary>
    public async Task LoadAsync()
    {
        try
        {
            if (File.Exists(_profilesPath))
            {
                var json = await File.ReadAllTextAsync(_profilesPath);
                _profiles = JsonSerializer.Deserialize<List<ConnectionProfile>>(json) ?? new();
                
                // Sort by last used (most recent first)
                _profiles.Sort((a, b) => b.LastUsed.CompareTo(a.LastUsed));
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[ProfileManager] Error loading profiles: {ex.Message}");
            _profiles = new();
        }
    }

    /// <summary>
    /// Save profiles to disk.
    /// </summary>
    public async Task SaveAsync()
    {
        try
        {
            var json = JsonSerializer.Serialize(_profiles, new JsonSerializerOptions { WriteIndented = true });
            await File.WriteAllTextAsync(_profilesPath, json);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[ProfileManager] Error saving profiles: {ex.Message}");
        }
    }

    /// <summary>
    /// Add or update a profile.
    /// </summary>
    public async Task SaveProfileAsync(ConnectionProfile profile)
    {
        profile.LastUsed = DateTime.Now;
        
        // Check if profile with same name exists
        var existingIndex = _profiles.FindIndex(p => 
            p.Account.Equals(profile.Account, StringComparison.OrdinalIgnoreCase) &&
            p.GameCode.Equals(profile.GameCode, StringComparison.OrdinalIgnoreCase) &&
            (p.Character ?? "").Equals(profile.Character ?? "", StringComparison.OrdinalIgnoreCase));

        if (existingIndex >= 0)
        {
            _profiles[existingIndex] = profile;
        }
        else
        {
            _profiles.Insert(0, profile);
        }

        await SaveAsync();
    }

    /// <summary>
    /// Delete a profile.
    /// </summary>
    public async Task DeleteProfileAsync(ConnectionProfile profile)
    {
        _profiles.Remove(profile);
        await SaveAsync();
    }

    /// <summary>
    /// Update the last used time for a profile.
    /// </summary>
    public async Task UpdateLastUsedAsync(ConnectionProfile profile)
    {
        profile.LastUsed = DateTime.Now;
        
        // Re-sort and save
        _profiles.Sort((a, b) => b.LastUsed.CompareTo(a.LastUsed));
        await SaveAsync();
    }

    /// <summary>
    /// Simple encryption for password storage (not cryptographically secure, just obfuscation).
    /// </summary>
    public static string EncryptPassword(string password, string account)
    {
        if (string.IsNullOrEmpty(password)) return string.Empty;
        
        // Simple XOR obfuscation with account name as key
        var key = "G5" + account.ToUpper();
        var result = new char[password.Length];
        for (int i = 0; i < password.Length; i++)
        {
            result[i] = (char)(password[i] ^ key[i % key.Length]);
        }
        return Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(new string(result)));
    }

    /// <summary>
    /// Decrypt a stored password.
    /// </summary>
    public static string DecryptPassword(string encrypted, string account)
    {
        if (string.IsNullOrEmpty(encrypted)) return string.Empty;
        
        try
        {
            var key = "G5" + account.ToUpper();
            var bytes = Convert.FromBase64String(encrypted);
            var chars = System.Text.Encoding.UTF8.GetString(bytes);
            var result = new char[chars.Length];
            for (int i = 0; i < chars.Length; i++)
            {
                result[i] = (char)(chars[i] ^ key[i % key.Length]);
            }
            return new string(result);
        }
        catch
        {
            return string.Empty;
        }
    }
}


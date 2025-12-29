using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Threading;
using GenieClient.Genie;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace GenieClient.Views;

/// <summary>
/// Represents an alias entry for display in the grid.
/// </summary>
public class AliasEntry
{
    public string Key { get; set; } = "";
    public string Value { get; set; } = "";
}

public partial class AliasesDialog : Window
{
    private readonly Aliases? _aliasList;
    private readonly ObservableCollection<AliasEntry> _displayAliases = new();
    private AliasEntry? _selectedAlias;
    private bool _hasUnsavedChanges = false;

    public AliasesDialog()
    {
        InitializeComponent();
        AliasesGrid.ItemsSource = _displayAliases;
    }

    public AliasesDialog(Aliases? aliasList) : this()
    {
        _aliasList = aliasList;
        LoadAliases();
    }

    /// <summary>
    /// Shows the dialog and returns when closed.
    /// </summary>
    public static async Task ShowDialog(Window parent, Aliases? aliasList)
    {
        var dialog = new AliasesDialog(aliasList);
        await dialog.ShowDialog(parent);
    }

    private void LoadAliases()
    {
        _displayAliases.Clear();

        if (_aliasList == null) return;

        foreach (System.Collections.DictionaryEntry entry in _aliasList)
        {
            _displayAliases.Add(new AliasEntry
            {
                Key = entry.Key.ToString() ?? "",
                Value = entry.Value?.ToString() ?? ""
            });
        }

        UpdateStatus();
    }

    private void UpdateStatus()
    {
        CountText.Text = $"{_displayAliases.Count} alias{(_displayAliases.Count != 1 ? "es" : "")} loaded";
        
        if (_hasUnsavedChanges)
        {
            StatusText.Text = "⚠️ You have unsaved changes!";
            StatusText.Foreground = Avalonia.Media.Brushes.Orange;
        }
        else
        {
            StatusText.Text = "Double-click to edit, or use buttons above";
            StatusText.Foreground = Avalonia.Media.Brushes.LightYellow;
        }
    }

    private void OnSelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        _selectedAlias = AliasesGrid.SelectedItem as AliasEntry;
        
        EditButton.IsEnabled = _selectedAlias != null;
        DeleteButton.IsEnabled = _selectedAlias != null;
    }

    private async void OnRowDoubleClick(object? sender, RoutedEventArgs e)
    {
        if (_selectedAlias != null)
        {
            await EditAlias(_selectedAlias);
        }
    }

    private async void OnAddClick(object? sender, RoutedEventArgs e)
    {
        var entry = new AliasEntry();
        if (await ShowEditDialog(entry, isNew: true))
        {
            if (_aliasList != null)
            {
                _aliasList.Add(entry.Key, entry.Value);
                _displayAliases.Add(entry);
                _hasUnsavedChanges = true;
                UpdateStatus();
            }
        }
    }

    private async void OnEditClick(object? sender, RoutedEventArgs e)
    {
        if (_selectedAlias != null)
        {
            await EditAlias(_selectedAlias);
        }
    }

    private async Task EditAlias(AliasEntry entry)
    {
        var originalKey = entry.Key;
        var editedEntry = new AliasEntry { Key = entry.Key, Value = entry.Value };
        
        if (await ShowEditDialog(editedEntry, isNew: false))
        {
            if (_aliasList != null)
            {
                // Remove old entry if key changed
                if (originalKey != editedEntry.Key)
                {
                    _aliasList.Remove(originalKey);
                }
                
                // Add/update with new values
                _aliasList.Add(editedEntry.Key, editedEntry.Value);
                
                // Update display
                entry.Key = editedEntry.Key;
                entry.Value = editedEntry.Value;
                
                _hasUnsavedChanges = true;
                
                // Refresh the grid
                var items = _displayAliases.ToList();
                _displayAliases.Clear();
                foreach (var item in items)
                {
                    _displayAliases.Add(item);
                }
                
                UpdateStatus();
            }
        }
    }

    private async void OnDeleteClick(object? sender, RoutedEventArgs e)
    {
        if (_selectedAlias == null) return;

        var result = await ShowConfirmDialog(
            "Delete Alias",
            $"Are you sure you want to delete the alias '{_selectedAlias.Key}'?");

        if (result)
        {
            if (_aliasList != null)
            {
                _aliasList.Remove(_selectedAlias.Key);
                _displayAliases.Remove(_selectedAlias);
                _hasUnsavedChanges = true;
                UpdateStatus();
            }
        }
    }

    private void OnReloadClick(object? sender, RoutedEventArgs e)
    {
        if (_hasUnsavedChanges)
        {
            StatusText.Text = "⚠️ Reload will discard unsaved changes!";
        }
        
        LoadAliases();
        _hasUnsavedChanges = false;
        UpdateStatus();
    }

    private void OnSaveClick(object? sender, RoutedEventArgs e)
    {
        if (_aliasList != null)
        {
            try
            {
                _aliasList.Save();
                _hasUnsavedChanges = false;
                StatusText.Text = "✅ Aliases saved successfully!";
                StatusText.Foreground = Avalonia.Media.Brushes.LightGreen;
                UpdateStatus();
            }
            catch (Exception ex)
            {
                StatusText.Text = $"❌ Error saving: {ex.Message}";
                StatusText.Foreground = Avalonia.Media.Brushes.Red;
            }
        }
    }

    private async void OnImportClick(object? sender, RoutedEventArgs e)
    {
        var dialog = new OpenFileDialog
        {
            Title = "Import Aliases",
            Filters = new List<FileDialogFilter>
            {
                new FileDialogFilter { Name = "Config Files", Extensions = { "cfg" } },
                new FileDialogFilter { Name = "All Files", Extensions = { "*" } }
            }
        };

        var result = await dialog.ShowAsync(this);
        if (result != null && result.Length > 0)
        {
            try
            {
                _aliasList?.Load(result[0]);
                LoadAliases();
                _hasUnsavedChanges = true;
                StatusText.Text = $"✅ Imported from {System.IO.Path.GetFileName(result[0])}";
                StatusText.Foreground = Avalonia.Media.Brushes.LightGreen;
            }
            catch (Exception ex)
            {
                StatusText.Text = $"❌ Import error: {ex.Message}";
                StatusText.Foreground = Avalonia.Media.Brushes.Red;
            }
        }
    }

    private async void OnCloseClick(object? sender, RoutedEventArgs e)
    {
        if (_hasUnsavedChanges)
        {
            var result = await ShowConfirmDialog(
                "Unsaved Changes",
                "You have unsaved changes. Close anyway?");
            
            if (!result) return;
        }
        
        Close();
    }

    /// <summary>
    /// Shows an edit dialog for an alias entry.
    /// </summary>
    private async Task<bool> ShowEditDialog(AliasEntry entry, bool isNew)
    {
        var dialog = new Window
        {
            Title = isNew ? "Add Alias" : "Edit Alias",
            Width = 500,
            Height = 250,
            WindowStartupLocation = WindowStartupLocation.CenterOwner,
            Background = Avalonia.Media.Brushes.DarkSlateGray,
            CanResize = false
        };

        var keyBox = new TextBox
        {
            Text = entry.Key,
            Watermark = "Alias name (e.g., 'go')",
            Margin = new Avalonia.Thickness(0, 4, 0, 0)
        };

        var valueBox = new TextBox
        {
            Text = entry.Value,
            Watermark = "Replacement text (e.g., 'go gate')",
            Margin = new Avalonia.Thickness(0, 4, 0, 0)
        };

        bool dialogResult = false;

        var okButton = new Button
        {
            Content = "OK",
            Width = 80,
            Margin = new Avalonia.Thickness(0, 0, 8, 0)
        };
        okButton.Click += (s, e) =>
        {
            if (string.IsNullOrWhiteSpace(keyBox.Text))
            {
                // Show error
                return;
            }
            entry.Key = keyBox.Text.Trim();
            entry.Value = valueBox.Text?.Trim() ?? "";
            dialogResult = true;
            dialog.Close();
        };

        var cancelButton = new Button
        {
            Content = "Cancel",
            Width = 80
        };
        cancelButton.Click += (s, e) => dialog.Close();

        var content = new StackPanel
        {
            Margin = new Avalonia.Thickness(16),
            Spacing = 8,
            Children =
            {
                new TextBlock { Text = "Alias Name:", FontWeight = Avalonia.Media.FontWeight.Bold },
                keyBox,
                new TextBlock { Text = "Replacement Text:", FontWeight = Avalonia.Media.FontWeight.Bold, Margin = new Avalonia.Thickness(0, 8, 0, 0) },
                valueBox,
                new StackPanel
                {
                    Orientation = Avalonia.Layout.Orientation.Horizontal,
                    HorizontalAlignment = Avalonia.Layout.HorizontalAlignment.Right,
                    Margin = new Avalonia.Thickness(0, 16, 0, 0),
                    Spacing = 8,
                    Children = { okButton, cancelButton }
                }
            }
        };

        dialog.Content = content;
        await dialog.ShowDialog(this);
        return dialogResult;
    }

    /// <summary>
    /// Shows a confirmation dialog.
    /// </summary>
    private async Task<bool> ShowConfirmDialog(string title, string message)
    {
        var dialog = new Window
        {
            Title = title,
            Width = 400,
            Height = 180,
            WindowStartupLocation = WindowStartupLocation.CenterOwner,
            Background = Avalonia.Media.Brushes.DarkSlateGray,
            CanResize = false
        };

        bool result = false;

        var yesButton = new Button
        {
            Content = "Yes",
            Width = 80,
            Margin = new Avalonia.Thickness(0, 0, 8, 0)
        };
        yesButton.Click += (s, e) =>
        {
            result = true;
            dialog.Close();
        };

        var noButton = new Button
        {
            Content = "No",
            Width = 80
        };
        noButton.Click += (s, e) => dialog.Close();

        var content = new StackPanel
        {
            Margin = new Avalonia.Thickness(16),
            Spacing = 16,
            Children =
            {
                new TextBlock { Text = message, TextWrapping = Avalonia.Media.TextWrapping.Wrap },
                new StackPanel
                {
                    Orientation = Avalonia.Layout.Orientation.Horizontal,
                    HorizontalAlignment = Avalonia.Layout.HorizontalAlignment.Right,
                    Spacing = 8,
                    Children = { yesButton, noButton }
                }
            }
        };

        dialog.Content = content;
        await dialog.ShowDialog(this);
        return result;
    }
}


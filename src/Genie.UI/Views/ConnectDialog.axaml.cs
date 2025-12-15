using Avalonia.Controls;
using Avalonia.Interactivity;
using GenieClient.UI.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenieClient.Views;

public partial class ConnectDialog : Window
{
    private readonly ProfileManager _profileManager;
    private ConnectionProfile? _selectedProfile;

    public string? SelectedGame { get; private set; }
    public string? Account { get; private set; }
    public string? Password { get; private set; }
    public string? Character { get; private set; }
    public bool SaveProfile { get; private set; }
    public bool Cancelled { get; private set; } = true;

    // Game code to ComboBox index mapping
    private static readonly Dictionary<string, int> GameCodeToIndex = new()
    {
        { "DR", 0 },
        { "DRX", 1 },
        { "DRF", 2 },
        { "DRP", 3 },
        { "DRT", 4 },
        { "GS4", 5 },
        { "GSX", 6 },
        { "GSF", 7 }
    };

    public ConnectDialog()
    {
        InitializeComponent();
        _profileManager = new ProfileManager();
        
        // Load profiles when dialog opens
        Opened += async (s, e) => await LoadProfilesAsync();
    }

    private async Task LoadProfilesAsync()
    {
        await _profileManager.LoadAsync();
        ProfileListBox.ItemsSource = _profileManager.Profiles;
        
        // If we have profiles, select the first one (most recently used)
        if (_profileManager.Profiles.Count > 0)
        {
            ProfileListBox.SelectedIndex = 0;
        }
    }

    private void OnProfileSelected(object? sender, SelectionChangedEventArgs e)
    {
        _selectedProfile = ProfileListBox.SelectedItem as ConnectionProfile;
        DeleteProfileButton.IsEnabled = _selectedProfile != null;

        if (_selectedProfile != null)
        {
            // Fill in the form from the profile
            if (GameCodeToIndex.TryGetValue(_selectedProfile.GameCode, out var index))
            {
                GameComboBox.SelectedIndex = index;
            }
            
            AccountTextBox.Text = _selectedProfile.Account;
            CharacterTextBox.Text = _selectedProfile.Character ?? "";
            
            // Decrypt and fill password if saved
            if (!string.IsNullOrEmpty(_selectedProfile.EncryptedPassword))
            {
                PasswordTextBox.Text = ProfileManager.DecryptPassword(
                    _selectedProfile.EncryptedPassword, 
                    _selectedProfile.Account);
                SaveProfileCheckBox.IsChecked = true;
            }
            else
            {
                PasswordTextBox.Text = "";
                SaveProfileCheckBox.IsChecked = false;
            }
        }
    }

    private async void OnDeleteProfile(object? sender, RoutedEventArgs e)
    {
        if (_selectedProfile != null)
        {
            await _profileManager.DeleteProfileAsync(_selectedProfile);
            ProfileListBox.ItemsSource = null;
            ProfileListBox.ItemsSource = _profileManager.Profiles;
            _selectedProfile = null;
            DeleteProfileButton.IsEnabled = false;
            
            // Clear the form
            AccountTextBox.Text = "";
            PasswordTextBox.Text = "";
            CharacterTextBox.Text = "";
            GameComboBox.SelectedIndex = 0;
            SaveProfileCheckBox.IsChecked = false;
        }
    }

    private void OnCancel(object? sender, RoutedEventArgs e)
    {
        Cancelled = true;
        Close();
    }

    private async void OnConnect(object? sender, RoutedEventArgs e)
    {
        // Validate inputs
        if (string.IsNullOrWhiteSpace(AccountTextBox.Text))
        {
            StatusText.Text = "Please enter your account name.";
            AccountTextBox.Focus();
            return;
        }

        if (string.IsNullOrWhiteSpace(PasswordTextBox.Text))
        {
            StatusText.Text = "Please enter your password.";
            PasswordTextBox.Focus();
            return;
        }

        // Get selected game code from Tag property
        var selectedItem = GameComboBox.SelectedItem as ComboBoxItem;
        SelectedGame = selectedItem?.Tag?.ToString() ?? "DR";
        Account = AccountTextBox.Text;
        Password = PasswordTextBox.Text;
        Character = string.IsNullOrWhiteSpace(CharacterTextBox.Text) ? null : CharacterTextBox.Text;
        SaveProfile = SaveProfileCheckBox.IsChecked ?? false;
        Cancelled = false;

        // Save profile if requested
        if (SaveProfile)
        {
            var profile = new ConnectionProfile
            {
                GameCode = SelectedGame,
                Account = Account,
                Character = Character,
                EncryptedPassword = ProfileManager.EncryptPassword(Password, Account)
            };
            await _profileManager.SaveProfileAsync(profile);
        }
        else if (_selectedProfile != null)
        {
            // Update last used time for selected profile
            await _profileManager.UpdateLastUsedAsync(_selectedProfile);
        }

        Close();
    }

    /// <summary>
    /// Shows the dialog and returns the connection info if not cancelled.
    /// </summary>
    public static new async Task<ConnectDialog?> Show(Window owner)
    {
        var dialog = new ConnectDialog();
        await dialog.ShowDialog(owner);
        return dialog.Cancelled ? null : dialog;
    }
}

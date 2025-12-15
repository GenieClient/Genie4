using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using GenieClient.UI.Services;
using System.Threading.Tasks;

namespace GenieClient.Views;

public partial class ProfileConnectDialog : Window
{
    private readonly ProfileManager _profileManager;
    private ConnectionProfile? _selectedProfile;

    public ConnectionProfile? SelectedProfile => _selectedProfile;
    public bool Cancelled { get; private set; } = true;

    public ProfileConnectDialog()
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
        
        // Select the first profile if available
        if (_profileManager.Profiles.Count > 0)
        {
            ProfileListBox.SelectedIndex = 0;
        }
    }

    private void OnProfileSelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        _selectedProfile = ProfileListBox.SelectedItem as ConnectionProfile;
        ConnectButton.IsEnabled = _selectedProfile != null;
        DeleteButton.IsEnabled = _selectedProfile != null;
    }

    private void OnListBoxDoubleTapped(object? sender, TappedEventArgs e)
    {
        if (_selectedProfile != null)
        {
            DoConnect();
        }
    }

    private void OnConnect(object? sender, RoutedEventArgs e)
    {
        DoConnect();
    }

    private void DoConnect()
    {
        if (_selectedProfile != null)
        {
            Cancelled = false;
            Close();
        }
    }

    private void OnCancel(object? sender, RoutedEventArgs e)
    {
        Cancelled = true;
        Close();
    }

    private async void OnDeleteProfile(object? sender, RoutedEventArgs e)
    {
        if (_selectedProfile != null)
        {
            await _profileManager.DeleteProfileAsync(_selectedProfile);
            _selectedProfile = null;
            ProfileListBox.ItemsSource = null;
            ProfileListBox.ItemsSource = _profileManager.Profiles;
            
            ConnectButton.IsEnabled = false;
            DeleteButton.IsEnabled = false;
        }
    }

    /// <summary>
    /// Shows the dialog and returns the selected profile if not cancelled.
    /// </summary>
    public static new async Task<ProfileConnectDialog?> Show(Window owner)
    {
        var dialog = new ProfileConnectDialog();
        await dialog.ShowDialog(owner);
        return dialog.Cancelled ? null : dialog;
    }

    /// <summary>
    /// Gets the decrypted password for the selected profile.
    /// </summary>
    public string? GetPassword()
    {
        if (_selectedProfile == null || string.IsNullOrEmpty(_selectedProfile.EncryptedPassword))
            return null;
        
        return ProfileManager.DecryptPassword(_selectedProfile.EncryptedPassword, _selectedProfile.Account);
    }
}

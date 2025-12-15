using Avalonia.Controls;
using Avalonia.Interactivity;
using GenieClient.UI.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GenieClient.Views;

public partial class ConnectDialog : Window
{
    private readonly ProfileManager _profileManager;

    public string? SelectedGame { get; private set; }
    public string? Account { get; private set; }
    public string? Password { get; private set; }
    public string? Character { get; private set; }
    public bool SaveProfile { get; private set; }
    public bool Cancelled { get; private set; } = true;

    public ConnectDialog()
    {
        InitializeComponent();
        _profileManager = new ProfileManager();
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
            await _profileManager.LoadAsync();
            var profile = new ConnectionProfile
            {
                GameCode = SelectedGame,
                Account = Account,
                Character = Character,
                EncryptedPassword = ProfileManager.EncryptPassword(Password, Account)
            };
            await _profileManager.SaveProfileAsync(profile);
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

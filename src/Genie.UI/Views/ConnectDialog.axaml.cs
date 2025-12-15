using Avalonia.Controls;
using Avalonia.Interactivity;
using System.Threading.Tasks;

namespace GenieClient.Views;

public partial class ConnectDialog : Window
{
    public string? SelectedGame { get; private set; }
    public string? Account { get; private set; }
    public string? Password { get; private set; }
    public string? Character { get; private set; }
    public bool Cancelled { get; private set; } = true;

    public ConnectDialog()
    {
        InitializeComponent();
    }

    private void OnCancel(object? sender, RoutedEventArgs e)
    {
        Cancelled = true;
        Close();
    }

    private void OnConnect(object? sender, RoutedEventArgs e)
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
        Cancelled = false;

        Close();
    }

    /// <summary>
    /// Shows the dialog and returns the connection info if not cancelled.
    /// </summary>
    public static async Task<ConnectDialog?> Show(Window owner)
    {
        var dialog = new ConnectDialog();
        await dialog.ShowDialog(owner);
        return dialog.Cancelled ? null : dialog;
    }
}


using AMITMAUI1.Helper;

namespace AMITMAUI1.Views;

public partial class SignInPage : ContentPage

{
    private string _username;
    private string _password;
    private bool _enteryasPassword;
    public string Username
    {
        get => _username;
        set
        {
            if (_username != value)
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
            }
        }
    }
    public string UserPassword
    {
        get => _password;
        set
        {
            if (_password != value)
            {
                _password = value;
                OnPropertyChanged(nameof(UserPassword));
            }
        }
    }
    public bool EntryAsPassword
    {
        get => _enteryasPassword;
        set
        {
            if (_enteryasPassword != value)
            {
                _enteryasPassword = value;
                OnPropertyChanged(nameof(EntryAsPassword));
            }
        }
    }

    public SignInPage()
	{
		InitializeComponent();
        BindingContext = this;
        _enteryasPassword = true;
    }

    public object PasswordEntry { get; private set; }

    private void OnSignInButtonClicked(object sender, EventArgs e)
    {
        var visBtn = sender as Button;
        if (EntryAsPassword)
            visBtn!.Text = FontHelper.CLOSED_EYE_ICON;
        else
            visBtn!.Text = FontHelper.OPEN_EYE_ICON;

        EntryAsPassword = !EntryAsPassword;
    }
}
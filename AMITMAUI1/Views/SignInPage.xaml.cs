using AMITMAUI1.Helper;
using AMITMAUI1.Service;

namespace AMITMAUI1.Views;

public partial class SignInPage : ContentPage

{
    private string _username;
    private string _password;
    private bool _enteryasPassword;
    private bool _isDEbugMode => true;
    private DBMokup _dbMokup;
    public bool IsSignInButtonEnabled
    {
        get => !(string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(UserPassword));
    }
    public string Username
    {
        get => _username;
        set
        {
            if (_username != value)
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
                OnPropertyChanged(nameof(IsSignInButtonEnabled));
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
                OnPropertyChanged(nameof(IsSignInButtonEnabled));
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
        EntryAsPassword = true;

        _dbMokup = new DBMokup();

        if (_isDEbugMode)
        {
            Username = "admin@mail.com";
            UserPassword = "admin";
        }
    }

    void OnTugglePasswordButtonClicked(object sender, EventArgs e)
    {
        var visBtn = sender as Button;
        if (EntryAsPassword)
            visBtn!.Text = FontHelper.CLOSED_EYE_ICON;
        else
            visBtn!.Text = FontHelper.OPEN_EYE_ICON;

        EntryAsPassword = !EntryAsPassword;
    }
    
    private void OnSignInButtonClicked(object sender, EventArgs e)
    {
      if (_dbMokup.isExist(Username, UserPassword))
      {
            errorLbl.IsVisible=true;
            errorLbl.Text = "Sign in successful!";
      }
        else
        {
            errorLbl.IsVisible = true;

            errorLbl.Text = "Invalid username or password.";
        }
    }
}
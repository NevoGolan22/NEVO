using AMITMAUI1.Helper;
using AMITMAUI1.Service;

namespace AMITMAUI1.Views;

public partial class SignInPage : ContentPage

{
    private string _username;
    private string _password;
    private bool _enteryasPassword;
    private bool _isMessageLabelVisble;
    private string _MessageText;
    private Color _messageTextColor;
    private bool _isDEbugMode => true;
    private DBMokup _dbMokup;
    public bool IsSignInButtonEnabled
    {
        get => !(string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(UserPassword));
    }
    
    public bool IsMessageLabelVisble
    {
        get => _isMessageLabelVisble;
        set
        {
            if (_isMessageLabelVisble != value)
            {
                _isMessageLabelVisble = value;
                OnPropertyChanged(nameof(IsMessageLabelVisble));
            }
        }
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
    public string MessageText
    {
        get => _MessageText;
        set
        {
            if (_MessageText != value)
            {
                _MessageText = value;
                OnPropertyChanged(nameof(MessageText));
            }
        }
    }
    public Color MessageTextColor
    {
        get => _messageTextColor;
        set
        {
            if (_messageTextColor != value)
            {
                _messageTextColor = value;
                OnPropertyChanged(nameof(MessageTextColor));
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
    
     void OnSignInButtonClicked(object sender, EventArgs e)
     {
        var btn = sender as Button;
        if (_dbMokup.isExist(Username, UserPassword))
      {
            MessageText = MessagesHelper.SIGNINSUCCESSMESSAGE;
            MessageTextColor = Colors.Green;
        }
        else
        {
            MessageText = MessagesHelper.SIGNINERRORMESSAGE;
            MessageTextColor = Colors.Red;
        }
        IsMessageLabelVisble = true;
     }
    
}
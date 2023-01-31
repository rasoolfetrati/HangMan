using System.ComponentModel;

namespace HangMan;

public partial class MainPage : ContentPage, INotifyPropertyChanged
{
    #region Ui properties
    public string SpotLight
    {
        get => spotLight; 
        set
        {
            spotLight = value;
            OnPropertyChanged();
        }
    }
    #endregion
    #region Words
    List<string> words = new List<string>()
     {
        "python",
        "javascript",
        "maui",
        "csharp",
        "mongodb",
        "sql",
        "xaml",
        "word",
        "excel",
        "powerpoint",
        "code",
        "hotreload",
        "snippets"
     };
    List<char> guessed = new List<char>();
    string answer = "";
    private string spotLight;
    #endregion
    public MainPage()
    {
        InitializeComponent();
        BindingContext= this;
        PickWord();
        CalculateWord(answer, guessed);
    }

    #region Game Engine

    private void PickWord()
    {
        answer = words[new Random().Next(0, words.Count)];
    }
    #endregion
    private void CalculateWord(string answer, List<char> guessed)
    {
        var temp = answer.Select(x => (guessed.IndexOf(x) >= 0 ? x : '_')).ToArray();
        spotLight = string.Join(' ', temp);
    }

}


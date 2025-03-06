using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MatchGame;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        SetUpGame();
    }

    public void SetUpGame()
    {
        List<string> emojis = new List<string>()
        {
            "😀", "😀",
            "😍", "😍",
            "😉", "😉",
            "👍", "👍",
            "😘", "😘",
            "😒", "😒",
            "🤔", "🤔",
            "😮", "😮"
        };
           
        Random rand = new Random();

        foreach (TextBlock textBlock in mainGrid.Children.OfType<TextBlock>())
        {
            int index = rand.Next(emojis.Count);
            string nextEmoji = emojis[index];
            textBlock.Text = nextEmoji;
            emojis.RemoveAt(index);
        }
    }
}
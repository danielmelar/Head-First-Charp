using System.Windows;
using System.Windows.Controls;
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


    TextBlock lastTextBlockClicked;
    bool match = false;
    public void TextBlock_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
    {
        /* Se for o primeiro no 
         * par sendo clicado, veja
         * qual TextBlock
         * foi clicado e faça o animal desaparecer. Se 
         * for o segudo, faça-o desaparecer(se combinar) ou 
         * retorne o primeiro
         * (se não combinar).
         */

	TextBlock textBlock = sender as TextBlock;
	
	if (match is false)
	{
		textBlock.Visibility = Visibility.Hidden;
		lastTextBlockClicked = textBlock;
		match = true;
	}
	else if (textBlock.Text == lastTextBlockClicked.Text)
	{
		textBlock.Visibility = Visibility.Hidden;
		match = false;
	}
	else
	{
		lastTextBlockClicked.Visibility = Visibility.Visible;
		match = false;
	}


    }
}

using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
namespace MatchGame;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    DispatcherTimer timer = new DispatcherTimer();
    int tenthsOfSecondsElapsed;
    int matchesFound;

    public MainWindow()
    {
        InitializeComponent();

        timer.Interval = TimeSpan.FromSeconds(.1);
        timer.Tick += Timer_Tick;

        SetUpGame();
    }

    private void Timer_Tick(object sender, EventArgs e)
    {
        tenthsOfSecondsElapsed++;
        timeTextBlock.Text = (tenthsOfSecondsElapsed / 10F).ToString("0.0s");
        if (matchesFound == 8)
        {
            timer.Stop();
            timeTextBlock.Text = timeTextBlock.Text + " - Play again?";
        }
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
            if (textBlock.Name != "timeTextBlock")
            {
                int index = rand.Next(emojis.Count);
                string nextEmoji = emojis[index];
                textBlock.Text = nextEmoji;
                emojis.RemoveAt(index);
            }
        }

        timer.Start();
        tenthsOfSecondsElapsed = 0;
        matchesFound = 0;
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
            matchesFound++;
		    textBlock.Visibility = Visibility.Hidden;
		    match = false;
	    }
	    else
	    {
		    lastTextBlockClicked.Visibility = Visibility.Visible;
		    match = false;
	    }
    }

    private void TimeTextBlock_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
    {
        if (matchesFound == 8)
        {
            SetUpGame();
        }
    }
}

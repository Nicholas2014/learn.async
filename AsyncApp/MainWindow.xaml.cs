using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AsyncApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void btnStart_Click(object sender, RoutedEventArgs e)
        {
            // The display lines in the example lead you through the control shifts.
            resultsTextBox.Text += $"ONE({Thread.CurrentThread.ManagedThreadId}):   Entering startButton_Click.\r\n" +
                "           Calling AccessTheWebAsync.\r\n";

            Task<int> getLengthTask = AccessTheWebAsync();

            resultsTextBox.Text += $"\r\nFOUR({Thread.CurrentThread.ManagedThreadId}):  Back in startButton_Click.\r\n" +
                "           Task getLengthTask is started.\r\n" +
                "           About to await getLengthTask -- no caller to return to.\r\n";

            int contentLength = await getLengthTask;

            resultsTextBox.Text += $"\r\nSIX({Thread.CurrentThread.ManagedThreadId}):   Back in startButton_Click.\r\n" +
                "           Task getLengthTask is finished.\r\n" +
                "           Result from AccessTheWebAsync is stored in contentLength.\r\n" +
                "           About to display contentLength and exit.\r\n";

            resultsTextBox.Text +=
                $"\r\nLength of the downloaded string: {contentLength}.\r\n";
        }

        async Task<int> AccessTheWebAsync()
        {
            resultsTextBox.Text += $"\r\nTWO({Thread.CurrentThread.ManagedThreadId}):   Entering AccessTheWebAsync.";

            // Declare an HttpClient object.
            HttpClient client = new HttpClient();

            resultsTextBox.Text += "\r\n           Calling HttpClient.GetStringAsync.\r\n";

            // GetStringAsync returns a Task<string>.
            Task<string> getStringTask = client.GetStringAsync("https://msdn.microsoft.com");

            resultsTextBox.Text += $"\r\nTHREE({Thread.CurrentThread.ManagedThreadId}): Back in AccessTheWebAsync.\r\n" +
                "           Task getStringTask is started.";

            // AccessTheWebAsync can continue to work until getStringTask is awaited.

            resultsTextBox.Text +=
                "\r\n           About to await getStringTask and return a Task<int> to startButton_Click.\r\n";

            // Retrieve the website contents when task is complete.
            string urlContents = await getStringTask;

            resultsTextBox.Text += $"\r\nFIVE({Thread.CurrentThread.ManagedThreadId}):  Back in AccessTheWebAsync." +
                "\r\n           Task getStringTask is complete." +
                "\r\n           Processing the return statement." +
                "\r\n           Exiting from AccessTheWebAsync.\r\n";

            return urlContents.Length;
        }
    }
}

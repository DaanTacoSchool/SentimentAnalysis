using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

namespace Sentiment
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ProcessExecuter proc = new ProcessExecuter();
        Boolean phpExeIsset = false;
        string phpFilename = "";
        Boolean isRunning = false;
        public MainWindow()
        {
            InitializeComponent();

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            proc.runSentimentAnalysis(sentiment.Text, tweets.Text);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            phpFilename=proc.selectPHPExe();
            phpExeIsset = true;
            setButtonVisibility();
            phpPath.Text = phpFilename;
        }
        private void setButtonVisibility()
        {
            if (phpExeIsset)
            {
                btnSentiment.IsEnabled = true;
                btnStartServer.IsEnabled = true;
                btnHashtags.IsEnabled = true;
                btnTermFrequency.IsEnabled = true;
                btnStateMood.IsEnabled = true;
            }
            if (isRunning)
            {
                 btnRetrieveTweets.IsEnabled = true;
            }
        }

        private void phpPath_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btnStartServer_Click(object sender, RoutedEventArgs e)
        {
            int thePort = 0;
            bool didParse = false;
            try
            {
                thePort = Convert.ToInt32(txtPort.Text);
                if (thePort >= 1)
                {
                    didParse = true;
                }
                
            }
            catch(Exception ex)
            {
                didParse = false;
            };
            if (didParse)
            {
                isRunning = proc.startEmbeddedServer(thePort);
            }
            else
            {
                isRunning = proc.startEmbeddedServer(0);
            }
          
            if (isRunning)
            {
                txtStatus.Text = "Running";
            }
            else { txtStatus.Text = "Error Occurred, try again"; }
            setButtonVisibility();
        }

        private void btnRetrieveTweets_Click(object sender, RoutedEventArgs e)
        {
            bool isValid = false;
            int tp = 0;
            try
            {
                tp = Convert.ToInt32(txtNumTweets.Text);
                if (tp >= 1)
                {
                    isValid = true;
                }
            }catch(Exception ex)
            {
                isValid = false;
            }
            if (isValid)
            {


                bool tweetsRetrieved = proc.getTweets(tp);
                if (tweetsRetrieved)
                {
                    txtTweetSucces.Text = "Succces";
                }
                else
                {
                    txtTweetSucces.Text = "Error";
                }
            }
            else
            {
                bool tweetsRetrieved = proc.getTweets(20);
                if (tweetsRetrieved)
                {
                    txtTweetSucces.Text = "Succces";
                }
                else
                {
                    txtTweetSucces.Text = "Error";
                }
            }
           
        }

        private void btnTermFrequency_Click(object sender, RoutedEventArgs e)
        {
            proc.runTermFrequency(txtFrequency.Text);
            
        }

        private void btnStateMood_Click(object sender, RoutedEventArgs e)
        {
            proc.runStateMoods(txtStatemoodsSent.Text, txtStateMoods.Text);
        }

        private void txtStatemoodsSent_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btnHashtags_Click(object sender, RoutedEventArgs e)
        {
            proc.runCommonHashtags(txtHash.Text);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sentiment
{
    class ProcessExecuter
    {
        Boolean phpExeIsset = false;
        string phpPath = "";
        int intGPort = 0;
        public ProcessExecuter() {
           
        }
        public string selectPHPExe() {
       
            // Create OpenFileDialog 
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();



            // Set filter for file extension and default file extension 
            dlg.DefaultExt = ".exe";
           // dlg.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif";


            // Display OpenFileDialog by calling ShowDialog method 
            Nullable<bool> result = dlg.ShowDialog();


            // Get the selected file name and display in a TextBox 
            string filename = "";
            if (result == true)
            {
                // Open document 
                 filename = dlg.FileName;
                
               
            }
            phpExeIsset = true;
            phpPath = filename;
            return filename;
        }
        public bool startEmbeddedServer(int intPort) {

            //NOTE This will start a dedicated subprogram to start the server, this is done because while the server is running the program is not usable.

            Boolean runSucces = true;
            try
            { int tp = 0;
                bool isValid = false;
                try
                {
                    tp = Convert.ToInt32(intPort);
                    if (tp >= 0) {
                        isValid = true;
                        intGPort = tp;
                    }
                }catch(Exception ex)
                {

                }
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.FileName = @"Servercontroller.exe";
                startInfo.Arguments = phpPath +" "+tp;
                Process.Start(startInfo);
            }catch(Exception ex)
            {
                runSucces = false;
            }
         
            return runSucces;
        }
        public bool getTweets(int intTweetNum)
        {
            Boolean isSucces = true;
            try
            {
                string curDir = Directory.GetCurrentDirectory();
                string filepath = "C://Program Files//Internet Explorer//iexplore.exe";
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.FileName = filepath;
                
                if (intGPort != 0)
                {
                    string strTmp1= "http://localhost:" + intGPort + "/Scripts/RetrieveTweets.php?NT="+intTweetNum;
                    startInfo.Arguments = strTmp1;
                    Console.Out.WriteLine(intGPort);
                    Console.Out.WriteLine(strTmp1);
                }
                else
                {
                    startInfo.Arguments = "http://localhost:8000/Scripts/RetrieveTweets.php?NT=" + intTweetNum;
                }

                
              
                startInfo.CreateNoWindow = false;
                startInfo.ErrorDialog = false;
                startInfo.WorkingDirectory = curDir;
                
                //startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                startInfo.WindowStyle = ProcessWindowStyle.Normal;
                Process.Start(startInfo);
               
            }catch(Exception ex)
            {
                isSucces = false;
            }
            return isSucces;
        }
        public void runProces(string strOperation, string strSentiment, string strTweet) {
                string curDir = Directory.GetCurrentDirectory();
                //prepare input
                string input = "";
                if (strSentiment != "")
                {
               //  input = "../Userfiles/"+strSentiment + " " + "../Userfiles/"+ strTweet;
                input = strSentiment + " " + strTweet;
                }
                else
                {
                    input = strTweet;
                }
                //NOTE: change path according to your own PHP.exe file, if you have the proper environment variables setup, then you can just call PHP.exe directly without the path

                //string call = @"""c:\Program Files (x86)\PHP\php.exe""";
                //string call = curDir;
                // string call = selectPHPExe();
                string call = "";
                if (phpExeIsset && phpPath != "")
                {
                    call = phpPath;
                }
                else { call = selectPHPExe(); }

                //To execute the PHP file.
                string param1 = @"-f";

                //the PHP wrapper class file location. NOTE: remember to enclose in " (quotes) if there is a space in the directory structure. 
                //string param2 = @"""C:\Some Directory\WrapperPHP.php""";
                string param2 = '"' + curDir + '"' + ".//Scripts//" + strOperation;
                Process myProcess = new Process();

                // Start a new instance of this program but specify the 'spawned' version. using the PHP.exe file location as the first argument.
                ProcessStartInfo myProcessStartInfo = new ProcessStartInfo(call, "spawn");
                myProcessStartInfo.UseShellExecute = false;
                myProcessStartInfo.RedirectStandardOutput = true;

                //Provide the other arguments.
                myProcessStartInfo.Arguments = string.Format("{0} {1} {2}", param1, param2, input);
                myProcess.StartInfo = myProcessStartInfo;

                //Execute the process
                myProcess.Start();
                StreamReader myStreamReader = myProcess.StandardOutput;

                // Read the standard output of the spawned process.
                string myString = myStreamReader.ReadLine();

                Console.WriteLine(myString);
            
        }

        public void test(string resultfile)
        {
            string curDir = Directory.GetCurrentDirectory()+"\\Userfiles";
            Process myProcess = new Process();

            // Start a new instance of this program but specify the 'spawned' version. using the PHP.exe file location as the first argument.
            ProcessStartInfo myProcessStartInfo = new ProcessStartInfo();
            myProcessStartInfo.UseShellExecute = false;
            myProcessStartInfo.WorkingDirectory = curDir;
            myProcessStartInfo.RedirectStandardOutput = true;
            myProcessStartInfo.FileName = resultfile;

            //Provide the other arguments.
          //  myProcessStartInfo.Arguments = string.Format("{0} {1} {2}", param1, param2, input);
            myProcess.StartInfo = myProcessStartInfo;

            //Execute the process
           
            myProcess.Start();
            StreamReader myStreamReader = myProcess.StandardOutput;

            // Read the standard output of the spawned process.
            string myString = myStreamReader.ReadLine();

            Console.WriteLine(myString);
        }
        public void runSentimentAnalysis(string strSentimentfile, string strTweetfile)
        {
            runProces("SentimentAnalysis.php", "SentimentScore.txt", "tweets.txt");
            Console.Out.WriteLine("test");
            // test("tweetscores.txt");
            //werkt  Process.Start(@"C:\\Users\\D2110175\\Documents\\Visual Studio 2017\\Projects\\Sentiment\\Sentiment\\bin\\Debug\\Userfiles\\tweetscores.txt");
            Process.Start(@"Userfiles\\tweetscores.txt");

        }
        public void runTermFrequency(string strTweetfile)
        {
            runProces("TermFrequency.php", "", strTweetfile);
            Process.Start(@"Userfiles\\termfrequency.txt");
        }
        public void runStateMoods(string strSentiment,string strTweetfile)
        {
            runProces("StateMoods.php", strSentiment, strTweetfile);
            Process.Start(@"Userfiles\\happieststate.txt");
        }
        public void runCommonHashtags(string strTweetfile)
        {
            runProces("MostCommonHashtags.php", "", strTweetfile);
            Process.Start(@"Userfiles\\commonhashtags.txt");
        }


    }   
}

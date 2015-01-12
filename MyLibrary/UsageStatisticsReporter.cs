using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace MyLibrary {

    public delegate void UserStatisticsSendingHandler();

    public partial class UsageStatisticsReporter : Component {
        public event UserStatisticsSendingHandler UserStatisticsSend;
        private List<string> userActions = new List<string>();
        private Timer timer = new Timer(10*1000);
        private Uri statisticsCollectingServer;        

        [Category("Server connection data")]
        public Uri StatisticsCollectingServer {
            get { return statisticsCollectingServer; }
            set { statisticsCollectingServer = value; }
        }
        [Category("Server connection data")]
        public Timer Timer {
            get { return timer; }
            set { timer = value; }
        }

        //-- CONSTRUCTOR --
        public UsageStatisticsReporter(/*IContainer container*/) {
            //container.Add(this);
            InitializeComponent();
            System.Diagnostics.Debug.WriteLine("Usage Statistics Reporter raised");
            if(UserStatisticsSend != null){
                UserStatisticsSend();
            }
            //clear the list 
            userActions.Clear();
            timer.Elapsed += new ElapsedEventHandler(sendDataToTheStatisticsCollectingServer);
            timer.Start();
        }

        public void reportClickedButton(string buttonName){
            userActions.Add("Clicked:  " + buttonName);
        }
        public void reportAddedDocuemnts(int howManyDocs){
            userActions.Add("Number of documents added : " + howManyDocs);
        }
        public void reportDeletedDocuments(int howManyDocs){
            userActions.Add("Number of documents added : " + howManyDocs);
        }

        public void sendDataToTheStatisticsCollectingServer(object sender, ElapsedEventArgs e) {
            System.Diagnostics.Debug.WriteLine("Statistic data send");
            if (userActions.Count > 0){
                System.Diagnostics.Debug.WriteLine("Writing to file " + userActions.Count + " events!");
                System.IO.StreamWriter file = new System.IO.StreamWriter(
                    @"C:\Users\Aleksandra\Desktop\JPP_W_Ptasznik\SerwerGry\statistics.txt", true);
                file.WriteLine(string.Join("\r\n", userActions));
                file.Close();
                userActions.Clear();
            }
        }


    }
}

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
        private List<string> userActionsInfo = new List<string>();
        private Timer timer = new Timer(15*1000);
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
            timer.Elapsed += new ElapsedEventHandler(sendDataToTheStatisticsCollectingServer);
        }

        public void reportClickedButton(string buttonName){
            userActionsInfo.Add("Button clisked " + buttonName);
        }
        public void reportAddedDocuemnts(int howManyDocs){
            userActionsInfo.Add("Number of documents added : " + howManyDocs);
        }
        public void reportDeletedDocuments(int howManyDocs){
            userActionsInfo.Add("Number of documents added : " + howManyDocs);
        }

        public void sendDataToTheStatisticsCollectingServer(object sender, ElapsedEventArgs e) {
            //TODO: making JSON from the userActionsInfo List and sending to the server
            //http:// msdn.microsoft.com/en-us/library/debx8sh9%28v=vs.110%29.aspx
            System.Diagnostics.Debug.WriteLine("Data send");
        }


    }
}

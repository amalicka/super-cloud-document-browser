using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary {

    public delegate void UserStatisticsSendingHandler();

    public partial class UsageStatisticsReporter : Component {
        private List<string> userActionsInfo = new List<string>();

        private Uri statisticsCollectingServer;
        public event UserStatisticsSendingHandler UserStatisticsSend;
        [Category("Server connection data")]
        public Uri StatisticsCollectingServer {
            get { 
                return statisticsCollectingServer; 
            }
            set { 
                statisticsCollectingServer = value; 
            }
        }

        public UsageStatisticsReporter() {
            InitializeComponent();

            
            
        }

        public UsageStatisticsReporter(IContainer container) {
            container.Add(this);

            InitializeComponent();

            if(UserStatisticsSend != null){
                UserStatisticsSend();
            }
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

        public void sendDataToTheStatisticsCollectingServer() {
            //TODO: making JSON from the userActionsInfo List and sending to the server
            //http:// msdn.microsoft.com/en-us/library/debx8sh9%28v=vs.110%29.aspx
        }


    }
}

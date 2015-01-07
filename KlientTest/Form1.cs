using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KlientTest.ServiceGameReference;

namespace KlientTest {
    public partial class Form1 : Form {
        Player ja = new Player();
        Player[] playersi = new Player[0];
        ServiceGameClient client = new ServiceGameClient();
        public Form1() {
            InitializeComponent();
            ja.Nick = textBox1.Text;
            ja.X = 300;
            ja.Y = 300;
            timer1.Start();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e) {
            foreach (var p in playersi) {
                e.Graphics.FillEllipse(Brushes.Red, (float)p.X - 8, (float)p.Y - 8, 16, 16);
                e.Graphics.DrawString(p.Nick, Font, Brushes.Red, (float)p.X + 8, (float)p.Y + 8);
            }
        }

        private void timer1_Tick(object sender, EventArgs e) {
            //if (client.State == System.ServiceModel.CommunicationState.Opened ||
            //    client.State == System.ServiceModel.CommunicationState.Created) {
                //client.SendData(ja);
                //playersi = client.GetData();
                pictureBox1.Refresh();
           // }
        }

        private void button1_Click(object sender, EventArgs e) {
            label1.Text = myComponent1.dajMiText();
        }

        
    }
}



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
        //Player ja = new Player();
        //Player[] playersi = new Player[0];
        Document[] documents = new Document[10];

        ServiceGameClient client = new ServiceGameClient();
        public Form1() {
            InitializeComponent();
            //ja.Nick = textBox1.Text;
            //ja.X = 300;
            //ja.Y = 300;
            timer1.Start();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e) {
            //foreach (var p in playersi) {
            //    e.Graphics.FillEllipse(Brushes.Red, (float)p.X - 8, (float)p.Y - 8, 16, 16);
            //    e.Graphics.DrawString(p.Nick, Font, Brushes.Red, (float)p.X + 8, (float)p.Y + 8);
            //}
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

        private void button2_Click(object sender, EventArgs e) {
            
            //client.InserTestDocs();
            //Document dok1 = new DocumentDoc("Dokument 1", "Autor 1");
            //Document dok2 = new DocumentDoc("Dokument 1", "Autor 2");
            //Document dok3 = new DocumentDoc("Dokument 1", "Autor 3");
            //Document dok4 = new DocumentDoc("Dokument 1", "Autor 4");
            //Document dok5 = new DocumentDoc("Dokument 1", "Autor 5");
            //Document dok6 = new DocumentDoc("Dokument 1", "Autor 6");
            Document dok1 = new DocumentDoc();
            Document dok2 = new DocumentDoc();
            Document dok3 = new DocumentDoc();
            Document dok4 = new DocumentDoc();
            Document dok5 = new DocumentDoc();
            Document dok6 = new DocumentPdf();
            documents[0] = dok1;
            documents[1] = dok2;
            documents[2] = dok3;
            documents[3] = dok4;
            documents[4] = dok5;
            documents[5] = dok6;
            label1.Text = "Zrobiono testowe dokumenty";

            //if (client.State == System.ServiceModel.CommunicationState.Opened ||
            //    client.State == System.ServiceModel.CommunicationState.Created) {
                client.SendData(documents);
            //}
            label1.Text = "Zrobiono SendData";
            System.Diagnostics.Debug.WriteLine("1 Debug po SendData");
        }

        private void button3_Click(object sender, EventArgs e) {
            System.Diagnostics.Debug.WriteLine(" docu wypisz extention: "+ documents[0].FileExtension + " ! ");
            System.Diagnostics.Debug.WriteLine(" docu wypisz: " + documents[0].ToString());
            System.Diagnostics.Debug.WriteLine(" docu wypisz: " + documents[5].ToString());
            System.Diagnostics.Debug.WriteLine("2 Kliknieto wyswietl dane");
            label1.Text = "Spis dokumentów: ";
            System.Diagnostics.Debug.WriteLine("3 Zmieniono tekst labelki");
            documents = client.GetData();
            System.Diagnostics.Debug.WriteLine("4 Zrbion GetData");
            label2.Text = documents[0].Name;// Convert.ToString(documents[0].Name);// + " " +  documents[0].Author + " " + documents[0].FileExtension + " " +  Convert.ToString(documents[0].Size);
            System.Diagnostics.Debug.WriteLine("docu extention: " + documents[0].FileExtension + " !!! ");
            System.Diagnostics.Debug.WriteLine(" docu wypisz: " + documents[0].ToString());
            System.Diagnostics.Debug.WriteLine(" docu wypisz: " + documents[5].ToString());
            //foreach (var d in documents) {
            //    richTextBox1.AppendText(Convert.ToString(d.ToString()));
            //}
            System.Diagnostics.Debug.WriteLine("5 END");
        }
    }
}



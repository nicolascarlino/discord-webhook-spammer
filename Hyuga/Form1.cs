using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Collections.Specialized;

namespace Hyuga
{
    public partial class Window : Form
    {
        // Defs
        bool spam_state = false;
        string name = "Hyuga";

        public Window()
        {
            InitializeComponent();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (whname.Text.Length == 0)
            {
                MessageBox.Show("Invalid name");
            }

            else
            {
                name = whname.Text;
                output.Text += $"[Hyuga] Sucefully saved name \n";
            }
        }

        private void start_spam_Click(object sender, EventArgs e)
        {
            try
            {
                if (spam_state == true)
                {
                    spam_state = false;
                    start_spam.Text = "start";
                    output.Text += "[Hyuga] Stopped spam to Webhook \n";
                }

                else
                {
                    spam_state = true;
                    start_spam.Text = "stop";
                    output.Text += "[Hyuga] Started spam to Webhook \n";

                    if (spam_state == true)
                    {
                        string webhook = whspaminput.Text;


                        if (msge.Text.Length == 0)
                        {
                            MessageBox.Show("Invalid Message");
                        }

                        else
                        {
                            string mssge = msge.Text;

                            // Deleting Webhook
                            var httpRequest = (HttpWebRequest)WebRequest.Create(webhook);

                            spam_state = true;

                            void sWh(string URL, string msg, string nn)
                            {
                                Http.Post(URL, new NameValueCollection()
                                {
                                    { "username", name },
                                    { "content", mssge }
                                });
                            }

                            async Task requests()
                            {
                                while (spam_state == true)
                                {
                                    sWh(webhook, string.Concat(new string[] { mssge }), name);
                                    await Task.Delay(1000);
                                }
                            }
                            requests();
                        }
                    }
                }
            }

            // Unknown Webhook
            catch
            {
                output.Text += "[Hyuga] Invalid Webhook Code \n";
            }
        }

        private void delete_Click(object sender, EventArgs e)
        {
            try
            {
                // Deleting Webhook
                var httpRequest = (HttpWebRequest)WebRequest.Create(whinput.Text);
                httpRequest.Method = "DELETE";
                httpRequest.Accept = "*/*";

                // Sucefully deleted
                var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
                output.Text += "[Hyuga] Sucefully deleted Webhook \n";
            }

            catch
            {
                output.Text += "[Hyuga] Unknown Webhook Code \n";
            }
        }

        private void close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void Window_MouseUp(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        // Move Window
        int m, mx, my;
        private void panel5_MouseUp(object sender, MouseEventArgs e)
        {
            m = 0;
        }

        private void groupBox6_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel5_MouseMove(object sender, MouseEventArgs e)
        {
            if (m == 1)
            {
                this.SetDesktopLocation(MousePosition.X - mx, MousePosition.Y - my);
            }
        }

        private void panel5_MouseDown(object sender, MouseEventArgs e)
        {
            m = 1;
            mx = e.X;
            my = e.Y;
        }
    }
}

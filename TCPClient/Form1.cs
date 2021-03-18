using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

namespace TCPClient
{
    public partial class TCPClient : Form
    {

        TcpClient client;
        int port = 12345;

        public TCPClient()
        {
            InitializeComponent();
        }

        private void TCPClient_Load(object sender, EventArgs e)
        {

        }

        private void btnSayHello_Click(object sender, EventArgs e)
        {
            IPAddress adress = IPAddress.Parse(tbxIPAdress.Text);
            client = new TcpClient();
            client.NoDelay = true;
            client.Connect(adress, port);

            if (client.Connected)
            {
                byte[] outData = Encoding.Unicode.GetBytes("Hello!");
                client.GetStream().Write(outData, 0, outData.Length);
                client.Close();
            }
        }
    }
}

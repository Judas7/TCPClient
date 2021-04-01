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

        private void btnSayHello_Click(object sender, EventArgs e) //När man klickar på knappen kopplas klienten till servern och "hello" skickas till inkorgen i servern.
        {
            IPAddress adress = IPAddress.Parse(tbxIPAdress.Text); //IP adressen som skrevs in av användaren i klienten lagras. 
            client = new TcpClient(); //Ny klient skapas
            client.NoDelay = true;
            client.Connect(adress, port); //Klienten kopplas till servern med rätt IP samt port. 

            if (client.Connected) //Om klienten kopplas så skickas meddelandet. 
            {
                byte[] outData = Encoding.Unicode.GetBytes("Hello!"); //Här görs meddelandet om till ettor och nollor
                client.GetStream().Write(outData, 0, outData.Length) //Här skickas meddelandet iväg till servern
                client.Close();
            }
        }
    }
}

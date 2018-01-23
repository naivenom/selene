using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Net.NetworkInformation;
using System.Net;
using System.Net.Sockets;
using System.IO;


namespace selene
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
            CheckForIllegalCrossThreadCalls = false;
        }
        Thread myThread = null;

        public void _netBios(string _host, string _port)
        {
            int port = Int32.Parse(_port);
            OutPut.Items.Clear();
            UdpClient udpClient = new UdpClient();
            try
            {
                udpClient.Connect(_host, port);
                
                Byte[] sendBytes = {0xce, 0x5b, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x20,
                0x43, 0x4b, 0x41, 0x41, 0x41, 0x41, 0x41, 0x41, 0x41, 0x41, 0x41, 0x41, 0x41, 0x41, 0x41, 0x41, 0x41, 0x41, 0x41, 0x41, 0x41, 0x41, 0x41,
                    0x41, 0x41, 0x41, 0x41, 0x41, 0x41, 0x41, 0x41, 0x41, 0x00, 0x00, 0x21, 0x00, 0x01 };

                udpClient.Send(sendBytes, sendBytes.Length);
                while (true)
                {
                    IPEndPoint RemoteIpEndPoint = new IPEndPoint(IPAddress.Any, 0);
                    Byte[] receiveBytes = udpClient.Receive(ref RemoteIpEndPoint);
                    string StringByte = BitConverter.ToString(receiveBytes);
                    int bytes = receiveBytes.Length;
                    
                    OutPut.Items.Add(new ListViewItem(new String[] { "Paquete (bytes): "+ bytes.ToString(), StringByte }));
                    string _dataReceive = StringByte;
                    _dataReceive = StringByte.Replace("-", "");
                    byte[] raw = new byte[_dataReceive.Length / 2];
                    
                    List<string> list = new List<string>();
                    for (int i = 0; i < raw.Length; i++)
                    {
                        
                        raw[i] = Convert.ToByte(_dataReceive.Substring(i * 2, 2), 16);
                        char c = Convert.ToChar(raw[i]);
                        
                        string d = c.ToString();
                        list.Add(d);
                        //OutPut.Items.Add(new ListViewItem(new String[] {"Salida:", d }));
                        
                    }
                    
                    string[] terms = list.ToArray();
                    OutPut.Items.Add(new ListViewItem(new String[] {"NetBios Name:", terms[57] + terms[58] + terms[59] + terms[60] + terms[61] + terms[62] + terms[63] + terms[64] }));
                    OutPut.Items.Add(new ListViewItem(new String[] { "NetBios Name:", terms[129] + terms[130] + terms[131] + terms[132] + terms[133] + terms[134] + terms[135] + terms[136] }));
                  
                }
       
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            
        }
        private void nBNSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ipAddress.Text == string.Empty)
            {
                MessageBox.Show("No se ha introducido ninguna IP.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (Port.Text == string.Empty)
            {
                MessageBox.Show("No se ha introducido ningun puerto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                myThread = new Thread(() => _netBios(ipAddress.Text, Port.Text));
                myThread.Start();

                if (myThread.IsAlive == true)
                {
                    stop.Enabled = true;
                    ipAddress.Enabled = false;
                }
            }
        }

       
    }
}

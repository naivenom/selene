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
        public void _smb(string _host, string _port)
        {
            int port = Int32.Parse(_port);
            OutPut.Items.Clear();
            
            TcpClient tcpClient = new TcpClient();
            try
            {
                tcpClient.Connect(_host, port);
                while (true)
                {
                    Byte[] _protocolRequest = { 0x00, 0x00, 0x00, 0x54, 0xff, 0x53, 0x4d, 0x42, 0x72, 0x00, 0x00, 0x00, 0x00, 0x18, 0x01, 0x28,
                    0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x58, 0x4d,
                    0x00, 0x00, 0x23, 0xd0, 0x00, 0x31, 0x00, 0x02, 0x4c, 0x41, 0x4e, 0x4d, 0x41, 0x4e, 0x31, 0x2e,
                    0x30, 0x00, 0x02, 0x4c, 0x4d, 0x31, 0x2e, 0x32, 0x58, 0x30, 0x30, 0x32, 0x00, 0x02, 0x4e, 0x54,
                    0x20, 0x4c, 0x41, 0x4e, 0x4d, 0x41, 0x4e, 0x20, 0x31, 0x2e, 0x30, 0x00, 0x02, 0x4e, 0x54, 0x20,
                    0x4c, 0x4d, 0x20, 0x30, 0x2e, 0x31, 0x32, 0x00};
                    NetworkStream stream = tcpClient.GetStream();

                    stream.Write(_protocolRequest, 0, _protocolRequest.Length);
                    _protocolRequest = new Byte[1024];

                    // String to store the response ASCII representation.
                    String responseData = String.Empty;
                    // Numero de Bytes del paquete recibido
                    Int32 bytes = stream.Read(_protocolRequest, 0, _protocolRequest.Length);
                    responseData = BitConverter.ToString(_protocolRequest, 0, bytes);
                    OutPut.Items.Add(new ListViewItem(new String[] { "Negotiate Protocol Response (bytes): " + bytes.ToString(), responseData }));
                    // Close everything.
                    //stream.Close();
                    //tcpClient.Close();
                    Byte[] _sessionSetupAndXRequest = { 0x00, 0x00, 0x00, 0x63, 0xff, 0x53, 0x4d, 0x42, 0x73, 0x00, 0x00, 0x00, 0x00, 0x18, 0x01, 0x20,
                    0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x18, 0x0e,
                    0x00, 0x00, 0x16, 0x59, 0x0d, 0xff, 0x00, 0x00, 0x00, 0xdf, 0xff, 0x02, 0x00, 0x01, 0x00, 0xa2,
                    0x17, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x40, 0x00, 0x00, 0x00, 0x26,
                    0x00, 0x00, 0x2e, 0x00, 0x57, 0x69, 0x6e, 0x64, 0x6f, 0x77, 0x73, 0x20, 0x32, 0x30, 0x30, 0x30,
                    0x20, 0x32, 0x31, 0x39, 0x35, 0x00, 0x57, 0x69, 0x6e, 0x64, 0x6f, 0x77, 0x73, 0x20, 0x32, 0x30,
                    0x30, 0x30, 0x20, 0x35, 0x2e, 0x30, 0x00};
                    NetworkStream stream1 = tcpClient.GetStream();
                    stream1.Write(_sessionSetupAndXRequest, 0, _sessionSetupAndXRequest.Length);
                    _sessionSetupAndXRequest = new Byte[1024];

                    // String to store the response ASCII representation.
                    String responseData1 = String.Empty;
                    // Numero de Bytes del paquete recibido
                    Int32 bytes1 = stream1.Read(_sessionSetupAndXRequest, 0, _sessionSetupAndXRequest.Length);
                    responseData1 = BitConverter.ToString(_sessionSetupAndXRequest, 0, bytes1);
                    OutPut.Items.Add(new ListViewItem(new String[] { "Session Setup AndX Response(bytes): " + bytes1.ToString(), responseData1 }));
                    string _dataReceive = responseData1;
                    _dataReceive = responseData1.Replace("-", "");
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
                    OutPut.Items.Add(new ListViewItem(new String[] { "Native OS:", terms[45] + terms[46] + terms[47] + terms[48] }));
                    OutPut.Items.Add(new ListViewItem(new String[] { "Version Service:", terms[50] + terms[51] + terms[52] + terms[53] + terms[54] + terms[55] + terms[56] + terms[57] + terms[58] + terms[59] + terms[60] + terms[61] + terms[62] + terms[63] + terms[64] + terms[65] + terms[66] }));
                    // Close everything.
                    stream1.Close();
                    tcpClient.Close();


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

        private void sMBToolStripMenuItem_Click(object sender, EventArgs e)
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
                myThread = new Thread(() => _smb(ipAddress.Text, Port.Text));
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

using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Lab17
{
    public partial class Form1 : Form
    {
        private TcpListener tcpListener;
        private TcpClient tcpClient;
        private NetworkStream stream;
        private readonly Thread listenThread;

        public Form1()
        {
            InitializeComponent();
            listenThread = new Thread(new ThreadStart(ListenForClients));
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            listenThread.Start();
            AddMessage("������ ��������.");
        }

        private void ListenForClients()
        {
            try
            {
                tcpListener = new TcpListener(IPAddress.Any, 8888);
                tcpListener.Start();
                AddMessage("������ ����� �'�������...");

                while (true)
                {
                    if (!tcpListener.Pending())
                    {
                        Thread.Sleep(100);
                        continue;
                    }

                    tcpClient = tcpListener.AcceptTcpClient();
                    stream = tcpClient.GetStream();

                    byte[] message = new byte[4096];
                    int bytesRead;

                    while (true)
                    {
                        bytesRead = 0;

                        try
                        {
                            bytesRead = stream.Read(message, 0, 4096);
                        }
                        catch
                        {
                            break;
                        }

                        if (bytesRead == 0)
                        {
                            break;
                        }

                        string receivedMessage = Encoding.Unicode.GetString(message, 0, bytesRead);
                        AddMessage(receivedMessage);
                    }

                    tcpClient.Close();
                }
            }
            catch (Exception ex)
            {
                AddMessage("�������: " + ex.Message);
            }
        }

        private void SendMessage(string message)
        {
            byte[] data = Encoding.Unicode.GetBytes(message);
            stream.Write(data, 0, data.Length);
        }

        private void AddMessage(string message)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string>(AddMessage), message);
                return;
            }
            messagesListBox.Items.Add(message);
        }

        private void sendButton_Click(object sender, EventArgs e)
        {
            if (tcpClient == null)
            {
                MessageBox.Show("�� �� �������� �� ������� �������. �������� ������ ��� ����������� �� �������.");
                return;
            }

            string message = $"{userNameTextBox.Text}: {inputTextBox.Text}";
            SendMessage(message);
            inputTextBox.Clear();
        }

        private void connectButton_Click(object sender, EventArgs e)
        {
            if (tcpClient != null)
            {
                MessageBox.Show("�� ��� �������� �� �������.");
                return;
            }

            try
            {
                tcpClient = new TcpClient();
                tcpClient.Connect("127.0.0.1", 8888);
                stream = tcpClient.GetStream();
                SendMessage(userNameTextBox.Text);

                Thread receiveThread = new Thread(ReceiveMessage);
                receiveThread.Start();

                AddMessage("ϳ�������� �� �������.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("������� ���������� �� �������: " + ex.Message);
            }
        }

        private void ReceiveMessage()
        {
            byte[] data = new byte[4096];
            int bytes;

            while (true)
            {
                try
                {
                    bytes = stream.Read(data, 0, data.Length);
                    string message = Encoding.Unicode.GetString(data, 0, bytes);
                    AddMessage(message);
                }
                catch
                {
                    break;
                }
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (tcpListener != null)
            {
                tcpListener.Stop();
            }

            if (tcpClient != null)
            {
                stream.Close();
                tcpClient.Close();
            }
        }
    }
}

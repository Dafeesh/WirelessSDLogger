using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WirelessLoggerClient
{
    enum Cmd
    {
        Null = 0,
        DeleteAll = '!',
        ResendFill = '&',

        Update_Front = '<',
        Update_Tail = '>',

        FillEntry_Front = '(',
        FillEntry_Tail = ')',
    }

    public partial class LogClientForm : Form
    {
        static readonly IPEndPoint EndPoint = new IPEndPoint(IPAddress.Parse("192.168.4.1"), 9000);

        private TcpClient _con = new TcpClient();
        private Thread _conListenThread;

        public LogClientForm()
        {
            InitializeComponent();

            _conListenThread = new Thread(new ThreadStart(__THREAD_listenToConnection));
            _conListenThread.Start();
        }

        private void LogClientForm_Shown(object sender, EventArgs e)
        {
            button_connect_Click(sender, e);
        }

        private void LogClientForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                _conListenThread.Abort();
            }
            catch (Exception)
            { }
        }

        private void button_connect_Click(object sender, EventArgs e)
        {
            if (!Connected)
            {
                try
                {
                    var result = _con.BeginConnect(EndPoint.Address, EndPoint.Port, null, _con);
                    var success = result.AsyncWaitHandle.WaitOne(TimeSpan.FromSeconds(3));
                    if (success)
                    {
                        _con.EndConnect(result);
                        _con.Client.Send(CmdBytes(Cmd.ResendFill));
                    }
                    else
                        throw new Exception("No connection.");
                }
                catch (SocketException se)
                {
                    MessageBox.Show(this, "Failed to connect. \r\nSocket: " + se.ToString());
                }
                catch (Exception ee)
                {
                    MessageBox.Show(this, "Failed to connect. \r\n" + ee.Message);
                }
                finally
                {
                    if (!Connected)
                    {
                        _con.Client.Close();
                        _con.Client.Dispose();
                        _con.Close();
                        _con = new TcpClient();
                    }
                }
            }

            checkBox_connected.Checked = Connected;
        }

        private void button_deleteAll_Click(object sender, EventArgs e)
        {
            if (Connected)
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete everything on the device?", "Warning", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    Console.Write("(DELETE)");
                    _con.Client.Send(CmdBytes(Cmd.DeleteAll));
                }
            }
        }

        private void __THREAD_listenToConnection()
        {
            string interp = "";
            bool interping = false;
            char[] reading = new char[3];
            byte[] incomingBuffer = new byte[1];

            try
            {
                while (true)
                {
                    try
                    {
                        if (!Connected)
                        {
                            Console.WriteLine("Not connected...waiting...");
                            Thread.Sleep(1000);
                            continue;
                        }

                        while (_con.Available > 0)
                        {
                            _con.Client.Receive(incomingBuffer, 0, incomingBuffer.Length, SocketFlags.None);

                            reading[2] = reading[1];
                            reading[1] = reading[0];
                            reading[0] = Convert.ToChar(incomingBuffer[0]);

                            Console.Write(reading[0]);

                            if (reading[2] == reading[1] && reading[1] == reading[0] &&
                                !Char.IsNumber((char)reading[0]))
                            {
                                /*
                                switch ((Cmd)reading[0])
                                {
                                    case (Cmd.FillingOn):
                                        this.Invoke(new Action(() =>
                                        {
                                            SetTextFlow(true);
                                            Console.Write("(F+)");
                                        }));
                                        break;
                                    case (Cmd.FillingOff):
                                        this.Invoke(new Action(() =>
                                        {
                                            Console.Write("(F-)");
                                            SetTextFlow(false);
                                        }));
                                        break;
                                    case (Cmd.GuardOn):
                                        this.Invoke(new Action(() =>
                                        {
                                            Console.Write("(G-)");
                                            SetTextGuard(true);
                                        }));
                                        break;
                                    case (Cmd.GuardOff):
                                        this.Invoke(new Action(() =>
                                        {
                                            Console.Write("(G+)");
                                            SetTextGuard(false);
                                        }));
                                        break;
                                }
                                */

                                if (interping)
                                {
                                    switch ((Cmd)reading[0])
                                    {
                                        case (Cmd.Update_Tail):

                                            Console.Write("(-U)");
                                            {
                                                string[] pieces = interp.Trim().Split(',');
                                                this.Invoke(new Action(() =>
                                                {
                                                    try
                                                    {
                                                        SetTextRunId(long.Parse(pieces[0]));
                                                        SetTextTime(long.Parse(pieces[1]));
                                                        SetTextSensors(int.Parse(pieces[2]), int.Parse(pieces[3]));
                                                        SetTextFlow(int.Parse(pieces[4]) > 0);
                                                        SetTextGuard(int.Parse(pieces[5]) > 0);
                                                    }
                                                    catch (Exception e)
                                                    { Console.WriteLine("Unable to parse update: " + e.ToString()); }
                                                }));
                                                interping = false;
                                            }
                                            break;

                                        case (Cmd.FillEntry_Tail):

                                            Console.Write("(-F)");
                                            {
                                                string[] pieces = interp.Trim().Split(',');
                                                this.Invoke(new Action(() =>
                                                {
                                                    try
                                                    {
                                                        SetTextFillId(long.Parse(pieces[1]));
                                                        SetTextFillTime(long.Parse(pieces[2]));
                                                        SetTextFillDuration(long.Parse(pieces[3]) - long.Parse(pieces[2]));
                                                        SetTextLeak(int.Parse(pieces[4]) != 0);
                                                        SetTextDelta(int.Parse(pieces[5]));
                                                    }
                                                    catch (Exception e)
                                                    { Console.WriteLine("Unable to parse fill: " + e.ToString()); }
                                                }));
                                                interping = false;
                                            }
                                            break;
                                    }
                                }
                                else
                                {
                                    switch ((Cmd)reading[0])
                                    {
                                        case (Cmd.DeleteAll):
                                            Console.WriteLine("(Delete confirmed)");
                                            this.Invoke(new Action(() =>
                                            {
                                                MessageBox.Show(this, "Device successfully cleared!");
                                            }));
                                            break;

                                        case (Cmd.Update_Front):
                                            Console.Write("(+U)");
                                            interp = "";
                                            interping = true;
                                            break;

                                        case (Cmd.FillEntry_Front):
                                            Console.Write("(+F)");
                                            interp = "";
                                            interping = true;
                                            break;
                                    }
                                }
                            }
                            else
                            {
                                if (interping)
                                {
                                    char c = (char)reading[0];
                                    if (Char.IsNumber(c) || c == ',' || c == '\n')
                                    {
                                        interp += c;
                                    }
                                }
                            }
                        }
                    }
                    catch (ThreadAbortException)
                    { }
                    catch (Exception e)
                    { Console.WriteLine(e.ToString()); }
                    Thread.Sleep(10);
                }
            }
            finally
            {
                try
                {
                    _con.Close();
                }
                catch (Exception)
                { }
            }
        }

        private bool Connected
        {
            get
            {
                return _con.Connected;
            }
        }

        private byte[] CmdBytes(Cmd cmd)
        {
            return new byte[] { (byte)cmd, (byte)cmd, (byte)cmd };
        }

        private void SetTextRunId(long id)
        {
            textBox_runId.Text = id.ToString();
        }
        private void SetTextTime(long millis)
        {
            textBox_time.Text = TimeSpan.FromMilliseconds(millis).ToString(@"hh\:mm\:ss");
        }
        private void SetTextSensors(int a, int b)
        {
            textBox_sensorA.Text = (25f * ((a * 5f) / 1024f) + 12.5).ToString("N");
            textBox_sensorB.Text = (25f * ((b * 5f) / 1024f) + 12.5).ToString("N");
        }
        private void SetTextFlow(bool on)
        {
            textBox_readFlow.Text = on ? "On" : "Off";
        }
        private void SetTextGuard(bool on)
        {
            textBox_guard.Text = on ? "On" : "Off";
        }
        private void SetTextFillId(long id)
        {
            textBox_fillNumber.Text = id.ToString();
        }
        private void SetTextFillTime(long millis)
        {
            textBox_fillTime.Text = TimeSpan.FromMilliseconds(millis).ToString(@"hh\:mm\:ss");
        }
        private void SetTextFillDuration(long millis)
        {
            textBox_fillDur.Text = (millis / 1000f).ToString();
        }
        private void SetTextDelta(int deltaValue)
        {
            textBox_fillDelta.Text = (25f * ((deltaValue * 5f) / 1024f) + 12.5).ToString("N");
        }
        private void SetTextLeak(bool triggered)
        {
            textBox_isLeak.Text = triggered ? "No" : "Yes";
        }
    }
}

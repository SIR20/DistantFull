using System;
using System.IO;
using System.Collections.Generic;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;
using System.Drawing;
using System.Text;
using System.Reflection;
using AForge.Video.DirectShow;
using NAudio.Wave;
using DistantFull.Properties;
using JSON;

namespace DistantFull
{
    public partial class Main : Form
    {
        public string uname;
        public int us_id = 0;
        //public EndPoint NowEndPoint = new IPEndPoint(IPAddress.Any, 0);
        public Socket MediaSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram,ProtocolType.Udp);
        public Socket FileSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        public Socket MessageSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        public IPAddress ServerIpAddres = IPAddress.Any;
        public EndPoint MediaEndPoint;
        public EndPoint FileEndPoint;
        public EndPoint MessageEndPoint;
        public int MediaSocketPort = 13000;
        public int FileSocketPort = 13001;
        public int MessageSocketPort = 13002;
        public string ch_id = "";
        public VideoCaptureDevice Camera;
        public FilterInfoCollection Camera_collections;
        public WaveIn input;
        public bool flag_connect = false;
        public bool flag_create = false;
        public Thread MediaThread;
        public Thread FileThread;
        public Thread MessageThread;
        public int media_size = 100000;
        public int max_file_size = 5245728;
        public int message_size = 300;

        /// <summary>
        /// //////////////////////////////!!!!!!!!!!!!!!!!!!!!!Изменить имена переменных связанных с сокетами
        /// </summary>
        [Obsolete]
        public Main()
        {
            InitializeComponent();
            AppDomain.CurrentDomain.AssemblyResolve += (o, args) =>
            {
                string arg = args.Name;
                arg = arg.Substring(0, arg.IndexOf(','));
                switch (arg)
                {
                    case "AForge":
                        return Assembly.Load(Resources.AForge);
                    case "AForge.Video":
                        return Assembly.Load(Resources.AForge_Video);
                    case "AForge.Video.DirectShow":
                        return Assembly.Load(Resources.AForge_Video_DirectShow);
                    case "NAudio":
                        return Assembly.Load(Resources.NAudio);
                    case "Json.Net":
                        return Assembly.Load(Resources.Json_Net);
                }
                return null;
            };
            MessageThread = new Thread(MessageListening);
            FileThread = new Thread(FileListening);
            MediaThread = new Thread(MediaListening);
        }

        private void uname_r_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                uname = uname_r.Text;
                if (uname.Length > 0)
                {
                    toJSON js = new toJSON();
                    js.AddKeyValue("request", "newUser");
                    js.AddKeyValue("name", uname);
                    MessageSocket.Send(js.GetJSON().GetBytes());
                    byte[] data = new byte[message_size];
                    MessageSocket.Receive(data);
                    JSONto jss = new JSONto(data.GetString().Trim());
                    if (jss.GetValue("response") == "newUserResult")
                    {
                        us_id = jss.GetValue("us_id").Parse();
                        uname_r.Visible = false;
                        Create.Visible = true;
                        Connect.Visible = true;
                        js = new toJSON();
                        js.AddKeyValue("request", "connectToUser");
                        js.AddKeyValue("us_id", us_id.ToString());
                        MediaSocket.SendTo(js.GetJSON().GetBytes(), MediaEndPoint);  
                    }
                    else MessageBox.Show("Не удалось подключиться");
                }
                else MessageBox.Show("Поле не может быть пустым", "Ошибка");
            }
        }

        [Obsolete]
        private void id_KeyDown(object sender, KeyEventArgs e)
        {
            //Сделать проверку,после парсинга,есть ли чат с таким id
            if (e.KeyCode == Keys.Enter)
            {
                ch_id = id.Text;
                if (ch_id.Length > 0)
                {
                    if (int.TryParse(ch_id, out int i))
                    {
                        toJSON js = new toJSON();
                        js.AddKeyValue("request", "Connect");
                        js.AddKeyValue("ch_id", ch_id);
                        js.AddKeyValue("us_id", us_id.ToString());
                        MessageSocket.Send(js.GetJSON().GetBytes());
                        byte[] request = new byte[256];
                        try
                        {
                            MessageSocket.Receive(request);

                            JSONto jss = new JSONto(request.GetString().Trim());
                            if (jss.GetValue("response") == "connect_result")
                            {
                                if (jss.GetValue("result") == "true")
                                {
                                    id.Visible = false;
                                    Create.Visible = false;
                                    Connect.Visible = false;

                                    flag_connect = true;
                                    view_image.Visible = true;
                                    send_t.Visible = true;
                                    send_b.Visible = true;
                                    r_id_t.Visible = true;
                                    UpFile.Visible = true;
                                    messages_panel.BeginInvoke((MethodInvoker)(() => this.messages_panel.Visible = true));
                                    MediaThread.Start();
                                    MessageThread.Start();
                                    FileThread.Start();
                                }
                                else
                                {
                                    if (jss.GetValue("result") == "false") MessageBox.Show("Нет чата с таким ID", "Ошибка");
                                }
                            }
                        }catch(Exception ee)
                        {
                            MessageBox.Show(ee.ToString());
                        }
                    }
                    else MessageBox.Show("ID должен состоять только из цифр", "Ошибка");
                }
                else MessageBox.Show("Поле не может быть пустым", "Ошибка");
            }
        }

        private void send_t_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) Send_Message();
        }

        private void Create_Click(object sender, EventArgs e)
        {
            Create.Visible = false;
            Connect.Visible = false;
            toJSON js = new toJSON();
            js.AddKeyValue("request", "newChat");
            js.AddKeyValue("us_id", us_id.ToString());
            MessageSocket.Send(js.GetJSON().GetBytes());
            byte[] request = new byte[256];
            MessageSocket.Receive(request);
            JSONto jss = new JSONto(request.GetString().Trim());
            if (jss.GetValue("response") == "newChatResult")
            {
                ch_id = jss.GetValue("ch_id");
                js = new toJSON();
                r_id_t.Text = $"ID:{ch_id}";
                view_image.Visible = true;
                send_t.Visible = true;
                send_b.Visible = true;
                UpFile.Visible = true;
                r_id_t.Visible = true;
                flag_camera.Visible = true;
                flag_micro.Visible = true;
                messages_panel.BeginInvoke((MethodInvoker)(() => this.messages_panel.Visible = true));
                MediaThread.Start();
                MessageThread.Start();
                FileThread.Start();
                Camera_collections = new FilterInfoCollection(FilterCategory.VideoInputDevice);
                Camera = new VideoCaptureDevice(Camera_collections[0].MonikerString);
                input = new WaveIn();
                input.WaveFormat = new WaveFormat(8000, 16, 1);
                input.StartRecording();

                toJSON jsv = new toJSON();
                input.DataAvailable += (ob, ev) =>
                {
                    jsv.AddKeyValue("request", "Voice");
                    jsv.AddKeyValue("result", Convert.ToBase64String(ev.Buffer));
                    jsv.AddKeyValue("ch_id", ch_id);
                    MediaSocket.SendTo(jsv.GetJSON().GetBytes(), MediaEndPoint);
                    jsv.Clear();

                };
               // Camera.Start();
                MemoryStream ms;
                js.Clear();
                Camera.NewFrame += (ob, frame) =>
                {
                    ms = new MemoryStream();
                    Bitmap tempBitmap = (Bitmap)frame.Frame.Clone();
                    tempBitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    js.AddKeyValue("request", "Image");
                    js.AddKeyValue("result", Convert.ToBase64String(ms.ToArray()));
                    js.AddKeyValue("ch_id", ch_id);
                    MediaSocket.SendTo(js.GetJSON().GetBytes(), MediaEndPoint);
                    js.Clear();
                    ms.Dispose();
                };
            }
        }

        private void Connect_Click(object sender, EventArgs e)
        {
            Connect.Visible = false;
            Create.Visible = false;
            id.Visible = true;
            //Продолжение в методе private void id_KeyDown(object sender, KeyEventArgs e)(65 стр.)
        }

        private void send_b_Click(object sender, EventArgs e) => Send_Message();

        private void Send_Message()
        {
            string msg = send_t.Text.Trim();
            if (msg.Length > 0)
            {
                toJSON js = new toJSON();
                js.AddKeyValue("request", "newMessage");
                js.AddKeyValue("from", uname);
                js.AddKeyValue("message",msg);
                js.AddKeyValue("ch_id", ch_id);
                MessageSocket.Send(js.GetJSON().GetBytes());
            }
            send_t.Text = "";
            send_t.SelectionStart = 0;
        }


        private void FileListening()
        {
            JSONto jss;
            RichTextBox mb;

            byte[] b;
            while (true)
            {
                b = new byte[max_file_size];
                FileSocket.Receive(b);
                jss = new JSONto(b.GetString());
                switch (jss.GetValue("response"))
                {
                    case "new_file":
                        string fname = jss.GetValue("file_name");
                        mb = new RichTextBox();
                        mb.Height = 30;
                        mb.ReadOnly = true;
                        mb.ForeColor = Color.Gray;
                        mb.Text = $"Файл:{fname}";
                        mb.BorderStyle = BorderStyle.None;
                        mb.Cursor = Cursors.Arrow;
                        mb.Click += (o, e) =>
                        {
                            SaveFile = new SaveFileDialog();
                            SaveFile.FileName = fname;
                            SaveFile.AddExtension = false;
                            if (SaveFile.ShowDialog() == DialogResult.OK)
                            {
                                byte[] fb = Convert.FromBase64String(jss.GetValue("file"));
                                File.WriteAllBytes(SaveFile.FileName, fb);
                            }
                        };
                        messages_panel.BeginInvoke((MethodInvoker)(() => this.messages_panel.Controls.Add(mb)));
                        File.WriteAllText("test.txt", jss.JSONStr);
                        break;
                }
            }
        }

        private void MessageListening()
        {
            JSONto jss;
            RichTextBox mb;

            byte[] b;
            while (true)
            {
                b = new byte[message_size];
                MessageSocket.Receive(b);
                jss = new JSONto(b.GetString());
                switch (jss.GetValue("response"))
                {
                    case "message":
                        string msg = jss.GetValue("result");
                        string from = jss.GetValue("from");
                        mb = new RichTextBox();
                        mb.ReadOnly = true;
                        mb.Cursor = Cursors.Hand;
                        mb.Text = $"{from}:{msg}";
                        mb.BorderStyle = BorderStyle.None;
                        mb.Height = msg.Split().Length * 15;
                        mb.Width = 150;
                        messages_panel.BeginInvoke((MethodInvoker)(() => this.messages_panel.Controls.Add(mb)));
                        break;

                    case "new_connect":
                        string from_c = jss.GetValue("from");
                        mb = new RichTextBox();
                        mb.Height = 40;
                        mb.Enabled = false;
                        mb.Text = $"\"{from_c}\" подключился к чату";
                        mb.BorderStyle = BorderStyle.None;
                        messages_panel.BeginInvoke((MethodInvoker)(() => this.messages_panel.Controls.Add(mb)));
                        break;

                    case "disconnect":
                        string from_d = jss.GetValue("from");
                        mb = new RichTextBox();
                        mb.Height = 30;
                        mb.Enabled = false;
                        mb.Text = $"\"{from_d}\" отключился из чата";
                        mb.BorderStyle = BorderStyle.None;
                        messages_panel.BeginInvoke((MethodInvoker)(() => this.messages_panel.Controls.Add(mb)));
                        break;

                    case "chat_delete":
                        MessageBox.Show("Создатель завершил чат");
                        System.Diagnostics.Process.GetCurrentProcess().Kill();
                        break;

                    case "camera_off":
                        view_image.BeginInvoke((MethodInvoker)(() => this.view_image.Image = null));
                        break;
                }
            }
        }

        [Obsolete]
        private void MediaListening()
        {
            JSONto jss = new JSONto();
            WaveOut output = new WaveOut();
            BufferedWaveProvider buffer = new BufferedWaveProvider(new WaveFormat(8000, 16, 1));
            MemoryStream ms;

            output.Init(buffer);
            output.Play();
            while (true)
            {
                byte[] response = new byte[media_size];
                MediaSocket.ReceiveFrom(response,ref MediaEndPoint);
                jss.JSONStr = response.GetString().Trim();
                switch (jss.GetValue("response"))
                { 
                    case "voice":
                        byte[] by = Convert.FromBase64String(jss.GetValue("result"));
                        buffer.AddSamples(by, 0, by.Length);
                        buffer.ClearBuffer();
                        break;

                    case "image":
                        byte[] bi = Convert.FromBase64String(jss.GetValue("result"));
                        ms = new MemoryStream(bi);
                        Image im = Image.FromStream(ms);
                        view_image.Image = im;
                        break;

                        //Получение результата,если нужно
                }
            }

        }

        private void flag_micro_CheckedChanged(object sender, EventArgs e)
        {
            if (flag_micro.Checked)
            {
                input.StartRecording();
                toJSON js = new toJSON();
                js.AddKeyValue("request", "micro_on");
                js.AddKeyValue("chat_id", ch_id);
                MessageSocket.Send(js.GetJSON().GetBytes());
                //Сделать уведомление всем пользователям о включении микрофона
            }
            else
            {
                input.StopRecording();
                toJSON js = new toJSON();
                js.AddKeyValue("request", "micro_off");
                js.AddKeyValue("chat_id", ch_id);
                MessageSocket.Send(js.GetJSON().GetBytes());
                //Сделать уведомление всем пользователям о выключении микрофона
            }
        }

        private void flag_camera_CheckedChanged(object sender, EventArgs e)
        {
            if (flag_camera.Checked)
            {
                Camera.Start();
                toJSON js = new toJSON();
                js.AddKeyValue("request", "camera_on");
                js.AddKeyValue("chat_id",ch_id);
                MessageSocket.Send(js.GetJSON().GetBytes());
                //Сделать уведомление всем пользователям о включении камеры
            }
            else
            {
                Camera.Stop();
                view_image.Image = null;
                toJSON js = new toJSON();
                js.AddKeyValue("request", "camera_off");
                js.AddKeyValue("chat_id", ch_id);
                MessageSocket.Send(js.GetJSON().GetBytes());
                //Сделать уведомление всем пользователям о выключении камеры
            }
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                toJSON js = new toJSON();
                js.AddKeyValue("request", "Disconnect");
                js.AddKeyValue("chat_id", ch_id);
                js.AddKeyValue("us_id", us_id.ToString());
                MessageSocket.Send(js.GetJSON().GetBytes());
                System.Diagnostics.Process.GetCurrentProcess().Kill();
            }
            catch{ };
            
        }

        private void Main_Load(object sender, EventArgs e)
        {
            if (File.Exists("ServerIP.txt"))
            {
                string ipf = File.ReadAllText("ServerIP.txt");
                try
                {
                    ServerIpAddres = IPAddress.Parse(ipf);
                }
                catch
                {
                    MessageBox.Show("Неверный IP");
                }
            }
            else
            {
                InpIP f = new InpIP();
                f.StartPosition = FormStartPosition.CenterScreen;
                f.FormClosed += (oe, ee) =>
                {
                    ServerIpAddres = IPAddress.Parse(f.IP);
                    File.WriteAllText("ServerIP.txt", f.IP);
                };
                f.ShowDialog(this);
            }
            MediaEndPoint = new IPEndPoint(ServerIpAddres, MediaSocketPort);
            FileEndPoint = new IPEndPoint(ServerIpAddres, FileSocketPort);
            MessageEndPoint = new IPEndPoint(ServerIpAddres, MessageSocketPort);
            try
            {
                MessageSocket.Connect(MessageEndPoint);
                FileSocket.Connect(FileEndPoint);
            }
            catch
            {
                MessageBox.Show("Не удалось подключиться к серверу.");
                Application.Exit();
            }
        }

        private void UpFile_Click(object sender, EventArgs e)
        {
                byte[] fbytes = new byte[0];
                string fname = string.Empty;
                bool FOK = false;
                int fsize;
                do
                {
                    if (UpFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        fname = UpFileDialog.FileName;
                        fbytes = File.ReadAllBytes(fname);
                        fsize = fbytes.Length + fname.GetBytes().Length;
                        FOK = true;
                    }
                    else break;
                    if (fsize > max_file_size) MessageBox.Show("Максимальный размер файла 3МБ");
                } while (fsize > max_file_size);
                if (FOK)
                {
                    fname = Path.GetFileName(fname);
                    toJSON js = new toJSON();
                    js.AddKeyValue("request", "newFile");
                    js.AddKeyValue("chat_id", ch_id);
                    js.AddKeyValue("file_name", fname);
                    js.AddKeyValue("file", Convert.ToBase64String(fbytes));
                    FileSocket.Send(js.GetJSON().GetBytes());
                }
        }
    }
}

using System.Diagnostics;
using System.IO.Ports;
using SerialToKeyboard.Control;
using System.Runtime.InteropServices.ComTypes;
using YamlDotNet.RepresentationModel;
using System.Runtime.InteropServices;

namespace SerialToKeyboard
{
    public partial class FrmMain : Form
    {
        private bool _isListening;
        private readonly int[] _bauds = [ 4_800, 9_600, 19_200, 38_400, 57_600, 115_200 ];
        private ComToKey _transfer;
        public string StartChar;
        public string EndChar;

        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int state);
        private const int SW_SHOWNORMAL = 1;

        public FrmMain()
        {
            InitializeComponent();
            KeyPreview = true;
            KeyDown += OnKeyDown;
        }

        private void OnKeyDown(object sender, KeyEventArgs keyEventArgs)
        {
            if (keyEventArgs.KeyCode == Keys.Return)
            {
                Debug.Print("Enter received");
            }
            //keyEventArgs.SuppressKeyPress = true;
            //keyEventArgs.Handled = true;
        }

        private bool IsInStartup()
        {
            var startupPath = Environment.GetFolderPath(Environment.SpecialFolder.Startup);
            var exeFilePath = Application.ExecutablePath;
            var appName = Path.GetFileNameWithoutExtension(exeFilePath);
            var lnkFilePath = Path.Combine(startupPath, $"{appName}.lnk");
            if (File.Exists(lnkFilePath))
                return true;
            return false;
        }

        private void FrmMainLoad(object sender, EventArgs e)
        {
            checkBoxStartWithWindows.Checked = IsInStartup();

            Debug.Print("FrmMainLoad");
            FillPortList();
            FillBaudList();

            BtnTransferClick(sender, e);

            string configFile = Application.StartupPath + @"\settings.yaml";
            if (File.Exists(configFile))
            {
                try
                {
                    using (var reader = new StreamReader(configFile))
                    {
                        var yaml = new YamlStream();
                        yaml.Load(reader);
                        var settings = (YamlMappingNode)yaml.Documents[0].RootNode["settings"];

                        string defaultCOMPort = settings["defaultCOMPort"].ToString();
                        if (cmbPort.Items.IndexOf(defaultCOMPort) != -1)
                        {
                            cmbPort.SelectedIndex = cmbPort.Items.IndexOf(defaultCOMPort);
                        }

                        int defaultBaudRate;
                        int.TryParse(settings["defaultBaudRate"].ToString(), out defaultBaudRate);
                        cmbBaud.SelectedIndex = cmbBaud.Items.IndexOf(defaultBaudRate);

                        string windowState = settings["windowState"].ToString();
                        EndChar = settings["endChar"].ToString();
                        StartChar = settings["startChar"].ToString();

                        if (windowState == "minimized")
                        {
                            WindowState = FormWindowState.Minimized;
                        }
                        else
                        {
                            WindowState = FormWindowState.Normal;
                        }

                        //Iniciar captura automatica
                        _isListening = true;
                        btnTransfer.Text = "Parar";
                        StartListening();

                    }
                }
                catch (Exception ex)
                {
                    //notifyIcon1.Visible = true;
                    notifyIcon1.BalloonTipText = "Ocorreu um erro " + ex.Message;
                    notifyIcon1.ShowBalloonTip(100);
                }
            }
        }



        private void FillBaudList()
        {
            foreach (var baud in _bauds)
            {
                cmbBaud.Items.Add(baud);
            }
            if (cmbBaud.Items.Count > 0)
                cmbBaud.SelectedItem = 9600;
        }

        private void FillPortList()
        {
            cmbPort.Items.Clear();
            cmbPort.Sorted = true;
            var s = SerialPort.GetPortNames();
            foreach (var s1 in s)
            {
                cmbPort.Items.Add(s1);
            }

            if (cmbPort.Items.Count == 0)
            {
                cmbPort.Enabled = false;
                btnTransfer.Enabled = false;
            }
            else
            {
                cmbPort.SelectedIndex = 0;
            }
        }

        private void BtnTransferClick(object sender, EventArgs e)
        {
            if (e is MouseEventArgs)
            {
                if (!_isListening)
                {
                    _isListening = true;
                    btnTransfer.Text = "Parar Captura";
                    StartListening();
                    WindowState = FormWindowState.Minimized;
                }
                else
                {
                    _isListening = false;
                    btnTransfer.Text = "Iniciar Captura";
                    StopListening();
                }
            }
        }

        private void StopListening()
        {
            _transfer.Stop();
            _transfer.Dispose();
            SetInterfaceEnable(true);
        }

        private void StartListening()
        {
            if (_transfer != null)
                _transfer.Dispose();

            if (cmbPort.Items.Count != 0)
            {
                SetInterfaceEnable(false);
                var pName = cmbPort.SelectedItem?.ToString();
                int pBaud;
                int.TryParse(cmbBaud.SelectedItem?.ToString(), out pBaud);
                _transfer = new ComToKey(new SerialPort(pName, pBaud, Parity.None, 8, StopBits.One), StartChar, EndChar);
                _transfer.Start();
                notifyIcon1.Visible = true;
                notifyIcon1.BalloonTipText = $"Leitura da Balança Iniciada na porta {pName}";
                notifyIcon1.ShowBalloonTip(100);
            }
            else
            {
                btnTransfer.Text = "Iniciar captura";
                btnTransfer.Enabled = false;
                _isListening = false;
                this.Show();
                this.WindowState = FormWindowState.Normal;
                this.ShowInTaskbar = true;
            }

        }

        private void SetInterfaceEnable(bool b)
        {
            cmbBaud.Enabled = b;
            cmbPort.Enabled = b;
        }

        private void FrmMainActivated(object sender, EventArgs e)
        {
            Debug.Print("FrmMainActivated");
        }

        private void FrmMain_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == this.WindowState)
            {
                this.Hide();
                this.ShowInTaskbar = false;
            }

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            this.ShowInTaskbar = true;
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            this.ShowInTaskbar = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var startupPath = Environment.GetFolderPath(Environment.SpecialFolder.Startup);
            var exeFilePath = Application.ExecutablePath;
            var appName = Path.GetFileNameWithoutExtension(exeFilePath);
            var lnkFilePath = Path.Combine(startupPath, $"{appName}.lnk");
            if (checkBoxStartWithWindows.Checked)
            {
                if (File.Exists(lnkFilePath))
                    return;
                var lnk = (IShellLinkW)new ShellLink();
                lnk.SetPath(exeFilePath);
                lnk.SetDescription("Serial to Keyboard");
                lnk.SetIconLocation(exeFilePath, 0);
                var file = (IPersistFile)lnk;
                file.Save(lnkFilePath, false);
            }
            else
            {
                if (File.Exists(lnkFilePath))
                    File.Delete(lnkFilePath);
            }
        }

        private void btnReloadPorts_Click(object sender, EventArgs e)
        {
            FillPortList();
            if (cmbPort.Items.Count != 0)
            {
                cmbPort.Enabled = true;
                btnTransfer.Enabled = true;
            }
        }
    }
}

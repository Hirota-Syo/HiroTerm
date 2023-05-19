using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using System.Drawing;

using System.IO.Ports;

namespace HiroTerm
{
    public class SerialSet
    {
        public SerialPort serialPort = new SerialPort();
        private ComboBox cmbComPort = new ComboBox();
        private ComboBox cmbBandrate = new ComboBox();
        private ComboBox cmbParity = new ComboBox();
        private ComboBox cmbStopbit = new ComboBox();
        private RichTextBox rtbInfo = new RichTextBox();
        private Button btnOpen = new Button();
        private Button btnClose = new Button();
        private Button btnScan = new Button();

        /// <summary>
        /// コントロール（ボタンなど）の高さ
        /// </summary>
        public const int ControlHeight = 50;

        /// <summary>
        /// コントロール（ボタンなど）の幅
        /// </summary>
        public const int ControlWidth = 100;

        /// <summary>
        /// インストラクタ
        /// </summary>
        public SerialSet()
        {
            InitSerialPort();
            InitComPort();
            InitBaudRate();
            InitParity();
            InitStopBit();
            InitOpen();
            InitClose();
            InitScan();
            InitTextInfo();
        }

        /// <summary>
        /// 初期化処理（Serial Port）
        /// </summary>
        private void InitSerialPort()
        {
            serialPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.OnDataReceived);
        }

        /// <summary>
        /// イベントハンドラ（データ受信時）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnDataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            var data = serialPort.ReadExisting();
            serialPort.WriteLine(data);
        }

        /// <summary>
        /// 初期化処理（Com Port）
        /// </summary>
        private void InitComPort()
        {
            cmbComPort.Width = ControlWidth;
            ScanComPort();
        }

        /// <summary>
        /// 初期化処理（Baudrate）
        /// </summary>
        private void InitBaudRate()
        {
            cmbBandrate.Width = ControlWidth;
            cmbBandrate.Items.Clear();
            cmbBandrate.Items.Add("115200");
            cmbBandrate.Items.Add("57600");
            cmbBandrate.Items.Add("38400");
            cmbBandrate.Items.Add("19200");
            cmbBandrate.Items.Add("9600");
            cmbBandrate.Items.Add("4800");
            cmbBandrate.SelectedIndex = 0;
        }
        
        /// <summary>
        /// 初期化処理（Parity）
        /// </summary>
        private void InitParity()
        {
            cmbParity.Width = ControlWidth;
            cmbParity.Items.Clear();
            cmbParity.Items.Add("None");
            cmbParity.SelectedIndex = 0;
        }
        
        /// <summary>
        /// 初期化処理（Stop Bit）
        /// </summary>
        private void InitStopBit()
        {
            cmbStopbit.Width = ControlWidth;
            cmbStopbit.Items.Clear();
            cmbStopbit.Items.Add("One");
            cmbStopbit.SelectedIndex = 0;
        }

        /// <summary>
        /// 初期化処理（Open）
        /// </summary>
        private void InitOpen()
        {
            btnOpen.Width = ControlWidth;
            btnOpen.Height = ControlHeight;
            btnOpen.Text = "Open";
            btnOpen.Click += new EventHandler(this.btnOpen_Click);
        }

        /// <summary>
        /// イベントハンドラ（COM Port）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void btnOpen_Click(object sender, EventArgs e)
        {
            try
            {
                serialPort.PortName = cmbComPort.Text;
                serialPort.BaudRate = 115200;
                serialPort.Open();

                btnOpen.Enabled = false;
                btnClose.Enabled = true;
                btnScan.Enabled = false;
                cmbComPort.Enabled = false;
                cmbBandrate.Enabled = false;
                cmbStopbit.Enabled = false;
                cmbParity.Enabled = false;
            }
            catch
            {
                btnClose_Click(this, null);
                rtbInfo.Text = "オープンできず";
            }
        }

        /// <summary>
        /// 初期化処理（Close）
        /// </summary>
        private void InitClose()
        {
            btnClose.Width = ControlWidth;
            btnClose.Height = ControlHeight;
            btnClose.Text = "Close";
            btnClose.Click += new EventHandler(this.btnClose_Click);
        }

        void btnClose_Click(object sender, EventArgs e)
        {
            btnOpen.Enabled = true;
            btnClose.Enabled = false;
            btnScan.Enabled = true;
            cmbComPort.Enabled = true;
            cmbBandrate.Enabled = true;
            cmbStopbit.Enabled = true;
            cmbParity.Enabled = true;
            try
            {
                serialPort.DiscardInBuffer();  // 入力バッファを破棄
                serialPort.DiscardOutBuffer(); // 出力バッファを破棄
                serialPort.Close();
            }
            catch { };
        }
        
        /// <summary>
        /// 初期化処理（Scan）
        /// </summary>
        private void InitScan()
        {
            btnScan.Width = ControlWidth;
            btnScan.Text = "Scan";
            btnScan.Click += new EventHandler(this.btnScan_Click);
        }

        void btnScan_Click(object sender, EventArgs e)
        {
            ScanComPort();
        }


        /// <summary>
        /// 初期化処理（Text Info）
        /// </summary>
        private void InitTextInfo()
        {
            rtbInfo.Width = ControlWidth * 2;
            rtbInfo.Height = ControlHeight;
        }
        
        void ScanComPort()
        {
            cmbComPort.Items.Clear();
            string[] ports = SerialPort.GetPortNames();
            foreach (string p in ports)
            {
                cmbComPort.Items.Add(p);
                cmbComPort.SelectedIndex = 0;
            }
        }
        
        /// <summary>
        /// コントロールの位置を決める
        /// </summary>
        /// <param name="posX">ボタン群を並べたい位置の左上X座標</param>
        /// <param name="posY">ボタン群を並べいた位置の左上Y座標</param>
        public void SetPosition(int posX, int posY)
        {
            int nextPosX = posX;
            int nextPosY = posY;
            
            btnOpen.Location = new Point(nextPosX, nextPosY);

            nextPosX = posX + btnOpen.Width;
            btnClose.Location = new Point(nextPosX, nextPosY);

            nextPosX = posX;
            nextPosY = nextPosY + btnClose.Height + 10;
            cmbComPort.Location = new Point(nextPosX, nextPosY);

            nextPosX = nextPosX + cmbComPort.Width;
            btnScan.Location = new Point(nextPosX, nextPosY);

            nextPosX = posX;
            nextPosY = nextPosY + cmbComPort.Height;
            cmbBandrate.Location = new Point(nextPosX, nextPosY);

            nextPosY = nextPosY + cmbBandrate.Height;
            cmbParity.Location = new Point(nextPosX, nextPosY);

            nextPosY = nextPosY + cmbParity.Height;
            cmbStopbit.Location = new Point(nextPosX, nextPosY);
            
            nextPosY = nextPosY + cmbStopbit.Height + 10;
            rtbInfo.Location = new Point(nextPosX, nextPosY);
        }

        /// <summary>
        /// ボタン群をFormに設置する
        /// </summary>
        /// <param name="form">設置左記のフォーム</param>
        public void AddForm(Form form)
        {
            form.Controls.Add(cmbComPort);
            form.Controls.Add(cmbBandrate);
            form.Controls.Add(cmbParity);
            form.Controls.Add(cmbStopbit);
            form.Controls.Add(btnOpen);
            form.Controls.Add(btnClose);
            form.Controls.Add(btnScan);
            form.Controls.Add(rtbInfo);
        }

    }
}

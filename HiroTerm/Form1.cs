using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO.Ports;

namespace HiroTerm
{
    public partial class Form1 : Form
    {
        static SerialSet serialSet = new SerialSet();

        public Form1()
        {
            InitializeComponent();
            
            serialSet.SetPosition(10, 20);
            serialSet.AddForm(this);
        }
        

        private void btn_Click(object sender, EventArgs e)
        {
            byte[] byDebug = new byte[3] { 0, 1, 2 };
            serialSet.serialPort.Write("aiueo");
        }

        private void timer1000_Tick(object sender, EventArgs e)
        {
            RenewDisp();
        }

        void RenewDisp()
        {
            string comStatus = "";
            if(serialSet.serialPort.IsOpen == true)
            {
                comStatus = serialSet.serialPort.PortName;
            }
            else
            {
                comStatus = "未接続";
            }

            string txtBefore = this.Text;
            string txtAfter = comStatus + " HiroTerm";

            if(txtBefore != txtAfter)
            {
                this.Text = txtAfter;
            }
            
        }

        private void timer10_Tick(object sender, EventArgs e)
        {

        }
    }
}

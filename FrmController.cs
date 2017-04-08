using Amib.Threading;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TVController
{
    public partial class FrmController : Form
    {
        public FrmController()
        {
            InitializeComponent();
        }

        public string Device { get; set; }

        //30 seconds, 1 thread
        private readonly SmartThreadPool pool = new SmartThreadPool(30, 1);
        private IExecutor executor = new AdbExecutor();

        private void SendKey(string keyName) {
            pool.QueueWorkItem(() => {
                executor.Execute("input keyevent {1}", Device, keyName);
            });
        }

        private void FrmController_Load(object sender, EventArgs e)
        {
            this.Text = Device;
            executor.Prepare(Device);
        }

        private void FrmController_FormClosed(object sender, FormClosedEventArgs e)
        {
            executor.Dispose();
        }

        private void mnuClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            SendKey("KEYCODE_DPAD_CENTER");
        }

        private void btnLeft_Click(object sender, EventArgs e)
        {
            SendKey("KEYCODE_DPAD_LEFT");
        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            SendKey("KEYCODE_DPAD_RIGHT");
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            SendKey("KEYCODE_DPAD_UP");
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            SendKey("KEYCODE_DPAD_DOWN");
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            SendKey("KEYCODE_BACK");
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            SendKey("KEYCODE_HOME");
        }

        private void btnCall_Click(object sender, EventArgs e)
        {
            SendKey("KEYCODE_CALL");
        }

        private void btnEndCall_Click(object sender, EventArgs e)
        {
            SendKey("KEYCODE_ENDCALL");
        }

        private void btnNotification_Click(object sender, EventArgs e)
        {
            SendKey("KEYCODE_NOTIFICATION");
        }

        private void btnMute_Click(object sender, EventArgs e)
        {
            SendKey("KEYCODE_MUTE");
        }

        private void btnVolumeUp_Click(object sender, EventArgs e)
        {
            SendKey("KEYCODE_VOLUME_UP");
        }

        private void btnVolumeDown_Click(object sender, EventArgs e)
        {
            SendKey("KEYCODE_VOLUME_DOWN");
        }

        private void btnNum1_Click(object sender, EventArgs e)
        {
            SendKey("KEYCODE_1");
        }

        private void btnNum2_Click(object sender, EventArgs e)
        {
            SendKey("KEYCODE_2");
        }

        private void btnNum3_Click(object sender, EventArgs e)
        {
            SendKey("KEYCODE_3");
        }

        private void btnNum4_Click(object sender, EventArgs e)
        {
            SendKey("KEYCODE_4");
        }

        private void btnNum5_Click(object sender, EventArgs e)
        {
            SendKey("KEYCODE_5");
        }

        private void btnNum6_Click(object sender, EventArgs e)
        {
            SendKey("KEYCODE_6");
        }

        private void btnNum7_Click(object sender, EventArgs e)
        {
            SendKey("KEYCODE_7");
        }

        private void btnNum8_Click(object sender, EventArgs e)
        {
            SendKey("KEYCODE_8");
        }

        private void btnNum9_Click(object sender, EventArgs e)
        {
            SendKey("KEYCODE_9");
        }

        private void btnNum0_Click(object sender, EventArgs e)
        {
            SendKey("KEYCODE_0");
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            SendKey("KEYCODE_DEL");
        }
    }
}

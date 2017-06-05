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
    public partial class frmDevices : Form
    {
        public frmDevices()
        {
            InitializeComponent();
        }

        private void ReloadDevices()
        {
            lstDevices.Items.Clear();
            Tuple<int, string> result = Program.ExecuteCommand("adb devices | findstr \"device$\"");

            string output = result.Item2;
            string[] lines = output.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

            foreach(string line in lines)
            {
                string[] columns = line.Split(new string[] { "\t" }, StringSplitOptions.RemoveEmptyEntries);
                lstDevices.Items.Add(columns[0]);
            }
        }

        private void ConnectDevice(string address) {
            ReloadDevices();
        }

        private void frmDevices_Load(object sender, EventArgs e)
        {
            ReloadDevices();
        }

        private void miExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void miConnect_Click(object sender, EventArgs e)
        {

        }

        private void miRefresh_Click(object sender, EventArgs e)
        {
            ReloadDevices();
        }

        private void lstDevices_DoubleClick(object sender, EventArgs e)
        {
            string selected = (string)lstDevices.SelectedItem;
            if (selected != null) {
                FrmController form = new FrmController();
                form.Device = selected;
                form.Show();
            }

        }
    }
}

using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SmartDeviceProjectTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void ExportToAOPP_Click(object sender, EventArgs e)
        {
            var taskForm = new SelectTask();
            taskForm.Show();
        }

        private void ExportForWarehouse_Click(object sender, EventArgs e)
        {

        }

        private void Refund_Click(object sender, EventArgs e)
        {

        }
    }
}
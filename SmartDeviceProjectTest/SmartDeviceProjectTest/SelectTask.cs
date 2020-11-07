using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SmartDeviceProjectTest.Services;
using System.Net;
using Rebex.Net;
using System.IO;
using Newtonsoft.Json.Linq;
using SmartDeviceProjectTest.Models;
using Newtonsoft.Json;


namespace SmartDeviceProjectTest
{
    public partial class SelectTask : Form
    {
        private readonly SelectTaskService _selectTaskService;
        private DataTable _exportTable;
        public SelectTask()
        {
            _selectTaskService = new SelectTaskService();
            InitializeComponent();
        }

        private void SelectTask_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            //var selectTaskServie = new SelectTaskService();
            var scanJobs = _selectTaskService.SendRequest();
            _selectTaskService.Insert(scanJobs);
            //ChangeTaskExportGrig.MouseUp += 
            var scanJobsForDB = _selectTaskService.GetSQLite();
            var table = MakeDataSet(scanJobsForDB);
            ChangeTaskExportGrig.DataSource = table;
            _exportTable = table;
            Cursor.Current = Cursors.Default;
                       
        }

        private void validateCertificate(object sender, SslCertificateValidationEventArgs e)
        {
            // get a string representation of the certificate's fingerprint
            string fingerprint = e.Certificate.Thumbprint;
            // check whether the fingerprint matches the desired fingerprint
            bool ok = true;
            if (ok)
                e.Accept();
            else
                e.Reject();
        }

        private DataTable MakeDataSet(List<ScanJob> scanJobs)
        {
            var dataSet = new DataSet();
            var table = new DataTable("Exports");
            //DataColumn id = new DataColumn("Id", typeof(int));
            DataColumn flightNum = new DataColumn("FlightNum", typeof(string));
            DataColumn planContainersTotalNum = new DataColumn("PlanContainersTotalNum", typeof(string));
            DataColumn planContainsTotalWidth = new DataColumn("PlanContainsTotalWidth", typeof(string));
            //table.Columns.Add("ID");
            table.Columns.Add("Задание \r\n Рейс");
            table.Columns.Add("Вес, ОСКАР \n Емк. ОСКАР");
            table.Columns.Add("Вес, сканб \n Ёмк скан");            
            foreach (var scanJob in scanJobs)
            {
                table.Rows.Add(scanJob.SourceElementId + "/" + scanJob.FlightNum + " от " + scanJob.FlightDate.ToString("dd.MM.yy") , scanJob.PlanContainersTotalNum, scanJob.PlanContainsTotalWidth);               
            }
            dataSet.Tables.Add(table);
            return table;
        }

        private void FindByFlightButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(FindByFlightTextBox.Text))
            {                
                ChangeTaskExportGrig.DataSource = MakeDataSet(_selectTaskService.GetByFlightNum(FindByFlightTextBox.Text));
            }
        }

        private void FindByPassageButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(FindByPassageTextBox.Text))
            {
                ChangeTaskExportGrig.DataSource = MakeDataSet(_selectTaskService.GetByContainerNum(FindByPassageTextBox.Text));
            }
        }
    }
}
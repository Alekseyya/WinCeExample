namespace SmartDeviceProjectTest
{
    partial class SelectTask
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MainMenu mainMenu1;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.ChangeTaskExportGrig = new System.Windows.Forms.DataGrid();
            this.DepartureLabel = new System.Windows.Forms.Label();
            this.ExportForAOPPLabel = new System.Windows.Forms.Label();
            this.FindByFlightButton = new System.Windows.Forms.Button();
            this.FindByFlightTextBox = new System.Windows.Forms.TextBox();
            this.FindByPassageButton = new System.Windows.Forms.Button();
            this.FindByPassageTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // ChangeTaskExportGrig
            // 
            this.ChangeTaskExportGrig.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.ChangeTaskExportGrig.Location = new System.Drawing.Point(0, 70);
            this.ChangeTaskExportGrig.Name = "ChangeTaskExportGrig";
            this.ChangeTaskExportGrig.RowHeadersVisible = false;
            this.ChangeTaskExportGrig.Size = new System.Drawing.Size(240, 195);
            this.ChangeTaskExportGrig.TabIndex = 0;
            // 
            // DepartureLabel
            // 
            this.DepartureLabel.Location = new System.Drawing.Point(0, 0);
            this.DepartureLabel.Name = "DepartureLabel";
            this.DepartureLabel.Size = new System.Drawing.Size(39, 20);
            this.DepartureLabel.Text = "Вылет";
            // 
            // ExportForAOPPLabel
            // 
            this.ExportForAOPPLabel.Location = new System.Drawing.Point(88, 0);
            this.ExportForAOPPLabel.Name = "ExportForAOPPLabel";
            this.ExportForAOPPLabel.Size = new System.Drawing.Size(126, 20);
            this.ExportForAOPPLabel.Text = "Экспорт от АООПП";
            // 
            // FindByFlightButton
            // 
            this.FindByFlightButton.Location = new System.Drawing.Point(123, 22);
            this.FindByFlightButton.Name = "FindByFlightButton";
            this.FindByFlightButton.Size = new System.Drawing.Size(114, 20);
            this.FindByFlightButton.TabIndex = 3;
            this.FindByFlightButton.Text = "Найти по рейсу";
            this.FindByFlightButton.Click += new System.EventHandler(this.FindByFlightButton_Click);
            // 
            // FindByFlightTextBox
            // 
            this.FindByFlightTextBox.Location = new System.Drawing.Point(0, 22);
            this.FindByFlightTextBox.Name = "FindByFlightTextBox";
            this.FindByFlightTextBox.Size = new System.Drawing.Size(100, 21);
            this.FindByFlightTextBox.TabIndex = 4;
            // 
            // FindByPassageButton
            // 
            this.FindByPassageButton.Location = new System.Drawing.Point(123, 48);
            this.FindByPassageButton.Name = "FindByPassageButton";
            this.FindByPassageButton.Size = new System.Drawing.Size(114, 20);
            this.FindByPassageButton.TabIndex = 5;
            this.FindByPassageButton.Text = "Найти по СП";
            this.FindByPassageButton.Click += new System.EventHandler(this.FindByPassageButton_Click);
            // 
            // FindByPassageTextBox
            // 
            this.FindByPassageTextBox.Location = new System.Drawing.Point(0, 48);
            this.FindByPassageTextBox.Name = "FindByPassageTextBox";
            this.FindByPassageTextBox.Size = new System.Drawing.Size(100, 21);
            this.FindByPassageTextBox.TabIndex = 6;
            // 
            // SelectTask
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.FindByPassageTextBox);
            this.Controls.Add(this.FindByPassageButton);
            this.Controls.Add(this.FindByFlightTextBox);
            this.Controls.Add(this.FindByFlightButton);
            this.Controls.Add(this.ExportForAOPPLabel);
            this.Controls.Add(this.DepartureLabel);
            this.Controls.Add(this.ChangeTaskExportGrig);
            this.Menu = this.mainMenu1;
            this.Name = "SelectTask";
            this.Text = "SelectTask";
            this.Load += new System.EventHandler(this.SelectTask_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGrid ChangeTaskExportGrig;
        private System.Windows.Forms.Label DepartureLabel;
        private System.Windows.Forms.Label ExportForAOPPLabel;
        private System.Windows.Forms.Button FindByFlightButton;
        private System.Windows.Forms.TextBox FindByFlightTextBox;
        private System.Windows.Forms.Button FindByPassageButton;
        private System.Windows.Forms.TextBox FindByPassageTextBox;
    }
}
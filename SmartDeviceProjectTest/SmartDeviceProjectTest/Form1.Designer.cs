namespace SmartDeviceProjectTest
{
    partial class Form1
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
            this.ExportToAOPP = new System.Windows.Forms.Button();
            this.ExportForWarehouse = new System.Windows.Forms.Button();
            this.Refund = new System.Windows.Forms.Button();
            this.contextMenu1 = new System.Windows.Forms.ContextMenu();
            this.contextMenu2 = new System.Windows.Forms.ContextMenu();
            this.Tab = new System.Windows.Forms.TabControl();
            this.DepartureTab = new System.Windows.Forms.TabPage();
            this.ArrivedTab = new System.Windows.Forms.TabPage();
            this.Tab.SuspendLayout();
            this.DepartureTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // ExportToAOPP
            // 
            this.ExportToAOPP.Location = new System.Drawing.Point(44, 32);
            this.ExportToAOPP.Name = "ExportToAOPP";
            this.ExportToAOPP.Size = new System.Drawing.Size(142, 20);
            this.ExportToAOPP.TabIndex = 0;
            this.ExportToAOPP.Text = "Экспорт в АООП";
            this.ExportToAOPP.Click += new System.EventHandler(this.ExportToAOPP_Click);
            // 
            // ExportForWarehouse
            // 
            this.ExportForWarehouse.Location = new System.Drawing.Point(44, 94);
            this.ExportForWarehouse.Name = "ExportForWarehouse";
            this.ExportForWarehouse.Size = new System.Drawing.Size(142, 20);
            this.ExportForWarehouse.TabIndex = 1;
            this.ExportForWarehouse.Text = "Экспор со склада";
            this.ExportForWarehouse.Click += new System.EventHandler(this.ExportForWarehouse_Click);
            // 
            // Refund
            // 
            this.Refund.Location = new System.Drawing.Point(44, 149);
            this.Refund.Name = "Refund";
            this.Refund.Size = new System.Drawing.Size(142, 17);
            this.Refund.TabIndex = 2;
            this.Refund.Text = "Возврат";
            this.Refund.Click += new System.EventHandler(this.Refund_Click);
            // 
            // Tab
            // 
            this.Tab.Controls.Add(this.DepartureTab);
            this.Tab.Controls.Add(this.ArrivedTab);
            this.Tab.Location = new System.Drawing.Point(0, 0);
            this.Tab.Name = "Tab";
            this.Tab.SelectedIndex = 0;
            this.Tab.Size = new System.Drawing.Size(238, 264);
            this.Tab.TabIndex = 3;
            // 
            // DepartureTab
            // 
            this.DepartureTab.Controls.Add(this.ExportToAOPP);
            this.DepartureTab.Controls.Add(this.Refund);
            this.DepartureTab.Controls.Add(this.ExportForWarehouse);
            this.DepartureTab.Location = new System.Drawing.Point(0, 0);
            this.DepartureTab.Name = "DepartureTab";
            this.DepartureTab.Size = new System.Drawing.Size(238, 241);
            this.DepartureTab.Text = "Вылет";
            // 
            // ArrivedTab
            // 
            this.ArrivedTab.Location = new System.Drawing.Point(0, 0);
            this.ArrivedTab.Name = "ArrivedTab";
            this.ArrivedTab.Size = new System.Drawing.Size(238, 241);
            this.ArrivedTab.Text = "Прилет";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(238, 267);
            this.Controls.Add(this.Tab);
            this.Menu = this.mainMenu1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Tab.ResumeLayout(false);
            this.DepartureTab.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ExportToAOPP;
        private System.Windows.Forms.Button ExportForWarehouse;
        private System.Windows.Forms.Button Refund;
        private System.Windows.Forms.ContextMenu contextMenu1;
        private System.Windows.Forms.ContextMenu contextMenu2;
        private System.Windows.Forms.TabControl Tab;
        private System.Windows.Forms.TabPage DepartureTab;
        private System.Windows.Forms.TabPage ArrivedTab;
    }
}


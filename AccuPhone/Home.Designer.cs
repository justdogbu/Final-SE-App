namespace GUI
{
    partial class Home
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.panelHeader = new System.Windows.Forms.Panel();
            this.picMenu1 = new System.Windows.Forms.PictureBox();
            this.panelMenuBar = new System.Windows.Forms.Panel();
            this.panelButtonR = new System.Windows.Forms.Panel();
            this.bReceipts = new System.Windows.Forms.Button();
            this.panelButtonE = new System.Windows.Forms.Panel();
            this.bExport = new System.Windows.Forms.Button();
            this.panelButtonI = new System.Windows.Forms.Panel();
            this.bImport = new System.Windows.Forms.Button();
            this.panelButtonDB = new System.Windows.Forms.Panel();
            this.bDashboard = new System.Windows.Forms.Button();
            this.picEmployee = new System.Windows.Forms.PictureBox();
            this.lblWarehouse = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.picMenu2 = new System.Windows.Forms.PictureBox();
            this.panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picMenu1)).BeginInit();
            this.panelMenuBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picEmployee)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMenu2)).BeginInit();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.DodgerBlue;
            this.panelHeader.Controls.Add(this.picMenu1);
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(961, 43);
            this.panelHeader.TabIndex = 0;
            // 
            // picMenu1
            // 
            this.picMenu1.BackColor = System.Drawing.Color.Transparent;
            this.picMenu1.BackgroundImage = global::GUI.Properties.Resources.menu;
            this.picMenu1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picMenu1.Location = new System.Drawing.Point(0, 0);
            this.picMenu1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.picMenu1.Name = "picMenu1";
            this.picMenu1.Size = new System.Drawing.Size(56, 43);
            this.picMenu1.TabIndex = 0;
            this.picMenu1.TabStop = false;
            this.picMenu1.Click += new System.EventHandler(this.picMenu1_Click);
            // 
            // panelMenuBar
            // 
            this.panelMenuBar.BackColor = System.Drawing.SystemColors.Highlight;
            this.panelMenuBar.Controls.Add(this.panelButtonR);
            this.panelMenuBar.Controls.Add(this.bReceipts);
            this.panelMenuBar.Controls.Add(this.panelButtonE);
            this.panelMenuBar.Controls.Add(this.bExport);
            this.panelMenuBar.Controls.Add(this.panelButtonI);
            this.panelMenuBar.Controls.Add(this.bImport);
            this.panelMenuBar.Controls.Add(this.panelButtonDB);
            this.panelMenuBar.Controls.Add(this.bDashboard);
            this.panelMenuBar.Controls.Add(this.picEmployee);
            this.panelMenuBar.Controls.Add(this.lblWarehouse);
            this.panelMenuBar.Controls.Add(this.lblName);
            this.panelMenuBar.Controls.Add(this.picMenu2);
            this.panelMenuBar.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenuBar.Location = new System.Drawing.Point(0, 0);
            this.panelMenuBar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelMenuBar.Name = "panelMenuBar";
            this.panelMenuBar.Size = new System.Drawing.Size(230, 540);
            this.panelMenuBar.TabIndex = 1;
            // 
            // panelButtonR
            // 
            this.panelButtonR.BackColor = System.Drawing.Color.DodgerBlue;
            this.panelButtonR.Location = new System.Drawing.Point(0, 417);
            this.panelButtonR.Name = "panelButtonR";
            this.panelButtonR.Size = new System.Drawing.Size(10, 55);
            this.panelButtonR.TabIndex = 10;
            // 
            // bReceipts
            // 
            this.bReceipts.BackColor = System.Drawing.Color.Transparent;
            this.bReceipts.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.bReceipts.FlatAppearance.BorderSize = 0;
            this.bReceipts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bReceipts.Font = new System.Drawing.Font("Comfortaa", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.bReceipts.ForeColor = System.Drawing.Color.White;
            this.bReceipts.Image = global::GUI.Properties.Resources.receipts;
            this.bReceipts.Location = new System.Drawing.Point(0, 416);
            this.bReceipts.Name = "bReceipts";
            this.bReceipts.Size = new System.Drawing.Size(230, 55);
            this.bReceipts.TabIndex = 11;
            this.bReceipts.Text = "  Receipts";
            this.bReceipts.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bReceipts.UseVisualStyleBackColor = false;
            // 
            // panelButtonE
            // 
            this.panelButtonE.BackColor = System.Drawing.Color.DodgerBlue;
            this.panelButtonE.Location = new System.Drawing.Point(0, 356);
            this.panelButtonE.Name = "panelButtonE";
            this.panelButtonE.Size = new System.Drawing.Size(10, 55);
            this.panelButtonE.TabIndex = 8;
            // 
            // bExport
            // 
            this.bExport.BackColor = System.Drawing.Color.Transparent;
            this.bExport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.bExport.FlatAppearance.BorderSize = 0;
            this.bExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bExport.Font = new System.Drawing.Font("Comfortaa", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.bExport.ForeColor = System.Drawing.Color.White;
            this.bExport.Image = global::GUI.Properties.Resources.export;
            this.bExport.Location = new System.Drawing.Point(0, 355);
            this.bExport.Name = "bExport";
            this.bExport.Size = new System.Drawing.Size(230, 55);
            this.bExport.TabIndex = 9;
            this.bExport.Text = "  Export";
            this.bExport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bExport.UseVisualStyleBackColor = false;
            // 
            // panelButtonI
            // 
            this.panelButtonI.BackColor = System.Drawing.Color.DodgerBlue;
            this.panelButtonI.Location = new System.Drawing.Point(0, 295);
            this.panelButtonI.Name = "panelButtonI";
            this.panelButtonI.Size = new System.Drawing.Size(10, 55);
            this.panelButtonI.TabIndex = 6;
            // 
            // bImport
            // 
            this.bImport.BackColor = System.Drawing.Color.Transparent;
            this.bImport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.bImport.FlatAppearance.BorderSize = 0;
            this.bImport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bImport.Font = new System.Drawing.Font("Comfortaa", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.bImport.ForeColor = System.Drawing.Color.White;
            this.bImport.Image = global::GUI.Properties.Resources.import_2;
            this.bImport.Location = new System.Drawing.Point(0, 294);
            this.bImport.Name = "bImport";
            this.bImport.Size = new System.Drawing.Size(230, 55);
            this.bImport.TabIndex = 7;
            this.bImport.Text = "  Import";
            this.bImport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bImport.UseVisualStyleBackColor = false;
            // 
            // panelButtonDB
            // 
            this.panelButtonDB.BackColor = System.Drawing.Color.DodgerBlue;
            this.panelButtonDB.Location = new System.Drawing.Point(0, 234);
            this.panelButtonDB.Name = "panelButtonDB";
            this.panelButtonDB.Size = new System.Drawing.Size(10, 55);
            this.panelButtonDB.TabIndex = 2;
            // 
            // bDashboard
            // 
            this.bDashboard.BackColor = System.Drawing.Color.Transparent;
            this.bDashboard.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.bDashboard.FlatAppearance.BorderSize = 0;
            this.bDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bDashboard.Font = new System.Drawing.Font("Comfortaa", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.bDashboard.ForeColor = System.Drawing.Color.White;
            this.bDashboard.Image = global::GUI.Properties.Resources.home22;
            this.bDashboard.Location = new System.Drawing.Point(0, 233);
            this.bDashboard.Name = "bDashboard";
            this.bDashboard.Size = new System.Drawing.Size(230, 55);
            this.bDashboard.TabIndex = 5;
            this.bDashboard.Text = " Dashboard";
            this.bDashboard.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bDashboard.UseVisualStyleBackColor = false;
            // 
            // picEmployee
            // 
            this.picEmployee.BackgroundImage = global::GUI.Properties.Resources.person1;
            this.picEmployee.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picEmployee.Location = new System.Drawing.Point(59, 72);
            this.picEmployee.Name = "picEmployee";
            this.picEmployee.Size = new System.Drawing.Size(100, 68);
            this.picEmployee.TabIndex = 4;
            this.picEmployee.TabStop = false;
            // 
            // lblWarehouse
            // 
            this.lblWarehouse.AutoSize = true;
            this.lblWarehouse.Font = new System.Drawing.Font("Comfortaa", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblWarehouse.ForeColor = System.Drawing.Color.White;
            this.lblWarehouse.Location = new System.Drawing.Point(57, 186);
            this.lblWarehouse.Name = "lblWarehouse";
            this.lblWarehouse.Size = new System.Drawing.Size(104, 21);
            this.lblWarehouse.TabIndex = 3;
            this.lblWarehouse.Text = "Warehouse 02";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Comfortaa", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblName.ForeColor = System.Drawing.Color.White;
            this.lblName.Location = new System.Drawing.Point(35, 157);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(148, 29);
            this.lblName.TabIndex = 2;
            this.lblName.Text = "Mai Gia Minh";
            // 
            // picMenu2
            // 
            this.picMenu2.BackColor = System.Drawing.Color.Transparent;
            this.picMenu2.BackgroundImage = global::GUI.Properties.Resources.menu;
            this.picMenu2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picMenu2.Location = new System.Drawing.Point(174, 0);
            this.picMenu2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.picMenu2.Name = "picMenu2";
            this.picMenu2.Size = new System.Drawing.Size(56, 43);
            this.picMenu2.TabIndex = 1;
            this.picMenu2.TabStop = false;
            this.picMenu2.Click += new System.EventHandler(this.picMenu2_Click);
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(960, 540);
            this.Controls.Add(this.panelMenuBar);
            this.Controls.Add(this.panelHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Home";
            this.Text = "Home";
            this.Load += new System.EventHandler(this.Home_Load);
            this.panelHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picMenu1)).EndInit();
            this.panelMenuBar.ResumeLayout(false);
            this.panelMenuBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picEmployee)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMenu2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panelHeader;
        private PictureBox picMenu1;
        private Panel panelMenuBar;
        private PictureBox picMenu2;
        private Label lblName;
        private Label lblWarehouse;
        private PictureBox picEmployee;
        private Button bDashboard;
        private Panel panelButtonDB;
        private Panel panelButtonR;
        private Button bReceipts;
        private Panel panelButtonE;
        private Button bExport;
        private Panel panelButtonI;
        private Button bImport;
    }
}
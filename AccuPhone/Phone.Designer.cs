namespace GUI
{
    partial class Phone
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.bImportPhone = new System.Windows.Forms.Button();
            this.lblPhone = new System.Windows.Forms.Label();
            this.picPhone = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picPhone)).BeginInit();
            this.SuspendLayout();
            // 
            // bImportPhone
            // 
            this.bImportPhone.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(148)))), ((int)(((byte)(239)))));
            this.bImportPhone.Font = new System.Drawing.Font("Comfortaa", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.bImportPhone.ForeColor = System.Drawing.Color.White;
            this.bImportPhone.Location = new System.Drawing.Point(30, 204);
            this.bImportPhone.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.bImportPhone.Name = "bImportPhone";
            this.bImportPhone.Size = new System.Drawing.Size(104, 47);
            this.bImportPhone.TabIndex = 5;
            this.bImportPhone.Text = "Import";
            this.bImportPhone.UseVisualStyleBackColor = false;
            this.bImportPhone.Click += new System.EventHandler(this.bImportPhone_Click);
            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.Font = new System.Drawing.Font("Comfortaa", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblPhone.ForeColor = System.Drawing.Color.Black;
            this.lblPhone.Location = new System.Drawing.Point(23, 164);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(113, 32);
            this.lblPhone.TabIndex = 4;
            this.lblPhone.Text = "iPhone 14";
            // 
            // picPhone
            // 
            this.picPhone.BackgroundImage = global::GUI.Properties.Resources.Samsung_Galaxy_Z_Flip4;
            this.picPhone.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picPhone.Location = new System.Drawing.Point(1, 18);
            this.picPhone.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.picPhone.Name = "picPhone";
            this.picPhone.Size = new System.Drawing.Size(159, 136);
            this.picPhone.TabIndex = 3;
            this.picPhone.TabStop = false;
            // 
            // Phone
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.bImportPhone);
            this.Controls.Add(this.lblPhone);
            this.Controls.Add(this.picPhone);
            this.Name = "Phone";
            this.Size = new System.Drawing.Size(160, 260);
            ((System.ComponentModel.ISupportInitialize)(this.picPhone)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button bImportPhone;
        private Label lblPhone;
        private PictureBox picPhone;
    }
}

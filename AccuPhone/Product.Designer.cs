namespace GUI
{
    partial class Product
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
            this.picPhone = new System.Windows.Forms.PictureBox();
            this.txtNum = new System.Windows.Forms.TextBox();
            this.picMinus = new System.Windows.Forms.PictureBox();
            this.picAdd = new System.Windows.Forms.PictureBox();
            this.lblPrice = new System.Windows.Forms.Label();
            this.lblRemove = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picPhone)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMinus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAdd)).BeginInit();
            this.SuspendLayout();
            // 
            // picPhone
            // 
            this.picPhone.Location = new System.Drawing.Point(3, 3);
            this.picPhone.Name = "picPhone";
            this.picPhone.Size = new System.Drawing.Size(74, 69);
            this.picPhone.TabIndex = 0;
            this.picPhone.TabStop = false;
            // 
            // txtNum
            // 
            this.txtNum.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNum.Location = new System.Drawing.Point(219, 26);
            this.txtNum.Name = "txtNum";
            this.txtNum.Size = new System.Drawing.Size(20, 23);
            this.txtNum.TabIndex = 1;
            this.txtNum.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNum_KeyPress);
            // 
            // picMinus
            // 
            this.picMinus.BackgroundImage = global::GUI.Properties.Resources.minus_2;
            this.picMinus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picMinus.Location = new System.Drawing.Point(197, 31);
            this.picMinus.Name = "picMinus";
            this.picMinus.Size = new System.Drawing.Size(16, 16);
            this.picMinus.TabIndex = 2;
            this.picMinus.TabStop = false;
            this.picMinus.Click += new System.EventHandler(this.picMinus_Click);
            // 
            // picAdd
            // 
            this.picAdd.BackgroundImage = global::GUI.Properties.Resources.add_2;
            this.picAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picAdd.Location = new System.Drawing.Point(245, 31);
            this.picAdd.Name = "picAdd";
            this.picAdd.Size = new System.Drawing.Size(16, 16);
            this.picAdd.TabIndex = 3;
            this.picAdd.TabStop = false;
            this.picAdd.Click += new System.EventHandler(this.picAdd_Click);
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Font = new System.Drawing.Font("Comfortaa", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblPrice.Location = new System.Drawing.Point(298, 26);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(52, 21);
            this.lblPrice.TabIndex = 4;
            this.lblPrice.Text = "$25,00";
            // 
            // lblRemove
            // 
            this.lblRemove.AutoSize = true;
            this.lblRemove.Font = new System.Drawing.Font("Comfortaa", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblRemove.Location = new System.Drawing.Point(382, 27);
            this.lblRemove.Name = "lblRemove";
            this.lblRemove.Size = new System.Drawing.Size(19, 21);
            this.lblRemove.TabIndex = 5;
            this.lblRemove.Text = "X";
            this.lblRemove.Click += new System.EventHandler(this.lblRemove_Click);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Comfortaa", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblName.Location = new System.Drawing.Point(83, 28);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(74, 21);
            this.lblName.TabIndex = 6;
            this.lblName.Text = "iPhone 14";
            // 
            // Product
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblRemove);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.picAdd);
            this.Controls.Add(this.picMinus);
            this.Controls.Add(this.txtNum);
            this.Controls.Add(this.picPhone);
            this.Name = "Product";
            this.Size = new System.Drawing.Size(416, 75);
            ((System.ComponentModel.ISupportInitialize)(this.picPhone)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMinus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAdd)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PictureBox picPhone;
        private TextBox txtNum;
        private PictureBox picMinus;
        private PictureBox picAdd;
        private Label lblPrice;
        private Label lblRemove;
        private Label lblName;
    }
}

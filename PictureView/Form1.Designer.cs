namespace PictureView
{
    partial class frmPictureView
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btAddPicture = new System.Windows.Forms.Button();
            this.btDelPicture = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.Info;
            this.pictureBox1.Location = new System.Drawing.Point(318, 36);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(339, 226);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // btAddPicture
            // 
            this.btAddPicture.Location = new System.Drawing.Point(67, 36);
            this.btAddPicture.Name = "btAddPicture";
            this.btAddPicture.Size = new System.Drawing.Size(109, 41);
            this.btAddPicture.TabIndex = 1;
            this.btAddPicture.Text = "dodaj zdjęcie";
            this.btAddPicture.UseVisualStyleBackColor = true;
            this.btAddPicture.Click += new System.EventHandler(this.btAddPicture_Click);
            // 
            // btDelPicture
            // 
            this.btDelPicture.Location = new System.Drawing.Point(67, 83);
            this.btDelPicture.Name = "btDelPicture";
            this.btDelPicture.Size = new System.Drawing.Size(109, 34);
            this.btDelPicture.TabIndex = 2;
            this.btDelPicture.Text = "Usuń zdjęcie";
            this.btDelPicture.UseVisualStyleBackColor = true;
            this.btDelPicture.Click += new System.EventHandler(this.btDelPicture_Click);
            // 
            // frmPictureView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(886, 354);
            this.Controls.Add(this.btDelPicture);
            this.Controls.Add(this.btAddPicture);
            this.Controls.Add(this.pictureBox1);
            this.Name = "frmPictureView";
            this.Text = "Pokaz zdjęć";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmPictureView_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btAddPicture;
        private System.Windows.Forms.Button btDelPicture;
    }
}


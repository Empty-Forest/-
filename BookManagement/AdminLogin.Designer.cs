namespace BookManagement
{
    partial class AdminLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminLogin));
            this.panel2 = new System.Windows.Forms.Panel();
            this.exitBt = new System.Windows.Forms.Button();
            this.backU = new System.Windows.Forms.Button();
            this.signIn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.aPasswordInput = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.HighlightText;
            this.panel2.Controls.Add(this.exitBt);
            this.panel2.Controls.Add(this.backU);
            this.panel2.Controls.Add(this.signIn);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.aPasswordInput);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(12, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(521, 317);
            this.panel2.TabIndex = 2;
            // 
            // exitBt
            // 
            this.exitBt.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.exitBt.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.exitBt.FlatAppearance.BorderSize = 2;
            this.exitBt.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.exitBt.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightGray;
            this.exitBt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exitBt.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitBt.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.exitBt.Location = new System.Drawing.Point(485, 1);
            this.exitBt.Name = "exitBt";
            this.exitBt.Size = new System.Drawing.Size(35, 36);
            this.exitBt.TabIndex = 9;
            this.exitBt.Text = "╳";
            this.exitBt.UseVisualStyleBackColor = false;
            this.exitBt.Click += new System.EventHandler(this.exitBt_Click);
            // 
            // backU
            // 
            this.backU.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.backU.FlatAppearance.BorderSize = 2;
            this.backU.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.backU.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightGray;
            this.backU.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.backU.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.backU.ForeColor = System.Drawing.Color.DarkOrange;
            this.backU.Location = new System.Drawing.Point(185, 260);
            this.backU.Name = "backU";
            this.backU.Size = new System.Drawing.Size(211, 38);
            this.backU.TabIndex = 8;
            this.backU.Text = "返回用户登录";
            this.backU.UseVisualStyleBackColor = false;
            this.backU.Click += new System.EventHandler(this.backU_Click);
            // 
            // signIn
            // 
            this.signIn.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.signIn.FlatAppearance.BorderSize = 2;
            this.signIn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.signIn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightGray;
            this.signIn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.signIn.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.signIn.ForeColor = System.Drawing.Color.LimeGreen;
            this.signIn.Location = new System.Drawing.Point(224, 195);
            this.signIn.Name = "signIn";
            this.signIn.Size = new System.Drawing.Size(122, 38);
            this.signIn.TabIndex = 7;
            this.signIn.Text = "登录";
            this.signIn.UseVisualStyleBackColor = false;
            this.signIn.Click += new System.EventHandler(this.signIn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.SystemColors.InfoText;
            this.label3.Location = new System.Drawing.Point(116, 140);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 27);
            this.label3.TabIndex = 6;
            this.label3.Text = "密码";
            // 
            // aPasswordInput
            // 
            this.aPasswordInput.Font = new System.Drawing.Font("Arial Narrow", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aPasswordInput.Location = new System.Drawing.Point(185, 137);
            this.aPasswordInput.Name = "aPasswordInput";
            this.aPasswordInput.PasswordChar = '*';
            this.aPasswordInput.Size = new System.Drawing.Size(211, 34);
            this.aPasswordInput.TabIndex = 4;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(243, 39);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(75, 70);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.label1.Location = new System.Drawing.Point(218, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 31);
            this.label1.TabIndex = 1;
            this.label1.Text = "管理员登录";
            // 
            // AdminLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.ClientSize = new System.Drawing.Size(545, 341);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AdminLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AdminLogin";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button exitBt;
        private System.Windows.Forms.Button backU;
        private System.Windows.Forms.Button signIn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox aPasswordInput;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
    }
}
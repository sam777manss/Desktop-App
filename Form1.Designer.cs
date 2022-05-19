namespace HelloWorld
{
    partial class Form1
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
            this.click = new System.Windows.Forms.Button();
            this.labelHello3 = new System.Windows.Forms.Label();
            this.admin = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.login = new System.Windows.Forms.Button();
            this.exit = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // click
            // 
            this.click.BackColor = System.Drawing.SystemColors.ControlDark;
            this.click.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.click.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.click.Location = new System.Drawing.Point(84, 226);
            this.click.Name = "click";
            this.click.Size = new System.Drawing.Size(85, 35);
            this.click.TabIndex = 0;
            this.click.Text = "Sign up";
            this.click.UseVisualStyleBackColor = false;
            this.click.Click += new System.EventHandler(this.click_Click);
            // 
            // labelHello3
            // 
            this.labelHello3.AutoSize = true;
            this.labelHello3.BackColor = System.Drawing.SystemColors.ControlDark;
            this.labelHello3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelHello3.Location = new System.Drawing.Point(346, 424);
            this.labelHello3.Name = "labelHello3";
            this.labelHello3.Size = new System.Drawing.Size(45, 20);
            this.labelHello3.TabIndex = 2;
            this.labelHello3.Text = "Hello";
            this.labelHello3.Click += new System.EventHandler(this.labelHello_Click);
            // 
            // admin
            // 
            this.admin.BackColor = System.Drawing.SystemColors.ControlDark;
            this.admin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.admin.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.admin.Location = new System.Drawing.Point(84, 156);
            this.admin.Name = "admin";
            this.admin.Size = new System.Drawing.Size(85, 35);
            this.admin.TabIndex = 3;
            this.admin.Text = "Admin";
            this.admin.UseVisualStyleBackColor = false;
            this.admin.Click += new System.EventHandler(this.delete_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.SeaGreen;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(76, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(231, 46);
            this.label1.TabIndex = 4;
            this.label1.Text = "Home Page";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // login
            // 
            this.login.BackColor = System.Drawing.SystemColors.ControlDark;
            this.login.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.login.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.login.Location = new System.Drawing.Point(84, 297);
            this.login.Name = "login";
            this.login.Size = new System.Drawing.Size(85, 35);
            this.login.TabIndex = 5;
            this.login.Text = "Login";
            this.login.UseVisualStyleBackColor = false;
            this.login.Click += new System.EventHandler(this.login_Click);
            // 
            // exit
            // 
            this.exit.BackColor = System.Drawing.SystemColors.ControlDark;
            this.exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exit.Location = new System.Drawing.Point(84, 372);
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(85, 35);
            this.exit.TabIndex = 6;
            this.exit.Text = "Exit";
            this.exit.UseVisualStyleBackColor = false;
            this.exit.Click += new System.EventHandler(this.exit_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::HelloWorld.Properties.Resources.icons8_home_64;
            this.pictureBox1.Location = new System.Drawing.Point(719, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(81, 86);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SeaGreen;
            this.BackgroundImage = global::HelloWorld.Properties.Resources.WordPress;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.exit);
            this.Controls.Add(this.login);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.admin);
            this.Controls.Add(this.labelHello3);
            this.Controls.Add(this.click);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button click;
        private System.Windows.Forms.Label labelHello3;
        private System.Windows.Forms.Button admin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button login;
        private System.Windows.Forms.Button exit;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}


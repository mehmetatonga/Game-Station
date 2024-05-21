
namespace WindowsFormsApp2
{
    partial class Form4
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form4));
            this.label1 = new System.Windows.Forms.Label();
            this.TimerForGame = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox_ground = new System.Windows.Forms.PictureBox();
            this.pictureBox3_meteor2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1_meteor1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2_spaceship = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_ground)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3_meteor2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1_meteor1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2_spaceship)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.RoyalBlue;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(9, 594);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "SCORE";
            // 
            // TimerForGame
            // 
            this.TimerForGame.Enabled = true;
            this.TimerForGame.Interval = 20;
            this.TimerForGame.Tick += new System.EventHandler(this.GameTimer);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.RoyalBlue;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.pictureBox8);
            this.panel1.Location = new System.Drawing.Point(-2, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(571, 30);
            this.panel1.TabIndex = 21;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseUp);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(3, 1);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(176, 26);
            this.label2.TabIndex = 2;
            this.label2.Text = "FLAPPY SPACESHIP";
            // 
            // pictureBox8
            // 
            this.pictureBox8.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox8.Image = global::WindowsFormsApp2.Properties.Resources._525px_Black_x_svg;
            this.pictureBox8.Location = new System.Drawing.Point(540, 1);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(28, 28);
            this.pictureBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox8.TabIndex = 0;
            this.pictureBox8.TabStop = false;
            this.pictureBox8.Click += new System.EventHandler(this.pictureBox8_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.White;
            this.button3.BackgroundImage = global::WindowsFormsApp2.Properties.Resources.asdasdasd;
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button3.Font = new System.Drawing.Font("Stencil", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(227, 272);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(113, 52);
            this.button3.TabIndex = 8;
            this.button3.Text = "HELP";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.White;
            this.button2.BackgroundImage = global::WindowsFormsApp2.Properties.Resources.asdasdasd;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2.Font = new System.Drawing.Font("Stencil", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(227, 358);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(113, 52);
            this.button2.TabIndex = 6;
            this.button2.Text = "BACK TO GAME MENU";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.BackgroundImage = global::WindowsFormsApp2.Properties.Resources.asdasdasd;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Stencil", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(227, 190);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(113, 52);
            this.button1.TabIndex = 5;
            this.button1.Text = "PLAY AGAIN";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox_ground
            // 
            this.pictureBox_ground.BackColor = System.Drawing.Color.RoyalBlue;
            this.pictureBox_ground.Location = new System.Drawing.Point(-2, 585);
            this.pictureBox_ground.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox_ground.Name = "pictureBox_ground";
            this.pictureBox_ground.Size = new System.Drawing.Size(573, 45);
            this.pictureBox_ground.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_ground.TabIndex = 4;
            this.pictureBox_ground.TabStop = false;
            // 
            // pictureBox3_meteor2
            // 
            this.pictureBox3_meteor2.Image = global::WindowsFormsApp2.Properties.Resources.meteorson21;
            this.pictureBox3_meteor2.Location = new System.Drawing.Point(380, 422);
            this.pictureBox3_meteor2.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox3_meteor2.Name = "pictureBox3_meteor2";
            this.pictureBox3_meteor2.Size = new System.Drawing.Size(105, 167);
            this.pictureBox3_meteor2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3_meteor2.TabIndex = 2;
            this.pictureBox3_meteor2.TabStop = false;
            // 
            // pictureBox1_meteor1
            // 
            this.pictureBox1_meteor1.Image = global::WindowsFormsApp2.Properties.Resources.meteorson1;
            this.pictureBox1_meteor1.Location = new System.Drawing.Point(361, 23);
            this.pictureBox1_meteor1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1_meteor1.Name = "pictureBox1_meteor1";
            this.pictureBox1_meteor1.Size = new System.Drawing.Size(105, 166);
            this.pictureBox1_meteor1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1_meteor1.TabIndex = 0;
            this.pictureBox1_meteor1.TabStop = false;
            this.pictureBox1_meteor1.Click += new System.EventHandler(this.pictureBox1_meteor1_Click);
            // 
            // pictureBox2_spaceship
            // 
            this.pictureBox2_spaceship.BackColor = System.Drawing.Color.Black;
            this.pictureBox2_spaceship.Image = global::WindowsFormsApp2.Properties.Resources._81dad0cd45c6bfa10994b6035c4cf175;
            this.pictureBox2_spaceship.Location = new System.Drawing.Point(26, 262);
            this.pictureBox2_spaceship.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox2_spaceship.Name = "pictureBox2_spaceship";
            this.pictureBox2_spaceship.Size = new System.Drawing.Size(92, 67);
            this.pictureBox2_spaceship.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2_spaceship.TabIndex = 1;
            this.pictureBox2_spaceship.TabStop = false;
            this.pictureBox2_spaceship.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::WindowsFormsApp2.Properties.Resources.space_gif_8;
            this.pictureBox1.Location = new System.Drawing.Point(-2, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(568, 577);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(566, 626);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox_ground);
            this.Controls.Add(this.pictureBox3_meteor2);
            this.Controls.Add(this.pictureBox1_meteor1);
            this.Controls.Add(this.pictureBox2_spaceship);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form4";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form4";
            this.Load += new System.EventHandler(this.Form4_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Game_down);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Game_up);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_ground)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3_meteor2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1_meteor1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2_spaceship)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1_meteor1;
        private System.Windows.Forms.PictureBox pictureBox2_spaceship;
        private System.Windows.Forms.PictureBox pictureBox3_meteor2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer TimerForGame;
        private System.Windows.Forms.PictureBox pictureBox_ground;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox8;
    }
}
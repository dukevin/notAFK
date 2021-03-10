
namespace notAFK
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pause_btn = new System.Windows.Forms.Button();
            this.rowboat_btn = new System.Windows.Forms.Button();
            this.wheel_btn = new System.Windows.Forms.Button();
            this.land_btn = new System.Windows.Forms.Button();
            this.timer_container = new System.Windows.Forms.GroupBox();
            this.sinceOpen_box = new System.Windows.Forms.GroupBox();
            this.sinceOpen_text = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.statusBar = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.timer_container.SuspendLayout();
            this.sinceOpen_box.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pause_btn);
            this.groupBox1.Controls.Add(this.rowboat_btn);
            this.groupBox1.Controls.Add(this.wheel_btn);
            this.groupBox1.Controls.Add(this.land_btn);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(100, 150);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Control";
            // 
            // pause_btn
            // 
            this.pause_btn.ForeColor = System.Drawing.Color.DarkOrange;
            this.pause_btn.Location = new System.Drawing.Point(6, 111);
            this.pause_btn.Name = "pause_btn";
            this.pause_btn.Size = new System.Drawing.Size(87, 23);
            this.pause_btn.TabIndex = 3;
            this.pause_btn.Text = "Pause";
            this.pause_btn.UseVisualStyleBackColor = true;
            // 
            // rowboat_btn
            // 
            this.rowboat_btn.Location = new System.Drawing.Point(6, 82);
            this.rowboat_btn.Name = "rowboat_btn";
            this.rowboat_btn.Size = new System.Drawing.Size(87, 23);
            this.rowboat_btn.TabIndex = 2;
            this.rowboat_btn.Text = "Rowboat oars";
            this.rowboat_btn.UseVisualStyleBackColor = true;
            this.rowboat_btn.Click += new System.EventHandler(this.rowboat_btn_Click);
            // 
            // wheel_btn
            // 
            this.wheel_btn.Location = new System.Drawing.Point(7, 53);
            this.wheel_btn.Name = "wheel_btn";
            this.wheel_btn.Size = new System.Drawing.Size(87, 23);
            this.wheel_btn.TabIndex = 1;
            this.wheel_btn.Text = "Ship wheel";
            this.wheel_btn.UseVisualStyleBackColor = true;
            this.wheel_btn.Click += new System.EventHandler(this.sloop_btn_Click);
            // 
            // land_btn
            // 
            this.land_btn.Location = new System.Drawing.Point(7, 23);
            this.land_btn.Name = "land_btn";
            this.land_btn.Size = new System.Drawing.Size(87, 23);
            this.land_btn.TabIndex = 0;
            this.land_btn.Text = "Land actions";
            this.land_btn.UseVisualStyleBackColor = true;
            this.land_btn.Click += new System.EventHandler(this.random_btn_Click);
            // 
            // timer_container
            // 
            this.timer_container.Controls.Add(this.sinceOpen_box);
            this.timer_container.Location = new System.Drawing.Point(119, 13);
            this.timer_container.Name = "timer_container";
            this.timer_container.Size = new System.Drawing.Size(200, 66);
            this.timer_container.TabIndex = 2;
            this.timer_container.TabStop = false;
            this.timer_container.Text = "Timers";
            // 
            // sinceOpen_box
            // 
            this.sinceOpen_box.Controls.Add(this.sinceOpen_text);
            this.sinceOpen_box.Location = new System.Drawing.Point(7, 23);
            this.sinceOpen_box.Name = "sinceOpen_box";
            this.sinceOpen_box.Size = new System.Drawing.Size(85, 37);
            this.sinceOpen_box.TabIndex = 0;
            this.sinceOpen_box.TabStop = false;
            this.sinceOpen_box.Text = "Since Open";
            // 
            // sinceOpen_text
            // 
            this.sinceOpen_text.AutoSize = true;
            this.sinceOpen_text.Location = new System.Drawing.Point(7, 16);
            this.sinceOpen_text.Name = "sinceOpen_text";
            this.sinceOpen_text.Size = new System.Drawing.Size(28, 15);
            this.sinceOpen_text.TabIndex = 0;
            this.sinceOpen_text.Text = "0:00";
            // 
            // statusBar
            // 
            this.statusBar.Cursor = System.Windows.Forms.Cursors.Default;
            this.statusBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.statusBar.Location = new System.Drawing.Point(0, 174);
            this.statusBar.Multiline = true;
            this.statusBar.Name = "statusBar";
            this.statusBar.ReadOnly = true;
            this.statusBar.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.statusBar.Size = new System.Drawing.Size(392, 54);
            this.statusBar.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(392, 228);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.timer_container);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "notAFK";
            this.groupBox1.ResumeLayout(false);
            this.timer_container.ResumeLayout(false);
            this.sinceOpen_box.ResumeLayout(false);
            this.sinceOpen_box.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button land_btn;
        private System.Windows.Forms.GroupBox timer_container;
        private System.Windows.Forms.GroupBox sinceOpen_box;
        private System.Windows.Forms.Label sinceOpen_text;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button rowboat_btn;
        private System.Windows.Forms.Button wheel_btn;
        private System.Windows.Forms.Button pause_btn;
        private System.Windows.Forms.TextBox statusBar;
    }
}


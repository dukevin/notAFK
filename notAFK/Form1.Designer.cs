
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
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.count_label = new System.Windows.Forms.Label();
            this.sinceOpen_box = new System.Windows.Forms.GroupBox();
            this.sinceOpen_text = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.statusBar = new System.Windows.Forms.TextBox();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.groupBox1.SuspendLayout();
            this.timer_container.SuspendLayout();
            this.groupBox2.SuspendLayout();
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
            this.pause_btn.Enabled = false;
            this.pause_btn.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.pause_btn.ForeColor = System.Drawing.Color.Black;
            this.pause_btn.Location = new System.Drawing.Point(6, 111);
            this.pause_btn.Name = "pause_btn";
            this.pause_btn.Size = new System.Drawing.Size(87, 23);
            this.pause_btn.TabIndex = 3;
            this.pause_btn.Text = "Stop";
            this.pause_btn.UseVisualStyleBackColor = true;
            this.pause_btn.Click += new System.EventHandler(this.pause_btn_Click);
            // 
            // rowboat_btn
            // 
            this.rowboat_btn.Enabled = false;
            this.rowboat_btn.Location = new System.Drawing.Point(6, 82);
            this.rowboat_btn.Name = "rowboat_btn";
            this.rowboat_btn.Size = new System.Drawing.Size(87, 23);
            this.rowboat_btn.TabIndex = 2;
            this.rowboat_btn.Text = "Row forward";
            this.rowboat_btn.UseVisualStyleBackColor = true;
            this.rowboat_btn.Click += new System.EventHandler(this.rowboat_btn_Click);
            // 
            // wheel_btn
            // 
            this.wheel_btn.Location = new System.Drawing.Point(7, 22);
            this.wheel_btn.Name = "wheel_btn";
            this.wheel_btn.Size = new System.Drawing.Size(87, 23);
            this.wheel_btn.TabIndex = 0;
            this.wheel_btn.Text = "Ship wheel";
            this.wheel_btn.UseVisualStyleBackColor = true;
            this.wheel_btn.Click += new System.EventHandler(this.sloop_btn_Click);
            // 
            // land_btn
            // 
            this.land_btn.Location = new System.Drawing.Point(7, 53);
            this.land_btn.Name = "land_btn";
            this.land_btn.Size = new System.Drawing.Size(87, 23);
            this.land_btn.TabIndex = 1;
            this.land_btn.Text = "Land actions";
            this.land_btn.UseVisualStyleBackColor = true;
            this.land_btn.Click += new System.EventHandler(this.random_btn_Click);
            // 
            // timer_container
            // 
            this.timer_container.Controls.Add(this.checkBox1);
            this.timer_container.Controls.Add(this.groupBox2);
            this.timer_container.Controls.Add(this.sinceOpen_box);
            this.timer_container.Location = new System.Drawing.Point(119, 13);
            this.timer_container.Name = "timer_container";
            this.timer_container.Size = new System.Drawing.Size(105, 150);
            this.timer_container.TabIndex = 2;
            this.timer_container.TabStop = false;
            this.timer_container.Text = "Timers";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(7, 114);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(97, 19);
            this.checkBox1.TabIndex = 3;
            this.checkBox1.Text = "Stop after 1hr";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.count_label);
            this.groupBox2.Location = new System.Drawing.Point(7, 22);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(85, 37);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "1hr count";
            // 
            // count_label
            // 
            this.count_label.AutoSize = true;
            this.count_label.Location = new System.Drawing.Point(7, 16);
            this.count_label.Name = "count_label";
            this.count_label.Size = new System.Drawing.Size(34, 15);
            this.count_label.TabIndex = 0;
            this.count_label.Text = "60:00";
            // 
            // sinceOpen_box
            // 
            this.sinceOpen_box.Controls.Add(this.sinceOpen_text);
            this.sinceOpen_box.Location = new System.Drawing.Point(7, 65);
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
            this.sinceOpen_text.Size = new System.Drawing.Size(34, 15);
            this.sinceOpen_text.TabIndex = 0;
            this.sinceOpen_text.Text = "00:00";
            // 
            // statusBar
            // 
            this.statusBar.Cursor = System.Windows.Forms.Cursors.Default;
            this.statusBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.statusBar.Location = new System.Drawing.Point(0, 201);
            this.statusBar.Multiline = true;
            this.statusBar.Name = "statusBar";
            this.statusBar.ReadOnly = true;
            this.statusBar.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.statusBar.Size = new System.Drawing.Size(239, 54);
            this.statusBar.TabIndex = 4;
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(12, 169);
            this.progressBar.Maximum = 60;
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(212, 23);
            this.progressBar.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(239, 255);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.timer_container);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "notAFK";
            this.TopMost = true;
            this.groupBox1.ResumeLayout(false);
            this.timer_container.ResumeLayout(false);
            this.timer_container.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
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
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label count_label;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}


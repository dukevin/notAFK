using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Threading;
using System.Runtime.InteropServices;
using static notAFK.InputSender;
using System.Diagnostics;

namespace notAFK
{
    public partial class Form1 : Form
    {
        Rectangle dimentions;
        private CountDownTimer timerDown = new CountDownTimer();
        CountDownTimer timerUp = new CountDownTimer();
        public delegate void SetProgressDelg(int level);
        public Form1()
        {
            InitializeComponent();
            Cursor cursor = new Cursor(Cursor.Current.Handle);
            dimentions = Screen.FromControl(this).Bounds;
            timerUp.SetTime(360, 0);
            timerUp.Start();
            timerUp.TimeChanged += () => sinceOpen_text.Text = timerUp._stpWatch.Elapsed.Minutes.ToString()+":"+timerUp._stpWatch.Elapsed.Seconds.ToString();
        }
        private void random_btn_Click(object sender, EventArgs e)
        {
            updateStatusLabel("Button pressed - Land Actions");
            Thread.Sleep(2000);
            movement_scripts scripts = new movement_scripts(dimentions, this);
            scripts.testCamera();
            updateStatusLabel("Finished Land Actions");
        }
        public void updateStatusLabel(string text)
        {
            if (text == "null")
                return;
            statusBar.AppendText(Environment.NewLine+text);
            Application.DoEvents();
        }

        private void sloop_btn_Click(object sender, EventArgs e) //ClickKey(0x11);
        {
            updateStatusLabel("Button pressed - Wheel");
            start_countDownTimer();
            movement_scripts scripts = new movement_scripts(dimentions, this);
            Thread.Sleep(2000);
            //scripts.wheelScript_start();
            //scripts.moveWheel();
            updateStatusLabel("Finished Wheel actions");
        }
        private void start_countDownTimer()
        {
            timerDown.SetTime(60, 0);
            timerDown.Start();
            timerDown.TimeChanged += () => count_label.Text = timerDown.TimeLeftStr;
            timerDown.TimeChanged += () => progressBar.Value = 60-(int)timerDown.TimeLeft.TotalMinutes;
            timerDown.CountDownFinished += () => updateStatusLabel("The 1 hour timer is up!");
            timerDown.CountDownFinished += () => progressBar.SetState(2);
            Debug.WriteLine(progressBar.Value);
        }
        private void doActions(Actions[] actions)
        {
            foreach(Actions a in actions)
            {
                updateStatusLabel(a.ToString());
                a.doAction();
            }
        }

        private void rowboat_btn_Click(object sender, EventArgs e)
        {  
            updateStatusLabel("Button pressed - Rowboat");
            Thread.Sleep(2000);
            Random rand = new Random();
            Actions[] inputs = {
                new InputWrapper('a', KeyEventF.KeyDown),
                new Wait(2500),
                new InputWrapper('a', KeyEventF.KeyUp),
                new InputWrapper('d', KeyEventF.KeyDown),
                new Wait(2500),
                new InputWrapper('d', KeyEventF.KeyUp),
                new InputWrapper('f', KeyEventF.KeyDown),
                new Wait(2500),
                new InputWrapper('f', KeyEventF.KeyUp),
            };
            doActions(inputs);
            updateStatusLabel("Finished sloop actions");
        }
    }
    public static class ModifyProgressBarColor
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = false)]
        static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr w, IntPtr l);
        public static void SetState(this ProgressBar pBar, int state)
        {
            SendMessage(pBar.Handle, 1040, (IntPtr)state, IntPtr.Zero);
        }
    }
}
//https://www.codeproject.com/Articles/5264831/How-to-Send-Inputs-using-Csharp
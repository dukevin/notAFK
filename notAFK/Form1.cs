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
        public readonly int VERSION = 1;
        Rectangle dimentions;
        private CountDownTimer timerDown = new CountDownTimer();
        CountDownTimer timerUp = new CountDownTimer();
        public delegate void SetProgressDelg(int level);
        private movement_scripts curScript = null;
        public Form1()
        {
            InitializeComponent();
            Cursor cursor = new Cursor(Cursor.Current.Handle);
            dimentions = Screen.FromControl(this).Bounds;
            timerUp.SetTime(360, 0);
            timerUp.Start();
            timerUp.TimeChanged += () => sinceOpen_text.Text = timerUp._stpWatch.Elapsed.Minutes.ToString("D2")+":"+timerUp._stpWatch.Elapsed.Seconds.ToString("D2");
            updateStatusLabel("Welcome!  Version "+ VERSION);
        }
        private void land_btn_Click(object sender, EventArgs e)
        {
            land_btn.Enabled = false;
            updateStatusLabel("Button pressed - Circular movement");
            start_countDownTimer();
            curScript = new movement_scripts(dimentions, this);
            Thread.Sleep(2000);
            curScript.landActionsScript_start();
        }
        public void updateStatusLabel(string text)
        {
            if (text == "null")
                return;
            Invoke(new Action(() =>
            {
                statusBar.AppendText(Environment.NewLine + text);
            }));
            //Application.DoEvents();
        }

        private void ship_btn_Click(object sender, EventArgs e) //ClickKey(0x11);
        {
            updateStatusLabel("Button pressed - Wheel");
            updateStatusLabel("Pressing: [A] [D] moving mouse");
            start_countDownTimer();
            curScript = new movement_scripts(dimentions, this);
            Thread.Sleep(2000);
            curScript.wheelScript_start();
        }
        private void start_countDownTimer()
        {
            progressBar.SetState(1);
            endisableButtons(false,pause_btn);
            timerDown.SetTime(60, 0);
            timerDown.Start();
            timerDown.TimeChanged += () => count_label.Text = timerDown.TimeLeftStr;
            timerDown.TimeChanged += () => progressBar.Value = 60-(int)timerDown.TimeLeft.TotalMinutes;
            timerDown.CountDownFinished += () => updateStatusLabel("== 1 hour has elapsed ==");
            timerDown.CountDownFinished += () => progressBar.SetState(2);
            timerDown.CountDownFinished += () => stop_scripts_checked();
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
        private void endisableButtons(bool endis, Button except = null)
        {
            wheel_btn.Enabled = endis;
            rowboat_btn.Enabled = endis;
            land_btn.Enabled = endis;
            if (except != null)
            {
                if(!endis)
                    except.Enabled = true;
                else
                    except.Enabled = false;
            }
                
        }
        private void rowboat_btn_Click(object sender, EventArgs e)
        {
            updateStatusLabel("Button pressed - Rowboat");
            updateStatusLabel("Pressing: [A] [D] with 2 sec delays");
            start_countDownTimer();
            curScript = new movement_scripts(dimentions, this);
            Thread.Sleep(2000);
            curScript.rowboatScript_start();
        }
        private void pause_btn_Click(object sender, EventArgs e)
        {
            updateStatusLabel("Stopping...");
            endisableButtons(true, pause_btn);
            curScript.clean();
            curScript.running = false;
            pause_btn.Enabled = false;
            curScript = null;
            progressBar.SetState(3);
            updateStatusLabel("Stopped");
        }
        private void stop_scripts_checked()
        {
            if (!checkBox1.Checked)
                return;
            pause_btn_Click(null, null);
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
/*
 *      private void rowboat_btn_Click(object sender, EventArgs e)
        {  
            updateStatusLabel("Button pressed - Rowboat");
            start_countDownTimer();
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
        }
*/
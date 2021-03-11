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

namespace notAFK
{
    public partial class Form1 : Form
    {
        Rectangle dimentions;
        private System.Windows.Forms.Timer timerSinceOpen;
        private int counter;
        public Form1()
        {
            InitializeComponent();
            Cursor cursor = new Cursor(Cursor.Current.Handle);
            dimentions = Screen.FromControl(this).Bounds
        }
        private void random_btn_Click(object sender, EventArgs e)
        {
            updateStatusLabel("Button pressed - Land Actions");
            Thread.Sleep(2000);
            movement_scripts scripts = new movement_scripts(dimentions, this);
            scripts.testCamera();
            updateStatusLabel("Finished Land Actions");
        }
        private void generateRandomMovement()
        {
            Random rand = new Random();
            updateStatusLabel("moveCursor between [" + dimentions.Width + ", " + dimentions.Height + "]");
            Thread.Sleep(2000);
            updateStatusLabel("Starting");
            Actions[] inputs = {
                new MouseMove(dimentions.Width/2, dimentions.Height/2)
                //new MouseMove(dimentions.Width, dimentions.Height)
            };

            doActions(inputs.ToArray());
            updateStatusLabel("Done moving mouse");
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
            movement_scripts scripts = new movement_scripts(dimentions, this);
            Thread.Sleep(2000);
            scripts.wheelScript_start();
            //scripts.moveWheel();
            updateStatusLabel("Finished Wheel actions");
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
}
//https://www.codeproject.com/Articles/5264831/How-to-Send-Inputs-using-Csharp
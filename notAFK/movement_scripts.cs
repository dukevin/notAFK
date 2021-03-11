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
    class movement_scripts
    {
        public readonly int fullWheel_time = 2500;
        public static Rectangle screen_size;
        Form1 form;
        public movement_scripts(Rectangle dimentions, Form1 form)
        {
            screen_size = dimentions;
            this.form = form;
        }
        public bool wheelScript_start()
        {
            Thread camera_thread = new Thread(new ThreadStart(moveCamera));
            Thread button_thread = new Thread(new ThreadStart(moveWheel));
            camera_thread.Start();
            button_thread.Start();
            return true;
        }
        public void moveWheel()
        {
            while (true)
            {
                List<Actions> inputs = new List<Actions>();
                Random rand = new Random();
                int turns = rand.Next(5, 15);
                int turnedAt;
                int turningDir = rand.Next(-1, 1);
                turnedAt = turningDir;
                for (int t = 0; t < turns; t++)
                {
                    if (turningDir < 0)
                        turningDir = rand.Next(1, fullWheel_time - turnedAt);
                    else if (turningDir >= 0)
                        turningDir = rand.Next(fullWheel_time * -1 - turnedAt, -1);
                    turnedAt += turningDir;
                    inputs.Add(getInputDirFromTime(turningDir));
                    inputs.Add(new Wait(Math.Abs(turningDir)));
                }
                inputs.Add(getInputDirFromTime(turnedAt * -1));
                inputs.Add(new Wait(Math.Abs(turnedAt)));
                doActions(inputs);
            }
            //return inputs.ToArray();
        }
        public void doActions(List<Actions> inputs)
        {
            foreach (Actions a in inputs)
            {
                //form.updateStatusLabel(a.ToString());
                Debug.WriteLine(a.ToString());
                a.doAction();
            }
        }
        public void moveCamera()
        {
            Point curPos = Cursor.Position;
            Random r = new Random();
            List<Actions> inputs = new List<Actions>();
            inputs.Add(new MouseMove(curPos));
            while (true)
            {
                inputs.Add(new MouseMove(curPos.X + r.Next(-50, 50), curPos.Y + r.Next(-50, 50)));
                inputs.Add(new MouseMove(curPos));
                doActions(inputs);
            }
        }
        public void testCamera()
        {
            List<Actions> inputs = new List<Actions>();
            Random r = new Random();
            Point origin = new Point(screen_size.Width / 2, screen_size.Height / 2);
            Point curPos = Cursor.Position;
            Debug.WriteLine(curPos);
            inputs.Add(new MouseMove(curPos));
            inputs.Add(new MouseMove(curPos.X + 50, curPos.Y + 50));
            inputs.Add(new Wait(1000));
            inputs.Add(new MouseMove(curPos));
            doActions(inputs);
        }
        private InputWrapper getInputDirFromTime(int time)
        {
            return time > 0 ? new InputWrapper('d') : new InputWrapper('a');
        }
    }
}

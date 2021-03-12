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
        public bool running = true;
        public Form1 form;
        public movement_scripts(Rectangle dimentions, Form1 form)
        {
            screen_size = dimentions;
            this.form = form;
            running = true;
            form.updateStatusLabel("Starting movement...");
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
            while (running)
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
                    inputs.Add(new KeyWait(Math.Abs(turningDir)));
                }
                inputs.Add(getInputDirFromTime(turnedAt * -1));
                inputs.Add(new KeyWait(Math.Abs(turnedAt)));
                doActions(inputs);
            }
        }
        public void doActions(List<Actions> inputs)
        {
            foreach (Actions a in inputs)
            {
                if (!running) break;
                form.updateStatusLabel(a.ToString());
                Debug.WriteLine(a.ToString());
                a.doAction();
            }
        }
        public void clean()
        {
            MouseMoveAbs.MouseMoveJobs.Clear();
            MouseMoveAbs.currentJob = null;
            MouseMove.MouseMoveJobs.Clear();
            MouseMove.currentJob = null;
            MouseMoveByTime.MouseMoveJobs.Clear();
            MouseMoveByTime.currentJob = null;
            running = false;
        }
        public void moveCamera()
        {
            Point curPos = Cursor.Position;
            Random r = new Random();
            List<Actions> inputs = new List<Actions>();
            while (running)
            {
                r = new Random();
                int rx = r.Next(-300, 300);
                int ry = r.Next(-200, 200);
                int rx2 = 0;
                int ry2 = 0;
                inputs.Add(new MouseMove(rx, ry));
                inputs.Add(new Wait(r.Next(0, 3000)));
                if (r.Next(1, 3) == 2)
                {
                    rx2 = r.Next(-200, 200);
                    ry2 = r.Next(-200, 50);
                    inputs.Add(new MouseMove(rx2, ry2));
                }
                inputs.Add(new MouseMove(-(rx+rx2), -(ry+ry2)));
                inputs.Add(new Wait(r.Next(0, 3000)));
                doActions(inputs);
            }
        }
        public void testCamera()
        {
            List<Actions> inputs = new List<Actions>();
            while (running)
            {
                inputs.Add(new MouseMoveByTime(new Point(1, 0), 1000));
                inputs.Add(new Wait(1000));
                inputs.Add(new MouseMoveByTime(new Point(-1, 0), 1000));
                inputs.Add(new Wait(1000));
                inputs.Add(new MouseMoveByTime(new Point(-1, 0), 1000));
                inputs.Add(new Wait(1000));
                inputs.Add(new MouseMoveByTime(new Point(1, 0), 1000));
                doActions(inputs);
            }
        }
        private InputWrapper getInputDirFromTime(int time)
        {
            return time > 0 ? new InputWrapper('d') : new InputWrapper('a');
        }
    }
}

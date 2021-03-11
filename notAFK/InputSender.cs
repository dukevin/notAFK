using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Diagnostics;

namespace notAFK
{
    public class InputSender
    {
        public static Queue<ushort> pressed = new Queue<ushort>();
        #region Imports/Structs/Enums
        [StructLayout(LayoutKind.Sequential)]
        public struct KeyboardInput
        {
            public ushort wVk;
            public ushort wScan;
            public uint dwFlags;
            public uint time;
            public IntPtr dwExtraInfo;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct MouseInput
        {
            public int dx;
            public int dy;
            public uint mouseData;
            public uint dwFlags;
            public uint time;
            public IntPtr dwExtraInfo;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct HardwareInput
        {
            public uint uMsg;
            public ushort wParamL;
            public ushort wParamH;
        }

        [StructLayout(LayoutKind.Explicit)]
        public struct InputUnion
        {
            [FieldOffset(0)] public MouseInput mi;
            [FieldOffset(0)] public KeyboardInput ki;
            [FieldOffset(0)] public HardwareInput hi;
        }

        public struct Input
        {
            public int type;
            public InputUnion u;
        }

        [Flags]
        public enum InputType
        {
            Mouse = 0,
            Keyboard = 1,
            Hardware = 2
        }

        [Flags]
        public enum KeyEventF
        {
            KeyDown = 0x0000,
            ExtendedKey = 0x0001,
            KeyUp = 0x0002,
            Unicode = 0x0004,
            Scancode = 0x0008
        }

        [Flags]
        public enum MouseEventF
        {
            Absolute = 0x8000,
            HWheel = 0x01000,
            Move = 0x0001,
            MoveNoCoalesce = 0x2000,
            LeftDown = 0x0002,
            LeftUp = 0x0004,
            RightDown = 0x0008,
            RightUp = 0x0010,
            MiddleDown = 0x0020,
            MiddleUp = 0x0040,
            VirtualDesk = 0x4000,
            Wheel = 0x0800,
            XDown = 0x0080,
            XUp = 0x0100
        }
        public static MouseInput mouseFactory(int x, int y, bool abs = false)
        {
            MouseEventF code = 0x0;
            if (abs)
                code = MouseEventF.Absolute;
            return new MouseInput
            {
                dx = x,
                dy = y,
                dwFlags = (uint)MouseEventF.Move + (uint)code
            };
        }
        public static Input buttonFactory(char letter, KeyEventF updown, ushort key = 0x00)
        {
            switch (letter)
            {
                case 'w':
                    key = 0x11; break;
                case 'a':
                    key = 0x1E; break;
                case 's':
                    key = 0x1F; break;
                case 'd':
                    key = 0x20; break;
                case 'f':
                    key = 0x21; break;
                case '_':
                    break;
            }
            return new Input
            {
                type = (int)InputType.Keyboard,
                u = new InputUnion
                {
                    ki = new KeyboardInput
                    {
                        wVk = 0,
                        wScan = key, // A
                        dwFlags = (uint)(updown | KeyEventF.Scancode),
                        dwExtraInfo = GetMessageExtraInfo()
                    }
                }
            };
        }
        public interface Actions
        {
            void doAction();
        }
        public class Wait : Actions
        {
            private int time;
            public Wait(int time)
            { this.time = time; }
            public void doAction()
            {
                while (MouseMove.currentJob != null) ; //wait for the mouse jobs to finish but not needed
                Thread.Sleep(time);
                while (pressed.Count > 0) //release all the buttons
                    new InputWrapper('_', KeyEventF.KeyUp, pressed.Dequeue()).doAction();
            }
            public override string ToString()
            {
                return "Waiting "+time/1000+" seconds...";
            }
        }

        public class MouseMoveByTime : Actions
        {
            public static Queue<MouseMove> MouseMoveJobs = new Queue<MouseMove>();
            public static MouseMove currentJob = null;
            public bool running = false;
            public Point velocity;
            public int time;

            public MouseMoveByTime(Point velocity, int time)
            {
                this.velocity = velocity;
                this.time = time;
            }

            public void doAction()
            {
                var timer = new Stopwatch();
                timer.Start();
                TimeSpan timeTaken = timer.Elapsed;
                while (timeTaken.TotalMilliseconds < time) {
                    timeTaken = timer.Elapsed;
                    SendMouseInput(new MouseInput[] { mouseFactory(velocity.X, velocity.Y) });
                    Thread.Sleep(1);
                }
            }
            public override string ToString()
            {
                return "Camera move for " + time/1000 + "s in direction "+velocity.X+", "+velocity.Y;
            }
        }
        public class MouseMove : Actions
        {
            public static Queue<MouseMove> MouseMoveJobs = new Queue<MouseMove>();
            public static MouseMove currentJob = null;
            private int steps = 200;
            public bool running = false;
            public int name = 0;
            public bool virtualCursor = true; //the virtual cursor is for applications that grab the mouse so the coords do not update
            Point dest;
            Point step;
            public MouseMove(int dx, int dy, bool vCursor = true)
            {
                MouseMoveJobs.Enqueue(this);
                name = MouseMoveJobs.Count;
                dest.X = dx;
                dest.Y = dy;
                virtualCursor = vCursor;
            }
            public MouseMove(Point dp, bool vCursor = false) : this(dp.X, dp.Y, vCursor) { }

            public void doAction()
            {
                Point curpos = Cursor.Position;
                PointF slope = new PointF(dest.X - curpos.X, dest.Y - curpos.Y);
                step = new Point((int)slope.X / steps, (int)slope.Y / steps);
                if (currentJob == null)
                {
                    currentJob = this;
                    currentJob.running = true;
                }
                while (currentJob.running && currentJob != this) ; //wait
                //Debug.WriteLine("Starting job " + name);
                Point before = step;
                for (int i = 0; i < 1400; i++) //1400 iterations is a failsafe
                {
                    if(!virtualCursor)
                        curpos = Cursor.Position;
                    if (dest.Equals(curpos))
                    {
                        Debug.WriteLine("Cursor " + name + " destination and curpos are equal.. skipping");
                        break;
                    }
                    if (step.X == 0 && !dest.X.Equals(curpos.X)) //not moving and not at dest
                        step.X = curpos.X > dest.X ? -1 : 1;
                    else if (step.Y == 0 && !dest.Y.Equals(curpos.Y)) //not moving and not at dest
                        step.Y = curpos.Y > dest.Y ? -1 : 1;
                    else if (step.X < 0 && curpos.X + step.X < dest.X) //if we're going backwards but we're about to pass dest
                        step.X = dest.X - curpos.X;
                    else if (step.Y < 0 && curpos.Y + step.Y < dest.Y)
                        step.Y = dest.Y - curpos.Y;
                    else if (step.X > 0 && curpos.X + step.X > dest.X) //if we're going forward but we're about to pass our dest
                        step.X = dest.X - curpos.X;
                    else if (step.Y > 0 && curpos.Y + step.Y > dest.Y)
                        step.Y = dest.Y - curpos.Y;
                    if (virtualCursor)
                    {
                        curpos.X += step.X;
                        curpos.Y += step.Y;
                    }
                    SendMouseInput(new MouseInput[] { mouseFactory(step.X, step.Y) });
                    //Debug.WriteLine("-- Cursor "+name+" @"+ curpos + " moving by "+step+" adjusted from "+before+" going to "+dest);
                    Thread.Sleep(1);
                }
                //Debug.WriteLine("Done job " + name);
                currentJob = null;
                if(MouseMoveJobs.Count > 0)
                    MouseMoveJobs.Dequeue();
            }
            public override string ToString()
            {
                return "Camera move to " + dest.X + ", " + dest.Y;
            }
        }
        public class InputWrapper : Actions
        {
            private List<Input> _input = new List<Input>();
            public char letter = '_';
            KeyEventF updown;
            public InputWrapper(char letter, KeyEventF updown = KeyEventF.KeyDown, ushort key = 0x00)
            {
                _input.Add(buttonFactory(letter, updown, key));
                this.updown = updown;
                this.letter = letter;
            }
            public void doAction()
            {
                foreach (Input inp in _input)
                {
                    if(updown == KeyEventF.KeyDown)
                        pressed.Enqueue(inp.u.ki.wScan);
                }
                SendInput((uint)_input.Count, _input.ToArray(), Marshal.SizeOf(typeof(Input)));
            }
            public override string ToString()
            {
                dynamic button;
                if (letter == '_')
                    button = _input[0].u.ki.wScan;
                else
                    button = letter;
                return "Pressing [" + char.ToUpper(button) + "]";
            }
        }

        [DllImport("user32.dll", SetLastError = true)]
        public static extern uint SendInput(uint nInputs, Input[] pInputs, int cbSize);

        [DllImport("user32.dll")]
        public static extern IntPtr GetMessageExtraInfo();

        [DllImport("user32.dll")]
        public static extern bool GetCursorPos(out POINT lpPoint);

        //[DllImport("InputSimulator.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [DllImport("user32.dll", SetLastError = true)]
        static extern void keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);

        [StructLayout(LayoutKind.Sequential)]
        public struct POINT
        {
            public int X;
            public int Y;
        }

        [DllImport("User32.dll")]
        private static extern bool SetCursorPos(int x, int y);
        #endregion

        #region Wrapper Methods
        public static POINT GetCursorPosition()
        {
            GetCursorPos(out POINT point);
            return point;
        }

        public static void SetCursorPosition(int x, int y)
        {
            SetCursorPos(x, y);
        }

        public static void SendKeyboardInput(KeyboardInput[] kbInputs)
        {
            Input[] inputs = new Input[kbInputs.Length];

            for (int i = 0; i < kbInputs.Length; i++)
            {
                inputs[i] = new Input
                {
                    type = (int)InputType.Keyboard,
                    u = new InputUnion
                    {
                        ki = kbInputs[i]
                    }
                };
            }

            SendInput((uint)inputs.Length, inputs, Marshal.SizeOf(typeof(Input)));
        }

        public static void ClickKey(ushort scanCode)
        {
            var inputs = new KeyboardInput[]
            {
                new KeyboardInput
                {
                    wScan = scanCode,
                    dwFlags = (uint)(KeyEventF.KeyDown | KeyEventF.Scancode),
                    dwExtraInfo = GetMessageExtraInfo()
                },
                new KeyboardInput
                {
                    wScan = scanCode,
                    dwFlags = (uint)(KeyEventF.KeyUp | KeyEventF.Scancode),
                    dwExtraInfo = GetMessageExtraInfo()
                }
            };
            SendKeyboardInput(inputs);
        }

        public static void SendMouseInput(MouseInput[] mInputs)
        {
            Input[] inputs = new Input[mInputs.Length];

            for (int i = 0; i < mInputs.Length; i++)
            {
                inputs[i] = new Input
                {
                    type = (int)InputType.Mouse,
                    u = new InputUnion
                    {
                        mi = mInputs[i]
                    }
                };
            }

            SendInput((uint)inputs.Length, inputs, Marshal.SizeOf(typeof(Input)));
        }
        #endregion
    }
}

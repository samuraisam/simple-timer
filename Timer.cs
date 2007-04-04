using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using gma.System.Windows;

namespace Timer
{
    public partial class Timer : Form
    {
        private Stopwatch stopwatch;
        UserActivityHook actHook;
        private bool isAltDown;
        private bool isSpcDown;
        private bool isCrtlDown;
        private bool useKeyCommands;
        private const int WMTaskbarRClick = 0x0313;
        private ContextMenu taskbarMenu;
        
        /// <summary>
        /// Constructs object and determines the use of key commands.
        /// </summary>
        /// <param name="_useKeyCommands">Whether or not to hook global key commands.</param>
        public Timer(bool _useKeyCommands)
        {
            stopwatch = new Stopwatch();
            isAltDown = false;
            isSpcDown = false;
            isCrtlDown = false;
            useKeyCommands = _useKeyCommands;

            if (useKeyCommands)
            {
                try
                {
                    actHook = new UserActivityHook();
                }
                catch
                {
                    MessageBox.Show(
                        "There has been an error hooking global key commands. " +
                        "Global key commands will not be available.",
                        "Timer Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                    useKeyCommands = false;
                }
                actHook.KeyDown += new KeyEventHandler(GlobalKeyDownHandler);
                actHook.KeyUp += new KeyEventHandler(GlobalKeyUpHandler);
            }

            InitializeComponent();
            InitializeTaskbarMenu();

            this.setName();
        }

        /// <summary>
        /// Quits Timer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Quit(object sender, KeyEventArgs e)
        {
            if (e.KeyData.ToString() == "Escape")
                exitButton_Click(sender, e);
        }

        /// <summary>
        /// Adds the right-click contextual menu to the taskbar item.
        /// </summary>
        /// <param name="m">Message sent by the windows messenger.</param>
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WMTaskbarRClick:
                    Point menuPos = new Point(Cursor.Position.X - this.Location.X,
                                              Cursor.Position.Y - this.Location.Y);
                    taskbarMenu.Show(this, menuPos);
                    break;
            }
            base.WndProc(ref m);
        }

        /// <summary>
        /// Creates the contextual menu for the taskbar.
        /// </summary>
        private void InitializeTaskbarMenu()
        {
            taskbarMenu = new ContextMenu();
            taskbarMenu.MenuItems.Add("Start", new EventHandler(startButton_Click));
            taskbarMenu.MenuItems.Add("Reset", new EventHandler(resetButton_Click));
            taskbarMenu.MenuItems.Add(new MenuItem("-"));
            taskbarMenu.MenuItems.Add("Rename", new EventHandler(renameButton_Click));
            taskbarMenu.MenuItems.Add(new MenuItem("-"));
            taskbarMenu.MenuItems.Add("Exit", new EventHandler(exitButton_Click));
        }

        /// <summary>
        /// Asks user for a name for this timer instance.
        /// </summary>
        /// <returns>Title for timer.</returns>
        /// <exception>Exception</exception>
        private string getName()
        {
            NameTimer namer = new NameTimer();
            DialogResult re = namer.ShowDialog();
            string name = namer.getNameValue();
            if (re == DialogResult.OK && !String.IsNullOrEmpty(name.Trim()))
            {
                return name;
            }
            else { throw new Exception(); }
        }

        /// <summary>
        /// Sets the name of the timer. Keeps asking until the
        /// bastard provides a valid name!
        /// </summary>
        private void setName()
        {
            bool keepAsking = true;
            while (keepAsking)
            {
                try
                {
                    this.Text = getName() + " - Timer";
                }
                catch
                {
                    MessageBox.Show("You must provide a name.", "Timer Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    continue;
                }
                keepAsking = false;
            }
        }

        /// <summary>
        /// Runs the key handlers if combinations are found. Also sets the
        /// internal state of the keys.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void GlobalKeyDownHandler(object sender, KeyEventArgs e)
        {
            string keyString = e.KeyData.ToString();
            if (keyString == "LMenu" || keyString == "RMenu")
                isAltDown = true;
            if (keyString == "Space")
                isSpcDown = true;
            if (keyString == "LControlKey" || keyString == "RControlKey")
                isCrtlDown = true;
            // stop/start  alt+spc
            if (isAltDown && isSpcDown)
            {
                startButton_Click(sender, e);
                e.Handled = true;
            }
            // reset       crtl+alt+spc
            if (isAltDown && isSpcDown && isCrtlDown)
            {
                resetButton_Click(sender, e);
                e.Handled = true;
            }
        }

        /// <summary>
        /// Does nothing other than reset the internal state of the keys
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void GlobalKeyUpHandler(object sender, KeyEventArgs e)
        {
            string keyString = e.KeyData.ToString();
            if (keyString == "LMenu" || keyString == "RMenu")
                isAltDown = false;
            if (keyString == "Space")
                isSpcDown = false;
            if (keyString == "LControlKey" || keyString == "RControlKey")
                isCrtlDown = false;
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            if (stopwatch.IsRunning)
            {
                stopwatch.Stop();
                startButton.Text = "Start";
                taskbarMenu.MenuItems[0].Text = "Start"; // ugly, i know...
            }
            else
            {
                stopwatch.Start();
                startButton.Text = "Stop";
                taskbarMenu.MenuItems[0].Text = "Stop";
            }
        }

        private void timerMain_Tick(object sender, EventArgs e)
        {
            if (stopwatch.IsRunning)
            {
                TimeSpan ts = stopwatch.Elapsed;
                timeDisplay.Text = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                    ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds/10);
            }
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            if (stopwatch.IsRunning)
            {
                stopwatch.Stop();
                startButton.Text = "Start";
            }
            timeDisplay.Text = "";
            stopwatch.Reset();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Renames this timer. Only asks once. If input is invalid, ignore it
        /// and don't change the name.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void renameButton_Click(object sender, EventArgs e)
        {
            string name;
            try
            {
                name = this.getName();
            }
            catch { return;  }
            this.Text = name;
        }
    }
}
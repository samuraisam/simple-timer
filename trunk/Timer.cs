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
        /// <summary>
        /// Winforms class constructor. Does all the usual suspects.
        /// </summary>
        public Timer()
        {
            stopwatch = new Stopwatch();
            isAltDown = false;
            isSpcDown = false;
            isCrtlDown = false;

            actHook = new UserActivityHook();
            actHook.KeyDown += new KeyEventHandler(GlobalKeyDownHandler);
            actHook.KeyUp += new KeyEventHandler(GlobalKeyUpHandler);

            InitializeComponent();
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
            }
            else
            {
                stopwatch.Start();
                startButton.Text = "Stop";
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
    }
}
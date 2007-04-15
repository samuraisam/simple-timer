using System;
using System.Resources;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

using gma.System.Windows;
using OOGroup;

namespace Timer
{
    public partial class Timer : Form
    {
        private Stopwatch stopwatch;
        UserActivityHook actHook;
        private ResourceManager resman;
        private ContextMenu taskbarMenu;
        private DateTime timerStarted;
        private Stopwatch beepStopwatch;

        #region custom components
        private OOGroup.Windows.Forms.ImageButton startButton;
        private OOGroup.Windows.Forms.ImageButton resetButton;
        private OOGroup.Windows.Forms.ImageButton exitButton;
        #endregion

        private int beepInterval = 0;
        private bool isAltDown = false;
        private bool isSpcDown = false;
        private bool isCrtlDown = false;
        private bool useKeyCommands;
        private const int WMTaskbarRClick = 0x0313;
        private bool showingLog = false;
        
        /// <summary>
        /// Constructs object and determines the use of key commands.
        /// </summary>
        public Timer()
        {
            this.stopwatch = new Stopwatch();
            this.beepStopwatch = new Stopwatch();
            this.useKeyCommands = this.DetectKeyCommands();

            this.resman = new ResourceManager("Timer.Properties.Resources", this.GetType().Assembly);

            if (this.useKeyCommands)
            {
                try
                {
                    this.actHook = new UserActivityHook();
                    this.actHook.KeyDown += new KeyEventHandler(GlobalKeyDownHandler);
                    this.actHook.KeyUp += new KeyEventHandler(GlobalKeyUpHandler);
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
                    this.useKeyCommands = false;
                }
            }

            this.InitializeCustomComponents();
            this.InitializeComponent();

            this.SetName();
        }

        #region custom components
        private void InitializeCustomComponents()
        {
            //
            //  startButton
            //
            this.startButton = new OOGroup.Windows.Forms.ImageButton();
            this.startButton.SetImage(
                (System.Drawing.Bitmap)(resman.GetObject("timerStart")),
                OOGroup.Windows.Forms.ImageButton.Alignment.Left
            );
            this.startButton.Text = "Start";
            this.startButton.TextImageRelation = TextImageRelation.ImageBeforeText;
            this.startButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startButton.Location = new System.Drawing.Point(13, 60);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(114, 38);
            this.startButton.TabIndex = 1;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);

            // 
            //  resetButton
            // 
            this.resetButton = new OOGroup.Windows.Forms.ImageButton();
            this.resetButton.SetImage(
                (System.Drawing.Bitmap)(resman.GetObject("timerReset")),
                OOGroup.Windows.Forms.ImageButton.Alignment.Left
            );
            this.resetButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resetButton.Location = new System.Drawing.Point(133, 60);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(88, 38);
            this.resetButton.TabIndex = 2;
            this.resetButton.Text = "Reset";
            this.resetButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
            
            // 
            //  exitButton
            // 
            this.exitButton = new OOGroup.Windows.Forms.ImageButton();
            this.exitButton.SetImage(
                (System.Drawing.Bitmap)(resman.GetObject("quitTimer")),
                OOGroup.Windows.Forms.ImageButton.Alignment.Left
            );
            this.exitButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.exitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitButton.Location = new System.Drawing.Point(227, 60);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(70, 38);
            this.exitButton.TabIndex = 3;
            this.exitButton.Text = "Exit";
            this.exitButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);

            //
            //  taskbarMenu
            //
            this.taskbarMenu = new ContextMenu();
            this.taskbarMenu.MenuItems.Add("Start", new EventHandler(startButton_Click));
            this.taskbarMenu.MenuItems.Add("Reset", new EventHandler(resetButton_Click));
            this.taskbarMenu.MenuItems.Add(new MenuItem("-"));
            this.taskbarMenu.MenuItems.Add("Rename", new EventHandler(renameButton_Click));
            this.taskbarMenu.MenuItems.Add(new MenuItem("-"));
            this.taskbarMenu.MenuItems.Add("Exit", new EventHandler(exitButton_Click));

            this.Controls.Add(this.startButton);
            this.Controls.Add(this.resetButton);
            this.Controls.Add(this.exitButton);
        }
        #endregion

        /// <summary>
        /// Quits Timer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Quit(object sender, KeyEventArgs e)
        {
            if (e.KeyData.ToString() == "Escape")
                this.exitButton_Click(sender, e);
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
                    this.taskbarMenu.Show(this, menuPos);
                    break;
            }
            base.WndProc(ref m);
        }

        /// <summary>
        /// Detects whether we will use the key commands or not.
        /// </summary>
        /// <returns>Whether we use global key commands.</returns>
        private bool DetectKeyCommands()
        {
            string proc = Process.GetCurrentProcess().ProcessName;
            Process[] processes = Process.GetProcessesByName(proc);
            if (processes.Length > 1)
                return false;
            else
                return true;
        }

        /// <summary>
        /// Asks user for a name for this timer instance.
        /// </summary>
        /// <returns>Title for timer.</returns>
        /// <exception>Exception</exception>
        private string GetName()
        {
            NameTimer namer = new NameTimer();
            DialogResult re = namer.ShowDialog();
            string name = namer.GetNameValue();
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
        private void SetName()
        {
            bool keepAsking = true;
            while (keepAsking)
            {
                try
                {
                    this.Text = GetName() + " - Timer";
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
                this.isAltDown = true;
            if (keyString == "Space")
                this.isSpcDown = true;
            if (keyString == "LControlKey" || keyString == "RControlKey")
                this.isCrtlDown = true;
            // stop/start  alt+spc
            if (isAltDown && isSpcDown)
            {
                this.startButton_Click(sender, e);
                e.Handled = true;
            }
            // reset       crtl+alt+spc
            if (isAltDown && isSpcDown && isCrtlDown)
            {
                this.resetButton_Click(sender, e);
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
                this.isAltDown = false;
            if (keyString == "Space")
                this.isSpcDown = false;
            if (keyString == "LControlKey" || keyString == "RControlKey")
                this.isCrtlDown = false;
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            if (stopwatch.IsRunning)
            {
                this.stopwatch.Stop();
                this.startButton.Text = "Start";
                this.startButton.SetImage(
                    (System.Drawing.Bitmap)(resman.GetObject("timerStart")),
                    OOGroup.Windows.Forms.ImageButton.Alignment.Left
                );
                this.taskbarMenu.MenuItems[0].Text = "Start"; // ugly, i know...
                this.UpdateLog();
            }
            else
            {
                this.stopwatch.Start();
                this.startButton.Text = "Stop";
                this.startButton.SetImage(
                    (System.Drawing.Bitmap)(resman.GetObject("timerStop")),
                    OOGroup.Windows.Forms.ImageButton.Alignment.Left
                );
                this.taskbarMenu.MenuItems[0].Text = "Stop";
                this.timerStarted = DateTime.Now;
            }
        }

        private void timerMain_Tick(object sender, EventArgs e)
        {
            if (this.stopwatch.IsRunning)
            {
                TimeSpan ts = this.stopwatch.Elapsed;
                this.timeDisplay.Text = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                    ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds/10);
            }
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            if (this.stopwatch.IsRunning)
            {
                this.stopwatch.Stop();
                this.startButton.Text = "Start";
            }
            this.timeDisplay.Text = "";
            this.stopwatch.Reset();
            this.timerLog.Rows.Clear();
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
                name = this.GetName();
            }
            catch { return;  }
            this.Text = name + " - Timer";
        }

        /// <summary>
        /// Shows or hides the loging pane. Does a quick little transition for each one.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void showLog_Click(object sender, EventArgs e)
        {
            if (!this.showingLog)
            {
                while (this.Height < 300)
                {
                    this.Height += 20;
                    this.Refresh();
                }
                this.showingLog = true;
                this.showLog.Image = ((System.Drawing.Image)(resman.GetObject("showLogUp")));
            }
            else
            {
                while (this.Height > 140)
                {
                    this.Height -= 20;
                    this.Refresh();
                }
                this.showingLog = false;
                this.showLog.Image = ((System.Drawing.Image)(resman.GetObject("showLogDown")));
            }
        }

        /// <summary>
        /// Adds a row to the timerLog representing time started/stoped and total time taken.
        /// </summary>
        private void UpdateLog()
        {
            TimeSpan ts = DateTime.Now - this.timerStarted;
            this.timerLog.Rows.Add(
                this.timerStarted.ToString("T"),
                DateTime.Now.ToString("T"),
                String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                    ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10)
            );
        }

        private void beepMenuItem_Click(object sender, EventArgs e)
        {
            // uncheck non-clicked-on items and check the clicked on items
            foreach (ToolStripMenuItem i in beepAtMeToolStripMenuItem.DropDownItems)
            {
                if (sender == i)
                    i.Checked = true;
                else
                    i.Checked = false;
            }
            int interval = Convert.ToInt32(((ToolStripMenuItem)sender).Tag);

            if (interval != this.beepInterval && interval == 0)
            {
                this.beepStopwatch.Stop();
                this.beepStopwatch.Reset();
            }
            else if (interval != this.beepInterval)
            {
                if (this.beepStopwatch.IsRunning)
                    this.beepStopwatch.Stop();
                this.beepStopwatch.Reset();
                this.beepStopwatch.Start();
            }
            this.beepInterval = interval;
        }

        private void beepTimer_Tick(object sender, EventArgs e)
        {
            if (this.beepInterval == 0)
                return; // bail early to save resources
            if (this.beepStopwatch.IsRunning)
            {
                TimeSpan ts = this.beepStopwatch.Elapsed;
                if (ts.Minutes == beepInterval)
                    System.Console.Beep();
            }
        }

        private void aboutTimerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About aboutDialog = new About();
            DialogResult re = aboutDialog.ShowDialog();
        }

        private void transparancyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Transparancy t = new Transparancy();
            DialogResult re = t.ShowCustomDialog(this);
        }
    }
}
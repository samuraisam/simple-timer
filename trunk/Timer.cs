using System;
using System.Resources;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Reflection;
using System.Threading;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

using gma.System.Windows;
using OOGroup;

namespace Timer
{
    /// <summary>
    /// Event handler for when forms change their opacity.
    /// </summary>
    public delegate void OpacityChangeHandler(object sender, EventArgs e);

    /// <summary>
    /// The Holy master timer class.
    /// </summary>
    public partial class Timer : Form
    {
        /// <summary>
        /// timerObject is what runs the timer. Publically ingestible for child forms.
        /// </summary>
        public TimerObject timerObject;

        /// <summary>
        /// The smaller display for timer. Publically ingestible for child forms.
        /// </summary>
        public Form smallDisplay;

        /// <summary>
        /// Event for when Timer changes it's opacity.
        /// </summary>
        public event OpacityChangeHandler OpacityChanged;

        /// <summary>
        /// The Opacity of Timer, also fires OpacityChanged (hides base class's Opacity)
        /// </summary>
        public new virtual double Opacity
        {
            get
            {
                return base.Opacity;
            }
            set
            {
                base.Opacity = value;
                if (OpacityChanged != null)
                    OpacityChanged(this, new EventArgs());
            }
        }

        #region custom components
        private OOGroup.Windows.Forms.ImageButton startButton;
        private OOGroup.Windows.Forms.ImageButton resetButton;
        private OOGroup.Windows.Forms.ImageButton exitButton;
        #endregion
        private UserActivityHook actHook;
        private ResourceManager resman;
        private ContextMenu taskbarMenu;
        private DateTime timerStarted;
        private Dictionary<int, Beeper> beepers;
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
            this.useKeyCommands = this.DetectKeyCommands();
            this.beepers = new Dictionary<int, Beeper>();
            this.timerObject = new LapTimer(this);
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

            // the tooltip, which is integral to finding the extended functionality
            // of timer, will not show up until starting the timer without this call to Focus
            this.Focus();
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
        /// <exception>Exception (when the input is invalid)</exception>
        private string GetName()
        {
            NameTimer namer = new NameTimer(this);
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

        /// <summary>
        /// Generates a html summary of the current timerLog
        /// </summary>
        /// <returns>String of HTML</returns>
        public string GenerateLogHTML()
        {
            string rowsHTML = "";
            string style = @"
                th { text-align: left; }
                .l { background-color: white; }
                .r { background-color: #ebebeb; }
                table { border-collapse: collapse; }
            ";

            int i = 2;

            foreach (DataGridViewRow row in this.timerLog.Rows)
            {
                bool r = (i % 2 == 0);
                rowsHTML += String.Format(@"
                    <tr bgcolor='{3}'>
                        <td width=300>{0}</td>
                        <td width=300>{1}</td>
                        <td width=300>{2}</td>
                    </tr>
                    ",
                    row.Cells[0].Value, row.Cells[1].Value, row.Cells[2].Value,
                    r ? "#FFFFFF" : "#EBEBEB"
                );
                i++;
            }

            return String.Format(@"
                <html>
                    <head>
                        <title>{0}</title>
                        <style>{3}</style>
                    </head>
                    <body>
                        <h1 style='border-bottom:1px solid black;'>{0}</h1>
                        <table>
                            <tr><th>Start</th><th>Stop</th><th>Total</th></tr>
                            {1}
                            <tr><td>&nbsp;</td><td>&nbsp;</td><td><b>{2}</b></td></tr>
                        </table>
                    </body>
                </html>
                ",
                this.Text, rowsHTML, this.timeDisplay.Text, style
            );
        }

        /// <summary>
        /// Shows a print dialog to print whatever GenerateLogHTML spits out
        /// </summary>
        public void PrintLog()
        {
            this.printBrowser.DocumentText = this.GenerateLogHTML();

            this.printBrowser.DocumentCompleted +=
                new WebBrowserDocumentCompletedEventHandler(delegate(object sender, WebBrowserDocumentCompletedEventArgs e)
            {
                this.printBrowser.ShowPrintDialog();
            });
        }

        /// <summary>
        /// Creates a list from all current timerLog items
        /// </summary>
        /// <returns>A list of current timerLog items</returns>
        private List<List<string>> ListFromLog()
        {
            List<List<string>> ret = new List<List<string>>();
            foreach (DataGridViewRow row in this.timerLog.Rows)
            {
                List<string> add = new List<string>();
                add.Add((string)row.Cells[0].Value);
                add.Add((string)row.Cells[1].Value);
                add.Add((string)row.Cells[2].Value);
                ret.Add(add);
            }
            return ret;
        }

        /// <summary>
        /// Resets the current timerLog and adds all new values
        /// from the provided list.
        /// </summary>
        /// <param name="values">Values to insert into timerLog</param>
        private void ResetLogFromList(List<List<string>> values)
        {
            this.timerLog.Rows.Clear();
            foreach (List<string> row in values)
            {
                this.timerLog.Rows.Add(
                    row[0], row[1], row[2]
                );
            }
        }

        /// <summary>
        /// Save the state of Timer to a file
        /// </summary>
        /// <param name="file">Stream to write to.</param>
        private void Save(Stream file)
        {
            BinaryFormatter b = new BinaryFormatter();
            Hashtable se = new Hashtable();
            se.Add("TimerObject", this.timerObject);
            se.Add("TimerLog", this.ListFromLog());
            se.Add("TimerTimerStarted", this.timerStarted);
            se.Add("TimerOpacity", this.Opacity);
            se.Add("TimerText", this.Text);
            b.Serialize(file, se);
        }

        /// <summary>
        /// Re-create a Timer that had been saved.
        /// </summary>
        /// <param name="file">Stream to reat from.</param>
        private void Open(Stream file)
        {
            BinaryFormatter b = new BinaryFormatter();
            Hashtable se = (Hashtable)b.Deserialize(file);
            TimerObject t = (TimerObject)se["TimerObject"];
            t.Timer = this;
            this.timerObject = t;
            this.ResetLogFromList((List<List<string>>)se["TimerLog"]);
            this.timerStarted = (DateTime)se["TimerTimerStarted"];
            this.Opacity = (double)se["TimerOpacity"];
            this.Text = (string)se["TimerText"];
        }

        /// <summary>
        /// Toggles between calling timer objects's start and stop method. Maintains Timer
        /// interface for appropriate state.
        /// </summary>
        private void startButton_Click(object sender, EventArgs e)
        {
            if (this.timerObject.IsRunning)
            {
                this.timerObject.Stop();
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
                this.timerObject.Start();
                this.startButton.Text = "Stop";
                this.startButton.SetImage(
                    (System.Drawing.Bitmap)(resman.GetObject("timerStop")),
                    OOGroup.Windows.Forms.ImageButton.Alignment.Left
                );
                this.taskbarMenu.MenuItems[0].Text = "Stop";
                this.timerStarted = DateTime.Now;
            }
        }

        /// <summary>
        /// Calls timer object's timerMain_Tick method and sets timeDisplay's
        /// text to whatever it returns.
        /// </summary>
        private void timerMain_Tick(object sender, EventArgs e)
        {
            this.timeDisplay.Text = this.timerObject.timerMain_Tick(sender, e);
        }

        /// <summary>
        /// Calls timer objects Reset method and maintains Timer interface for a reset
        /// timer object.
        /// </summary>
        private void resetButton_Click(object sender, EventArgs e)
        {
            if (this.timerObject.IsRunning)
            {
                this.timerObject.Stop();
                this.startButton.SetImage(
                    (System.Drawing.Bitmap)(resman.GetObject("timerStart")),
                    OOGroup.Windows.Forms.ImageButton.Alignment.Left
                );
                this.startButton.Text = "Start";
            }
            this.timeDisplay.Text = "";
            this.timerObject.Reset();
            this.timerLog.Rows.Clear();
        }

        /// <summary>
        /// Immediatly quits the timer
        /// </summary>
        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Renames this timer. Only asks once. If input is invalid, ignore it
        /// and don't change the name.
        /// </summary>
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
        /// Go small.
        /// </summary>
        private void timeDisplay_DoubleClick(object sender, EventArgs e)
        {
            this.smallDisplay = new TimerSmall(this);
            this.smallDisplay.Show();
            this.Hide();
        }

        /// <summary>
        /// Go Big. 
        /// </summary>
        public void GoBig()
        {
            this.Show();
            this.smallDisplay.Close();
        }

        /// <summary>
        /// Maintains dictionary of beeper objects. Removes unchecked beepers,
        /// adds newly checked beepers.
        /// </summary>
        private void beepMenuItem_Click(object sender, EventArgs e)
        {
            int interval = Convert.ToInt32(((ToolStripMenuItem)sender).Tag);
            foreach (ToolStripMenuItem i in beepAtMeToolStripMenuItem.DropDownItems)
            {
                if (sender == i && i.Checked)
                {   // removing beeper
                    this.beepers[interval].StopAlerting();
                    this.beepers.Remove(interval);
                    i.Checked = false;
                }
                else if (sender == i && !i.Checked)
                {   // adding beeper
                    i.Checked = true;
                    this.beepers.Add(interval, new Beeper(this, interval));
                }
            }
        }

        /// <summary>
        /// Show the about dialog
        /// </summary>
        private void aboutTimerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About aboutDialog = new About(this);
            aboutDialog.Show();
        }

        /// <summary>
        /// Show the transparency dialog
        /// </summary>
        private void transparancyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Transparency transparencyDialog = new Transparency(this);
            transparencyDialog.Show();
        }

        /// <summary>
        /// Start a new CoutdownTimer
        /// </summary>
        private void countdownToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Countdown countdownDialog = new Countdown(this);
            DialogResult re = countdownDialog.ShowDialog();
            if (re == DialogResult.OK)
            {
                if (this.timerObject.IsRunning)
                {
                    this.startButton_Click(sender, e);
                }
                this.timerObject = new CountdownTimer(
                    this,
                    Convert.ToInt32(countdownDialog.hours.Value),
                    Convert.ToInt32(countdownDialog.minutes.Value),
                    Convert.ToInt32(countdownDialog.seconds.Value)
                );
            }
        }

        /// <summary>
        /// Start a new LapTimer
        /// </summary>
        private void simpleTimerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.timerObject.IsRunning)
            {
                this.startButton_Click(sender, e);
            }
            this.timerObject = new LapTimer(this);
        }

        /// <summary>
        /// Toggles the timer's stayOnTop status
        /// </summary>
        private void stayOnTopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem i = (ToolStripMenuItem)sender;
            if (!this.TopMost)
            {
                i.BackColor = System.Drawing.SystemColors.ControlLight;
                this.TopMost = true;
            }
            else if (this.TopMost)
            {
                i.BackColor = System.Drawing.SystemColors.Control;
                this.TopMost = false;
            }
        }

        /// <summary>
        /// Tells Timer to print it's log.
        /// </summary>
        private void printTimerLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.PrintLog();
        }

        /// <summary>
        /// Tells timer to save it's state to a file.
        /// </summary>
        private void saveTimerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.saveFileDialog.FileName = this.Text;
            DialogResult re = this.saveFileDialog.ShowDialog();
            if (re == DialogResult.OK)
            {
                Stream f = this.saveFileDialog.OpenFile();
                this.Save(f);
                f.Close();
            }
        }

        /// <summary>
        /// Tells timer to open re-create a saved state.
        /// </summary>
        private void openTimerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult re = this.openFileDialog.ShowDialog();
            if (re == DialogResult.OK)
            {
                Stream f = this.openFileDialog.OpenFile();
                this.Open(f);
                f.Close();
            }
        }

        /// <summary>
        /// Flashes the window numTimes of times in another thread.
        /// Specifying true for stayLit will make the window stay "flashed" after flashing.
        /// </summary>
        /// <param name="numTimes">Number of times to flash.</param>
        /// <param name="stayLit">Keep the taskbar item highlit, default behavior
        /// should be false. (don't want to annoy the user too much)</param>

        [DllImport("user32.dll")]
        public static extern int FlashWindow(IntPtr Hwnd, bool Revert);

        public void FlashWindow(int numTimes, bool stayLit)
        {
            IntPtr handle = this.Handle;
            Thread t = new Thread(delegate() // woot closures
            {
                for (int i = 0; i < numTimes; i++)
                {
                    Timer.FlashWindow(handle, false);
                    Thread.Sleep(500);
                    Timer.FlashWindow(handle, true);
                    Thread.Sleep(500);
                }
                if (stayLit)
                {
                    Timer.FlashWindow(handle, false);
                }
            });
            t.Start();
        }
    }
}
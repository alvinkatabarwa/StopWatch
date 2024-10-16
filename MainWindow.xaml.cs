using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StopWatch
{
    public partial class StopWatch : Form
    {
        private DateTime startTime;
        private TimeSpan elapsedTime = TimeSpan.Zero;

        public StopWatch()
        {
            InitializeComponent();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            // Set a value to start time
            startTime = DateTime.Now - elapsedTime; ;
            // Start the timer
            formTimer.Start();
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            formTimer.Stop();
            elapsedTime = DateTime.Now - startTime;
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            formTimer.Stop();
            elapsedTime = TimeSpan.Zero;
            watchLabel.Text = "00:00.00";
        }

        private void formTimer_Tick(object sender, EventArgs e)
        {
            // Calculate how long it's been since start
            TimeSpan span = DateTime.Now - startTime;
            watchLabel.Text = span.ToString(@"mm\:ss\.ff");
        }
    }
}

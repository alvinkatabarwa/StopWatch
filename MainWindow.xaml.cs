using System;
using System.Windows;
using System.Windows.Threading;

namespace StopWatch_GCS
{
    public partial class MainWindow : Window
    {
        private DispatcherTimer _timer; // Timer to update every second
        private TimeSpan _elapsedTime;  // Tracks elapsed time
        private bool _isRunning;        // Tracks if stopwatch is currently running

        public MainWindow()
        {
            InitializeComponent();
            InitializeTimer();
        }

        // Initialize the timer with an interval of 1 second
        private void InitializeTimer()
        {
            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromSeconds(1);
            _timer.Tick += Timer_Tick;
            _elapsedTime = TimeSpan.Zero;
            _isRunning = false;
        }

        // Update the TimerDisplay every second
        private void Timer_Tick(object sender, EventArgs e)
        {
            _elapsedTime = _elapsedTime.Add(TimeSpan.FromSeconds(1));
            TimerDisplay.Text = _elapsedTime.ToString(@"hh\:mm\:ss");
        }

        // Start the stopwatch
        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            _timer.Start();
            _isRunning = true;
            ToggleButtons(started: true, paused: false);
        }

        // Pause the stopwatch
        private void PauseButton_Click(object sender, RoutedEventArgs e)
        {
            if (_isRunning)
            {
                _timer.Stop();
                _isRunning = false;
                ToggleButtons(started: false, paused: true);
            }
        }

        // Resume the stopwatch from a paused state
        private void ResumeButton_Click(object sender, RoutedEventArgs e)
        {
            if (!_isRunning)
            {
                _timer.Start();
                _isRunning = true;
                ToggleButtons(started: true, paused: false);
            }
        }

        // Stop the stopwatch
        private void StopButton_Click(object sender, RoutedEventArgs e)
        {
            _timer.Stop();
            _isRunning = false;
            ToggleButtons(started: false, paused: false);
        }

        // Reset the stopwatch to 00:00:00
        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            _timer.Stop();
            _elapsedTime = TimeSpan.Zero;
            TimerDisplay.Text = "00:00:00";
            _isRunning = false;
            ToggleButtons(started: false, paused: false);
        }

        // Toggles button states based on stopwatch activity
        private void ToggleButtons(bool started, bool paused)
        {
            StartButton.IsEnabled = !started && !paused;
            PauseButton.IsEnabled = started;
            ResumeButton.IsEnabled = paused;
            StopButton.IsEnabled = started || paused;
            ResetButton.IsEnabled = !started && _elapsedTime > TimeSpan.Zero;
        }
    }
}



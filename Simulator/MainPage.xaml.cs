using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.PlatformConfiguration;
using System.Diagnostics;
using Microsoft.Maui.Devices;
using Microsoft.Maui.Storage;
using System.IO;
using System.Windows.Input;
using System;
using System.ComponentModel;
using System.Timers;
using Microsoft.Maui.Dispatching;

namespace Simulator
{
    public partial class MainPage : ContentPage
    {
        private System.Timers.Timer _timer;

        public MainPage()
        {
            InitializeComponent();

            // Initialize and configure the timer
            _timer = new System.Timers.Timer(60000); // 1-minute interval
            _timer.Elapsed += (s, e) =>
            {
                // Ensure the UI is updated on the main thread
                Dispatcher.Dispatch(() =>
                {
                    UpdateDateTime();
                    UpdateBatteryStatus();
                });
            };
            _timer.Start();

            // Force an initial update to show the current time and date
            UpdateDateTime();
            UpdateBatteryStatus();
        }

        private void UpdateDateTime()
        {
            // Use the current system time to update labels
            TimeLabel.Text = DateTime.Now.ToString("h:mm tt");  // e.g., "12:30 PM"
            DateLabel.Text = DateTime.Now.ToString("M/d/yyyy"); // e.g., "1/27/2025"
        }

        private void UpdateBatteryStatus()
        {
            // Get the battery charge level and display it
            var batteryLevel = Battery.ChargeLevel * 100; // Convert to percentage
            BatteryLabel.Text = $"Battery {batteryLevel:0}%"; // e.g., "Battery 75%"
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            _timer?.Stop();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _timer?.Start();
        }

    private async void OnMusicTapped(object sender, EventArgs e)
        {
            try
            {
                var downloadsFolder = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "/Downloads";

                var result = await FilePicker.PickAsync(new PickOptions
                {
                    PickerTitle = "Select a file",
                    FileTypes = FilePickerFileType.Images
                });

                if (result != null)
                {
                    var filePath = result.FullPath;

                    if (filePath.StartsWith(downloadsFolder, StringComparison.OrdinalIgnoreCase))
                    {
                        Console.WriteLine($"File picked from Downloads: {result.FileName}, Path: {filePath}");
                    }
                    else
                    {
                        Console.WriteLine("Please select a file from the Downloads folder.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error accessing storage: {ex.Message}");
            }
        }

        private async void ChangeWallpaper()
        {
            var result = await FilePicker.PickAsync(new PickOptions
            {
                FileTypes = FilePickerFileType.Images,
                PickerTitle = "Select a Wallpaper"
            });

            if (result != null)
            {
                Wallpaper.Source = ImageSource.FromFile(result.FullPath);
            }
        }

        private void OnMicrosoftButtonTapped(object sender, EventArgs e)
        {
            Launcher.OpenAsync(new Uri("https://www.microsoft.com/en-us/edge/update/132?ep=925&form=MT00UA&es=173&channel=stable&version=132.0.2957.115&cs=3803538485"));
        }

        private void OnGoogleButtonTapped(object sender, EventArgs e)
        {
            if (Application.Current != null)
            {
                var googleWindow = new Simulator.Google();
                Application.Current.OpenWindow(googleWindow);
            }
            else
            {
                Console.WriteLine("Application.Current is null. Cannot open the new window.");
            }
        }

        private void OnZoomButtonTapped(object sender, EventArgs e)
        {
            if (Application.Current != null)
            {
                var zoomWindow = new Simulator.Zoom();
                Application.Current.OpenWindow(zoomWindow);
            }
            else
            {
                Console.WriteLine("Application.Current is null. Cannot open the new window.");
            }
        }

        private void OnEmailButtonTapped(object sender, EventArgs e)
        {
            if (Application.Current != null)
            {
                var emailWindow = new Simulator.Email();
                Application.Current.OpenWindow(emailWindow);
            }
            else
            {
                Console.WriteLine("Application.Current is null. Cannot open the new window.");
            }
        }

        private void OnFacebookButtonTapped(object sender, EventArgs e)
        {
            if (Application.Current != null)
            {
                var facebookWindow = new Simulator.Facebook();
                Application.Current.OpenWindow(facebookWindow);
            }
            else
            {
                Console.WriteLine("Application.Current is null. Cannot open the new window.");
            }
        }

        private void OnYTButtonTapped(object sender, EventArgs e)
        {
            if (Application.Current != null)
            {
                var ytWindow = new Simulator.Youtube();
                Application.Current.OpenWindow(ytWindow);
            }
            else
            {
                Console.WriteLine("Application.Current is null. Cannot open the new window.");
            }
        }

        private void OnNotesButtonTapped(object sender, EventArgs e)
        {
            if (Application.Current != null)
            {
                var notesWindow = new Simulator.Notes();
                Application.Current.OpenWindow(notesWindow);
            }
            else
            {
                Console.WriteLine("Application.Current is null. Cannot open the new window.");
            }
        }

        private async void OnStorageAccessClicked(object sender, EventArgs e)
        {
            try
            {
                var result = await FilePicker.PickAsync(new PickOptions
                {
                    PickerTitle = "Select a file"
                });

                if (result != null)
                {
                    Console.WriteLine($"File picked: {result.FileName}, Path: {result.FullPath}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error accessing storage: {ex.Message}");
            }
        }
    }
}
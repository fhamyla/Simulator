using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.PlatformConfiguration;
using System.Diagnostics;
using Microsoft.Maui.Devices;
using Microsoft.Maui.Storage;

namespace Simulator
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
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

        private async void OnGoogleButtonTapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new GooglePage());
        }

        private async void OnZoomButtonTapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ZoomPage());
        }

        private async void OnEmailButtonTapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EmailPage());
        }

        private async void OnFacebookButtonTapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new FacebookPage());
        }

        private async void OnYTButtonTapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new YouTubePage());
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
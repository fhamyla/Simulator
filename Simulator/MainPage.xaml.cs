using Microsoft.Maui.Controls;

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
            // Let user select an image from their device
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
    }
}
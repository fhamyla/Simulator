namespace Simulator
{
    public partial class ActiveAppPage : ContentPage
    {
        public ActiveAppPage()
        {
            InitializeComponent();
        }

        // Minimize Button Clicked (example)
        private void MinimizeButton_Clicked(object sender, EventArgs e)
        {
            // Implement minimize action here
            DisplayAlert("Minimize", "Window minimized", "OK");
        }

        // Maximize Button Clicked (example)
        private void MaximizeButton_Clicked(object sender, EventArgs e)
        {
            // Implement maximize action here
            DisplayAlert("Maximize", "Window maximized", "OK");
        }

        // Close Button Clicked (example)
        private void CloseButton_Clicked(object sender, EventArgs e)
        {
            // Implement close action here
            DisplayAlert("Close", "Window closed", "OK");
        }
    }
}
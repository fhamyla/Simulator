using System;
using Microsoft.Maui.Controls;

namespace Simulator
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void OnSimulateProcessManagement(object sender, EventArgs e)
        {
            string os = OsPicker.SelectedItem?.ToString() ?? "None";
            string result = $"[Process Management] Simulating for {os}\n";
            result += "Process Created: PID 101\n";
            result += "Process Scheduled: PID 101\n";
            result += "Process Terminated: PID 101\n";
            OutputEditor.Text = result;
        }

        private void OnSimulateMemoryManagement(object sender, EventArgs e)
        {
            string os = OsPicker.SelectedItem?.ToString() ?? "None";
            string result = $"[Memory Management] Simulating for {os}\n";
            result += "Allocating 4KB of memory\n";
            result += "Memory Paging Enabled\n";
            result += "Segmentation Enabled\n";
            OutputEditor.Text = result;
        }

        private void OnSimulateFileManagement(object sender, EventArgs e)
        {
            string os = OsPicker.SelectedItem?.ToString() ?? "None";
            string result = $"[File Management] Simulating for {os}\n";
            result += "File Created: 'example.txt'\n";
            result += "File Written: 'example.txt'\n";
            result += "File Deleted: 'example.txt'\n";
            OutputEditor.Text = result;
        }

        private void OnSimulateIOManagement(object sender, EventArgs e)
        {
            string os = OsPicker.SelectedItem?.ToString() ?? "None";
            string result = $"[I/O Management] Simulating for {os}\n";
            result += "Input Device: Keyboard\n";
            result += "Output Device: Screen\n";
            OutputEditor.Text = result;
        }
    }
}
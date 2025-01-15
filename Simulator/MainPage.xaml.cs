using System;
using System.Collections.Generic;
using Microsoft.Maui.Controls;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Simulator
{
    public partial class MainPage : ContentPage
    {
        private List<bool> memoryPages;
        private Dictionary<string, string> fileSystem;
        private Random random;
        private List<string> processQueue;
        private List<string> logHistory;

        public MainPage()
        {
            InitializeComponent();
            memoryPages = new List<bool>(new bool[10]); // Simulated Memory
            fileSystem = new Dictionary<string, string>();
            random = new Random();
            processQueue = new List<string>();
            logHistory = new List<string>();
        }

        private void Log(string message)
        {
            logHistory.Add(message);
            OutputEditor.Text += message + "\n";
        }

        private async void OnSimulateProcessClick(object sender, EventArgs e)
        {
            string os = OsPicker.SelectedItem?.ToString() ?? "Unknown OS";
            string priority = PriorityPicker.SelectedItem?.ToString() ?? "Medium";

            string processId = Guid.NewGuid().ToString().Substring(0, 5);
            processQueue.Add(processId);
            Log($"Process {processId} created on {os} with {priority} priority.");
            await SimulateCPUExecution(processId);
        }

        private async Task SimulateCPUExecution(string processId)
        {
            Log($"Scheduling process {processId}...");
            await Task.Delay(1000);
            Log($"Process {processId} executed.");
            processQueue.Remove(processId);
        }

        private void OnSimulateMemoryAllocation(object sender, EventArgs e)
        {
            int allocatedPages = 0;
            for (int i = 0; i < memoryPages.Count; i++)
            {
                if (!memoryPages[i] && random.NextDouble() > 0.5)
                {
                    memoryPages[i] = true;
                    allocatedPages++;
                }
            }
            MemoryStatusLabel.Text = $"Allocated {allocatedPages} pages.";
            Log($"Memory allocated: {allocatedPages} pages.");
        }

        private void OnCreateFile(object sender, EventArgs e)
        {
            string fileName = "example.txt";
            if (!fileSystem.ContainsKey(fileName))
            {
                fileSystem[fileName] = "";
                Log($"File {fileName} created.");
            }
        }

        private void OnReadFile(object sender, EventArgs e)
        {
            string fileName = "example.txt";
            if (fileSystem.ContainsKey(fileName))
            {
                Log($"Reading file {fileName}: {fileSystem[fileName]}");
            }
        }

        private void OnWriteFile(object sender, EventArgs e)
        {
            string fileName = "example.txt";
            if (fileSystem.ContainsKey(fileName))
            {
                fileSystem[fileName] = "Sample content.";
                Log($"Writing to file {fileName}.");
            }
        }

        private void OnStartMonitoring(object sender, EventArgs e)
        {
            Dispatcher.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                int cpuUsage = random.Next(0, 100);
                int memoryUsage = random.Next(0, 100);
                CpuUsageLabel.Text = $"CPU: {cpuUsage}%";
                MemoryUsageLabel.Text = $"Memory: {memoryUsage}%";
                return true;
            });
        }
    }
}
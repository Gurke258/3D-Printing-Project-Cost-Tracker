using PrintTracker.Common;
using PrintTracker.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace PrintTracker.Wpf.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public ObservableCollection<PrintProject> PrintProjects { get; } = new();

        private PrintProject? _selectedProject;
        public PrintProject? SelectedProject
        {
            get => _selectedProject;
            set => SetProperty(ref _selectedProject, value);
        }

        public MainViewModel()
        {
            LoadTestData();
        }

        private void LoadTestData()
        {
            // Beispielhafte Daten zum Testen
            PrintProjects.Add(new PrintProject
            {
                Name = "Testprojekt 1",
                FilePath = "C:\\Prints\\test1.gcode",
                PrintedAt = DateTime.Now.AddDays(-2),
                LastModifiedAt = DateTime.Now.AddDays(-3),
                PrinterUsed = "Prusa i3 MK3S",
                FilamentUsed = "PLA - Rot",
                PrintDurationHours = TimeSpan.FromHours(5),
                ElectricityPrice = 1.50m,
                FilamentPrice = 11.66m,
                PrintResult = true
            });

            PrintProjects.Add(new PrintProject
            {
                Name = "Testprojekt 2",
                FilePath = "C:\\Prints\\test2.gcode",
                PrintedAt = DateTime.Now.AddDays(-5),
                LastModifiedAt = DateTime.Now.AddDays(-6),
                PrinterUsed = "Ender 3 Pro",
                FilamentUsed = "PETG - Blau",
                PrintDurationHours = TimeSpan.FromHours(3.5),
                ElectricityPrice = 1.00m,
                FilamentPrice = 19.95m,
                PrintResult = false
            });

            PrintProjects.Add(new PrintProject
            {
                Name = "Testprojekt 3",
                FilePath = "C:\\Prints\\test3.gcode",
                PrintedAt = DateTime.Now.AddDays(-7),
                LastModifiedAt = DateTime.Now.AddDays(-2),
                PrinterUsed = "Ender 3 Pro",
                FilamentUsed = "PETG - Blau",
                PrintDurationHours = TimeSpan.FromHours(2),
                ElectricityPrice = 1.00m,
                FilamentPrice = 24.99m,
                PrintResult = true
            });
        }


    }
}
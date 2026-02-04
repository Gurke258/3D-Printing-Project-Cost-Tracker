using PrintTracker.Common;
using PrintTracker.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace PrintTracker.Wpf.ViewModel
{
    internal class MainViewModel : ViewModelBase
    {
        public ObservableCollection<PrintProject> PrintProjects { get; } = new();


        public MainViewModel()
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
                ElectricityPrice = 1.50m
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
                ElectricityPrice = 1.00m
            });
        }


    }
}
using System;
using System.Collections.Generic;
using System.Text;
using PrintTracker.Common;

namespace PrintTracker.Core.Models
{
    public class PrintProject : ViewModelBase
    {
        public Guid Id { get; init; } = Guid.NewGuid(); // Eindeutige ID für die Datenbank/Liste

        private string? _name;
        public string? Name // Name des Projekts
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        private string? _filePath;
        public string? FilePath // Pfad zur Projektdatei
        {
            get => _filePath;
            set => SetProperty(ref _filePath, value);
        }

        private DateTime _printedAt;
        public DateTime PrintedAt  // Datum des Drucks
        {
            get => _printedAt;
            set => SetProperty(ref _printedAt, value);
        }

        private DateTime _lastModifiedAt;
        public DateTime LastModifiedAt // Letzte Änderung am Projekt
        {
            get => _lastModifiedAt;
            set => SetProperty(ref _lastModifiedAt, value);
        }

        private string? _printerUsed;
        public string? PrinterUsed // Verwendeter Drucker
        {
            get => _printerUsed;
            set => SetProperty(ref _printerUsed, value);
        }

        private string? _filamentUsed;
        public string? FilamentUsed  // Verwendetes Filament
        {
            get => _filamentUsed;
            set => SetProperty(ref _filamentUsed, value);
        }

        private TimeSpan _printDurationHours;
        public TimeSpan PrintDurationHours // Druckdauer in Stunden
        {
            get => _printDurationHours;
            set => SetProperty(ref _printDurationHours, value);
        }

        private decimal? _electricityPrice;
        public decimal? ElectricityPrice // // Stromkosten für den Druck
        {
            get => _electricityPrice;
            set
            {
                SetProperty(ref _electricityPrice, value);
                OnPropertyChanged(nameof(TotalCost)); // TotalCost neu berechnen, wenn sich der Strompreis ändert
            }


        }

        private double? _electricityUsedWatt;
        public double? ElectricityUsedWatt // Stromverbrauch in Watt 
        {
            get => _electricityUsedWatt;
            set
            {
                SetProperty(ref _electricityUsedWatt, value);
                OnPropertyChanged(nameof(TotalCost));
            }
        }

        private decimal? _filamentPrice;
        public decimal? FilamentPrice // Preis des verwendeten Filaments#
        {
            get => _filamentPrice;
            set
            {
                SetProperty(ref _filamentPrice, value);
                OnPropertyChanged(nameof(TotalCost));
            }
        }                 

        private double? _usedFilamentWeight;
        public double? UsedFilamentWeight // Verwendetes Filamentgewicht in Gramm
        {
            get => _usedFilamentWeight;
            set
            {
                SetProperty(ref _usedFilamentWeight, value);
                OnPropertyChanged(nameof(TotalCost));
            }
        }

        private bool _printResult;
        public bool PrintResult // Erfolg des Drucks (true = erfolgreich, false = fehlgeschlagen)
        {
            get => _printResult;
            set => SetProperty(ref _printResult, value);
        }

        public decimal? TotalCost
        {
            get
            {
                decimal filamentCost = FilamentPrice.HasValue && UsedFilamentWeight.HasValue
                    ? (decimal)UsedFilamentWeight.Value * FilamentPrice.Value / 1000m // Preis pro Gramm
                    : 0m;
                decimal electricityCost = ElectricityPrice.HasValue && ElectricityUsedWatt.HasValue && PrintDurationHours.TotalHours > 0
                    ? (decimal)ElectricityUsedWatt.Value * (decimal)PrintDurationHours.TotalHours * ElectricityPrice.Value / 1000m // Preis pro kWh
                    : 0m;
                return filamentCost + electricityCost;
            }
        }
        // public List<PrintJob> PrintJobs { get; set; } = new List<PrintJob>();
    }
}

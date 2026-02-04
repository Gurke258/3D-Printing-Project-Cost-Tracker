using System;
using System.Collections.Generic;
using System.Text;
using PrintTracker.Common;

namespace PrintTracker.Core
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
        public decimal? ElectricityPrice { get; set; } // Stromkosten für den Druck

        private decimal? _filamentPrice;
        public decimal? FilamentPrice // Preis des verwendeten Filaments#
        {
            get => _filamentPrice;
            set => SetProperty(ref _filamentPrice, value);
        }

        private bool _printResult;
        public bool PrintResult // Erfolg des Drucks (true = erfolgreich, false = fehlgeschlagen)
        {
            get => _printResult;
            set => SetProperty(ref _printResult, value);
        }
        // public List<PrintJob> PrintJobs { get; set; } = new List<PrintJob>();
    }
}

using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using PrintTracker.Common;
using PrintTracker.Core.Interfaces;
using PrintTracker.Core.Models;
using SkiaSharp;
using System.Collections.ObjectModel;

namespace PrintTracker.Wpf.ViewModels
{
    class DisplayChartViewModel : ViewModelBase
    {

        public ISeries[]? Series { get; set; }
        public Axis[]? XAxes { get; set; }

        private readonly ObservableCollection<PrintProject> _printprojects;

        public DisplayChartViewModel(ObservableCollection<PrintProject> printProjects)
        {
            _printprojects = printProjects;
            FillLiveCharts();
        }

        private void FillLiveCharts()
        {

            string[] labels = _printprojects
                                .Select(p => p.Name ?? "").ToArray();

            double[] erfolg = _printprojects
                                .Select(p => p.PrintResult == true ? p.UsedFilamentWeight ?? 0 : 0)
                                .ToArray();
            double[] fehler = _printprojects
                                .Select(p => p.PrintResult != true ? p.UsedFilamentWeight ?? 0 : 0)
                                .ToArray();

            XAxes = new Axis[]
            {
                new Axis { Labels = labels }
            };

            Series = new ISeries[]
            {
                new ColumnSeries<double>
                {
                    Name = "Erfolgreich",
                    Values = erfolg,
                    Fill = new SolidColorPaint(SKColors.Green)
                },

                new ColumnSeries<double>
                {
                    Name = "Fehlgeschlagen",
                    Values = fehler,
                    Fill = new SolidColorPaint(SKColors.IndianRed)
                }
            };
        }

    }
}

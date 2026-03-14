using PrintTracker.Core.Interfaces;
using PrintTracker.Core.Models;
using PrintTracker.Wpf.ViewModels;
using PrintTracker.Wpf.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace PrintTracker.Wpf
{
    public class DialogService : IDialogService
    {
        public PrintProject? ShowAddProjectDialog()
        {
            // 1. Fenster erstellen
            var window = new AddProjectWindow();

            // 2. Das passende ViewModel erstellen
            var vm = new AddProjectViewModel();

            // 3. Beides verheiraten
            window.DataContext = vm;

            // 4. Fenster anzeigen und warten, bis der Nutzer fertig ist
            bool? result = window.ShowDialog();

            // 5. Wenn der Nutzer "Speichern" gedrückt hat, geben wir das Projekt zurück
            if (result == true)
            {
                return vm.NewProject;
            }
            return null;
        }

        public PrintProject? ShowDisplayChartDialog(object? parameter)
        {
            // 1. Fenster erstellen
            var window = new ShowDisplayChartWindow();

            var projects = parameter as ObservableCollection<PrintProject> ?? new ObservableCollection<PrintProject>();

            // 2. Das passende ViewModel erstellen
            var vm = new DisplayChartViewModel(projects);

            // 3. Beides verheiraten
            window.DataContext = vm;
            window.ShowDialog();

            //// 4. Fenster anzeigen und warten, bis der Nutzer fertig ist
            //bool? result = window.ShowDialog();

            //// 5. Wenn der Nutzer "Speichern" gedrückt hat, geben wir das Projekt zurück
            //if (result == true)
            //{
            //    return vm.NewProject;
            //}
            return null;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace PrintTracker.Common
{
    public class ViewModelBase : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler? PropertyChanged;

        // Das [CallerMemberName] sorgt dafür, dass man propertyName meistens leer lassen kann
        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        // Property-Setter-Methode, die den Wert nur ändert, wenn er sich wirklich ändert
        protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string? propertyName = null)
        {
            // Prüfen - "Ist der neue Wert überhaupt anders?"
            if (EqualityComparer<T>.Default.Equals(storage, value))
                return false;

            // Speichern - "Den neuen Wert in die Variable schreiben"
            storage = value;

            // Benachrichtigen - "Die Klingel drücken"
            OnPropertyChanged(propertyName);

            return true; // "Ja, es hat sich wirklich was geändert!"
        }
    }
}

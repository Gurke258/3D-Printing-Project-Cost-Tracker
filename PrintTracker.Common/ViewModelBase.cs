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

        // Diese Hilfsmethode wird dein bester Freund!
        protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string? propertyName = null)
        {
            // JOB 1: Prüfen - "Ist der neue Wert überhaupt anders?"
            // Wenn ich den Namen von "Ben" auf "Ben" ändere, muss ich das UI nicht unnötig nerven.
            if (EqualityComparer<T>.Default.Equals(storage, value))
                return false;

            // JOB 2: Speichern - "Den neuen Wert in die Variable schreiben"
            storage = value;

            // JOB 3: Benachrichtigen - "Die Klingel drücken"
            OnPropertyChanged(propertyName);

            return true; // "Ja, es hat sich wirklich was geändert!"
        }
    }
}

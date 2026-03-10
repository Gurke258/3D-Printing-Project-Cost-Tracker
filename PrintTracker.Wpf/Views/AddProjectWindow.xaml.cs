using PrintTracker.Core.Models;
using System.Windows;

namespace PrintTracker.Wpf.Views
{
    /// <summary>
    /// Interaktionslogik für AddProjectWindow.xaml
    /// </summary>
    public partial class AddProjectWindow : Window
    {
        public AddProjectWindow()
        {
            InitializeComponent();
        }

        public PrintProject? Project { get; internal set; }

    }
}

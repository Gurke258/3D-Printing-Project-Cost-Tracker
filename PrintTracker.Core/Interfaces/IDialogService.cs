using PrintTracker.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PrintTracker.Core.Interfaces
{
    public interface IDialogService
    {
        PrintProject? ShowAddProjectDialog();
        PrintProject? ShowDisplayChartDialog(object? parameter);
    }
}

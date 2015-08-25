using System;
using System.Windows.Input;

namespace GeekyTool.Models
{
    interface IMenuItem
    {
        string Icon { get; set; }
        string Title { get; set; }
        Type View { get; set; }
        ICommand Command { get; set; }
    }
}

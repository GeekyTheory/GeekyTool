using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GeekyTool.Models
{
    public class MenuItem : IMenuItem
    {
        public string Icon { get; set; }
        public string Title { get; set; }
        public Type View { get; set; }
        public ICommand Command { get; set; }
        public string Brush { get; set; }
        public string Url { get; set; }
    }
}

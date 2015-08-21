using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeekyTool.Models
{
    public class MenuItems
    {
        public static MenuItems instance = null;

        private MenuItems() { }

        public static MenuItems Instance()
        {
            if (instance == null)
                instance = new MenuItems();
            return instance;
        }

        public ObservableCollection<MenuItem> Items { get; set; }
    }
}

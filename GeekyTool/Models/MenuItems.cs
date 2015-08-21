using System.Collections.ObjectModel;

namespace GeekyTool
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

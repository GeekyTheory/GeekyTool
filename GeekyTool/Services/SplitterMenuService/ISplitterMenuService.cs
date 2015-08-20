using System.Collections.Generic;
using System.Collections.ObjectModel;
using GeekyTool.Models;

namespace GeekyTool.Services.SplitterMenuService
{
    public interface ISplitterMenuService
    {
        void RegisterCollection(ObservableCollection<MenuItem> menuItemsCollection);

        void AddItems(IEnumerable<MenuItem> menuItemsCollection);
    }
}

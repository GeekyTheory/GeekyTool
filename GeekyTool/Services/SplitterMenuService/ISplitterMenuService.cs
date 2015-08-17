using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeekyTool.Models;

namespace GeekyTool.Services.SplitterMenuService
{
    public interface ISplitterMenuService
    {
        void RegisterCollection(ObservableCollection<MenuItem> menuItemsCollection);

        void AddItems(IEnumerable<MenuItem> menuItemsCollection);
    }
}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using GeekyTool.Models;

namespace GeekyTool.Services.SplitterMenuService
{
    public class SplitterMenuService : ISplitterMenuService
    {
        private ObservableCollection<MenuItem> menuItems;

        public void RegisterCollection(ObservableCollection<MenuItem> menuItemsCollection)
        {
            if (menuItemsCollection == null)
                throw new ArgumentException("Menu item collection must not be null.");

            menuItems = menuItemsCollection;
        }

        public void AddItems(IEnumerable<MenuItem> menuItemsCollection)
        {
            if (menuItems == null)
                throw new ArgumentException("There is no collection registered. You must register one before modify the item collection.");

            foreach (var item in menuItemsCollection)
            {
                menuItems.Add(item);
            }
        }
    }
}

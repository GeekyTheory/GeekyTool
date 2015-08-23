using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using GeekyTool.Models;

namespace GeekyTool.Services.SplitterMenuService
{
    public class SplitterMenuService : ISplitterMenuService
    {
        public void RegisterCollection(ObservableCollection<MenuItem> menuItemsCollection)
        {
            MenuItems.Instance();
            if (menuItemsCollection == null)
                throw new ArgumentException("Menu item collection must not be null.");

            MenuItems.instance.Items = menuItemsCollection;
        }

        public void AddItems(IEnumerable<MenuItem> menuItemsCollection)
        {
            if (MenuItems.instance.Items == null)
                throw new ArgumentException(
                    "There is no collection registered. You must register one before modify the item collection.");

            foreach (var item in menuItemsCollection)
            {
                MenuItems.instance.Items.Add(item);
            }
        }

        public void AddItem(MenuItem menuItem)
        {
            if (MenuItems.instance.Items == null)
                throw new ArgumentException(
                    "There is no collection registered. You must register one before modify the item collection.");

            MenuItems.instance.Items.Add(menuItem);
        }

        public void RemoveItems(IEnumerable<MenuItem> menuItemsCollection)
        {
            if (MenuItems.instance.Items == null)
                throw new ArgumentException(
                    "There is no collection registered. You must register one before modify the item collection.");

            foreach (var item in menuItemsCollection)
            {
                MenuItems.instance.Items.Remove(item);
            }
        }

        public void RemoveItem(MenuItem menuItem)
        {
            if (MenuItems.instance.Items == null)
                throw new ArgumentException(
                    "There is no collection registered. You must register one before modify the item collection.");

            MenuItems.instance.Items.Remove(menuItem);
        }
    }
}

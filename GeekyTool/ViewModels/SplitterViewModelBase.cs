using System.Collections.ObjectModel;
using Windows.UI.Xaml.Controls;
using GeekyTool.Models;
using GeekyTool.Services.SplitterMenuService;

namespace GeekyTool.ViewModels
{
    public abstract class SplitterViewModelBase : ViewModelBase
    {
        private bool isPaneOpen;
        private Frame splitViewFrame;
        private ObservableCollection<MenuItem> menuItems;
        private MenuItem menuItem;
        private ISplitterMenuService splitterMenuService;

        public Frame SplitViewFrame => splitViewFrame;

        public bool IsPaneOpen
        {
            get { return isPaneOpen; }
            set
            {
                if (isPaneOpen != value)
                {
                    isPaneOpen = value;
                    OnPropertyChanged();
                }
            }
        }

        public ObservableCollection<MenuItem> MenuItems
        {
            get { return menuItems; }
            private set
            {
                if (menuItems != value)
                {
                    menuItems = value;
                    OnPropertyChanged();
                }
            }
        }

        public MenuItem MenuItem
        {
            get { return menuItem; }
            set
            {
                menuItem = value;
                OnPropertyChanged();
                PerformNavigationCommandDelegate(menuItem);
            }
        }

        protected ISplitterMenuService SplitterMenuService
        {
            get
            {
                if (splitterMenuService == null)
                {
                    splitterMenuService = new SplitterMenuService();

                    if (menuItems == null)
                        menuItems = new ObservableCollection<MenuItem>();
                    splitterMenuService.RegisterCollection(menuItems);
                }
                return splitterMenuService;
            }
        }

        internal void SetSplitFrame(Frame viewFrame)
        {
            splitViewFrame = viewFrame;
        }

        protected abstract void PerformNavigationCommandDelegate(MenuItem item);
    }
}

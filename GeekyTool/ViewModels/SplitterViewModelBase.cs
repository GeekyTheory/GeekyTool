using System.Collections.ObjectModel;
using Windows.Foundation.Metadata;
using Windows.UI.Core;
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

        public new virtual void SetVisibilityOfNavigationBack()
        {
            var currentView = SystemNavigationManager.GetForCurrentView();

            if (!ApiInformation.IsTypePresent("Windows.Phone.UI.Input.HardwareButtons"))
            {
                if (AppFrame != null && AppFrame.CanGoBack)
                {
                    currentView.AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
                }
                else if (SplitViewFrame != null && SplitViewFrame.CanGoBack)
                {
                    currentView.AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
                }
                else
                {
                    currentView.AppViewBackButtonVisibility = AppViewBackButtonVisibility.Collapsed;
                }
            }
        }

        public new virtual void SystemNavigationManager_BackRequested(object sender, BackRequestedEventArgs e)
        {
            if (AppFrame != null && AppFrame.CanGoBack)
            {
                AppFrame.GoBack();
                e.Handled = true;
            }
            else if (SplitViewFrame != null && SplitViewFrame.CanGoBack)
            {
                SplitViewFrame.GoBack();
                e.Handled = true;
            }
        }

        internal void SetSplitFrame(Frame viewFrame)
        {
            splitViewFrame = viewFrame;
        }

        protected abstract void PerformNavigationCommandDelegate(MenuItem item);
    }
}

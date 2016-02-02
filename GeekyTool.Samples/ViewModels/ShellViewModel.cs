using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using GeekyTool.Commands;
using GeekyTool.Models;
using GeekyTool.Samples.Views;
using GeekyTool.ViewModels;

namespace GeekyTool.Samples.ViewModels
{
    public class ShellViewModel : SplitterViewModelBase
    {
        public ShellViewModel()
        {
            OpenPaneCommand = new DelegateCommand(OpenPaneCommandDelegate);
        }

        public ICommand OpenPaneCommand { get; private set; }

        public override Task OnNavigatedFrom(NavigationEventArgs e)
        {
            return null;
        }

        public override Task OnNavigatedTo(NavigationEventArgs e)
        {
            var items = new List<MenuItem>
            {
                new MenuItem
                {
                    Icon = "ms-appx:///Assets/Icons/Dashboard.png",
                    Title = "Dominant Color Sample",
                    Brush = new SolidColorBrush(Colors.ForestGreen).Color.ToString(),
                    View = typeof (MainView)
                },
                new MenuItem
                {
                    Icon = "ms-appx:///Assets/Geeky/geeky_theory_icon_round.png",
                    Title = "Another Sample",
                    Brush = new SolidColorBrush(Colors.Aqua).Color.ToString(),
                    View = typeof (MainView)
                },
                new MenuItem
                {
                    Icon = "ms-appx:///Assets/Geeky/geeky_juegos_icon_round.png",
                    Title = "Another Sample",
                    Brush = new SolidColorBrush(Colors.Aqua).Color.ToString(),
                    View = typeof (MainView)
                }
            };

            SplitterMenuService.AddItems(items);

            MenuItem = MenuItems.FirstOrDefault(x => x.View == typeof (MainView));

            return Task.FromResult(true);
        }

        private void OpenPaneCommandDelegate()
        {
            IsPaneOpen = !IsPaneOpen;
        }

        protected override void PerformNavigationCommandDelegate(MenuItem item)
        {
            if (item.View == null)
                return;

            if (item.View == typeof (MainView))
            {
                while (SplitViewFrame.CanGoBack)
                {
                    SplitViewFrame.GoBack();
                }
            }
            SplitViewFrame.Navigate(item.View, item);
        }
    }
}
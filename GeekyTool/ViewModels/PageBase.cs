using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using GeekyTool.ViewModels;

namespace GeekyTool
{
    public class PageBase : Page
    {
        private ViewModelBase vm;
        private Frame splitViewFrame;


        public Frame SplitViewFrame
        {
            get { return splitViewFrame; }
            set
            {
                splitViewFrame = value;

                if (vm == null)
                    vm = (ViewModelBase) this.DataContext;

                vm.SetSplitFrame(splitViewFrame);
            }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            vm = (ViewModelBase)this.DataContext;
            vm.SetAppFrame(this.Frame);
            vm.OnNavigatedTo(e);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);
            vm.OnNavigatedFrom(e);
        }
    }
}

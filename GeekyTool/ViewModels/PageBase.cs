using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using GeekyTool.ViewModels;

namespace GeekyTool
{
    public class PageBase : Page
    {
        private ViewModelBase vm;
        private SplitterViewModelBase svm;
        private Frame splitViewFrame;


        public Frame SplitViewFrame
        {
            get { return splitViewFrame; }
            set
            {
                splitViewFrame = value;

                if (svm == null)
                    svm = (SplitterViewModelBase) this.DataContext;

                svm.SetSplitFrame(splitViewFrame);
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

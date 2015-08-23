using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Windows.Foundation.Metadata;
using Windows.UI.Core;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace GeekyTool.ViewModels
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        private Frame appFrame;
        private bool isBusy;
        private double variableSizedGrid_Width;
        private double viewWidth;

        public Frame AppFrame => appFrame;

        public bool IsBusy
        {
            get { return isBusy; }
            set
            {
                isBusy = value;
                OnPropertyChanged();
            }
        }

        public double VariableSizedGrid_Width
        {
            get { return variableSizedGrid_Width; }
            set
            {
                if (variableSizedGrid_Width != value)
                {
                    variableSizedGrid_Width = value;
                    OnPropertyChanged();
                }
            }
        }

        public double ViewWidth
        {
            get { return viewWidth; }
            set
            {
                if (viewWidth != value)
                {
                    viewWidth = value;
                    OnPropertyChanged();
                }
            }
        }

        public abstract Task OnNavigatedFrom(NavigationEventArgs e);

        public abstract Task OnNavigatedTo(NavigationEventArgs e);

        public void GetCalculatedVariableSize(double width, int n)
        {
            VariableSizedGrid_Width = width / n;
        }

        public void SetVisibilityOfNavigationBack()
        {
            var currentView = SystemNavigationManager.GetForCurrentView();

            if (!ApiInformation.IsTypePresent("Windows.Phone.UI.Input.HardwareButtons"))
            {
                if (AppFrame != null && AppFrame.CanGoBack)
                {
                    currentView.AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
                }
                else
                {
                    currentView.AppViewBackButtonVisibility = AppViewBackButtonVisibility.Collapsed;
                }
            }
        }

        public void SystemNavigationManager_BackRequested(object sender, BackRequestedEventArgs e)
        {
            if (AppFrame != null && AppFrame.CanGoBack)
            {
                AppFrame.GoBack();
                e.Handled = true;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        internal void SetAppFrame(Frame viewFrame)
        {
            appFrame = viewFrame;
        }
    }
}

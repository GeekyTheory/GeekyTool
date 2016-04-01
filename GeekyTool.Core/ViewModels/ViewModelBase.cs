#if WINDOWS_UWP
using System.Threading.Tasks;
using Windows.UI.Xaml.Navigation;
#endif

namespace GeekyTool.Core.ViewModels
{
#if WINDOWS_UWP
    public abstract class ViewModelBase : BindableBase, INavigable
#else
    public abstract class ViewModelBase : BindableBase
#endif
    {
        private bool isBusy;

        public bool IsBusy
        {
            get { return isBusy; }
            set
            {
                isBusy = value;
                OnPropertyChanged();
            }
        }

#if WINDOWS_UWP
        public Task OnNavigatedFrom(object e)
        {
            return Task.CompletedTask;
        }

        public Task OnNavigatedTo(object e)
        {
            return Task.CompletedTask;
        }
#endif
    }
}

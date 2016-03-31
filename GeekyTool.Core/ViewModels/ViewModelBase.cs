using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using GeekyTool.Core.Annotations;

namespace GeekyTool.Core.ViewModels
{
    public abstract class ViewModelBase : INotifyPropertyChanged
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

        public abstract Task OnNavigatedFrom(NavigationEventArgs e);

        public abstract Task OnNavigatedTo(NavigationEventArgs e);

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

using System.Threading.Tasks;
using Windows.UI.Xaml.Navigation;
using GeekyTool.ViewModels;

namespace GeekyTool.Samples.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
            
        }

        public override Task OnNavigatedFrom(NavigationEventArgs e)
        {
            return null;
        }

        public override Task OnNavigatedTo(NavigationEventArgs e)
        {
            return null;
        }
    }
}

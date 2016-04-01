using System.Threading.Tasks;

namespace GeekyTool.Core.ViewModels
{
    public interface INavigable
    {
        Task OnNavigatedFrom(object e);
        Task OnNavigatedTo(object e);
    }
}

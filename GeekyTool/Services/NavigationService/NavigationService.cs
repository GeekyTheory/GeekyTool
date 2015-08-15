using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace GeekyTool.Services
{
	/// <summary>
	/// NavigationService contract implementation.
	/// </summary>
	public class NavigationService : INavigationService
	{
		/// <summary>
		/// Navigate to a new page, using the page type, without parameters.
		/// </summary>
		/// <typeparam name="TPageType"></typeparam>
		public void NavigateTo<TPageType>()
		{
			var Frame = (Frame)Window.Current.Content;
			Frame.Navigate(typeof(TPageType));
		}

		/// <summary>
		/// Navigate to a new page, using the page type, without parameters.
		/// </summary>
		/// <param name="parameter">argument to be sent to the target page.</param>
		/// <typeparam name="TPageType"></typeparam>
		public void NavigateTo<TPageType>(object parameter)
		{
			var Frame = (Frame)Window.Current.Content;
			Frame.Navigate(typeof(TPageType), parameter);
		}

		/// <summary>
		/// Removes the BackStack history of navigation.
		/// </summary>
		public void ClearNavigationHistory()
		{
			var Frame = (Frame)Window.Current.Content;
			Frame.BackStack.Clear();
		}


		/// <summary>
		/// Go back navigation.
		/// </summary>
		public void GoBack()
		{
			var Frame = (Frame)Window.Current.Content;
			Frame.GoBack();
		}

		public void RemoveLastPageFromNavigationHistory()
		{
			var Frame = (Frame)Window.Current.Content;
			Frame.BackStack.Remove(Frame.BackStack.Last());
		}
	}
}

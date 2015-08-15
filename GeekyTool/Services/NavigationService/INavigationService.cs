namespace GeekyTool.Services
{
	/// <summary>
	/// NavigationService contract definition.
	/// </summary>
	public interface INavigationService
	{
		/// <summary>
		/// Navigate to a new page, using the page type, without parameters.
		/// </summary>
		/// <typeparam name="PageType"></typeparam>
		void NavigateTo<PageType>();

		/// <summary>
		/// Navigate to a new page, using the page type, with parameters.
		/// </summary>
		/// <param name="parameter">argument to be sent to the target page.</param>
		/// <typeparam name="PageType"></typeparam>
		void NavigateTo<PageType>(object parameter);

		/// <summary>
		/// Removes the BackStack history of navigation.
		/// </summary>
		void ClearNavigationHistory();

		/// <summary>
		/// Go back navigation.
		/// </summary>
		void GoBack();

		/// <summary>
		/// Remove the last page of the BackStack from the navigation history
		/// </summary>
		void RemoveLastPageFromNavigationHistory();
	}
}

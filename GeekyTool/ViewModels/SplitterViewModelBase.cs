using Windows.UI.Xaml.Controls;

namespace GeekyTool.ViewModels
{
    public abstract class SplitterViewModelBase : ViewModelBase
    {
        private Frame splitViewFrame;

        public Frame SplitViewFrame => splitViewFrame;

        internal void SetSplitFrame(Frame viewFrame)
        {
            splitViewFrame = viewFrame;
        }
    }
}

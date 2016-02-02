namespace GeekyTool.Samples.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ShellView
    {
        public ShellView()
        {
            this.InitializeComponent();

            base.SplitViewFrame = SplitViewFrame;
        }
    }
}

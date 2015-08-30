using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Microsoft.Xaml.Interactivity;
using Windows.UI.Xaml.Controls;

namespace GeekyTool.Behaviors
{
    public class SplitViewSwipeBehavior : DependencyObject, IBehavior
    {
        public enum SplitViewManipulationType 
        {
            Open,
            Close
        }


        public SplitViewManipulationType ManipulationType
        {
            get { return (SplitViewManipulationType)GetValue(ManipulationTypeProperty); }
            set { SetValue(ManipulationTypeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ManipulationType.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ManipulationTypeProperty =
            DependencyProperty.Register("ManipulationType", typeof(SplitViewManipulationType), typeof(SplitViewSwipeBehavior), new PropertyMetadata(null));


        public SplitView Splitter
        {
            get { return (SplitView)GetValue(SplitterProperty); }
            set { SetValue(SplitterProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Splitter.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SplitterProperty =
            DependencyProperty.Register("Splitter", typeof(SplitView), typeof(SplitViewSwipeBehavior), new PropertyMetadata(null));


        public void Attach(DependencyObject associatedObject)
        {
            AssociatedObject = associatedObject;
            var fe = associatedObject as FrameworkElement;

            if (fe == null) return;

            fe.ManipulationMode = Windows.UI.Xaml.Input.ManipulationModes.TranslateX;

            if (ManipulationType == SplitViewManipulationType.Open)
                fe.ManipulationCompleted += AssociatedObjectOnOpenManipulationCompleted;
            else if (ManipulationType == SplitViewManipulationType.Close)
                fe.ManipulationCompleted += AssociatedObjectOnCloseManipulationCompleted;
        }

        private void AssociatedObjectOnOpenManipulationCompleted(object sender, Windows.UI.Xaml.Input.ManipulationCompletedRoutedEventArgs e)
        {
            if (e.Cumulative.Translation.X > 50)
                Splitter.IsPaneOpen = true;
        }

        private void AssociatedObjectOnCloseManipulationCompleted(object sender, Windows.UI.Xaml.Input.ManipulationCompletedRoutedEventArgs e)
        {
            if (e.Cumulative.Translation.X < -50)
                Splitter.IsPaneOpen = false;
        }

        public void Detach()
        {
            var fe = AssociatedObject as FrameworkElement;

            if (fe == null) return;

            if (ManipulationType == SplitViewManipulationType.Open)
                fe.ManipulationCompleted -= AssociatedObjectOnOpenManipulationCompleted;
            else if (ManipulationType == SplitViewManipulationType.Close)
                fe.ManipulationCompleted -= AssociatedObjectOnCloseManipulationCompleted;

            AssociatedObject = null;
        }

        public DependencyObject AssociatedObject { get; private set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Microsoft.Xaml.Interactivity;

namespace GeekyTool.Behaviors
{
    public class SplitViewOpenerBehavior : DependencyObject, IBehavior
    {

        public SplitView Splitter
        {
            get { return (SplitView)GetValue(SplitterProperty); }
            set { SetValue(SplitterProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Splitter.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SplitterProperty =
            DependencyProperty.Register("Splitter", typeof(SplitView), typeof(SplitViewOpenerBehavior), new PropertyMetadata(null));



        public void Attach(DependencyObject associatedObject)
        {
            var fe = associatedObject as FrameworkElement;

            if (fe == null) return;

            fe.ManipulationMode = ManipulationModes.TranslateX;
            fe.ManipulationCompleted += AssociatedObjectOnManipulationCompleted;

        }

        private void AssociatedObjectOnManipulationCompleted(object sender, ManipulationCompletedRoutedEventArgs manipulationCompletedRoutedEventArgs)
        {
            if (manipulationCompletedRoutedEventArgs.Cumulative.Translation.X > 50)
                Splitter.IsPaneOpen = true;
        }

        public void Detach()
        {
            throw new NotImplementedException();
        }

        public DependencyObject AssociatedObject { get; }
    }
}

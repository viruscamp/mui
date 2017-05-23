using System;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Interactivity;

namespace ModernUI.Behaviors
{
    /// <summary>
    /// </summary>
    public class RepositionPopupBehavior : Behavior<Popup>
    {
        /// <summary>
        ///     Called after the behavior is attached to an <see cref="Behavior.AssociatedObject" />.
        /// </summary>
        protected override void OnAttached()
        {
            base.OnAttached();
            Window window = Window.GetWindow(AssociatedObject.PlacementTarget);
            if (window == null) return;
            window.LocationChanged += OnLocationChanged;
            window.SizeChanged += OnSizeChanged;
            AssociatedObject.Loaded += AssociatedObject_Loaded;
        }

        /// <summary>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void AssociatedObject_Loaded(object sender, RoutedEventArgs e)
        {
            //AssociatedObject.HorizontalOffset = 7;
            //AssociatedObject.VerticalOffset = -AssociatedObject.Height;
        }

        /// <summary>
        ///     Called when the behavior is being detached from its <see cref="Behavior.AssociatedObject" />, but before it has
        ///     actually occurred.
        /// </summary>
        protected override void OnDetaching()
        {
            base.OnDetaching();
            Window window = Window.GetWindow(AssociatedObject.PlacementTarget);
            if (window == null) return;
            window.LocationChanged -= OnLocationChanged;
            window.SizeChanged -= OnSizeChanged;
            AssociatedObject.Loaded -= AssociatedObject_Loaded;
        }

        /// <summary>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnLocationChanged(object sender, EventArgs e)
        {
            double offset = AssociatedObject.HorizontalOffset;
            AssociatedObject.HorizontalOffset = offset + 1;
            AssociatedObject.HorizontalOffset = offset;
        }

        /// <summary>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnSizeChanged(object sender, SizeChangedEventArgs e)
        {
            double offset = AssociatedObject.HorizontalOffset;
            AssociatedObject.HorizontalOffset = offset + 1;
            AssociatedObject.HorizontalOffset = offset;
        }
    }
}
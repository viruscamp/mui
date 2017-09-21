using System.Globalization;
using System.Windows.Controls;
using ModernUI.Windows.Navigation;

namespace ModernUI.App.Content
{
    /// <summary>
    ///     Interaction logic for ControlsModernFrame.xaml
    /// </summary>
    public partial class ControlsModernFrame : UserControl
    {
        private string eventLogMessage;

        public ControlsModernFrame()
        {
            InitializeComponent();

            TextEvents.Text = eventLogMessage;
        }

        private void LogMessage(string message, params object[] o)
        {
            message = string.Format(CultureInfo.CurrentUICulture, message, o);

            if (TextEvents == null)
            {
                eventLogMessage += message;
            }
            else
            {
                TextEvents.AppendText(message);
            }
        }

        private void Frame_FragmentNavigation(object sender, FragmentNavigationEventArgs e)
        {
            LogMessage("FragmentNavigation: {0}\r\n", e.Fragment);
        }

        private void Frame_Navigated(object sender, NavigationEventArgs e)
        {
            LogMessage("Navigated: [{0}] {1}\r\n", e.NavigationType, e.Source);
        }

        private void Frame_Navigating(object sender, NavigatingCancelEventArgs e)
        {
            LogMessage("Navigating: [{0}] {1}\r\n", e.NavigationType, e.Source);
        }

        private void Frame_NavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            LogMessage("NavigationFailed: {0}\r\n", e.Error.Message);
        }
    }
}
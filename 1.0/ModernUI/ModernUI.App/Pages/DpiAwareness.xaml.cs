using System.Windows.Controls;

namespace ModernUI.App.Pages
{
    /// <summary>
    ///     Interaction logic for DpiAwareness.xaml
    /// </summary>
    public partial class DpiAwareness : UserControl
    {
        public DpiAwareness()
        {
            InitializeComponent();

            DataContext = new DpiAwarenessViewModel();
        }
    }
}
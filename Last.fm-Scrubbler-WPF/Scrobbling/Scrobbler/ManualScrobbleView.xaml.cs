using System.Windows;
using System.Windows.Controls;

namespace Scrubbler.Scrobbling.Scrobbler
{
  /// <summary>
  /// Interaction logic for ManualScrobbleView.xaml
  /// </summary>
  public partial class ManualScrobbleView : UserControl
  {
    /// <summary>
    /// Constructor.
    /// </summary>
		public ManualScrobbleView()
    {
      InitializeComponent();
    }

    private void ClearButton_Click(object sender, RoutedEventArgs e)
    {
      if (DataContext is ManualScrobbleViewModel vm)
        vm.Clear();
    }

  }
}
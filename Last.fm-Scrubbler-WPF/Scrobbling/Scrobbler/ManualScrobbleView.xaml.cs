using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

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

      ArtistTextBox.PreviewKeyDown += ArtistTextBox_PreviewKeyDown;
      DataObject.AddPastingHandler(ArtistTextBox, ArtistTextBox_Paste);
    }

    private void ArtistTextBox_PreviewKeyDown(object sender, KeyEventArgs e)
    {
      // optional: hier könnte man Copy-Paste über Strg+V abfangen, 
      // oft reicht jedoch der Pasting-Handler
    }

    private void ArtistTextBox_Paste(object sender, DataObjectPastingEventArgs e)
    {
      if (chkSplitArtistTrack.IsChecked != true)
        return;

      if (e.DataObject.GetDataPresent(DataFormats.Text))
      {
        string pastedText = e.DataObject.GetData(DataFormats.Text) as string;
        if (string.IsNullOrEmpty(pastedText))
          return;

        string[] parts = pastedText.Split(new[] { '-' }, 2); // nur am ersten Bindestrich trennen
        if (parts.Length == 2)
        {
          string artist = parts[0].Trim();
          string track = parts[1].Trim();

          // TextBox-Werte setzen
          ArtistTextBox.Text = artist;
          TrackTextBox.Text = track;

          e.CancelCommand(); // verhindert den normalen Einfügevorgang
        }
      }
    }
  }
}
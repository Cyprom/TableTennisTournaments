using Cyprom.TableTennisTournaments.Model;
using Cyprom.TableTennisTournaments.View.Details;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Cyprom.TableTennisTournaments.View.Overviews
{
    /// <summary>
    /// Interaction logic for MatchOverview.xaml
    /// </summary>
    public partial class MatchOverview : UserControl
    {
        public MatchOverview()
        {
            InitializeComponent();
        }

        public void SetMatches(List<Match> matches)
        {
            grdMatches.ItemsSource = null;
            grdMatches.ItemsSource = matches;
        }

        private void ViewMatch(object sender, RoutedEventArgs e)
        {
            var selection = grdMatches.SelectedItem as Match;
            if (selection != null)
            {
                var detailView = new MatchDetails();
                detailView.Initialize(selection.ID);
                MainWindow.LoadView(detailView);
            }
        }

        private void MatchSelected(object sender, SelectionChangedEventArgs e)
        {
            btnView.IsEnabled = e.AddedItems.Count == 1;
        }
    }
}

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
using Cyprom.TableTennisTournaments.Model.Managers;
using Cyprom.TableTennisTournaments.View.Details;
using Cyprom.TableTennisTournaments.View.Dialogs;
using Cyprom.TableTennisTournaments.Model;

namespace Cyprom.TableTennisTournaments.View.Overviews
{
    /// <summary>
    /// Interaction logic for TournamentOverview.xaml
    /// </summary>
    public partial class TournamentOverview : UserControl
    {
        public TournamentOverview()
        {
            InitializeComponent();
        }

        public void Refresh()
        {
            grdTournaments.ItemsSource = null;
            grdTournaments.ItemsSource = ModelManager.Tournaments;
        }

        private void CreateTournament(object sender, RoutedEventArgs e)
        {
            var dialog = new TournamentCreationDialog();
            if (dialog.ShowDialog().GetValueOrDefault())
            {
                Refresh();
            }
        }

        private void ViewTournament(object sender, RoutedEventArgs e)
        {
            var selection = grdTournaments.SelectedItem as Tournament;
            if (selection != null)
            {
                var detailView = new TournamentDetails();
                detailView.Initialize(selection.ID);
                MainWindow.LoadView(detailView);
            }
        }

        private void RemoveTournament(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("TODO: Implement remove tournament");
        }

        private void TournamentSelected(object sender, SelectionChangedEventArgs e)
        {
            btnView.IsEnabled = e.AddedItems.Count == 1;
            btnRemove.IsEnabled = e.AddedItems.Count == 1;
        }
    }
}

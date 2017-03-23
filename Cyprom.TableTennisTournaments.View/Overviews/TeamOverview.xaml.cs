using Cyprom.TableTennisTournaments.Model;
using Cyprom.TableTennisTournaments.Model.Enums;
using Cyprom.TableTennisTournaments.View.Details;
using Cyprom.TableTennisTournaments.View.Dialogs;
using Cyprom.TableTennisTournaments.View.Extensions;
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
    /// Interaction logic for TeamOverview.xaml
    /// </summary>
    public partial class TeamOverview : UserControl
    {
        public bool ReadOnly
        {
            set
            {
                if (value)
                {
                    btnNew.Visibility = Visibility.Collapsed;
                    btnRemove.Visibility = Visibility.Collapsed;
                }
                else
                {
                    btnNew.Visibility = Visibility.Visible;
                    btnRemove.Visibility = Visibility.Visible;
                }
            }
        }

        public TeamOverview()
        {
            InitializeComponent();
        }

        public void SetTeams(List<Team> teams)
        {
            grdTeams.ItemsSource = null;
            grdTeams.ItemsSource = teams;
        }

        private void CreateTeam(object sender, RoutedEventArgs e)
        {
            var dialog = new TeamCreationDialog();
            if (dialog.ShowDialog().GetValueOrDefault())
            {
                var tournamentDetails = this.FindParent<TournamentDetails>();
                if (tournamentDetails != null)
                {
                    dialog.Team.Tournament = tournamentDetails.Tournament;
                    SetTeams(tournamentDetails.Tournament.Teams);
                }
            }
        }

        private void ViewTeam(object sender, RoutedEventArgs e)
        {
            var selection = grdTeams.SelectedItem as Team;
            if (selection != null)
            {
                var detailView = new TeamDetails();
                detailView.Initialize(selection.ID);
                MainWindow.LoadView(detailView);
            }
        }

        private void RemoveTeam(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("TODO: Implement remove team");
        }

        private void TeamSelected(object sender, SelectionChangedEventArgs e)
        {
            btnView.IsEnabled = e.AddedItems.Count == 1;
            btnRemove.IsEnabled = e.AddedItems.Count == 1;
        }
    }
}

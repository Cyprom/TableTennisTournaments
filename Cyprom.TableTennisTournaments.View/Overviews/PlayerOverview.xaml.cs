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
    /// Interaction logic for PlayerOverview.xaml
    /// </summary>
    public partial class PlayerOverview : UserControl
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

        public PlayerOverview()
        {
            InitializeComponent();
        }

        public void SetPlayers(List<Player> players)
        {
            grdPlayers.ItemsSource = null;
            grdPlayers.ItemsSource = players;
        }

        private void CreatePlayer(object sender, RoutedEventArgs e)
        {
            var dialog = new PlayerCreationDialog();
            if (dialog.ShowDialog().GetValueOrDefault())
            {
                var tournamentDetails = this.FindParent<TournamentDetails>();
                if (tournamentDetails != null)
                {
                    dialog.Player.Tournament = tournamentDetails.Tournament;
                    SetPlayers(tournamentDetails.Tournament.Players);
                }
            }
        }

        private void ViewPlayer(object sender, RoutedEventArgs e)
        {
            var selection = grdPlayers.SelectedItem as Player;
            if (selection != null)
            {
                var detailView = new PlayerDetails();
                detailView.Initialize(selection.ID);
                MainWindow.LoadView(detailView);
            }
        }

        private void RemovePlayer(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("TODO: Implement remove player");
        }

        private void PlayerSelected(object sender, SelectionChangedEventArgs e)
        {
            btnView.IsEnabled = e.AddedItems.Count == 1;
            btnRemove.IsEnabled = e.AddedItems.Count == 1;
        }
    }
}

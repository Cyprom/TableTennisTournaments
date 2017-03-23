using Cyprom.TableTennisTournaments.Business;
using Cyprom.TableTennisTournaments.Model;
using Cyprom.TableTennisTournaments.Model.Enums;
using Cyprom.TableTennisTournaments.Model.Managers;
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

namespace Cyprom.TableTennisTournaments.View.Details
{
    /// <summary>
    /// Interaction logic for TournamentDetails.xaml
    /// </summary>
    public partial class TournamentDetails : UserControl
    {
        private Tournament _tournament;
        public Tournament Tournament
        {
            get
            {
                return _tournament;
            }
            private set {
                _tournament = value;
                txtName.Text = value.Name;
                cmbType.SelectedValue = (int)(value.Type);
                txtDate.Text = value.Date.ToString("dd/MM/yyyy HH:mm");
                txtTables.Text = value.AmountTables.ToString();
                chkPoolsRequired.IsChecked = value.PoolsRequired;
                txtMaxFinaleRounds.Text = value.MaxAmountFinaleRounds.ToString();
                UpdatePlayTypeView();
                if (value.Started)
                {
                    FinalizeTournamentView();
                }
            }
        }

        public TournamentDetails()
        {
            InitializeComponent();
            cmbType.ItemsSource = Enum.GetValues(typeof(PlayType)).Cast<PlayType>().ToDictionary(x => (int)x, x => x.ToString());
            cmbType.SelectedIndex = 0;
        }

        public void Initialize(Guid tournamentID)
        {
            Tournament = ModelManager.GetTournament(tournamentID);
        }

        private void StartTournament(object sender, RoutedEventArgs e)
        {
            if (_tournament.PlayingUnits.Count < 2)
            {
                MessageBox.Show("At least 2 players or teams are required to start a tournament!", "Not enough players or teams", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else
            {
                TournamentManager.StartTournament(Tournament);
                FinalizeTournamentView();
            }
        }

        private void ValidateNumericInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, e.Text.Length - 1))
            {
                e.Handled = true;
            }
        }

        private void TypeChanged(object sender, EventArgs e)
        {
            var newType = (PlayType)((KeyValuePair<int, string>)(cmbType.SelectedItem)).Key;
            if (newType != _tournament.Type)
            {
                var confirmation = MessageBox.Show("Are you sure you want to change the type? This will reset all registered players and teams!", "Change type", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (confirmation == MessageBoxResult.Yes)
                {
                    _tournament.Type = newType;
                    _tournament.PlayingUnits.Clear();
                }
                UpdatePlayTypeView();
            }
        }

        private void UpdatePlayTypeView() {
            cmbType.SelectedValue = (int)(_tournament.Type);
            switch (_tournament.Type)
            {
                case PlayType.Single:
                    tabTeams.Visibility = Visibility.Collapsed;
                    ovwTeams.SetTeams(_tournament.Teams);
                    ovwPlayers.SetPlayers(_tournament.Players);
                    tabPlayers.Visibility = Visibility.Visible;
                    break;
                case PlayType.Double:
                    tabPlayers.Visibility = Visibility.Collapsed;
                    ovwPlayers.SetPlayers(_tournament.Players);
                    ovwTeams.SetTeams(_tournament.Teams);
                    tabTeams.Visibility = Visibility.Visible;
                    break;
            }
        }

        private void FinalizeTournamentView()
        {
            // Make general details read-only
            txtName.IsReadOnly = true;
            cmbType.IsEnabled = false;
            txtTables.IsReadOnly = true;
            chkPoolsRequired.IsEnabled = false;
            txtMaxFinaleRounds.IsReadOnly = true;
            btnStart.IsEnabled = false;

            // Load and show all
            ovwTables.SetTables(_tournament.Tables);
            ovwPools.SetPools(_tournament.Pools);
            //ovwFinaleRounds.Refresh();
            ovwMatches.SetMatches(_tournament.Matches);
            tabTables.Visibility = Visibility.Visible;
            tabPools.Visibility = Visibility.Visible;
            tabFinaleRounds.Visibility = Visibility.Visible;
            tabMatches.Visibility = Visibility.Visible;
        }

    }
}

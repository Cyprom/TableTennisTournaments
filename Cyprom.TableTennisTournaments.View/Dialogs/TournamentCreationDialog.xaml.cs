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
using System.Windows.Shapes;

namespace Cyprom.TableTennisTournaments.View.Dialogs
{
    /// <summary>
    /// Interaction logic for TournamentCreationDialog.xaml
    /// </summary>
    public partial class TournamentCreationDialog : Window
    {
        private Tournament _tournament;
        public Tournament Tournament
        {
            get
            {
                return _tournament;
            }
        }

        public TournamentCreationDialog()
        {
            InitializeComponent();
            cmbType.ItemsSource = Enum.GetValues(typeof(PlayType)).Cast<PlayType>().ToDictionary(x => (int)x, x => x.ToString());
            cmbType.SelectedIndex = 0;
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Please enter a name for this tournament", "Name required", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                _tournament = ModelManager.CreateTournament(txtName.Text, false, DateTime.Now,
                    (PlayType)((KeyValuePair<int, string>)(cmbType.SelectedItem)).Key, int.Parse(txtTables.Text),
                    int.Parse(txtMaxFinaleRounds.Text), chkPoolsRequired.IsChecked.GetValueOrDefault());
                DialogResult = true;
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void ValidateNumericInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, e.Text.Length - 1))
            {
                e.Handled = true;
            }
        }
    }
}

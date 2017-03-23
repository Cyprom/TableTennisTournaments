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
    /// Interaction logic for TeamCreationDialog.xaml
    /// </summary>
    public partial class TeamCreationDialog : Window
    {
        private Team _team;
        public Team Team
        {
            get
            {
                return _team;
            }
        }

        public TeamCreationDialog()
        {
            InitializeComponent();
            cmbRanking1.ItemsSource = Enum.GetValues(typeof(Ranking)).Cast<Ranking>().ToDictionary(x => (int)x, x => x.ToString());
            cmbRanking2.ItemsSource = Enum.GetValues(typeof(Ranking)).Cast<Ranking>().ToDictionary(x => (int)x, x => x.ToString());
            cmbRanking1.SelectedIndex = 0;
            cmbRanking2.SelectedIndex = 0;
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName1.Text))
            {
                MessageBox.Show("Please enter a name for the first player", "Name required", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else if (string.IsNullOrWhiteSpace(txtName2.Text))
            {
                MessageBox.Show("Please enter a name for the second player", "Name required", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                _team = ModelManager.CreateTeam(txtName1.Text, (Ranking)((KeyValuePair<int, string>)(cmbRanking1.SelectedItem)).Key,
                    txtName2.Text, (Ranking)((KeyValuePair<int, string>)(cmbRanking2.SelectedItem)).Key);
                DialogResult = true;
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}

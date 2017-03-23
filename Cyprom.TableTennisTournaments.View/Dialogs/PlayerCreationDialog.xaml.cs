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
    /// Interaction logic for PlayerCreationDialog.xaml
    /// </summary>
    public partial class PlayerCreationDialog : Window
    {
        private Player _player;
        public Player Player
        {
            get
            {
                return _player;
            }
        }

        public PlayerCreationDialog()
        {
            InitializeComponent();
            cmbRanking.ItemsSource = Enum.GetValues(typeof(Ranking)).Cast<Ranking>().ToDictionary(x => (int)x, x => x.ToString());
            cmbRanking.SelectedIndex = 0;
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Please enter a name for this player", "Name required", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                _player = ModelManager.CreatePlayer(txtName.Text, (Ranking)((KeyValuePair<int, string>)(cmbRanking.SelectedItem)).Key);
                DialogResult = true;
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}

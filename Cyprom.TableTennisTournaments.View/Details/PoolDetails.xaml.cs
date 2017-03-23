using Cyprom.TableTennisTournaments.Model;
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
    /// Interaction logic for PoolDetails.xaml
    /// </summary>
    public partial class PoolDetails : UserControl
    {
        private Pool _pool;
        public Pool Pool
        {
            get
            {
                return _pool;
            }
            private set {
                _pool = value;
                txtLetter.Text = value.Letter.ToString();
                var players = value.Players;
                if (players.Any())
                {
                    ovwPlayers.SetPlayers(value.Players);
                    tabTeams.Visibility = Visibility.Visible;
                }
                else
                {
                    tabTeams.Visibility = Visibility.Collapsed;
                }
                var teams = value.Teams;
                if (teams.Any())
                {
                    ovwTeams.SetTeams(value.Teams);
                    tabTeams.Visibility = Visibility.Visible;
                }
                else
                {
                    tabTeams.Visibility = Visibility.Collapsed;
                }
                ovwMatches.SetMatches(value.Matches);
            }
        }

        public PoolDetails()
        {
            InitializeComponent();
        }

        public void Initialize(Guid poolID)
        {
            Pool = ModelManager.GetPool(poolID);
        }
    }
}

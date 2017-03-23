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
    /// Interaction logic for PlayerDetails.xaml
    /// </summary>
    public partial class PlayerDetails : UserControl
    {
        private Player _player;
        public Player Player
        {
            get
            {
                return _player;
            }
            private set {
                _player = value;
                txtName.Text = value.Name;
                txtRanking.Text = value.Ranking.ToString();
                ovwMatches.SetMatches(value.Matches);
            }
        }

        public PlayerDetails()
        {
            InitializeComponent();
        }

        public void Initialize(Guid playerID)
        {
            Player = (Player)ModelManager.GetPlayingUnit(playerID);
        }
    }
}

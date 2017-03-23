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
    /// Interaction logic for TeamDetails.xaml
    /// </summary>
    public partial class TeamDetails : UserControl
    {
        private Team _team;
        public Team Team
        {
            get
            {
                return _team;
            }
            private set {
                _team = value;
                txtName1.Text = value.Name1;
                txtRanking1.Text = value.Ranking1.ToString();
                txtName2.Text = value.Name2;
                txtRanking2.Text = value.Ranking2.ToString();
                ovwMatches.SetMatches(value.Matches);
            }
        }

        public TeamDetails()
        {
            InitializeComponent();
        }

        public void Initialize(Guid teamID)
        {
            Team = (Team)ModelManager.GetPlayingUnit(teamID);
        }
    }
}

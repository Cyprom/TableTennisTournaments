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
    /// Interaction logic for MatchDetails.xaml
    /// </summary>
    public partial class MatchDetails : UserControl
    {
        private Match _match;
        public Match Match
        {
            get
            {
                return _match;
            }
            private set {
                _match = value;
                txtSide1.Text = value.PlayingUnit1.FullName;
                txtSide2.Text = value.PlayingUnit2.FullName;
            }
        }

        public MatchDetails()
        {
            InitializeComponent();
        }

        public void Initialize(Guid matchID)
        {
            Match = ModelManager.GetMatch(matchID);
        }
    }
}

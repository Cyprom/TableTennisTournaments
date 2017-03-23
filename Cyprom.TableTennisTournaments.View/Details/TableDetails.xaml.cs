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
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Cyprom.TableTennisTournaments.View.Details
{
    /// <summary>
    /// Interaction logic for TableDetails.xaml
    /// </summary>
    public partial class TableDetails : UserControl
    {
        private Table _table;
        public Table Table
        {
            get
            {
                return _table;
            }
            private set {
                _table = value;
                txtNumber.Text = value.Number.ToString();
                ovwMatches.SetMatches(value.Matches);
            }
        }

        public TableDetails()
        {
            InitializeComponent();
        }

        public void Initialize(Guid tableID)
        {
            Table = ModelManager.GetTable(tableID);
        }
    }
}

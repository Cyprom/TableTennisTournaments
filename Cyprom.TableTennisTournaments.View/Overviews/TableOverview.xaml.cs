using Cyprom.TableTennisTournaments.Model;
using Cyprom.TableTennisTournaments.View.Details;
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

namespace Cyprom.TableTennisTournaments.View.Overviews
{
    /// <summary>
    /// Interaction logic for TableOverview.xaml
    /// </summary>
    public partial class TableOverview : UserControl
    {
        public TableOverview()
        {
            InitializeComponent();
        }

        public void SetTables(List<Table> tables)
        {
            grdTables.ItemsSource = null;
            grdTables.ItemsSource = tables;
        }

        private void ViewTable(object sender, RoutedEventArgs e)
        {
            var selection = grdTables.SelectedItem as Table;
            if (selection != null)
            {
                var detailView = new TableDetails();
                detailView.Initialize(selection.ID);
                MainWindow.LoadView(detailView);
            }
        }

        private void TableSelected(object sender, SelectionChangedEventArgs e)
        {
            btnView.IsEnabled = e.AddedItems.Count == 1;
        }

    }
}

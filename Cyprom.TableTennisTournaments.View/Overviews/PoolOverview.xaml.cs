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
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Cyprom.TableTennisTournaments.View.Overviews
{
    /// <summary>
    /// Interaction logic for PoolOverview.xaml
    /// </summary>
    public partial class PoolOverview : UserControl
    {
        public PoolOverview()
        {
            InitializeComponent();
        }

        public void SetPools(List<Pool> pools)
        {
            grdPools.ItemsSource = null;
            grdPools.ItemsSource = pools;
        }

        private void ViewPool(object sender, RoutedEventArgs e)
        {
            var selection = grdPools.SelectedItem as Pool;
            if (selection != null)
            {
                var detailView = new PoolDetails();
                detailView.Initialize(selection.ID);
                MainWindow.LoadView(detailView);
            }
        }

        private void PoolSelected(object sender, SelectionChangedEventArgs e)
        {
            btnView.IsEnabled = e.AddedItems.Count == 1;
        }
    }
}

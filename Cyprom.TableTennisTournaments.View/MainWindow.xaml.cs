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
using Cyprom.TableTennisTournaments.View.Overviews;

namespace Cyprom.TableTennisTournaments.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static MainWindow _instance;

        public MainWindow()
        {
            InitializeComponent();
            _instance = this;
        }

        public static void LoadView(UserControl view)
        {
            _instance.ucContent.Content = view;
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            LoadView(new TournamentOverview());
        }
    }
}

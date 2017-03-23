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

namespace Cyprom.TableTennisTournaments.View.Menu
{
    /// <summary>
    /// Interaction logic for MenuBar.xaml
    /// </summary>
    public partial class MenuBar : System.Windows.Controls.Menu
    {
        public MenuBar()
        {
            InitializeComponent();
        }

        private void Save(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("TODO: Implement save");
        }

        private void Load(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("TODO: Implement load");
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("TODO: Implement exit");
        }

        private void Language(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("TODO: Implement language");
        }

        private void Info(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("TODO: Implement info");
        }

        private void About(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("TODO: Implement about");
        }
    }
}

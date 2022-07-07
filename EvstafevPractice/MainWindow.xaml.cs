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

namespace EvstafevPractice
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MFrame.Navigate(new Tours());
            Admin.MFrame = MFrame;
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            Admin.MFrame.GoBack();
        }

        private void MFrame_ContentRendered(object sender, EventArgs e)
        {
            if (MFrame.CanGoBack) 
            {
                BtnBack.Visibility = Visibility.Visible;
            }
            else 
            {
                BtnBack.Visibility = Visibility.Hidden;
            }
        }

        private void HotelsBtn_Click(object sender, RoutedEventArgs e)
        {
            MFrame.Navigate(new HotelsPage());
        }
    }
}

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
    /// Логика взаимодействия для HotelsPage.xaml
    /// </summary>
    public partial class HotelsPage : Page
    {
        public HotelsPage()
        {
            InitializeComponent();
           
        }

        
        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {

            Admin.MFrame.Navigate(new AdminPage((sender as Button).DataContext as Hotel)); 
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            Admin.MFrame.Navigate(new AdminPage(null));
        }

        private void DltBtn_Click(object sender, RoutedEventArgs e)
        {
            var hotelsForRemoving = DGHotels.SelectedItems.Cast<Hotel>().ToList();
            if (MessageBox.Show($"Вы намерены удалить следующие {hotelsForRemoving.Count()} элементов?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    ToursEntities.GetContext().Hotel.RemoveRange(hotelsForRemoving);
                    ToursEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены");
                    DGHotels.ItemsSource = ToursEntities.GetContext().Hotel.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString()); 
                }
            }
        }
        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible) 
            {
                ToursEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                DGHotels.ItemsSource = ToursEntities.GetContext().Hotel.ToList();
            }
        }
    }
}

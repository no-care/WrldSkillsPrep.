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
    /// Логика взаимодействия для Tours.xaml
    /// </summary>
    public partial class Tours : Page
    {
        public Tours()
        {
            InitializeComponent();

            var allTypes = ToursEntities.GetContext().Type.ToList();
            allTypes.Insert(0, new Type
            {
                Name = "Все типы"
            });
            ComboType.ItemsSource = allTypes;

            Check.IsChecked = true;
            ComboType.SelectedIndex = 0;

            UpdateTour();
        }
        private void UpdateTour() 
        {
            var currentTours = ToursEntities.GetContext().Tour.ToList();

            if (ComboType.SelectedIndex > 0)
                currentTours = currentTours.Where(p => p.Type.Contains(ComboType.SelectedItem as Type)).ToList();

            currentTours = currentTours.Where(p => p.Name.ToLower().Contains(SearchBox.Text.ToLower())).ToList();

            if (Check.IsChecked.Value)
                currentTours = currentTours.Where(p => p.IsActual).ToList();
            LVTours.ItemsSource = currentTours.OrderBy(p => p.TicketCount).ToList();
        }

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateTour();
        }

        private void ComboType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateTour();
        }

        private void Check_Checked(object sender, RoutedEventArgs e)
        {
            UpdateTour();
        }

        private void Check_Unchecked(object sender, RoutedEventArgs e)
        {

        }
    }
}

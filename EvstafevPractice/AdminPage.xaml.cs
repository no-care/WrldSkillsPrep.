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
    /// Логика взаимодействия для AdminPage.xaml
    /// </summary>
    public partial class AdminPage : Page
    {
        private Hotel _currentHotel = new Hotel();
        public AdminPage(Hotel selectedHotel)
        {
            InitializeComponent();
            if (selectedHotel != null)
                _currentHotel = selectedHotel; 
            DataContext = _currentHotel;
            ComboCountries.ItemsSource = ToursEntities.GetContext().Country.ToList();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (String.IsNullOrWhiteSpace(_currentHotel.Name))
                errors.AppendLine("Название отеля не указана");
            if (_currentHotel.CountOfStars < 1 || _currentHotel.CountOfStars > 5)
                errors.AppendLine("Неверное кол-во звезд");
            if (_currentHotel.Country == null)
                errors.AppendLine("Страна не выбрана");

            if (errors.Length > 0) 
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (_currentHotel.Id == 0)
                ToursEntities.GetContext().Hotel.Add(_currentHotel);
            try
            {
                ToursEntities.GetContext().SaveChanges();
                MessageBox.Show("Данные успешно созранены");
                Admin.MFrame.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}

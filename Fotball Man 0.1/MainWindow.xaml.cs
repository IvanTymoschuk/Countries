using System;
using System.Collections.Generic;
using System.IO;
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

namespace Fotball_Man_0._1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        CountriesEntities store;
        List<Countries>ls;
        public MainWindow()
        {
            InitializeComponent();
     
          
            store = new CountriesEntities();
            ls= store.Countries.ToList();
            ls=ls.OrderBy(a => a.CountryName).ToList();
            foreach (var el in ls)
            {
                ListCountries.Items.Add(el.CountryName);
            }



        }

        private void ListCountries_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            tbCountName.Text = ls[ListCountries.SelectedIndex].CountryName;
            tbCapital.Text = ls[ListCountries.SelectedIndex].Capital;
            tbPopulation.Text =string.Format("{0:N0}", ls[ListCountries.SelectedIndex].Population);
            tbCurr.Text = ls[ListCountries.SelectedIndex].CurrencyCode;
            tbArea.Text = string.Format("{0:N0}", ls[ListCountries.SelectedIndex].AreaSqKm);

            string path = String.Format(@"C:\Users\Ivan\source\repos\Fotball Man 0.1\Fotball Man 0.1\Pictures\Flags\Big\" +
                                        ls[ListCountries.SelectedIndex].CountryCode.ToLower() + ".png");
            if (!File.Exists(path))
            {
                
                path = String.Format(@"C:\Users\Ivan\source\repos\Fotball Man 0.1\Fotball Man 0.1\Pictures\System\notfound.jpg");
            }
            imgFlag.Source = new BitmapImage(new Uri(path, UriKind.RelativeOrAbsolute));

        }
        private void Window_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            ((Window)sender).DragMove();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}


using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;

namespace kalapacs
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<Versenyzo> versenyzok = Versenyzo.Beolvasas("Selejtezo2012.txt");
        public MainWindow()
        {
            InitializeComponent();
            athleteComboBox.ItemsSource = versenyzok.Select(x => x.Nev);
            athleteComboBox.SelectedItem = "Pars Krisztián";
        }

        private void athleteComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            var kivalasztott = versenyzok[athleteComboBox.SelectedIndex];
            lblGroup.Content = kivalasztott.Csoport;
            lblCountry.Content = kivalasztott.CsakNemzet;
            lblCountryCode.Content = kivalasztott.Kód;
            lblOrder.Content = $"{kivalasztott.D1};{kivalasztott.D2};{kivalasztott.D3}";
            lblResult.Content = kivalasztott.Eredmény();

            imgKep.Source = new BitmapImage(new Uri("img/" + kivalasztott.Kód + ".png", UriKind.Relative));

        }
    }
}
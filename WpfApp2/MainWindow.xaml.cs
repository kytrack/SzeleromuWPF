using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<Szeleromu> list = new ObservableCollection<Szeleromu>();
        public MainWindow()
        {
            InitializeComponent();
            AdatokBetoltese();
        }
        public void AdatokBetoltese()
        {
            StreamReader sr = new StreamReader("szeleromu.txt");

            while (!sr.EndOfStream)
            {
                string[] adatok = sr.ReadLine().Split(";");
                list.Add(new Szeleromu(adatok[0],int.Parse(adatok[1]), int.Parse(adatok[2]), int.Parse(adatok[3])));
            }
            dgAdatok.ItemsSource = list;
            sr.Close();
        }

        private void btnSzeleromuvek_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(list.Count().ToString());
        }

        private void btnHelyszinekszama_Click(object sender, RoutedEventArgs e)
        {
            string hely = tbHelyszinnveve.Text;
            ObservableCollection<Szeleromu> listszukitett = new ObservableCollection<Szeleromu>();
            foreach (Szeleromu s in list)
            {
                if (s.Helyszin==hely)
                {
                    listszukitett.Add(s);
                    lbxAdatok.Items.Add(s.Egyseg+";"+s.Teljesitmeny);
                }
            }
            lbHelyszinekszama.Content = listszukitett.Count().ToString();
        }

        private void btn2010atlag_Click(object sender, RoutedEventArgs e)
        {
            double ossz = 0;
            double db = 0;
            foreach (Szeleromu s in list)
            {
                if (s.Evjarat==2010)
                {
                    ossz += s.Teljesitmeny;
                    db++;
                }
            }

            MessageBox.Show($"{Math.Round(ossz / db, 2)}W");
        }

        private void btnlegnagyobb_Click(object sender, RoutedEventArgs e)
        {
            Szeleromu max = list[0];
            foreach (var item in list)
            {
                if (item.Teljesitmeny>max.Teljesitmeny)
                {
                    max = item;
                }
            }
            MessageBox.Show(max.Helyszin+";"+max.Teljesitmeny+";"+max.Evjarat);
        }

        private void btnjelentes_Click(object sender, RoutedEventArgs e)
        {
            StreamWriter sw = new StreamWriter("jelentes.txt", append: true);
            foreach (var item in list)
            {
                sw.WriteLine(item.Helyszin+","+item.Egyseg + "," +item.Teljesitmeny + "," +item.Evjarat + "," +item.Kategorizalas());
            }        
            sw.Close();
        }
    }
}

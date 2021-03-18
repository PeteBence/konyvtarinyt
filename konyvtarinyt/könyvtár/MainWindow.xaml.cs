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
using System.IO;
using System.Xml.Serialization;
using Microsoft.Win32;


namespace konyvtarinyt
{

    public partial class MainWindow : Window
    {

        List<Adatok> a = new List<Adatok>();
        List<Adatok2> b = new List<Adatok2>();
        List<Adatok3> c = new List<Adatok3>();
        public MainWindow()
        {
            InitializeComponent();

        }
        class Adatok
        {
            public int id { get; set; }
            public string szerzo { get; set; }
            public string cim { get; set; }
            public string ev { get; set; }
            public string kiado { get; set; }
            public bool ig { get; set; }
            public Adatok(string sor)
            {
                string[] resz = sor.Split(';');
                id = Convert.ToInt32(resz[0]);
                szerzo = resz[1];
                cim = resz[2];
                ev = resz[3];
                kiado = resz[4];
                ig = Convert.ToBoolean(resz[5]);

            }
        }
        class Adatok2
        {
            public int olvasid { get; set; }
            public string nev { get; set; }
            public DateTime datum { get; set; }
            public int szam { get; set; }
            public string telepules { get; set; }
            public string utca { get; set; }
            public Adatok2(string sor)
            {
                string[] resz = sor.Split(';');
                olvasid = Convert.ToInt32(resz[0]);
                nev = resz[1];
                datum = Convert.ToDateTime(resz[2]);
                szam = Convert.ToInt32(resz[3]);
                telepules = resz[4];
                utca = resz[5];


            }
        }
        class Adatok3
        {
            public int kolcsonzesid { get; set; }
            public int olvasoid { get; set; }
            public int konyvid { get; set; }
            public DateTime kolcsonzesdatum { get; set; }
            public DateTime visszdatum { get; set; }

            public Adatok3(string sor)
            {
                string[] resz = sor.Split(';');
                kolcsonzesid = Convert.ToInt32(resz[0]);
                olvasoid = Convert.ToInt32(resz[1]);
                konyvid = Convert.ToInt32(resz[2]);
                kolcsonzesdatum = Convert.ToDateTime(resz[3]);



            }
        }
        private void Konyvek_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (var item in File.ReadAllLines("konyvek.txt"))
            {
                a.Add(new Adatok(item));
            }
            Konyv.ItemsSource = a;

            Konyv.AutoGenerateColumns = false;
        }

        private void Tagok_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (var item in File.ReadAllLines("tagok.txt"))
            {
                b.Add(new Adatok2(item));

                Tag.ItemsSource = b;
                Tag.AutoGenerateColumns = false;
            }
        }

        private void Kolcsonzes_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (var item in File.ReadAllLines("kolcsonzesek.txt"))
            {
                c.Add(new Adatok3(item));

                Kolcson.ItemsSource = c;
                Kolcson.AutoGenerateColumns = false;
            }
        }
    }
}  

 


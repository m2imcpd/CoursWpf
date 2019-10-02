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

namespace CoursWPF
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //Button b1 = new Button() { Content="t1"};
            //Content = b1;
            Grid g = new Grid();
            //Ligne avec une hauteur de 100 px
            //g.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(100) });
            //Ligne avec une hauteur de 2 * 
            g.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(2,GridUnitType.Star) });
            //Ligne avec une hauteur de 1 *
            g.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1, GridUnitType.Star) });
            //Column avec une largeur de 1 *
            g.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
            g.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });

            Button b = new Button() { Content = "mon bouton" };
            //Placer le bouton dans la ligne n° 1
            Grid.SetRow(b, 0);
            //Placer le bouton dans la column n° 2
            Grid.SetColumn(b, 1);
            g.Children.Add(b);
            Content = g;
        }
    }
}

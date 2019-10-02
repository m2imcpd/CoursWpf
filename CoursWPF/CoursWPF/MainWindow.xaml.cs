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
            //Grid g = new Grid();
            ////Ligne avec une hauteur de 100 px
            ////g.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(100) });
            ////Ligne avec une hauteur de 2 * 
            //g.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(2,GridUnitType.Star) });
            ////Ligne avec une hauteur de 1 *
            //g.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1, GridUnitType.Star) });
            ////Column avec une largeur de 1 *
            //g.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
            //g.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });

            //Button b = new Button() { Content = "mon bouton" };
            ////Placer le bouton dans la ligne n° 1
            //Grid.SetRow(b, 0);
            ////Placer le bouton dans la column n° 2
            //Grid.SetColumn(b, 1);
            //g.Children.Add(b);
            //Content = g;
            b1.Content = "Coucou";
            Button b2 = new Button() { Content = "B2" };
            Grid.SetRow(b2, 0);
            Grid.SetColumn(b2, 1);
            maGrille.Children.Add(b2);
            b2.Click += Methode_Click;
            b2.Click += (s, e) =>
            {
                
                MessageBox.Show((s as Button).Content.ToString());
                Grid.SetColumn((s as Button), 0);
            };
        }

        //Methode abonnée à l'event click du bouton B1
        private void Methode_Click(object sender, RoutedEventArgs e)
        {
            //if(sender.GetType() == typeof(Button))
            //<=>
            if(sender is Button)
            {
                l1.Content = l1.Content.ToString() + (sender as Button).Content;
                (sender as Button).Content = "coucou2";

            }
                
            //b1.Content = "Coucou2";
        }
    }
}

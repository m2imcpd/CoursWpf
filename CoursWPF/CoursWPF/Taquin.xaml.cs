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
using System.Windows.Shapes;

namespace CoursWPF
{
    /// <summary>
    /// Logique d'interaction pour Taquin.xaml
    /// </summary>
    public partial class Taquin : Window
    {
        private Button bStart;
        private Label labelCpt;
        private char[] tabChar = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H' };
        public Taquin()
        {
            InitializeComponent();
            CreateRowAndColumn();
            CreateHeader();
        }

        private void CreateRowAndColumn()
        {
            for(int i=0; i <= 3; i++)
            {
                maGrille.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
                if (i < 3)
                    maGrille.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            }
        }

        private void CreateHeader()
        {
            bStart = new Button() { Content = "Start" };
            bStart.Click += CreateButton;
            Grid.SetColumn(bStart, 0);
            Grid.SetRow(bStart, 0);
            Grid.SetColumnSpan(bStart, 2);
            maGrille.Children.Add(bStart);
            labelCpt = new Label { Content = "0", VerticalAlignment = VerticalAlignment.Center, HorizontalAlignment= HorizontalAlignment.Center };
            Grid.SetColumn(labelCpt, 2);
            Grid.SetRow(labelCpt, 0);
            maGrille.Children.Add(labelCpt);
        }

        private void CreateButton(object sender, RoutedEventArgs e)
        {
            Shuffle(tabChar);
            int k = 0;
            for(int i= 1; i < 4; i++)
            {
                for(int j=0; j < 3; j++)
                {
                    if(k < 8)
                    {
                        Button b = new Button { Content = tabChar[k] };
                        Grid.SetRow(b, i);
                        Grid.SetColumn(b, j);
                        maGrille.Children.Add(b);
                        k++;
                    }
                    
                }
            }
        }

        private void Shuffle(char[] tab)
        {
            Random r = new Random();
            for(int i = 0; i < tab.Length; i++)
            {
                int aleatoire = r.Next(tab.Length);
                char tmp = tab[aleatoire];
                tab[aleatoire] = tab[i];
                tab[i] = tmp;
            }
        }
    }
}

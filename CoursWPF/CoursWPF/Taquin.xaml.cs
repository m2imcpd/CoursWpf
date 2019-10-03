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
            //supprimer les anciens boutons
            //List<UIElement> listeASupprimer = new List<UIElement>();
            //foreach(UIElement element in maGrille.Children)
            //{
            //    if(Grid.GetRow(element) > 0)
            //    {
            //        listeASupprimer.Add(element);
            //    }
            //}
            //listeASupprimer.ForEach(el =>
            //{
            //    maGrille.Children.Remove(el);
            //});
            maGrille.Children.Cast<UIElement>().Where(x=> Grid.GetRow(x) > 0).ToList().ForEach(x=>maGrille.Children.Remove(x));
            Shuffle(tabChar);
            int k = 0;
            for(int i= 1; i < 4; i++)
            {
                for(int j=0; j < 3; j++)
                {
                    if(k < 8)
                    {
                        Button b = new Button { Content = tabChar[k] };
                        b.Click += Click_bouton;
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

        private void Click_bouton(object sender, RoutedEventArgs e)
        {
            if(sender is Button)
            {
                Button b = (sender as Button);
                int x = Grid.GetRow(b);
                int y = Grid.GetColumn(b);
                if(Test_Deplacement(x+1, y) && x < 3)
                {
                    Grid.SetRow(b, x + 1);
                }
                else if(Test_Deplacement(x-1, y) && x > 1)
                {
                    Grid.SetRow(b, x - 1);
                }
                else if(Test_Deplacement(x, y+1) && y < 2)
                {
                    Grid.SetColumn(b, y + 1);
                }
                else if (Test_Deplacement(x, y - 1) && y > 0)
                {
                    Grid.SetColumn(b, y - 1);
                }
                labelCpt.Content = Convert.ToInt32(labelCpt.Content.ToString()) + 1;
                if(Win())
                {
                    MessageBox.Show("Bravo");
                }
            }
        }

        private bool Test_Deplacement(int x, int y)
        {
            //Return true si elementTrouve est null
            //UIElement elementTrouve = null;
            //foreach(UIElement element in maGrille.Children)
            //{
            //    if(Grid.GetRow(element) == x && Grid.GetColumn(element) == y)
            //    {
            //        elementTrouve = element;
            //        break;
            //    }
            //}
            //return elementTrouve == null;
            //<=>
            return maGrille.Children.Cast<UIElement>().FirstOrDefault(e => (Grid.GetColumn(e) == y && Grid.GetRow(e) == x)) == null;
        }

        private bool Win()
        {
            string chaineW = "ABCDEFGH#";
            string chaine = "";
            for(int i=1; i < 4; i++)
            {
                for(int j=0; j < 3; j++)
                {
                    UIElement b = maGrille.Children.Cast<UIElement>().FirstOrDefault(e => (Grid.GetColumn(e) == j && Grid.GetRow(e) == i));
                    if(b == null)
                    {
                        chaine += "#";
                    }
                    else
                    {
                        chaine += (b as Button).Content.ToString();
                    }
                }
            }
            return chaine == chaineW;
        }
    }
}

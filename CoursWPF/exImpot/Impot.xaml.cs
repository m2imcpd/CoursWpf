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

namespace exImpot
{
    /// <summary>
    /// Logique d'interaction pour Impot.xaml
    /// </summary>
    public partial class Impot : Window
    {
        TextBox tSalaire;
        TextBox tNbEnfants;
        Label lSalaire;
        Label lNbEnfant;
        Label lMarie;
        RadioButton rOui;
        RadioButton rNon;
        Button bCalculer;
        public Impot()
        {
            InitializeComponent();
            maGrille.CreateRowsAddColumn(4,2);
            CreateImpotForms();
        }

        private void CreateImpotForms()
        {
            tSalaire = new TextBox();
            Grid.SetColumn(tSalaire, 1);
            Grid.SetRow(tSalaire, 0);
            lSalaire = new Label { Content = "Votre salaire" };
            Grid.SetColumn(lSalaire, 0);
            Grid.SetRow(lSalaire, 0);
            tNbEnfants = new TextBox();
            Grid.SetColumn(tNbEnfants, 1);
            Grid.SetRow(tNbEnfants, 1);
            lNbEnfant= new Label { Content = "nb Enfants" };
            Grid.SetColumn(lNbEnfant, 0);
            Grid.SetRow(lNbEnfant, 1);
            lMarie = new Label { Content = "Marie ?" };
            Grid.SetColumn(lMarie, 0);
            Grid.SetRow(lMarie, 2);
            rOui = new RadioButton { Content = "Oui", HorizontalAlignment = HorizontalAlignment.Left };
            Grid.SetColumn(rOui, 1);
            Grid.SetRow(rOui, 2);
            rNon = new RadioButton { Content = "Non", HorizontalAlignment = HorizontalAlignment.Right };
            Grid.SetColumn(rNon, 1);
            Grid.SetRow(rNon, 2);
            bCalculer = new Button { Content = "Calculer Impot" };
            bCalculer.Click += CalculerImpot;
            Grid.SetColumn(bCalculer, 0);
            Grid.SetRow(bCalculer, 3);
            Grid.SetColumnSpan(bCalculer, 2);
            maGrille.Children.Add(tSalaire);
            maGrille.Children.Add(tNbEnfants);
            maGrille.Children.Add(lSalaire);
            maGrille.Children.Add(lNbEnfant);
            maGrille.Children.Add(lMarie);
            maGrille.Children.Add(rOui);
            maGrille.Children.Add(rNon);
            maGrille.Children.Add(bCalculer);
        }

        private void CalculerImpot(object sender , RoutedEventArgs e)
        {
            float part = (rOui.IsChecked == true) ? 2 : 1;
            int nbEnfants;
            Int32.TryParse(tNbEnfants.Text, out nbEnfants);
            if(nbEnfants < 3)
            {
                part += nbEnfants * 0.5F;
            }
            else
            {
                part += nbEnfants - 1;
            }
            double salaire;
            Double.TryParse(tSalaire.Text, out salaire);
            double imposable = salaire * .9;
            double impot = 0;
            if (imposable <= 9964)
            {
                impot = 0;
            }
            else if (imposable > 9964 && imposable <= 27519)
            {
                impot = (imposable * 0.14) - (1394.96 * part);
            }
            else if (imposable > 27519 && imposable <= 73779)
            {
                impot = (imposable * 0.30) - (5798 * part);
            }
            else if (imposable > 73779 && imposable <= 156244)
            {
                impot = (imposable * 0.41) - (13913.69 * part);
            }
            else
            {
                impot = (imposable * 0.45) - (20163.45 * part);
            }
            if (impot < 0)
            {
                impot = 0;
            }

            MessageBox.Show($"Votre Impot est de {impot} €");
        }



    }
}

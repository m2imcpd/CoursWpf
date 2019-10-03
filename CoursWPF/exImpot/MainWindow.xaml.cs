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

namespace exImpot
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double salaire;
        int Enfants;
        float part = 1;
        bool marie = false;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Calcul_Click(object sender, RoutedEventArgs e)
        {
            salaire = Convert.ToDouble(salaireN.Text);
            Enfants = Convert.ToInt32(NbEnfants.Text);
            if (Enfants < 3)
            {
                part+= Enfants*.5F;
            }
            else
            {
                part += Enfants - 1;
            }
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
            result.Text = impot.ToString();
        }

        private void ROui_Checked(object sender, RoutedEventArgs e)
        {
            marie = true;
            if (marie)
            {
                part = 2;
            }
        }

        private void RNon_Checked(object sender, RoutedEventArgs e)
        {
            marie = false;
            if (marie)
            {
                part = 1;
            }
        }
    }
}

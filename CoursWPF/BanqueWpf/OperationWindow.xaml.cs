using BanqueWpf.Classes;
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

namespace BanqueWpf
{
    /// <summary>
    /// Logique d'interaction pour OperationWindow.xaml
    /// </summary>
    public partial class OperationWindow : Window
    {
        private Compte compte; 
        public OperationWindow()
        {
            InitializeComponent();
        }

        public OperationWindow(Compte c) : this()
        {
            compte = c;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            decimal montant;
            Decimal.TryParse(tMontant.Text, out montant);
            montant = ((bool)rType.IsChecked) ? Math.Abs(montant) * -1 : Math.Abs(montant);
            if((bool)rType.IsChecked)
            {
                if (compte.Solde >= Math.Abs(montant))
                {
                    DataBase.Instance.AddOperation(montant, compte.Id);
                    compte.Solde += montant;
                }
                else
                    MessageBox.Show("Pas d'argent");
            }
            else
            {
                DataBase.Instance.AddOperation(montant, compte.Id);
                compte.Solde += montant;
            }
            MessageBox.Show("Nouveau solde : "+compte.Solde);
        }
    }
}

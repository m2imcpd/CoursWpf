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
    /// Logique d'interaction pour ListeOperationsWindow.xaml
    /// </summary>
    public partial class ListeOperationsWindow : Window
    {
        private Compte compte;
        public ListeOperationsWindow()
        {
            InitializeComponent();
        }

        public ListeOperationsWindow(Compte c) : this()
        {
            compte = c;
            listeOperationsView.ItemsSource = DataBase.Instance.GetOperationsByCompte(compte.Id);
        }
    }
}

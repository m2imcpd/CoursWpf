using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using GestionRendezVousHopital.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace GestionRendezVousHopital.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public ICommand GMedecinCommand { get; set; }
        public ICommand GPatientCommand { get; set; }
        public ICommand GRdvCommand { get; set; }
        public ICommand CToutCommand { get; set; }
        public ICommand CParDateCommand { get; set; }
        public ICommand CParClientCommand { get; set; }

        public MainWindowViewModel()
        {
           
            GMedecinCommand = new RelayCommand(() =>
            {
                GestionMedecinWindow w = new GestionMedecinWindow();
                w.Show();
            });
            GPatientCommand = new RelayCommand(() =>
            {
                GestionPatientWindow w = new GestionPatientWindow();
                w.Show();
            });
            GRdvCommand = new RelayCommand(() =>
            {
                GestionRendezVousWindow w = new GestionRendezVousWindow();
                w.Show();
            });
            CToutCommand = new RelayCommand(() =>
            {
                CToutWindow w = new CToutWindow();
                w.Show();
            });
            CParDateCommand = new RelayCommand(() =>
            {
                CParDateWindow w = new CParDateWindow();
                w.Show();
            });
            CParClientCommand = new RelayCommand(() =>
            {
                CParClientWindow w = new CParClientWindow();
                w.Show();
            });

        }
    }
}

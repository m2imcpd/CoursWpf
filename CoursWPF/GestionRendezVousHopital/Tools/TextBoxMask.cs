using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace GestionRendezVousHopital.Tools
{
    public class TextBoxMask : TextBox
    {

        public static DependencyProperty NombreMaskProperty = DependencyProperty.Register("NbNombreMask", typeof(int), typeof(TextBoxMask));
        public int NbNombreMask { get => (int)base.GetValue(NombreMaskProperty); set => base.SetValue(NombreMaskProperty, value); }
        public TextBoxMask() : base()
        {
            DataContext = new Binding("Telephone");
            Text = "";
            for (int i = 1; i <= 10; i++)
            {
                Text += " * ";
            }
            GotFocus += (sender, e) =>
            {
                Text = "";
                
            };
        }
    }
}

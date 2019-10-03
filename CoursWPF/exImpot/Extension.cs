using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace exImpot
{
    static class Extension
    {
        public static void CreateRowsAddColumn(this Grid grille, int nbLigne, int nbColumn)
        {
            for (int i = 0; i < nbLigne; i++)
            {
                grille.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            }
            for (int i = 0; i < nbColumn; i++)
            {
                grille.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            }
        }
    }
}

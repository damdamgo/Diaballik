using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using Diaballik;

namespace DiaballikGame.Utils
{
    /// <summary>
    /// Permet de convertir le nombre de mouvement d'un joueur en visiblite si >=1 et < 3
    /// </summary>
    /// <seealso cref="System.Windows.Data.IValueConverter" />
    class ConvertPlayerToVisible : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((int)value) >=1 && ((int)value) <3 ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

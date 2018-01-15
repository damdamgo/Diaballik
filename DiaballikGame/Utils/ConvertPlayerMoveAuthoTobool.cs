using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace DiaballikGame.Utils
{
    /// <summary>
    /// Permet de convertir nombre de mouvement d'un joueur en bool
    /// </summary>
    public class ConvertPlayerMoveAuthoTobool : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((int)value) >= 1 && ((int)value) < 3 ? true : false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

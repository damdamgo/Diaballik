using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using Diaballik;
using System.Windows;

namespace DiaballikGame.Utils
{
    /// <summary>
    /// Permet de convertir une présence de balle en visibilite
    /// </summary>
    /// <seealso cref="System.Windows.Data.IValueConverter" />
    class ConvertElementBallToVisible : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Piece p = ((Piece)value);
            return p != null && p.hasBall() ? Visibility.Visible : Visibility.Collapsed;
            
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

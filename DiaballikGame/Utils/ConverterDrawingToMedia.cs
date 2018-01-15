using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

using MColor = System.Windows.Media.Color;
using DColor = System.Drawing.Color;
using System.Windows.Media;

namespace DiaballikGame.Utils
{
    /// <summary>
    /// Permet de convertir une couleur drawing en media
    /// </summary>
    /// <seealso cref="System.Windows.Data.IValueConverter" />
    class ConverterDrawingToMedia : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return new SolidColorBrush(MColor.FromArgb(((DColor)value).A, ((DColor)value).R, ((DColor)value).G, ((DColor)value).B));
        }


        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DColor.FromArgb(((MColor)value).A, ((MColor)value).R, ((MColor)value).G, ((MColor)value).B);
        }
    }
}
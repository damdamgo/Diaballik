using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using Diaballik.DataManager;

namespace DiaballikGame.Utils
{
    /// <summary>
    /// Permet de convertir un statut de jeu en action
    /// </summary>
    /// <seealso cref="System.Windows.Data.IValueConverter" />
    class ConverterGameStatusToAction : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            String text;
            switch ((GameModelDB.GameStatus)value)
            {
                case GameModelDB.GameStatus.STARTING:
                    text = "Start";
                    break;
                case GameModelDB.GameStatus.FINISHED:
                    text = "Replay";
                    break;
                default:
                    text = "Resume";
                    break;
            }
            return text;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

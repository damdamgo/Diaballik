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
    /// Permet de convertir statut du jeu en information
    /// </summary>
    /// <seealso cref="System.Windows.Data.IValueConverter" />
    class ConverterGameStatusToString : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
           String text;
            switch ((GameModelDB.GameStatus)value)
            {
                case GameModelDB.GameStatus.STARTING:
                    text = "To start";
                    break;
                case GameModelDB.GameStatus.TURNPLAYER1:
                    text = "Player1 turn";
                    break;
                case GameModelDB.GameStatus.TURNPLAYER2:
                    text = "Player2 turn";
                    break;
                default:
                    text = "Finished";
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

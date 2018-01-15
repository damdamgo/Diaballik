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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Diaballik;
using DiaballikGame.Welcome;

namespace DiaballikGame.Game
{
    /// <summary>
    /// Logique d'interaction pour GameManager.xaml
    /// </summary>
    public partial class GameManager : UserControl
    {
        /// <summary>
        /// Constructeur <see cref="GameManager"/> class.
        /// </summary>
        /// <param name="game">Modele du jeu</param>
        /// <param name="mI">Acces à la fenetre</param>
        public GameManager(Diaballik.Game game,MainInterface mI)
        {
            InitializeComponent();
            DataContext = new GameManagerModel(game,mI);
        }


    }
}

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
using MaterialDesignThemes.Wpf;

namespace DiaballikGame.Winner
{
    /// <summary>
    /// Logique d'interaction pour Winner.xaml
    /// </summary>
    public partial class Winner : UserControl
    {
        /// <summary>
        /// Modele de la vue
        /// </summary>
        private ModelWinner mW;

        /// <summary>
        /// Constructeur <see cref="Winner"/> class.
        /// </summary>
        /// <param name="mI">Accès à la fenetre principale</param>
        /// <param name="winnerGame">Joueur gagnant</param>
        /// <param name="IDDB">Id de la partie</param>
        public Winner(MainInterface mI, Player winnerGame,int IDDB)
        {
            mW = new ModelWinner(mI, IDDB);
            DataContext = mW;
            InitializeComponent();
            playerWin.Text = winnerGame.Name;
        }

        /// <summary>
        /// permet de fixer l'instance pour fermer le dialog
        /// </summary>
        public void close(DialogOpenedEventArgs close)
        {
            mW.setCloseCommand(close);
        }
    }
}

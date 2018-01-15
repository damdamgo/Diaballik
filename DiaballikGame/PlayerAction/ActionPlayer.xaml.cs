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

namespace DiaballikGame.PlayerAction
{
    /// <summary>
    /// Logique d'interaction pour ActionPlayer.xaml
    /// </summary>
    public partial class ActionPlayer : UserControl
    {
        /// <summary>
        /// Modele
        /// </summary>
        private PlayerActionModel playerM;

        /// <summary>
        /// Constructeur <see cref="ActionPlayer"/> class.
        /// </summary>
        /// <param name="player">Joueur</param>
        public ActionPlayer(Player player)
        {
            InitializeComponent();
            playerM = new PlayerActionModel(player);
            DataContext = playerM;
            configureLabelButton(player);
        }

        /// <summary>
        /// Configuration de la vue
        /// </summary>
        /// <param name="player">Joueur</param>
        public void configureLabelButton(Player player)
        {
            NamePlayer.Content = player.Name;
            NamePlayer.Foreground = new SolidColorBrush(Color.FromArgb(player.Color.A, player.Color.R, player.Color.G, player.Color.B));
            if (player.getType() != Player.PLAYER_TYPE.HUMAN) EndTurnView.Visibility = Visibility.Collapsed;
        }

        /// <summary>
        /// Event bouton tour suivant
        /// </summary>
        private void EndTurn_Click(object sender, RoutedEventArgs e)
        {
            playerM.endTurn();
        }
    }
}

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
using DiaballikGame.Welcome;
using Diaballik.Replay;

namespace DiaballikGame.Replay
{
    /// <summary>
    /// Logique d'interaction pour Replay.xaml
    /// </summary>
    public partial class Replay : UserControl
    {
        /// <summary>
        /// Constructeur <see cref="Replay"/> class.
        /// </summary>
        /// <param name="mI">Accès à la fenetre principale.</param>
        /// <param name="replayM">Modele du replay</param>
        /// <param name="replayType">Type de replay</param>
        public Replay(MainInterface mI,ReplayManager replayM, ReplayModel.TYPE_REPLAY replayType = ReplayModel.TYPE_REPLAY.REPLAY_FROM_FINISHED_GAME)
        {
            InitializeComponent();
            DataContext = new ReplayModel(mI, replayM);
            player1.Text = replayM.P1.Name;
            player1.Foreground = new SolidColorBrush(Color.FromArgb(replayM.P1.Color.A, replayM.P1.Color.R, replayM.P1.Color.G, replayM.P1.Color.B));
            player2.Text = replayM.P2.Name;
            player2.Foreground = new SolidColorBrush(Color.FromArgb(replayM.P2.Color.A, replayM.P2.Color.R, replayM.P2.Color.G, replayM.P2.Color.B));

            if (replayType == ReplayModel.TYPE_REPLAY.REPLAY_FROM_FINISHED_GAME)
            {
                this.resumeGameButton.Visibility = Visibility.Hidden;
            }
        }
    }
}

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
    /// Logique d'interaction pour MainReplayView.xaml
    /// </summary>
    public partial class MainReplayView : UserControl
    {
        /// <summary>
        /// Constructeur <see cref="MainReplayView"/> class.
        /// </summary>
        /// <param name="mI">Acces à la fenetre principale</param>
        /// <param name="replayM">Modele du replay</param>
        /// <param name="replayType">Type du replay</param>
        public MainReplayView(MainInterface mI, ReplayManager replayM, ReplayModel.TYPE_REPLAY replayType = ReplayModel.TYPE_REPLAY.REPLAY_FROM_FINISHED_GAME)
        {
            InitializeComponent();
            DataContext = new MainReplayViewModel(mI, replayM, replayType);
        }
 
    }
}

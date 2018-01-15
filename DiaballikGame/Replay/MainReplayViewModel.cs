using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiaballikGame.Utils;
using DiaballikGame.Welcome;
using Diaballik.Replay;

namespace DiaballikGame.Replay
{
    /// <summary>
    /// Modele de la vue MainReplayViewModel
    /// </summary>
    /// <seealso cref="DiaballikGame.Utils.ViewModelBase" />
    class MainReplayViewModel : ViewModelBase
    {
        /// <summary>
        /// Vue de l'interface replay
        /// </summary>
        private object boardView, replayManager;

        /// <summary>
        /// Constructeur <see cref="MainReplayViewModel"/> class.
        /// </summary>
        /// <param name="mI">Acces à la fenetre principale</param>
        /// <param name="replayM">Modele du replay</param>
        /// <param name="replayType">Type de replay </param>
        public MainReplayViewModel(MainInterface mI, ReplayManager replayM,ReplayModel.TYPE_REPLAY replayType = ReplayModel.TYPE_REPLAY.REPLAY_FROM_FINISHED_GAME)
        {
            replayManager = new Replay(mI, replayM, replayType);
            boardView = new DiaballikGame.Board.Board(replayM.Board,null);
        }

        /// <summary>
        /// Vues de l'interface du replay
        /// </summary>
        public object BoardView
        {
            get
            {
                return this.boardView;
            }
        }

        public object ReplayManager
        {
            get
            {
                return this.replayManager;
            }
        }



    }
}

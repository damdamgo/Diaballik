using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using DiaballikGame.Utils;
using DiaballikGame.Welcome;
using Diaballik.Replay;
using System.Threading;
using System.Windows;

namespace DiaballikGame.Replay
{
    /// <summary>
    /// Modele de la vue Replay
    /// </summary>
    /// <seealso cref="DiaballikGame.Utils.ViewModelBase" />
    public class ReplayModel : ViewModelBase
    {
        /// <summary>
        /// Type de replay pour configurer l'interface
        /// </summary>
        public enum TYPE_REPLAY { REPLAY_FROM_FINISHED_GAME,REPLAY_FROM_CURRENT_GAME};
        /// <summary>
        /// Commandes des boutons
        /// </summary>
        private ICommand nextMove,backMove,playReplay, stopReplay,resumeGame;
        /// <summary>
        /// interface de la Fenetre principale 
        /// </summary>
        private MainInterface mI;
        /// <summary>
        /// Modele du replay
        /// </summary>
        private ReplayManager replayM;
        /// <summary>
        /// Thread pour le replay automatic
        /// </summary>
        private Thread replayAuto= null;
        /// <summary>
        /// Semaphore pour la protection d'accès aux données
        /// </summary>
        private Semaphore action = new Semaphore(1, 1);
        /// <summary>
        /// Replay visibilite bouton stop
        /// </summary>
        private Visibility accessStop = Visibility.Hidden;
        /// <summary>
        /// Replay visibilite bouton start
        /// </summary>
        private Visibility accessStart = Visibility.Hidden;

        /// <summary>
        /// Constructeur <see cref="ReplayModel" /> class.
        /// </summary>
        /// <param name="mI">Accès à la fenetre principale</param>
        /// <param name="replayM">Modele du replay</param>
        public ReplayModel(MainInterface mI,Diaballik.Replay.ReplayManager replayM)
        {
            this.mI = mI;
            this.replayM = replayM;
            AccessStop = Visibility.Collapsed;
            AccessStart = Visibility.Visible;
        }

        /*
         * 
         * 
         * Commandes pour le replay
         * 
         * 
         * 
        */
        
        public ICommand NextMove
        {
            get
            {
                return nextMove ?? (nextMove = new RelayCommand(nextMoveAction));
            }
        }

        public ICommand BackMove
        {
            get
            {
                return backMove ?? (backMove = new RelayCommand(backMoveAction));
            }
        }

        public ICommand PlayReplay
        {
            get
            {
                return playReplay ?? (playReplay = new RelayCommand(playReplayAction));
            }
        }

        public ICommand StopReplay
        {
            get
            {
                return stopReplay ?? (stopReplay = new RelayCommand(stopReplayAction));
            }
        }

        public ICommand ResumeGame
        {
            get
            {
                return resumeGame ?? (resumeGame = new RelayCommand(resumeGameAction));
            }
        }

        /// <summary>
        /// Reprendre le jeu
        /// </summary>
        public void resumeGameAction()
        {
            mI.resumeGameFromReplay();
        }

        /// <summary>
        /// Passer au mouvement suivant
        /// </summary>
        public void nextMoveAction()
        {
            nextMoveActionGlobal();
        }

        /// <summary>
        /// Passer au mouvement suivant
        /// </summary>
        /// <returns>bool : vrai si un mouvement a été réalisé</returns>
        public bool nextMoveActionGlobal()
        {
            bool ret = false;
            action.WaitOne();
            ret = replayM.nextTurn();
            action.Release(1);
            return ret;
        }

        /// <summary>
        /// Retourner au mouvement precedent
        /// </summary>
        public void backMoveAction ()
        {
            action.WaitOne();
            replayM.backTurn();
            action.Release(1);
        }

        /// <summary>
        /// Commencer le replay automatique
        /// </summary>
        public void playReplayAction()
        {
            replayAuto = new Thread(ReplayAuto);
            replayAuto.Start();
            AccessStop = Visibility.Visible;
            AccessStart = Visibility.Collapsed;
        }

        /// <summary>
        /// Arreter le replay automatique
        /// </summary>
        public void stopReplayAction()
        {
            if (replayAuto != null)
            {
                replayAuto.Abort();
                replayAuto = null;
                AccessStop = Visibility.Collapsed;
                AccessStart = Visibility.Visible;
            }
        }

        /// <summary>
        /// replay automatique
        /// </summary>
        private void ReplayAuto()
        {
            while (nextMoveActionGlobal())
            {
                Thread.Sleep(2000);
            }
        }


        public Visibility AccessStop
        {
            get
            {
                return this.accessStop;
            }
            set
            {
                this.accessStop = value;
                RaisePropertyChanged("AccessStop");
            }
        }

        public Visibility AccessStart
        {
            get
            {
                return this.accessStart;
            }
            set
            {
                this.accessStart = value;
                RaisePropertyChanged("AccessStart");
            }
        }
    }
}

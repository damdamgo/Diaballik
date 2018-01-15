using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiaballikGame.Utils;
using System.Windows.Input;
using DiaballikGame.Game;
using DiaballikGame.MenuDiaballik;
using Diaballik;
using DiaballikGame.Replay;
using Diaballik.Replay;
using MaterialDesignThemes.Wpf;

namespace DiaballikGame.Welcome
{
    /// <summary>
    /// Modele de la vue Welcome
    /// </summary>
    /// <seealso cref="DiaballikGame.Utils.ViewModelBase" />
    /// <seealso cref="DiaballikGame.Welcome.MainInterface" />
    /// <seealso cref="Diaballik.ObserverEndGame" />
    class WelcomeModel : ViewModelBase, MainInterface, Diaballik.ObserverEndGame
    {
        /// <summary>
        /// Observer de l'etat de la fenetre
        /// </summary>
        private List<GameStateObserver> observerState = new List<GameStateObserver>();
        /// <summary>
        /// Vue courante
        /// </summary>
        private object _currentView;
        /// <summary>
        /// vue du menu
        /// </summary>
        private object _menuView;
        /// <summary>
        /// The current game
        /// </summary>
        private Diaballik.Game currentGame = null;
        /// <summary>
        /// Controleur
        /// </summary>
        private Welcome controlor;

        /// <summary>
        /// Constructeur <see cref="WelcomeModel"/> class.
        /// </summary>
        /// <param name="welcome">Controleur</param>
        public WelcomeModel(Welcome welcome)
        {
            controlor = welcome;
            _currentView = new ChoiceGameView(this);
            _menuView = new MenuDiaballik.MenuDiaballik(this);
            observerState.Add(((MenuDiaballik.MenuDiaballik)_menuView));
            notifyObserState(Utils.Properties.STATE_GAME.MENU);
        }

        /// <summary>
        /// <see cref="DiaballikGame.Welcome.MainInterface"/>
        /// </summary>
        public void changeMainView(ICommand command)
        {
            command.Execute(this);
            notifyObserState(Utils.Properties.STATE_GAME.GAME);
        }

        /// <summary>
        /// <see cref="DiaballikGame.Welcome.MainInterface"/>
        /// </summary>
        public void createGame(Diaballik.Game game)
        {
            setCurrentGame(game);
        }

        /// <summary>
        /// Fixer la partie courante
        /// </summary>
        /// <param name="game">Modele du jeu</param>
        public void setCurrentGame(Diaballik.Game game)
        {
            currentGame = game;
            currentGame.addObserverEnd(this);
            CurrentView = new MainGameView(this, game);
            notifyObserState(Utils.Properties.STATE_GAME.GAME);
        }

        /// <summary>
        /// <see cref="DiaballikGame.Welcome.MainInterface"/>
        /// </summary>
        public void replayGame(int id)
        {
            currentGame = null;
            CurrentView = new MainReplayView(this, new Diaballik.Replay.ReplayManager(id));
            notifyObserState(Utils.Properties.STATE_GAME.REPLAY);
        }

        /// <summary>
        /// <see cref="DiaballikGame.Welcome.MainInterface"/>
        /// </summary>
        public void resumeGame(int id)
        {
            Diaballik.Game g = new Diaballik.GameBuilder().build(id);
            setCurrentGame(g);
            notifyObserState(Utils.Properties.STATE_GAME.GAME);
        }

        /// <summary>
        /// <see cref="DiaballikGame.Welcome.MainInterface"/>
        /// </summary>
        public void saveCurrentGame()
        {
            if (currentGame != null)
            {
                currentGame.saveGame();
            }
        }


        /// <summary>
        /// <see cref="DiaballikGame.Welcome.MainInterface"/>
        /// </summary>
        public void displayMenu()
        {
            saveCurrentGame();
            CurrentView = new ChoiceGameView(this);
            notifyObserState(Utils.Properties.STATE_GAME.MENU);
        }

        /// <summary>
        /// Notifier que la partie est terminée
        /// </summary>
        /// <param name="game">Modele du jeu</param>
        /// <param name="playerNum">Numero du gagnant</param>
        public void gameEnded(Diaballik.Game game, int playerNum)
        {
            Player winnerGame = (currentGame.P1.NumberPlayer==playerNum)?currentGame.P1:currentGame.P2;
            Winner.Winner w = new Winner.Winner(this, winnerGame, currentGame.Board.MementoManager.getId());
            DialogHost.Show(w, delegate (object sender, DialogOpenedEventArgs args)
            {
                w.close(args);
            });
        }

        /// <summary>
        /// <see cref="DiaballikGame.Welcome.MainInterface"/>
        /// </summary>
        public void replayCurrentGame(int id)
        {
            currentGame.saveGame();
            ReplayManager rpM = new Diaballik.Replay.ReplayManager(id);
            rpM.loadAtTheEnd();
            CurrentView = new MainReplayView(this,rpM ,ReplayModel.TYPE_REPLAY.REPLAY_FROM_CURRENT_GAME);
            notifyObserState(Utils.Properties.STATE_GAME.REPLAY);
        }

        /// <summary>
        /// <see cref="DiaballikGame.Welcome.MainInterface"/>
        /// </summary>
        public void resumeGameFromReplay()
        {
            setCurrentGame(currentGame);
            notifyObserState(Utils.Properties.STATE_GAME.GAME);
        }

        /// <summary>
        ///Getter de la vue principale
        /// </summary>
        public object CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                RaisePropertyChanged("CurrentView");
            }
        }

        /// <summary>
        /// Getter du menu
        /// </summary>
        public object MenuView
        {
            get { return _menuView; }
            set
            {
                _menuView = value;
                RaisePropertyChanged("MenuView");
            }
        }

        /// <summary>
        /// Notifier changement de l'état de la fenetre
        /// </summary>
        /// <param name="state">Etat de la fenetre.</param>
        public void notifyObserState(Utils.Properties.STATE_GAME state)
        {
            observerState.ForEach(delegate(GameStateObserver ob){
                ob.notify(state);
            });
        }

        /// <summary>
        /// <see cref="DiaballikGame.Welcome.MainInterface"/>
        /// </summary>
        public void about()
        {
            DialogHost.Show(new About());
        }

        /// <summary>
        /// <see cref="DiaballikGame.Welcome.MainInterface"/>
        /// </summary>
        public void menuEndGame()
        {
            CurrentView = new ChoiceGameView(this);
            notifyObserState(Utils.Properties.STATE_GAME.MENU);
        }

        /// <summary>
        /// <see cref="DiaballikGame.Welcome.MainInterface"/>
        /// </summary>
        public void exitDiaballik()
        {
            saveCurrentGame();
            System.Windows.Application.Current.Shutdown();
        }
    }
}

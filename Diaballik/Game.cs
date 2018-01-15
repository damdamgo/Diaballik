using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Diaballik.DataManager;

namespace Diaballik
{
    /// <summary>
    /// Cette Classe permet de gérer une game
    /// </summary>
    public class Game
    {

        /// <summary>
        /// Reference vers le plateau
        /// </summary>
        private Board board;
        private Player p1, p2,playerWhoPlay = null;
        /// <summary>
        /// Observer de la fin d'une partie
        /// </summary>
        private List<ObserverEndGame> observerEndGame = new List<ObserverEndGame>();

        /// <summary>
        /// Constructeur du game <see cref="Diaballik.Game"/>
        /// </summary>
        /// <param name="board">Plateau du jeu</param>
        /// <param name="p1">Joueur 1</param>
        /// <param name="p2">Joueur 2</param>
        public Game(Board board,Player p1,Player p2)
        {
            this.board = board;
            this.p1 = p1;
            this.p2 = p2;
            this.P2.Pass = this.IWantStopMyTurn;
            this.P1.Pass = this.IWantStopMyTurn;
            board.MementoManager.TurnDone = this.hePlayed;
            saveGame();
            choosePlayerTurn();
        }

        /// <summary>
        /// Constructeur du game <see cref="Diaballik.Game"/>
        /// </summary>
        /// <param name="board">Plateau du jeu</param>
        /// <param name="p1">Joueur 1 </param>
        /// <param name="p2">Joueur 2</param>
        /// <param name="gameStatus">Statut du jeu</param>
        public Game(Board board, Player p1, Player p2, GameModelDB.GameStatus gameStatus)
        {
            this.board = board;
            this.p1 = p1;
            this.p2 = p2;
            this.P1.Pass = this.IWantStopMyTurn;
            this.P2.Pass = this.IWantStopMyTurn;
            board.MementoManager.TurnDone = this.hePlayed;
            if (gameStatus == GameModelDB.GameStatus.TURNPLAYER1)
            {
                p1.Canplay = true;
                playerWhoPlay = p1;
            }
            else if (gameStatus == GameModelDB.GameStatus.TURNPLAYER2)
            {
                p2.Canplay = true;
                playerWhoPlay = p2;
            }
            else if (gameStatus == GameModelDB.GameStatus.STARTING)
            {
                choosePlayerTurn();
            }
        }

        /// <summary>
        /// Getter du joueur 1
        /// </summary>
        /// <return>Joueur 1</return>
        public Player P1
        {
            get
            {
                return this.p1;
            }
        }
        /// <summary>
        /// Getter du plateau
        /// </summary>
        /// <return>Plateau</return>
        public Board Board
        {
            get
            {
                return this.board;
            }
        }
        /// <summary>
        /// Getter du joueur 2
        /// </summary>
        /// <return>Joueur 2</return>
        public Player P2
        {
            get
            {
                return this.p2;
            }
        }

        /// <summary>
        /// Joueur qui joue
        /// </summary>
        public Player PlayerWhoPlay
        {
            get
            {
                return this.playerWhoPlay;
            }
        }

        /// <summary>
        /// Changement de joueur
        /// </summary>
        public void choosePlayerTurn()
        {
            board.unSelectedAllTile();
            if (playerWhoPlay == null)
            {
                Random rand = new Random();
                playerWhoPlay = (rand.Next(2)==1) ? p1 : p2;
            }
            else
            {
                playerWhoPlay = (playerWhoPlay.Equals(p1)) ? p2 : p1;
            }
            playerWhoPlay.myTurn(board);
        }

        /// <summary>
        /// sauvegarde une partie
        /// </summary>
        public void saveGame(bool endGame = false)
        {
            GameModelDB.GameStatus gameStatus = GameModelDB.GameStatus.STARTING;
            if (playerWhoPlay != null)
            {
                gameStatus = (playerWhoPlay.Equals(p1)) ? GameModelDB.GameStatus.TURNPLAYER1 : GameModelDB.GameStatus.TURNPLAYER2;
            }
            if (endGame) gameStatus = GameModelDB.GameStatus.FINISHED;
            board.MementoManager.saveData(board.convertBoardForCpp(), p1, p2, gameStatus);
        }

        /// <summary>
        /// Change de joueur si le joueur courant à fait au moins un mouvement
        /// </summary>
        public void IWantStopMyTurn()
        {
            if (playerWhoPlay.Nbmove >= 1)
            {
                playerWhoPlay.NumberTurn++;
                playerWhoPlay.Canplay = false;
                PlayerWhoPlay.Nbmove = 0;
                choosePlayerTurn();
                saveGame();
            }
        }

        /// <summary>
        /// Indique que le joueur courant a joué
        /// </summary>
        public void hePlayed()
        {
            this.playerWhoPlay.Nbmove= this.playerWhoPlay.Nbmove+1;
            if (playerWhoPlay.Nbmove == 3)
            {
                playerWhoPlay.NumberTurn++;
                playerWhoPlay.Canplay = false;
                PlayerWhoPlay.Nbmove = 0;
                choosePlayerTurn();
                saveGame();
            }
            verifyVictory();
        }

        /// <summary>
        /// Verifie si un joueur a gagné
        /// </summary>
        /// <returns>
        ///     0 si pas de gagnant
        ///     1 si joueur 1 gagne
        ///     2 si joueuer 2 gagne
        /// </returns>
        public int verifyVictory()
        {
            int winner = 0;

            for (int i = 0; i < board.SizeBoard; i++)
            {
                if (board.getTile(0, i).hasPiece() && board.getTile(0, i).Piece.Player.Equals(p2) && board.getTile(0, i).Piece.hasBall())
                {
                    winner = 2;
                    break;
                }
            }

            if (winner==0)
            {
                for (int i = 0; i < board.SizeBoard; i++)
                {
                    if (board.getTile(board.SizeBoard-1, i).hasPiece() && board.getTile(board.SizeBoard - 1, i).Piece.Player.Equals(p1) && board.getTile(board.SizeBoard - 1, i).Piece.hasBall())
                    {
                        winner = 1;
                        break;
                    }
                }
            }
            if (winner != 0)
            {
                notifyEndGame(winner);
            }
            return winner;
        }

        /// <summary>
        /// Ajout d'un observer d'une fin de partie
        /// </summary>
        /// <param name="ob">Nouveau observer.</param>
        public void addObserverEnd(ObserverEndGame ob)
        {
            observerEndGame.Add(ob);
        }

        /// <summary>
        /// Notifier la fin d'une partie
        /// </summary>
        public void notifyEndGame(int player)
        {
            saveGame(true);
            observerEndGame.ForEach(delegate (ObserverEndGame ob)
            {
                ob.gameEnded(this,player);
            });
        }
    }
}
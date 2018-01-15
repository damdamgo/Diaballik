using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Diaballik.DataManager;
using Diaballik.Memento;

namespace Diaballik.Replay
{
    /// <summary>
    /// Gere le replay d'une partie
    /// </summary>
    public class ReplayManager
    {
        /// <summary>
        /// Données d'une partie
        /// </summary>
        private GameModelDB gameToReplay;
        /// <summary>
        /// Etat des cases
        /// </summary>
        private List<MementoTurn> listMemento;
        /// <summary>
        /// Indice du tour
        /// </summary>
        private int indTurn = 0;
        /// <summary>
        /// Joueurs de la partie
        /// </summary>
        private Player p1, p2;
        /// <summary>
        /// Plateau de la partie
        /// </summary>
        private Board board;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="IdDB">ID de la partie dans la bases de données</param>
        public ReplayManager(int IdDB)
        {
            GameDataManager db = DBManager.getInstance();
            gameToReplay = db.getGameById(IdDB);
            listMemento = new List<MementoTurn>();
            p1 = new PlayerReplay(ColorTranslator.FromHtml(gameToReplay.colorP1), gameToReplay.nameP1, gameToReplay.numP1,gameToReplay.numberTurnP1);
            p2 = new PlayerReplay(ColorTranslator.FromHtml(gameToReplay.colorP2), gameToReplay.nameP2, gameToReplay.numP2, gameToReplay.numberTurnP2);
            board = new Board(gameToReplay.initialBoard, p1, p2,true);
        }

        /// <summary>
        /// Getter du board
        /// </summary>
        public Board Board
        {
            get
            {
                return this.board;
            }
        }

        /// <summary>
        /// Charge à la fin du jeu
        /// </summary>
        public void loadAtTheEnd()
        {
            while (nextTurn()) ;
        }

        /// <summary>
        /// Passer au tour suivant
        /// </summary>
        public bool nextTurn()
        {
            bool ret = false;
            if (indTurn< gameToReplay.turnInformation.Length)
            {
                String turnInfo = gameToReplay.turnInformation[indTurn];
                TurnModelDB turnModelDB = TurnModelDB.BuildTurnModelWithString(turnInfo);
                MementoTurn mementoTurn = new MementoTurn();
                mementoTurn.Selection = board.getTile(turnModelDB.lineS, turnModelDB.columnS).createMemento();
                mementoTurn.Move = board.getTile(turnModelDB.lineE, turnModelDB.columnE).createMemento();
                mementoTurn.TSelection = board.getTile(turnModelDB.lineS, turnModelDB.columnS);
                mementoTurn.TMove = board.getTile(turnModelDB.lineE, turnModelDB.columnE);
                if (turnModelDB.turnType == Command.COMMAND_ACTION.BALL)
                {
                    mementoTurn.TMove.setBall( mementoTurn.TSelection.Piece.Ball);
                    mementoTurn.TSelection.setBall( null);
                }
                else
                {
                    mementoTurn.TMove.Piece = mementoTurn.TSelection.Piece;
                    mementoTurn.TSelection.Piece = null;
                }
                listMemento.Add(mementoTurn);
                indTurn++;
                ret = true;
            }
            return ret;
        }

        /// <summary>
        /// Retourner au tour precedent
        /// </summary>
        public void backTurn()
        {
            if (listMemento.Count > 0)
            {
                MementoTurn item = listMemento[listMemento.Count - 1];
                listMemento.RemoveAt(listMemento.Count - 1);
                item.undoTurn();
                indTurn--;
            }
        }

        /// <summary>
        /// Getter du joueur 1
        /// </summary>
        /// <value>
        /// joueur 2
        /// </value>
        public Player P1
        {
            get
            {
                return this.p1;
            }
        }

        /// <summary>
        /// Getter du joueur 2
        /// </summary>
        /// <value>
        /// joueur 2
        /// </value>
        public Player P2
        {
            get
            {
                return this.p2;
            }
        }
    }
}

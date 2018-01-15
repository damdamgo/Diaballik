using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Diaballik.DataManager;

namespace Diaballik.Memento
{
    /// <summary>
    /// permet de gérer les état des mouvements
    /// </summary>
    public class MementoManager
    {
        /// <summary>
        /// Gestionnaire de la base de données
        /// </summary>
        private GameDataManager gameDataManager;
        /// <summary>
        /// Callback quand un nouvement a été effectué
        /// </summary>
        private Action turnDone;
        /// <summary>
        /// Liste des mouvements
        /// </summary>
        private List<MementoTurn> listMementoObjects = new List<MementoTurn>();
        /// <summary>
        /// Sauvegarde l'état d'un mouvement
        /// </summary>
        private MementoTurn mementoTurn;
        /// <summary>
        /// ID de la partie dans la base de données
        /// </summary>
        private int idGame;
        /// <summary>
        /// Constructeur
        /// </summary>
        public MementoManager()
        {
            mementoTurn = null;
            gameDataManager = DBManager.getInstance(); 
        }
        /// <summary>
        /// Permet de fixer l'ID de la partie
        /// </summary>
        /// <param name="idGame"></param>
        public void setId(int idGame)
        {
            this.idGame = idGame;
        }
        /// <summary>
        /// Permet de récupérer l'id de la partie
        /// </summary>
        public int getId()
        {
            return this.idGame;
        }
        /// <summary>
        /// permet de recuperer la case selectionnée
        /// </summary>
        /// <returns>Case selectionnée</returns>
        public Tile getLastTileClick()
        {
            if (this.mementoTurn == null) return null;
            return this.mementoTurn.TSelection;
        }
        /// <summary>
        /// Ajoute dans l'état de mouvement la case qui contient l'élément que l'on souhaite déplacer
        /// </summary>
        /// <param name="mem">Memento de la case</param>
        /// <param name="tile">Case</param>
        public void pushChoice(MementoObject mem,Tile tile)
        {
            mementoTurn = new MementoTurn();
            mementoTurn.Selection = mem;
            mementoTurn.TSelection = tile; 
        }
        /// <summary>
        /// Ajoute dans l'état de mouvement la case qui va contenir l'élément que l'on déplace
        /// </summary>
        /// <param name="mem">Memento</param>
        /// <param name="tile">Case</param>
        /// <param name="action">Type d'action <see cref="Command.COMMAND_ACTION"/></param>
        public void pushAction(MementoObject mem,Tile tile,Command.COMMAND_ACTION action)
        {         
            mementoTurn.Move = mem;
            mementoTurn.TMove = tile;
            mementoTurn.Action = action;
        }

        /// <summary>
        /// La commande a été exectuéé
        /// </summary>
        public void commandExecuted()
        {
            listMementoObjects.Add(mementoTurn);
            mementoTurn = null;
            turnDone.Invoke();
        }

        /// <summary>
        /// Annule un choix
        /// </summary>
        public void cancelChoice()
        {
            mementoTurn = null;
        }

        /// <summary>
        /// Getter et setter du callback de mouvement
        /// </summary>
        public Action TurnDone {
            get
            {
                return this.turnDone;
            }
            set{
                this.turnDone = value;
            }
        }
        /// <summary>
        /// sauvegarde les mouvements dans la base de données
        /// </summary>
        /// <param name="currentBoard">Board</param>
        /// <param name="p1">Joueur 1</param>
        /// <param name="p2">Joueur 2</param>
        /// <param name="gS">statut de la partie <see cref="GameModelDB.GameStatus"/></param>
        public void saveData(int[] currentBoard,Player p1,Player p2,GameModelDB.GameStatus gS)
        {
            GameModelDB gameModelDB = gameDataManager.getGameById(this.idGame);
            gameModelDB.lastBoard = currentBoard;
            List<String> listTurnInfo = gameModelDB.turnInformation.ToList<String>();
            while (listMementoObjects.Count != 0)
            {
                MementoTurn mt = listMementoObjects.ElementAt(0);
                listMementoObjects.RemoveAt(0);
                listTurnInfo.Add(mt.dataToString());
            }

            gameModelDB.numberTurnP1 = p1.NumberTurn;
            gameModelDB.numberTurnP2 = p2.NumberTurn;

            gameModelDB.nbMoveP1 = p1.Nbmove;
            gameModelDB.nbMoveP2 = p2.Nbmove;

            gameModelDB.turnInformation = listTurnInfo.ToArray<String>();
            gameModelDB.gameStatus = gS;
            gameDataManager.updateGame(gameModelDB);
        }

    }
}
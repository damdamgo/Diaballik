using Diaballik.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Diaballik.DataManager;
using System.Drawing;

namespace Diaballik
{
    /// <summary>
    /// Permet de gérer un builder d'un game
    /// </summary>
    public class GameBuilder
    {
        /// <summary>
        /// Scenario du game
        /// </summary>
        private Scenario scenario;
        /// <summary>
        /// Differents joueurs de la partie
        /// </summary>
        private PlayerBuilder player1 = null, player2= null;
        /// <summary>
        /// gérer les données
        /// </summary>
        private GameDataManager gameDataManager;

        /// <summary>
        /// Getter et setter du scenario
        /// </summary>
        /// <value>
        /// Scenario
        /// </value>
        public Scenario Scenario
        {
            get
            {
                return this.scenario;
            }

            set
            {
                this.scenario = value;
            }
        }

        /// <summary>
        /// Getter et setter du joueur 1
        /// </summary>
        /// <value>
        /// Joueur 1
        /// </value>
        public PlayerBuilder Player1
        {
            get
            {
                return this.player1;
            }

            set
            {
                this.player1 = value;
            }
        }

        /// <summary>
        /// Getter et setter du joueur 2
        /// </summary>
        /// <value>
        /// Joueur 2
        /// </value>
        public PlayerBuilder Player2
        {
            get
            {
                return this.player2;
            }

            set
            {
                this.player2 = value;
            }
        }

        /// <summary>
        /// Getter et setter du gestionnaire des données
        /// </summary>
        /// <value>
        /// gestionnaire des données
        /// </value>
        public GameDataManager GameDataManager
        {
            get
            {
                return this.gameDataManager;
            }

            set
            {
                this.gameDataManager = value;
            }
        }

        /// <summary>
        /// Recuperer un game builder
        /// </summary>
        /// <returns><see cref="GameBuilder"/></returns>
        public static GameBuilder create()
        {
            return new GameBuilder();
        }

        /// <summary>
        /// Permet de placer les elements sur le plateau
        /// </summary>
        /// <param name="board">Le plateau.</param>
        /// <param name="p1">Joueur 1.</param>
        /// <param name="p2">Joueur 2.</param>
        private void configureBoard(Board board, Player p1, Player p2)
        {
            this.scenario.placeObject(board, p1, Scenario.Position.BAS);
            this.scenario.placeObject(board, p2, Scenario.Position.HAUT);
        }

        /// <summary>
        /// Construit un game
        /// </summary>
        /// <returns><see cref="Diaballik.Game"/></returns>
        /// <exception cref="PlayerNumberException">Nombre de joueur invalide</exception>
        /// <exception cref="PlayerSameColorException">Veuillez choisir des couleurs distinctes</exception>
        public Game build()
        {
            if(player1==null || player2 == null)
            {
                throw new PlayerNumberException("invalid number players");
            }
            Player p1 = player1.build(1);
            Player p2 = player2.build(2);
            if(p1.Color.Equals(p2.Color)) throw new PlayerSameColorException("Veuillez choisir des couleurs distinctes");

           Board board = new Board(Properties.DEFAULT_SIZE_BOARD);
           configureBoard(board, p1, p2);
            
            GameModelDB gameDB = new GameModelDB
            {
                nameP1 = p1.Name,
                colorP1 = "#" + p1.Color.R.ToString("X2") + p1.Color.G.ToString("X2") + p1.Color.B.ToString("X2"),
                numP1 = p1.NumberPlayer,
                typeP1 = p1.getType(),
                numberTurnP1 = 0,
                nbMoveP1 = 0,
                nameP2 = p2.Name,
                colorP2 = "#" + p2.Color.R.ToString("X2") + p2.Color.G.ToString("X2") + p2.Color.B.ToString("X2"),
                numP2 = p2.NumberPlayer,
                typeP2 = p2.getType(),
                numberTurnP2 = 0,
                nbMoveP2 = 0,
                initialBoard = board.convertBoardForCpp(),
                lastBoard = board.convertBoardForCpp(),
                turnInformation = new String[0],
                gameStatus = GameModelDB.GameStatus.STARTING
            };
            int idDB = createGameInDB(gameDB);
            board.MementoManager.setId(idDB);

            return new Game(board, p1, p2);

        }

        /// <summary>
        /// Construit un game depuis la base de données
        /// </summary>
        /// <param name="IdDB">Identifiant dans la BDD.</param>
        /// <returns><see cref="Diaballik.Game"/></returns>
        public Game build(int IdDB)
        {
            GameModelDB gameInfo = getGameInfoById(IdDB);
            Player p1 = initPlayer(gameInfo.typeP1, ColorTranslator.FromHtml(gameInfo.colorP1), gameInfo.nameP1, gameInfo.numP1,gameInfo.numberTurnP1);
            Player p2 = initPlayer(gameInfo.typeP2, ColorTranslator.FromHtml(gameInfo.colorP2), gameInfo.nameP2, gameInfo.numP2, gameInfo.numberTurnP2);
            p1.Nbmove = gameInfo.nbMoveP1;
            p2.Nbmove = gameInfo.nbMoveP2;
            Board board = new Board(gameInfo.lastBoard,p1,p2);
            board.MementoManager.setId(gameInfo.Id);
            return new Game(board, p1, p2,gameInfo.gameStatus);
        }

        /// <summary>
        /// Initialise un joueur
        /// </summary>
        /// <param name="type">Type de joueur.</param>
        /// <param name="color">Couleur.</param>
        /// <param name="name">Nom.</param>
        /// <param name="number">Numero du joueur.</param>
        /// <returns>un joueur</returns>
        private Player initPlayer(Player.PLAYER_TYPE type, System.Drawing.Color color,String name,int number,int numberOfTurn )
        {
            PlayerBuilder p;
            switch (type)
            {
                case Player.PLAYER_TYPE.HUMAN:
                    p = new PlayerHumanBuilder();
                    break;
                case Player.PLAYER_TYPE.IA_NOOB:
                    p = new PlayerIABuilder();
                    ((PlayerIABuilder)p).IaStrategy = new Noob();
                    break;
                case Player.PLAYER_TYPE.IA_PROGRESSIVE:
                    p = new PlayerIABuilder();
                    ((PlayerIABuilder)p).IaStrategy = new Progressive();
                    break;
                default:
                    p = new PlayerIABuilder();
                    ((PlayerIABuilder)p).IaStrategy = new Starting();
                    break;
            }
            p.Color = color;
            p.Name = name;
            p.NumberTurn = numberOfTurn;
            return p.build(number);
        }

        /// <summary>
        /// Créer une partie au sein de la BDD
        /// </summary>
        /// <param name="gameModelDB">La partie à sauvegarder.</param>
        /// <returns>id dans la base de données</returns>
        private int createGameInDB(GameModelDB gameModelDB)
        {
            DBManager dBManager = DBManager.getInstance();
            return dBManager.createGame(gameModelDB);
        }

        /// <summary>
        /// Recuperation d'une partie depuis la base de données
        /// </summary>
        /// <param name="IdDB">Identifiant dans la BDD.</param>
        /// <returns>une partie</returns>
        private GameModelDB getGameInfoById(int IdDB)
        {
            DBManager dBManager = DBManager.getInstance();
            return dBManager.getGameById(IdDB);
        }
    }
}
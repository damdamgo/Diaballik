using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Diaballik.DataManager;
using LiteDB;

namespace Diaballik.DataManager
{
    /// <summary>
    /// Classse qui gere les données
    /// <see cref="GameDataManager"/>
    /// </summary>
    public class DBManager : GameDataManager
    {
        /// <summary>
        /// Accès à la base de données
        /// </summary>
        private LiteDatabase db;
        /// <summary>
        /// Instance de la classe
        /// </summary>
        private static DBManager INSTANCE = null;
        /// <summary>
        /// colection du jeu
        /// </summary>
        public LiteCollection<GameModelDB> col { get; private set; }
        /// <summary>
        /// Constructeur
        /// </summary>
        private DBManager()
        {
            db = new LiteDatabase(@"MyData.db") ;
            col = db.GetCollection<GameModelDB>("games");
        }
        /// <summary>
        /// recuperation de l'instance de la classe
        /// </summary>
        /// <returns></returns>
        public static DBManager getInstance()
        {
            if (DBManager.INSTANCE == null) DBManager.INSTANCE = new DBManager();
            return DBManager.INSTANCE;
        }
        /// <summary>
        /// Recuperer une partie depuis un identifiant
        /// </summary>
        /// <param name="idGame">identifiant</param>
        /// <returns>Données de la partie <see cref="GameModelDB"/></returns>
        public GameModelDB getGameById(int idGame)
        {
            return col.FindOne(x => x.Id==idGame);
        }
        /// <summary>
        /// Créer une partie dans la base
        /// </summary>
        /// <param name="gameModelDB">Données de la partie</param>
        /// <returns>identifiant dans la base</returns>
        public int createGame(GameModelDB gameModelDB)
        {
            col.Insert(gameModelDB);
            return gameModelDB.Id;
        }
        /// <summary>
        /// Mettre à jour une partie dans la base
        /// </summary>
        /// <param name="gameModelDB">Données de la partie</param>
        public void updateGame(GameModelDB gameModelDB)
        {
            col.Update(gameModelDB);
        }
        /// <summary>
        /// Recuperer la liste des parties
        /// </summary>
        public IEnumerable<GameModelDB> getListGameSaved()
        {
            return col.FindAll();
        }
    }
}
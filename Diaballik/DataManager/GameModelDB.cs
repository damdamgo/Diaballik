using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diaballik.DataManager
{
    /// <summary>
    /// Modèle des parties
    /// </summary>
    public class GameModelDB
    {
        /// <summary>
        /// Enumaration qui definit le statut d'une partie
        /// </summary>
        public enum GameStatus { FINISHED, TURNPLAYER1, TURNPLAYER2,STARTING};
        /// <summary>
        /// Identifiant
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Nom du joueur 1
        /// </summary>
        public string nameP1 { get; set; }
        /// <summary>
        /// couleur du joueur 1
        /// </summary>
        public string colorP1 { get; set; }
        /// <summary>
        /// Numéro du joueur 1
        /// </summary>
        public int numP1 { get; set; }
        /// <summary>
        /// Nombre du tour du joueur 1
        /// </summary>
        public int numberTurnP1 { get; set; }
        /// <summary>
        /// Nombre de mouvement actuel du joueur 1
        /// </summary>
        public int nbMoveP1 { get; set; }
        /// <summary>
        /// Type du joueur 1 <see cref="Diaballik.Player.PLAYER_TYPE"/>
        /// </summary>
        public Player.PLAYER_TYPE typeP1 { get; set; }
        /// <summary>
        /// Nom du joueur 2
        /// </summary>
        public string nameP2 { get; set; }
        /// <summary>
        /// Couleur du joueur 2
        /// </summary>
        public string colorP2 { get; set; }
        /// <summary>
        /// Numéro du joueur 2
        /// </summary>
        public int numP2 { get; set; }
        /// <summary>
        /// Nombre de tour du joueur 2
        /// </summary>
        public int numberTurnP2 { get; set; }
        /// <summary>
        /// Nombre de mouvement actuel du joueur 2
        /// </summary>
        public int nbMoveP2 { get; set; }
        /// <summary>
        /// Type du joueur 2 <see cref="Diaballik.Player.PLAYER_TYPE"/>
        /// </summary>
        public Player.PLAYER_TYPE typeP2 { get; set; }
        /// <summary>
        /// Information sur les mouvements
        /// </summary>
        public String[] turnInformation { get; set; }
        /// <summary>
        /// Statut de la partie
        /// </summary>
        public GameStatus gameStatus { get; set; }
        /// <summary>
        /// Plateau au début de la partie
        /// </summary>
        public int[] initialBoard { get; set; }
        /// <summary>
        /// Dernier plateau connu
        /// </summary>
        public int[] lastBoard { get; set; }
    }
}

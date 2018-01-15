using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diaballik.DataManager
{
    /// <summary>
    /// Interface pour sauvegarder les parties
    /// </summary>
   public  interface GameDataManager
    {
        /// <summary>
        /// Recuperer une partie depuis un identifiant
        /// </summary>
        /// <param name="idGame">identifiant</param>
        /// <returns>Données de la partie</returns>
        GameModelDB getGameById(int idGame);
        /// <summary>
        /// Créer une partie
        /// </summary>
        /// <param name="gameModelDB">Données d'une partie</param>
        /// <returns>Identifiant de la partie</returns>
        int createGame(GameModelDB gameModelDB);
        /// <summary>
        /// Mettre à jour une partie
        /// </summary>
        /// <param name="gameModelDB">Données de la partie</param>
        void updateGame(GameModelDB gameModelDB);
        /// <summary>
        /// Recuperer l'ensemble des parties
        /// </summary>
        IEnumerable<GameModelDB> getListGameSaved();
    }
}

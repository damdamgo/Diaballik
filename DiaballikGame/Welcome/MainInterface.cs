using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Diaballik;

namespace DiaballikGame.Welcome
{
    /// <summary>
    /// Interface qui permet d'échanger avec la fenetre principale
    /// </summary>
    public interface MainInterface
    {
        /// <summary>
        /// Changer la vue principale
        /// </summary>
        /// <param name="command">Comande</param>
        void changeMainView(ICommand command);
        /// <summary>
        /// Affichage d'une partie
        /// </summary>
        /// <param name="game">Modele du jeu.</param>
        void createGame(Diaballik.Game game);
        /// <summary>
        /// Affichage d'un replay
        /// </summary>
        /// <param name="id">ID de la partie dans la base de données</param>
        void replayGame(int id);
        /// <summary>
        /// Reprendre un jeu
        /// </summary>
        /// <param name="id">ID de la partie dans la base de données</param>
        void resumeGame(int id);
        /// <summary>
        /// Sauvegarder la partie courante
        /// </summary>
        void saveCurrentGame();
        /// <summary>
        /// Affichage du menu
        /// </summary>
        void displayMenu();
        /// <summary>
        /// Replay de la partie courante
        /// </summary>
        /// <param name="id">ID de la partie dans la base de données</param>
        void replayCurrentGame(int id);
        /// <summary>
        /// Affichage replay de la partie courante
        /// </summary>
        void resumeGameFromReplay();
        /// <summary>
        /// Affichage de la vue about
        /// </summary>
        void about();
        /// <summary>
        /// Retour menu à la fin d'une partie
        /// </summary>
        void menuEndGame();
        /// <summary>
        /// Permet de fermer le jeu
        /// </summary>
        void exitDiaballik();
    }
}

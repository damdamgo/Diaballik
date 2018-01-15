using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Diaballik
{
    /// <summary>
    /// Definit la structure est les données pour un scenario
    /// </summary>
    public abstract class Scenario
    {
        /// <summary>
        /// Permet de definir de quel cote il faut positionner les elements
        /// </summary>
        public enum Position
        {
            BAS,HAUT
        };

        /// <summary>
        /// Place l'ensemble des elements sur le plateau
        /// </summary>
        /// <param name="board">Un plateau.</param>
        /// <param name="player">Un joueur.</param>
        /// <param name="position">La position <see cref="Position"/>.</param>
        public void placeObject(Board board, Player player,Position position)
        {
            placePiece(board,player,position);
            placeBall(board, player, position);
        }

        /// <summary>
        /// Place les pieces
        /// </summary>
        /// <param name="board">Un plateau.</param>
        /// <param name="player">Un joueur.</param>
        /// <param name="position">La position <see cref="Position"/>.</param>
        protected abstract void placePiece(Board board, Player player, Position position);


        /// <summary>
        /// Place la balle
        /// </summary>
        /// <param name="board">Un plateau.</param>
        /// <param name="player">Un joueur.</param>
        /// <param name="position">La position <see cref="Position"/>.</param>
        protected abstract void placeBall(Board board, Player player, Position position);
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Diaballik
{
    /// <summary>
    /// Classe qui permet de placer les éléments sur le plateau en fonction du scénario BallRandom
    /// <see cref="Diaballik.Scenario"/>
    /// </summary>
    public class BallRandom : Scenario
    {
        /// <summary>
        /// Permet de placer la balle
        /// </summary>
        /// <param name="board">Le plateau</param>
        /// <param name="player">Le joueur</param>
        /// <param name="position">Position sur le plateau</param>
        protected override void placeBall(Board board, Player player, Position position)
        {
            int line = (position == Scenario.Position.HAUT) ? board.SizeBoard - 1 : 0;
            Random rand = new Random();
            board.getTile(line, rand.Next(board.SizeBoard)).Piece.Ball = player.Ball;
        }

        /// <summary>
        /// Place l'ensemble de pièces sur le plateau
        /// </summary>
        /// <param name="board">Le plateau</param>
        /// <param name="player">Le joueur</param>
        /// <param name="position">Position sur le plateau</param>
        protected override void placePiece(Board board, Player player, Position position)
        {
            int line = (position == Scenario.Position.HAUT) ? board.SizeBoard - 1 : 0;
            for (int i = 0; i < board.SizeBoard; i++)
            {
                board.getTile(line, i).Piece = new Piece(player);
            }

        }


    }
}
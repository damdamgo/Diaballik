using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Diaballik
{
    /// <summary>
    /// Permet d'initialiser un plateau selon le scenario standard
    /// </summary>
    /// <seealso cref="Diaballik.Scenario" />
    public class Standart : Scenario
    {
        /// <summary>
        /// Place la balle
        /// </summary>
        /// <param name="board">Le plateau.</param>
        /// <param name="player">Le joueur.</param>
        /// <param name="position">La position.<see cref="Diaballik.Scenario.Position"/></param>
        protected override void placeBall(Board board, Player player, Position position)
        {
            int line = (position == Scenario.Position.HAUT) ? board.SizeBoard - 1 : 0;
            board.getTile(line, board.SizeBoard / 2).Piece.Ball = player.Ball;
        }

        /// <summary>
        /// Place les pieces
        /// </summary>
        /// <param name="board">Le plateau.</param>
        /// <param name="player">Le joueur.</param>
        /// <param name="position">La position.<see cref="Diaballik.Scenario.Position"/></param>
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
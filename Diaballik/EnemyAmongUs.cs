using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Diaballik
{
    /// <summary>
    /// Permet de placer les éléments selon le scenario EnemyAmongUs
    /// <see cref="Diaballik.Scenario"/>
    /// </summary>
    public class EnemyAmongUs : Scenario
    {
  
        /// <summary>
        /// Place la balle
        /// </summary>
        /// <param name="board">Le plateau</param>
        /// <param name="player">Le joueur</param>
        /// <param name="position">Position sur le plateau</param>
        protected override void placeBall(Board board, Player player, Position position)
        {
            int line = (position == Scenario.Position.HAUT) ? board.SizeBoard - 1 : 0;
            board.getTile(line, board.SizeBoard / 2).Piece.Ball = player.Ball;
        }

        /// <summary>
        /// Permet de placer les pieces
        /// </summary>
        /// <param name="board">Le plateau</param>
        /// <param name="player">Le joueur</param>
        /// <param name="position">Position sur le plateau</param>
        protected override void placePiece(Board board, Player player, Position position)
        {
            
            if (position == Position.BAS)
            {
                board.getTile(0, board.SizeBoard / 2).Piece = new Piece(player);
                int cpt = board.SizeBoard - 3;
                place(0, cpt, player, board);
                cpt = 2;
                place(board.SizeBoard-1, cpt, player, board);
            }
            else
            {
                for(int i = 0;i< board.SizeBoard; i++)
                {
                    if(checkPlace(board, board.SizeBoard-1, i)) board.getTile(board.SizeBoard - 1, i).Piece = new Piece(player);
                    if(checkPlace(board, 0, i)) board.getTile(0, i).Piece = new Piece(player);
                }
            }
        }

        /// <summary>
        /// Verifie si une piece est sur l'emplacement
        /// </summary>
        /// <param name="board">Le plateau</param>
        /// <param name="line">La ligne</param>
        /// <param name="column">La colonne</param>
        /// <returns></returns>
        private bool checkPlace(Board board,int line,int column)
        {
            return !board.getTile(line, column).hasPiece();
        }

        /// <summary>
        /// Placer des pieces sur une ligne dans les emplacements libres
        /// </summary>
        /// <param name="line">Ligne</param>
        /// <param name="cpt">Nombre de pieces</param>
        /// <param name="player">Joueur</param>
        /// <param name="board">Plateau</param>
        private void place(int line,int cpt,Player player,Board board)
        {
            Random rand = new Random();
            while (cpt != 0)
            {
                int col = rand.Next(board.SizeBoard);
                if (col!= board.SizeBoard / 2 && checkPlace(board, line, col))
                {
                    board.getTile(line, col).Piece = new Piece(player);
                    cpt--;
                }
            }
        }
    }
}
// ***********************************************************************
// Assembly         : Diaballik
// Author           : Bastien LELARGE
// Author           : Damien VILLIERS
// Created          : 12-03-2017
//
// Last Modified By : basti
// Last Modified On : 12-03-2017
// ***********************************************************************
// <copyright file="MovePiece.cs" company="">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Diaballik
{
    /// <summary>
    /// Class MovePiece.
    /// </summary>
    /// <seealso cref="Diaballik.Command" />
    public class MovePiece : Command
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="MovePiece"/> class.
        /// </summary>
        /// <param name="tile">The tile.</param>
        public MovePiece(Tile tile) : base(tile)
        {

        }

        /// <summary>
        /// Execute l'action en bougeant la piece de la Commande
        /// </summary>
        /// <param name="board">Le plateau</param>
        public void executeAction(Board board)
        {
            Tile selection = board.MementoManager.getLastTileClick();
            Tile.Piece = selection.Piece;
            selection.Piece = null;
            board.MementoManager.commandExecuted();
        }



        /// <summary>
        /// Execute la Commande qui bouge la piece vers sa destination 
        /// </summary>
        /// <param name="board">Le plateau</param>
        public override void execute(Board board)
        {
            
            board.MementoManager.pushAction(Tile.createMemento(), this.Tile, COMMAND_ACTION.PIECE);
            board.unSelectedAllTile();
            this.executeAction(board);
        }
    }
}
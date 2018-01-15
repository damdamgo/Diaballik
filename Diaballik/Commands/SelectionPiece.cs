// ***********************************************************************
// Assembly         : Diaballik
// Author           : Bastien LELARGE
// Author           : Damien VILLIERS
// Created          : 12-03-2017
//
// Last Modified By : basti
// Last Modified On : 12-03-2017
// ***********************************************************************
// <copyright file="SelectionPiece.cs" company="">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace Diaballik
{
    /// <summary>
    /// Class SelectionPiece.
    /// </summary>
    /// <seealso cref="Diaballik.Command" />
    public class SelectionPiece : Command
    {
        /// <summary>
        /// Chargement de l'API des algos
        /// </summary>
        /// <returns></returns>
        [DllImport("libCPP.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static IntPtr createAPI();

        [DllImport("libCPP.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static IntPtr removeAPI(IntPtr api);

        [DllImport("libCPP.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static IntPtr play_selectionPiece(IntPtr api, int[] board, int sizeBoard, int linePiece, int columnPiece, int[] res);

        /// <summary>
        /// constructeur
        /// </summary>
        /// <param name="tile">Case</param>
        public SelectionPiece(Tile tile) : base(tile)
        {

        }

        /// <summary>
        /// Récupère les coordonnées des destinations possibles de la piece sélectionnées
        /// </summary>
        /// <param name="board">Le plateau</param>
        /// <returns>Les coordonnées des destinations possibles de la pièce</returns>
        private int[] getPossibleMove(Board board)
        {
            int[] boardCpp = board.convertBoardForCpp();
            int[] res = new int[8];
            IntPtr api = createAPI();
            play_selectionPiece(api, boardCpp, board.SizeBoard, board.getLineTile(Tile),board.getColumnTile(Tile),res);
            removeAPI(api);
            return res;
        }

        /// <summary>
        /// Met les Tiles possible "Selected"
        /// </summary>
        /// <param name="board">Le plateau</param>
        /// <param name="move">Les coordonnées des destinations possibles de la piece</param>
        private void setSelectedPossibleTile(Board board, int[] move)
        {
            board.unSelectedAllTile();
            int i = 0;
            while (i < 8 && move[i] != -1 && move[i+1] != -1)
            {
                board.getTile(move[i], move[i + 1]).setSelected();
                i += 2;
            };
        }


        /// <summary>
        /// Execute la commande 
        /// </summary>
        /// <param name="board">Le plateau</param>
        public override void execute(Board board)
        {
            if (ReferenceEquals(this.Tile, board.MementoManager.getLastTileClick()))
            {
                board.unSelectedAllTile();
                board.MementoManager.cancelChoice();
            }
            else
            {
                board.MementoManager.pushChoice(Tile.createMemento(), this.Tile);
                setSelectedPossibleTile(board, getPossibleMove(board));
            }
        }
    }
}
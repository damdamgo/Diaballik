// ***********************************************************************
// Assembly         : Diaballik
// Author           : Bastien LELARGE
// Author           : Damien VILLIERS
// Created          : 12-03-2017
//
// Last Modified By : basti
// Last Modified On : 12-03-2017
// ***********************************************************************
// <copyright file="SelectionBall.cs" company="">
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
    /// Class SelectionBall.
    /// </summary>
    /// <seealso cref="Diaballik.Command" />
    public class SelectionBall : Command
    {
        /// <summary>
        /// Chargement de l'API
        /// </summary>
        /// <returns></returns>
        [DllImport("libCPP.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static IntPtr createAPI();

        [DllImport("libCPP.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static IntPtr removeAPI(IntPtr api);

        [DllImport("libCPP.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static IntPtr play_selectionBall(IntPtr api, int[] board, int sizeBoard, int player, int[] res);

        /// <summary>
        /// constructeur
        /// </summary>
        /// <param name="tile">Case</param>
        public SelectionBall(Tile tile) : base(tile)
        {

        }

        /// <summary>
        /// Récupère les coordonnées des destinations possibles de la balle sélectionnées
        /// </summary>
        /// <param name="board">Le plateau</param>
        /// <returns>les coordonnées des destinations possibles de la balle sélectionnées</returns>
        private int[] getPossibleMove(Board board)
        {
            int[] boardCpp = board.convertBoardForCpp();
            int[] res = new int[16];
            IntPtr api = createAPI();
            play_selectionBall(api, boardCpp, board.SizeBoard, Tile.Piece.Player.NumberPlayer, res);
            removeAPI(api);
            return res;
        }

        /// <summary>
        /// Met les Tiles possibles "Selected"
        /// </summary>
        /// <param name="board">Le plateau</param>
        /// <param name="move">Les coordonnées des destinations possibles de la balle</param>
        private void setSelectedPossibleTile(Board board,int[] move)
        {
            board.unSelectedAllTile();
            int i = 0;
            do
            {
                board.getTile(move[i], move[i + 1]).setSelected();
                i += 2;
            } while (i < 16 && move[i] != -1 && move[i] != -1);
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
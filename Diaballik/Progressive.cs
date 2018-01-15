using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace Diaballik
{
    /// <summary>
    /// Permet à une IA de jouer avec une stratégie Progressive
    /// </summary>
    /// <seealso cref="Diaballik.IAStrategy" />
    public class Progressive : IAStrategy
    {

        /// <summary>
        /// Chargement de l'API
        /// </summary>
        [DllImport("libCPP.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static IntPtr createAPI();
        [DllImport("libCPP.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static IntPtr removeAPI(IntPtr api);
        [DllImport("libCPP.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static IntPtr play_Progressive(IntPtr api, int[] board, int sizeBoard, int player, int[] res, int numTurn);

        /// <summary>
        /// Permet de recuperer le type de l'IA
        /// </summary>
        /// <returns>Type de l'IA
        /// <see cref="Diaballik.IAStrategy.IA_STRATEGY"/>
        /// </returns>
        public override IA_STRATEGY getType()
        {
            return IA_STRATEGY.PROGRESSIVE;
        }

        /// <summary>
        /// Recupere l'ensemble des mouvements choisis par l'IA
        /// </summary>
        /// <returns>resultat des mouvements</returns>
        public override int[] play(Board board, Player p)
        {
            int[] res = { -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1 };
            IntPtr api = createAPI();
            play_Progressive(api, board.convertBoardForCpp(), board.SizeBoard, p.NumberPlayer, res,p.NumberTurn);
            removeAPI(api);
            return res;
        }
    }
}
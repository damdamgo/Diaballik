using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Diaballik
{
    /// <summary>
    /// Permet de definir une strategie de l'IA
    /// </summary>
    public abstract class IAStrategy
    {
        /// <summary>
        /// Enum pour definir le type de l'IA
        /// </summary>
        public enum IA_STRATEGY {NOOB,STARTING,PROGRESSIVE};


        public abstract int[] play(Board board, Player p);

        /// <summary>
        /// Permet de recuperer le type de l'IA
        /// </summary>
        /// <returns><see cref="IA_STRATEGY"/></returns>
        public abstract IA_STRATEGY getType();
    }
}
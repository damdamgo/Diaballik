using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Diaballik
{
    /// <summary>
    /// Classe de l'élément Balle
    /// </summary>
    public class Ball
    {
        /// <summary>
        /// joueur qui possède la Balle
        /// </summary>
        private Player player;
        /// <summary>
        /// constructeur
        /// </summary>
        /// <param name="player">Joueur de la balle</param>
        public Ball(Player player)
        {
            this.player = player;
        }
        /// <summary>
        /// Getter du joueur
        /// </summary>
        /// <return>Joueur</return>
        public Player Player
        {
            get
            {
                return this.player;
            }
        }
        /// <summary>
        /// Clone la balle
        /// </summary>
        /// <returns>Clonage de la balle</returns>
        public Ball clone()
        {
            Ball ret = new Ball(this.player);
            return ret;
        }
    }
}
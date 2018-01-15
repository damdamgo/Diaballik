using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Diaballik;
using DiaballikGame.Utils;

namespace DiaballikGame.PlayerAction
{
    /// <summary>
    /// Modele de la vue ActionPLayer
    /// </summary>
    class PlayerActionModel
    {
        /// <summary>
        /// Joueur
        /// </summary>
        private Player player;

        /// <summary>
        /// Constructeur <see cref="PlayerActionModel"/> class.
        /// </summary>
        /// <param name="p">Joueur</param>
        public PlayerActionModel(Player p)
        {
            this.player = p;
        }

        /// <summary>
        /// Getter du joueur
        /// </summary>
        public Player Player
        {
            get
            {
                return this.player;
            }
        }

        /// <summary>
        /// Arret du tour
        /// </summary>
        public void endTurn()
        {
            if (player.getType() == Player.PLAYER_TYPE.HUMAN) player.endTurn();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Diaballik.Utils;
namespace Diaballik
{
    /// <summary>
    /// Classe de l'élément pièce
    /// </summary>
    public class Piece
    {
        /// <summary>
        /// Joueur qui possède la pièce
        /// </summary>
        private Player player;
        /// <summary>
        /// Balle que peut contenir la pièce
        /// </summary>
        private Ball ball;
        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="player">Joueur</param>
        public Piece(Player player)
        {
            this.player = player;
            this.ball = null;
        }
        /// <summary>
        /// Getter et setter de la Balle
        /// </summary>
        /// <return>Balle</return>
        public Ball Ball
        {
            get
            {
                return ball;
            }

            set
            {
                this.ball = value;
            }
        }
        /// <summary>
        /// Getter et setter du joueur
        /// </summary>
        /// <return>Joueur</return>
        public Player Player
        {
            get
            {
                return player;
            }

            set
            {
                this.player = value;
            }
        }
        /// <summary>
        /// permet de vérifier si la pièce possède une Balle
        /// </summary>
        /// <returns>Boolean  : si possède balle retoune vraie sinon faux</returns>
        public Boolean hasBall()
        {
            return this.ball != null;
        }
        /// <summary>
        /// Clone de la pièce
        /// </summary>
        /// <returns>Clonage de la pièce</returns>
        public Piece clone()
        {
            Piece ret = new Piece(this.player);
            if(this.hasBall())ret.Ball = this.Ball.clone();
            return ret;
        }
    }
}
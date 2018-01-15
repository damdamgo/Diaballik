using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;

namespace Diaballik
{
    /// <summary>
    /// Permet de gérer un builder pour un joueur général
    /// </summary>
    public abstract class PlayerBuilder
    {
        /// <summary>
        /// Nom du joueur
        /// </summary>
        private String name = null;
        /// <summary>
        /// Couleur du joueur
        /// </summary>
        private Color color = Color.Empty;
        /// <summary>
        /// Nombre de tour
        /// </summary>
        private int numberTurn = 0;

        /// <summary>
        /// Getter ou setter du nom
        /// </summary>
        /// <value>
        /// Nom du joueur
        /// </value>
        public String Name
        {
            get
            {
                return this.name;
            }

            set
            {
                this.name = value;
            }
        }

        /// <summary>
        /// Getter et setter de la couleur
        /// </summary>
        /// <value>
        /// Couleur du joueur
        /// </value>
        public Color Color
        {
            get
            {
                return this.color;
            }

            set
            {
                this.color = value;
            }
        }

        /// <summary>
        /// Getter et setter nombre de tour
        /// </summary>
        /// <value>
        /// nombre de tour
        /// </value>
        public int NumberTurn
        {
            get
            {
                return this.numberTurn;
            }
            set
            {
                this.numberTurn = value;
            }
        }

        /// <summary>
        /// Construit un joueur
        /// </summary>
        /// <param name="numberPlayer">Numero du joueur.</param>
        /// <returns>un joueur</returns>
        public abstract Player build(int numberPlayer);
    }
}
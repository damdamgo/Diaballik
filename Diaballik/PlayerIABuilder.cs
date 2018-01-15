using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Diaballik.Exceptions;

namespace Diaballik
{
    /// <summary>
    /// permet de créer un builder pour un joueur de type IA
    /// </summary>
    /// <seealso cref="Diaballik.PlayerBuilder" />
    public class PlayerIABuilder : PlayerBuilder
    {

        /// <summary>
        /// Strategie de l'IA
        /// </summary>
        private IAStrategy iaStrategy;

        /// <summary>
        /// Getter et setter de la strategie de l'IA
        /// </summary>
        /// <value>
        /// Strategie de l'IA
        /// </value>
        public IAStrategy IaStrategy
        {
            get
            {
                return this.iaStrategy;
            }

            set
            {
                this.iaStrategy = value;
            }
        }

        /// <summary>
        /// Permet de recuperer un builder pour l'IA
        /// </summary>
        /// <returns>Un builder de l'IA
        /// </returns>
        public static PlayerIABuilder create()
        {
            return new PlayerIABuilder();
        }

        /// <summary>
        /// Construit un player <see cref="Diaballik.Player"/>
        /// </summary>
        /// <param name="numberPlayer">Numero du joueur.</param>
        /// <returns></returns>
        /// <exception cref="ConfigurationPlayerException">
        /// Nom du joueur inconnu
        /// ou
        /// Couleur inconnue
        /// </exception>
        public override Player build(int numberPlayer)
        {
            if (this.Name == null) throw new ConfigurationPlayerException("Nom du joueur inconnu");
            if (this.Color == System.Drawing.Color.Empty) throw new ConfigurationPlayerException("Couleur inconnue");
            PlayerIA playerIA = new PlayerIA(this.Color,this.Name, numberPlayer, this.IaStrategy,this.NumberTurn);
            Ball ball = new Ball(playerIA);
            playerIA.Ball = ball;
            return playerIA;
        }


        
    }
}
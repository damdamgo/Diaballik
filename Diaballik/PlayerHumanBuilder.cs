using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Diaballik.Exceptions;

namespace Diaballik
{
    /// <summary>
    /// Permet de gérer le builder pour un joueur humain
    /// </summary>
    /// <seealso cref="Diaballik.PlayerBuilder" />
    public class PlayerHumanBuilder : PlayerBuilder
    {
        /// <summary>
        /// Permet de recuperer un builder
        /// </summary>
        /// <returns>Un builder humain
        /// </returns>
        public static PlayerHumanBuilder create()
        {
            return new PlayerHumanBuilder();
        }

        /// <summary>
        /// Construit un joueur
        /// </summary>
        /// <param name="numberPlayer">Numero du joueur.</param>
        /// <returns>Un joueur</returns>
        /// <exception cref="ConfigurationPlayerException">
        /// Nom du joueur inconnu
        /// ou
        /// Couleur inconnue
        /// </exception>
        public override Player build(int numberPlayer)
        {
            if (this.Name == null) throw new ConfigurationPlayerException("Nom du joueur inconnu");
            if (this.Color == System.Drawing.Color.Empty) throw new ConfigurationPlayerException("Couleur inconnue");
            Player playerHuman = new PlayerHuman(base.Color, base.Name, numberPlayer,this.NumberTurn);
            Ball ball = new Ball(playerHuman);
            playerHuman.Ball = ball;
            return playerHuman;
        }
    }
}
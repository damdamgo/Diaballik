using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Diaballik
{
    /// <summary>
    /// Classe qui permet de gerer un joueur humain
    /// </summary>
    /// <seealso cref="Diaballik.Player" />
    public class PlayerHuman : Player
    {
        /// <summary>
        /// Constructeur <see cref="PlayerHuman"/> class.
        /// </summary>
        /// <param name="color">Couleur.</param>
        /// <param name="name">Nom.</param>
        /// <param name="numberplayer">Numero du joueur.</param>
        public PlayerHuman(Color color,String name,int numberplayer,int numberTurn) : base(color,name, numberplayer, numberTurn)
        {
          
        }

        /// <summary>
        /// Permet d'arreter le tour
        /// </summary>
        public override void endTurn()
        {
            pass.Invoke();
        }

        /// <summary>
        /// Permet de recuperer le type de joueur
        /// </summary>
        /// <returns><see cref="Diaballik.Player.PLAYER_TYPE"/></returns>
        public override PLAYER_TYPE getType()
        {
            return PLAYER_TYPE.HUMAN;
        }

        /// <summary>
        /// Permet au joueur de jouer
        /// </summary>
        public override void myTurn(Board board)
        {
            Nbmove = 0;
            Canplay = true;
        }

        public override void playAgain()
        {
            throw new NotImplementedException();
        }
    }
}
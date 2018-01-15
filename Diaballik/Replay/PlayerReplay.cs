using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diaballik.Replay
{
    /// <summary>
    /// Permet de gérer un joueur en mode replay
    /// </summary>
    public class PlayerReplay : Player
    {
        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="color">Couleur</param>
        /// <param name="name">Nom du joueur</param>
        /// <param name="numberPlayer">Numero du joueur</param>
        /// <param name="numberTurn">Nombre de tour</param>
        public PlayerReplay(Color color, string name, int numberPlayer,int numberTurn) : base(color, name, numberPlayer,numberTurn)
        {
            Ball = new Ball(this);
        }

        /// <summary>
        /// Permet de stopper son tour
        /// </summary>
        public override void endTurn()
        {
        }

        /// <summary>
        /// Permet de recuperer le type de joueur
        /// </summary>
        /// <returns>Type de joueur <see cref="Diaballik.Player.PLAYER_TYPE"/></returns>
        public override PLAYER_TYPE getType()
        {
            return PLAYER_TYPE.REPLAY;
        }

        /// <summary>
        /// Indique au joueur que c'est son tour
        /// </summary>
        /// <param name="board"></param>
        public override void myTurn(Board board)
        {

        }

        public override void playAgain()
        {
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading;

namespace Diaballik
{
    /// <summary>
    /// Permet de gérer un joueur de type IA
    /// </summary>
    /// <seealso cref="Diaballik.Player" />
    public class PlayerIA : Player
    {
        /// <summary>
        /// Strategie de l'IA
        /// </summary>
        private IAStrategy iaStrategy;

        /// <summary>
        /// Constructor <see cref="PlayerIA"/> class.
        /// </summary>
        /// <param name="color">La couleur.</param>
        /// <param name="name">Le nom.</param>
        /// <param name="numberplayer">Numero du joueur.</param>
        /// <param name="iaStrategy">Strategie de l'IA.</param>
        public PlayerIA(Color color, string name,int numberplayer,IAStrategy iaStrategy,int numberTurn) : base(color, name, numberplayer, numberTurn)
        {
            this.iaStrategy = iaStrategy;
        }

        /// <summary>
        /// Getter de la strategie de l'IA
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
        }

        public void move(Board board)
        {
            throw new System.NotImplementedException();
        }

        public Piece choosePiece(Board board)
        {
            throw new System.NotImplementedException();
        }

        public Tile chooseTile(Board board)
        {
            throw new System.NotImplementedException();
        }

        public override void playAgain()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Arrete son tour
        /// </summary>
        public override void endTurn()
        {
            pass.Invoke();
        }

        /// <summary>
        /// Autorise le joueur à jouer
        /// </summary>
        public override void myTurn(Board board)
        {
            Thread thread = new Thread(() => playAsPlayer(board));
            thread.Start();
        }

        /// <summary>
        /// Permet de jouer comme un humain
        /// </summary>
        /// <param name="board">Le plateau</param>
        private void playAsPlayer(Board board)
        {
            nbMove = 0;
            canPlay = true;
            int[] moves = iaStrategy.play(board, this);
            int i = 0;
            while (i < Properties.NUMBERS_RES_API && moves[i] != -1)
            {
                Thread.Sleep(800);
                board.getTile(moves[i], moves[i + 1]).buildDecision();
                Thread.Sleep(800);
                board.getTile(moves[i + 2], moves[i + 3]).buildDecision();
                i = i + 4;
            }
            if (i < Properties.NUMBERS_RES_API) endTurn();
        }


        /// <summary>
        /// Permet de recuperer le type de joueur
        /// </summary>
        /// <returns><see cref="Diaballik.Player.PLAYER_TYPE"/>
        /// </returns>
        public override PLAYER_TYPE getType()
        {
            PLAYER_TYPE ia = PLAYER_TYPE.IA_PROGRESSIVE;
            switch (this.iaStrategy.getType())
            {
                case IAStrategy.IA_STRATEGY.NOOB:
                    ia = PLAYER_TYPE.IA_NOOB;
                    break;
                case IAStrategy.IA_STRATEGY.STARTING:
                    ia = PLAYER_TYPE.IA_STARTING;
                    break;
            }
            return ia;
        }
    }
}
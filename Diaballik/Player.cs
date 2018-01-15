using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Diaballik.Utils;

namespace Diaballik
{
    /// <summary>
    /// Permet de gérer un joueur general
    /// </summary>
    public abstract class Player : ViewModelBase
    {
        /// <summary>
        /// Type de joueur
        /// </summary>
        public enum PLAYER_TYPE { HUMAN,IA_NOOB,IA_PROGRESSIVE,IA_STARTING,REPLAY}
        /// <summary>
        /// Nom du joueur
        /// </summary>
        private String name;
        /// <summary>
        /// Balle du joueur
        /// </summary>
        private Ball ball;
        /// <summary>
        /// Numero de joueur
        /// </summary>
        private int numberPlayer;
        /// <summary>
        /// autorise le joueur à jouer
        /// </summary>
        protected bool canPlay = false;
        /// <summary>
        /// nombre de mouvements effectués
        /// </summary>
        protected int nbMove = 0;
        /// <summary>
        /// Couleur du joueur
        /// </summary>
        private Color color;
        /// <summary>
        /// Commande pour passer le tour <see cref="Diaballik.GameCommand"/>
        /// </summary>
        protected Action pass;
        /// <summary>
        /// Nombre de tour du joueur
        /// </summary>
        protected int numberTurn;

        /// <summary>
        /// Constructeur <see cref="Player" /> class.
        /// </summary>
        /// <param name="color">Couleur.</param>
        /// <param name="name">Nom.</param>
        /// <param name="numberPlayer">Numero du joueur.</param>
        public Player(Color color, String name,int numberPlayer,int numberTurn)
        {
            this.color = color;
            this.name = name;
            this.numberPlayer = numberPlayer;
            this.numberTurn = numberTurn;
        }

        /// <summary>
        /// Getter numero du joueur
        /// </summary>
        /// <value>
        /// Numero du joueur
        /// </value>
        public int NumberPlayer
        {
            get
            {
                return this.numberPlayer;
            } 
        }

        /// <summary>
        /// Getter et setter du nombre de tour
        /// </summary>
        /// <value>
        /// Nombre de tour
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
                RaisePropertyChanged("NumberTurn");
            }
        }

        /// <summary>
        /// Getter et setter de la couleur du joueur
        /// </summary>
        /// <value>
        /// Couleur
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
        ///  Getter et setter de la possibilite du joueur à jouer.
        /// </summary>
        /// <value>
        ///   <c>true</c> il peut jouer; sinon, <c>false</c>.
        /// </value>
        public bool Canplay
        {
            get
            {
                return this.canPlay;
            }

            set
            {
                this.canPlay = value;
                RaisePropertyChanged("Canplay");
            }
        }

        /// <summary>
        /// Getter et setter du nombre de mouvement
        /// </summary>
        /// <value>
        /// Nombre de mouvement
        /// </value>
        public int Nbmove
        {
            get
            {
                return this.nbMove;
            }

            set
            {
                this.nbMove = value;
                RaisePropertyChanged("Nbmove");
            }
        }

        /// <summary>
        /// Getter et setter de la balle
        /// </summary>
        /// <value>
        /// Balle du joueur
        /// </value>
        public Ball Ball
        {
            get
            {
                return this.ball;
            }

            set
            {
                this.ball = value;
            }
        }

        /// <summary>
        /// Getter et setter du nom du joueur
        /// </summary>
        /// <value>
        /// Nom
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
        /// Commande qui peut etre effectuée sur le game <see cref="Diaballik.Game"/>
        /// </summary>
        /// <value>
        /// GameCommande
        /// </value>
        public Action Pass
        {
            set
            {
                this.pass = value;
            }
        }

        /// <summary>
        /// Autorise le joueur à jouer
        /// </summary>
        public abstract void myTurn(Board board);

        public abstract void playAgain();

        /// <summary>
        /// Passe son tour
        /// </summary>
        public abstract void endTurn();

        /// <summary>
        /// Permet de recuperer le type du joueur
        /// </summary>
        /// <returns>Type du joueur <see cref="PLAYER_TYPE"/></returns>
        public abstract PLAYER_TYPE getType();
    }
}
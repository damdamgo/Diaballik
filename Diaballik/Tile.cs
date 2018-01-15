using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Diaballik.Memento;
using Diaballik.Utils;

namespace Diaballik
{
    /// <summary>
    /// Class Tile qui permet de gérer une case d'un board
    /// <seealso cref="Diaballik.Board" />
    /// </summary>
    public class Tile : ViewModelBase
    {
        /// <summary>
        /// Permet de savoir si la tile est selectionnable
        /// </summary>
        private bool selected;
        /// <summary>
        /// Permet d'avoir une reference vers le board
        /// <see cref="Diaballik.Board" />
        /// </summary>
        private Board board;
        /// <summary>
        /// Si la tile contient une piece on la reference
        /// <see cref="Diaballik.Piece"/>
        /// </summary>
        private Piece piece;
        /// <summary>
        /// Les coordonnées de la piece
        /// </summary>
        private int line, column;
        /// <summary>
        /// Vrai si la tile est inactive (aucune action exterieur peut être fait)
        /// </summary>
        private bool idle = false;

        /// <summary>
        /// Initialise une instance de <see cref="Tile"/> class.
        /// </summary>
        /// <param name="board">Le plateau</param>
        /// <param name="line">Coordonnée (ligne)</param>
        /// <param name="column">Coordonnée (colonne)</param>
        public Tile(Board board,int line,int column) 
        {
            this.selected = false;
            this.piece = null;
            this.board = board;
            this.line = line;
            this.column = column;
        }

        /// <summary>
        /// Initialise une instance de <see cref="Tile"/> class.
        /// </summary>
        /// <param name="board">Le plateau</param>
        /// <param name="line">Coordonnée (ligne)</param>
        /// <param name="column">Coordonnée (colonne)</param>
        /// <param name="idle">Inactivite de la tile</param>
        public Tile(Board board, int line, int column,bool idle) : this(board,line,column)
        {
            this.idle = idle;
        }

        /// <summary>
        /// Getter et setter d'une piece
        /// </summary>
        /// <value>
        /// Piece
        /// </value>
        public Piece Piece
        {
            get
            {
                return this.piece;
            }

            set
            {
                this.piece = value;
                RaisePropertyChanged("Piece");
            }
        }

        /// <summary>
        /// getter si la tile est selectionnée
        /// </summary>
        public bool Selected
        {
            get
            {
                return this.selected;
            }
            set
            {
                this.selected = value;
                RaisePropertyChanged("Selected");
            }
        }

        /// <summary>
        /// Getter du plateau
        /// </summary>
        /// <value>
        /// Le plateau
        /// </value>
        public Board Board
        {
            get
            {
                return this.board;
            }

        }

        /// <summary>
        /// getter de la ligne.
        /// </summary>
        /// <value>
        /// Numero de ligne
        /// </value>
        public int Line
        {
            get
            {
                return this.line;
            }
        }

        /// <summary>
        /// Getter de la colonne
        /// </summary>
        /// <value>
        /// Numero de colonne
        /// </value>
        public int Column
        {
            get
            {
                return this.column;
            }
        }

        /// <summary>
        /// Permet de savoir si la tile à une piece
        /// </summary>
        /// <returns>
        ///   <c>true</c> si la tile à une piece; sinon, <c>false</c>.
        /// </returns>
        public Boolean hasPiece()
        {
            return this.piece != null;
        }

        /// <summary>
        /// permet de selectionner la tile
        /// </summary>
        public void setSelected()
        {
            Selected = true;
        }

        /// <summary>
        /// Permet de deselectionner la tile
        /// </summary>
        public void unSelected()
        {
            Selected = false;
        }

        /// <summary>
        /// Setter de la balle pour une pièce
        /// </summary>
        /// <param name="b">Balle.</param>
        public void setBall(Ball b)
        {
            if (Piece != null)
            {
                Piece.Ball = b;
                RaisePropertyChanged("Piece");
            }

        }

        /// <summary>
        /// Envoit une commande en fonction du statut de la tile
        /// </summary>
        public void buildDecision()
        {
            if (!idle)
            {
                
                Command cm;
                if (hasPiece())
                {
                    if (this.piece.hasBall())
                    {
                        cm = new SelectionBall(this);
                    }
                    else if (selected)
                    {
                        cm = new MoveBall(this);
                    }
                    else
                    {
                        cm = new SelectionPiece(this);
                    }
                    board.sendCommand(cm);
                }
                else if (selected)
                {
                    cm = new MovePiece(this);                  
                    board.sendCommand(cm);
                }
            }

        }

        /// <summary>
        /// Pour un humain permet d'envoyer une commande
        /// </summary>
        /// <param name="p">un joueur</param>
        /// <returns>
        ///   <c>true</c> si une commande a ete envoyée ; sinon, <c>false</c>.
        /// </returns>
        public bool click(Player p)
        {
            bool ret = false;
            if (!idle)
            {
                if (selected && p.Canplay)
                {
                    buildDecision();
                    ret = true;
                }
                else if (hasPiece() && piece.Player.Equals(p) && p.Canplay && Piece.Player.getType() == Player.PLAYER_TYPE.HUMAN)
                {
                    buildDecision();
                    ret = true;
                }
            }
            return ret;
        }

        /// <summary>
        /// Permet de créer un memento de la tile
        /// </summary>
        /// <returns>un memento
        /// <see cref="Diaballik.Memento.MementoObject"/>
        /// </returns>
        public MementoObject createMemento()
        {
            MementoObject ret;
            if (hasPiece())
            {
                ret = new MementoObject(this.piece.clone());
            }
            else ret = new MementoObject();
            return ret;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Diaballik.Memento;

namespace Diaballik
{
    /// <summary>
    /// Classe qui permet de gérer un plateau
    /// </summary>
    public class Board
    {
        /// <summary>
        /// Tableau qui represente un plateau avec des cases
        /// </summary>
        private Tile[,] tiles;
        /// <summary>
        /// Permet de gérer les etats des cases
        /// </summary>
        private MementoManager mementoManager;
        /// <summary>
        /// Taille du plateau
        /// </summary>
        private int sizeBoard;
        /// <summary>
        /// Id du jeu dans la base de données
        /// </summary>
        private int gameID;

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="sizeBoard">Taille du plateau</param>
        public Board(int sizeBoard)
        {
            this.sizeBoard = sizeBoard;
            tiles = new Tile[sizeBoard,sizeBoard];
            for (int i = 0; i < sizeBoard; i++) for (int j = 0; j < sizeBoard; j++) tiles[i, j] = new Tile(this,i,j);
            mementoManager = new MementoManager();
        }

        /// <summary>
        /// Constructeur du plateau en à partir d'une ancienne partie
        /// </summary>
        /// <param name="lastestBoard">Ancienne partie</param>
        /// <param name="p1">Joueur 1</param>
        /// <param name="p2">Joueur 2</param>
        public Board(int[] lastestBoard,Player p1,Player p2)
        {
            this.sizeBoard = Properties.DEFAULT_SIZE_BOARD;
            tiles = new Tile[sizeBoard, sizeBoard];
            for (int i = 0; i < sizeBoard; i++)
            {
                for (int j = 0; j < sizeBoard; j++)
                {
                    tiles[i, j] = new Tile(this, i, j);
                    if(lastestBoard[i * sizeBoard + j] == p1.NumberPlayer)
                    {
                        tiles[i, j].Piece = new Piece(p1);
                    }
                    if (lastestBoard[i * sizeBoard + j] == p2.NumberPlayer)
                    {
                        tiles[i, j].Piece = new Piece(p2);
                    }
                    if (lastestBoard[i * sizeBoard + j] == (p1.NumberPlayer+2))
                    {
                        tiles[i, j].Piece = new Piece(p1);
                        tiles[i, j].Piece.Ball = p1.Ball;
                    }
                    if (lastestBoard[i * sizeBoard + j] == (p2.NumberPlayer + 2))
                    {
                        tiles[i, j].Piece = new Piece(p2);
                        tiles[i, j].Piece.Ball = p2.Ball;
                    }
                }
            }
            mementoManager = new MementoManager();
        }

        /// <summary>
        /// Constructeur d'un plateau depuis une ancienne partie avec option de desactivation sur les cases
        /// </summary>
        /// <param name="lastestBoard">Ancien plateau</param>
        /// <param name="p1">Joueur 1</param>
        /// <param name="p2">Joueur 2</param>
        /// <param name="idle">Etat de la case si vrai interaction possible sinon bloquée</param>
        public Board(int[] lastestBoard, Player p1, Player p2,bool idle)
        {
            this.sizeBoard = Properties.DEFAULT_SIZE_BOARD;
            tiles = new Tile[sizeBoard, sizeBoard];
            for (int i = 0; i < sizeBoard; i++)
            {
                for (int j = 0; j < sizeBoard; j++)
                {
                    tiles[i, j] = new Tile(this, i, j,idle);
                    if (lastestBoard[i * sizeBoard + j] == p1.NumberPlayer)
                    {
                        tiles[i, j].Piece = new Piece(p1);
                        
                    }
                    if (lastestBoard[i * sizeBoard + j] == p2.NumberPlayer)
                    {
                        tiles[i, j].Piece = new Piece(p2);
                    }
                    if (lastestBoard[i * sizeBoard + j] == (p1.NumberPlayer + 2))
                    {
                        tiles[i, j].Piece = new Piece(p1);
                        tiles[i, j].Piece.Ball = p1.Ball;
                    }
                    if (lastestBoard[i * sizeBoard + j] == (p2.NumberPlayer + 2))
                    {
                        tiles[i, j].Piece = new Piece(p2);
                        tiles[i, j].Piece.Ball = p2.Ball;
                    }
                }
            }
            mementoManager = new MementoManager();
        }

        /// <summary>
        /// Getter sur le gestionnaire des etats
        /// </summary>
        /// <return>Gestionnaire des etats</return>
        public MementoManager MementoManager {
            get {
                return this.mementoManager;
            }
        }

        /// <summary>
        /// Getter taille du plateau
        /// </summary>
        /// <return>Taille du plateau</return>
        public int SizeBoard
        {
            get
            {
                return this.sizeBoard;
            }

        }

        /// <summary>
        /// Récupère une Tile selon ses coordonnés
        /// </summary>
        /// <param name="line">La ligne</param>
        /// <param name="column">La colonne</param>
        /// <returns>Tile.</returns>
        public Tile getTile(int line,int column)
        {
            return this.tiles[line, column];
        }

        /// <summary>
        /// Envoit la commande pour l'executer
        /// </summary>
        /// <param name="command">La commande</param>
        public void sendCommand(Command command)
        {
            command.execute(this);
        }

        /// <summary>
        /// Convertit le plateau en un tableau 1 dimension d'int pour le transférer au C++
        /// </summary>
        /// <returns>Le plateau sous forme d'un tableau 1D d'int</returns>
        public int[] convertBoardForCpp()
        {
            int[] boardCpp = new int[49];
            for (int i = 0; i < sizeBoard; i++)
            {
                for (int j = 0; j < sizeBoard; j++)
                {
                    if (this.tiles[i, j].Piece == null)
                        boardCpp[i * sizeBoard + j] = 0;
                    else if (this.tiles[i, j].Piece.Ball != null)
                        boardCpp[i * sizeBoard + j] = this.tiles[i, j].Piece.Player.NumberPlayer+2;
                    else if (this.tiles[i, j].Piece != null)
                        boardCpp[i * sizeBoard + j] = this.tiles[i, j].Piece.Player.NumberPlayer;
                }
            }
            return boardCpp;



        }

        /// <summary>
        /// Déselectionne toutes les cases du plateau
        /// </summary>
        public void unSelectedAllTile()
        {
            for (int i = 0; i < sizeBoard; i++)
            {
                for (int j = 0; j < sizeBoard; j++)
                {
                    this.tiles[i, j].unSelected();
                }
            }
        }

        /// <summary>
        /// Récupère le numéro de la ligne d'une Tile
        /// </summary>
        /// <param name="tile">The tile.</param>
        /// <returns>Le numéro de ligne de la Tile</returns>
        public int getLineTile(Tile tile)
        {
            for (int i = 0; i < sizeBoard; i++)
            {
                for (int j = 0; j < sizeBoard; j++)
                {
                    if (this.tiles[i, j].Equals(tile))
                        return i;
                }
            }
            return -1;
        }

        /// <summary>
        /// Récupère le numéro de la colonne d'une Tile
        /// </summary>
        /// <param name="tile">The tile.</param>
        /// <returns>Le numéro de colonne de la Tile</returns>
        public int getColumnTile(Tile tile)
        {
            for (int i = 0; i < sizeBoard; i++)
            {
                for (int j = 0; j < sizeBoard; j++)
                {
                    if (this.tiles[i, j].Equals(tile))
                        return j;
                }
            }
            return -1;
        }

    }
}
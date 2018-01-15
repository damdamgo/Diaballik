using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Diaballik.Memento
{
    /// <summary>
    /// Sauvegarde l'état d'une case
    /// </summary>
    public class MementoObject { 

        /// <summary>
        /// Piece de l'etat de la case
        /// </summary>
        private Piece piece;
        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="piece">Piece de la case</param>
        public MementoObject(Piece piece)
        {
            this.piece = piece;
        }
        /// <summary>
        /// Constructeur qui initialise la piece à null (Case qui ne contient pas de case)
        /// </summary>
        public MementoObject()
        {
            this.piece = null;
        }
        /// <summary>
        /// Retourne la piece associée à l'etat de la case
        /// </summary>
        public Piece Piece
        {
            get
            {
                return this.piece;
            }
        }


    }
}
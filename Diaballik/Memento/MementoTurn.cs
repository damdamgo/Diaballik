using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diaballik.Memento
{
    /// <summary>
    /// Permet de gererl'etat des cases avant un tour 
    /// </summary>
    class MementoTurn
    {
        /// <summary>
        /// Etat de case qui a été selectionnée
        /// </summary>
        public MementoObject Selection { get; set; }
        /// <summary>
        /// Etat de case où l'élément va se positionner
        /// </summary>
        public MementoObject Move { get; set; }
        /// <summary>
        /// Case qui a été selectionnée
        /// </summary>
        public Tile TSelection { get; set; }
        /// <summary>
        /// Case qui va porter l'élément
        /// </summary>
        public Tile TMove { get; set; }
        /// <summary>
        /// Statut de l'action
        /// </summary>
        public Command.COMMAND_ACTION Action { get; set; }

        /// <summary>
        /// Permet de recuperer la chaine de caractère qui définit le mouvement
        /// </summary>
        /// <returns></returns>
        public String dataToString()
        {
            String res = TSelection.Line + ":" + TSelection.Column + ":" + TMove.Line + ":" + TMove.Column + ":" + Action + ":" + Selection.Piece.Player.NumberPlayer;
            return res;
        }

        /// <summary>
        /// Annule le mouvement
        /// </summary>
        public void undoTurn()
        {
            TSelection.Piece = Selection.Piece;
            TMove.Piece = Move.Piece;
        }
    }
}

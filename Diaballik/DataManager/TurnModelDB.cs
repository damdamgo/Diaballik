using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diaballik.DataManager
{
    /// <summary>
    /// Classe qui gere un mouvement
    /// </summary>
    class TurnModelDB
    {
        /// <summary>
        /// Type de mouvement
        /// <see cref="Command.COMMAND_ACTION"/>
        /// </summary>
        public Command.COMMAND_ACTION turnType { get; set; }
        /// <summary>
        /// Ligne du choix de case
        /// </summary>
        public int lineS { get; set; }
        /// <summary>
        /// Colonne du choix de case
        /// </summary>
        public int columnS { get; set; }
        /// <summary>
        /// Ligne de la case destinataire
        /// </summary>
        public int lineE { get; set; }
        /// <summary>
        /// Colonne de la case destinataire
        /// </summary>
        public int columnE { get; set; }
        /// <summary>
        /// Numero du joueur
        /// </summary>
        public int numPlayer { get; set; }
        /// <summary>
        /// Construit un instance de cette classe en fonction d'une chaine de caracteres
        /// </summary>
        /// <param name="data">Chaine de caracteres d'un mouvement</param>
        /// <returns><see cref="Diaballik.DataManager.TurnModelDB"/></returns>
        public static TurnModelDB BuildTurnModelWithString(String data)
        {
            TurnModelDB turn = new TurnModelDB();
            String[] info = data.Split(':');
            turn.lineS = int.Parse(info[0]);
            turn.columnS = int.Parse(info[1]);
            turn.lineE = int.Parse(info[2]);
            turn.columnE = int.Parse(info[3]);
            turn.turnType = (Command.COMMAND_ACTION)Enum.Parse(typeof(Command.COMMAND_ACTION), info[4]);
            turn.numPlayer = int.Parse(info[5]);
            return turn;
        }
    }

    
}

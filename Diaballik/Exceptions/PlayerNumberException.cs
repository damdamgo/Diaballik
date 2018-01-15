using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diaballik.Exceptions
{
    /// <summary>
    /// Exception sur le nombre de joueur d'une partie
    /// </summary>
    public class PlayerNumberException : Exception
    {
        /// <summary>
        /// constructeur
        /// </summary>
        public PlayerNumberException(): base() {

        }
        /// <summary>
        /// constructeur
        /// </summary>
        /// <param name="message">Message de l'exception</param>
        public PlayerNumberException(string message): base(message) 
        {

        }

    }
}

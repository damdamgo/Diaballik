using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diaballik.Exceptions
{
    /// <summary>
    /// Exception pour une même couleur choisie
    /// </summary>
    public class PlayerSameColorException : Exception
    {
        /// <summary>
        /// constructeur
        /// </summary>
        public PlayerSameColorException(): base() {

        }
        /// <summary>
        /// constructeur
        /// </summary>
        /// <param name="message">Message de l'exception</param>
        public PlayerSameColorException(string message): base(message) 
        {

        }
    }
}

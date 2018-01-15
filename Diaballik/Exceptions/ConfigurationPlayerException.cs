using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diaballik.Exceptions
{
    /// <summary>
    /// Exception pour un problème de configuration de joueur
    /// </summary>
    public class ConfigurationPlayerException : Exception
    {
        /// <summary>
        /// constructeur
        /// </summary>
        public ConfigurationPlayerException(): base() {

        }
        /// <summary>
        /// constructeur
        /// </summary>
        /// <param name="message">Message de l'exception</param>
        public ConfigurationPlayerException(string message): base(message) 
        {

        }
    }
}

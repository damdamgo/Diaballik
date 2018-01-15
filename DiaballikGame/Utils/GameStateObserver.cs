using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiaballikGame.Welcome;

namespace DiaballikGame.Utils
{
    /// <summary>
    /// interface pour observer le statut du jeu
    /// </summary>
    public interface GameStateObserver
    {
        void notify(Properties.STATE_GAME state);
    }
}

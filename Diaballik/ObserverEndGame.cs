using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diaballik
{
    public interface ObserverEndGame
    {
        void gameEnded(Game game,int playerNum);
    }
}

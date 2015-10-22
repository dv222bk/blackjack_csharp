using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model.rules
{
    class PlayerWinsOnTiedStrategy : IWinStrategy
    {
        public bool IsDealerWinner(model.Player a_player, model.Dealer a_dealer, int maxScore)
        {
            if (a_player.CalcScore() > maxScore)
            {
                return true;
            }
            else if (a_dealer.CalcScore() > maxScore)
            {
                return false;
            }

            return a_dealer.CalcScore() > a_player.CalcScore();
        }
    }
}

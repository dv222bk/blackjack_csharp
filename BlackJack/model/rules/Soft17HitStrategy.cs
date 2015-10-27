using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model.rules
{
    class Soft17HitStrategy : IHitStrategy
    {
        private const int g_hitLimit = 17;

        public bool DoHit(model.Player a_dealer)
        {
            if (a_dealer.CalcScore() == g_hitLimit)
            {
                int otherValue = 0;
                bool aceFound = false;
                int[] cardScores = new int[(int)model.Card.Value.Count] { 2, 3, 4, 5, 6, 7, 8, 9, 10, 10, 10, 10, 11 };

                foreach (Card card in a_dealer.GetHand())
                {
                    if (card.GetValue() == Card.Value.Ace && !aceFound)
                    {
                        aceFound = true;
                    } else {
                        otherValue += cardScores[(int)card.GetValue()];
                        if (otherValue > 6)
                        {
                            return false;
                        }
                    }
                }
                if (otherValue == 6 && aceFound)
                {
                    return true;
                }
            }
            return a_dealer.CalcScore() < g_hitLimit;
        }
    }
}

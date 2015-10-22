﻿using System;
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
            if (a_dealer.CalcScore() < g_hitLimit)
            {
                return true;
            }
            else if (a_dealer.CalcScore() == g_hitLimit)
            {
                int totalValue = 0;
                bool aceFound = false;
                foreach (Card card in a_dealer.GetHand())
                {
                    if (card.GetValue() == Card.Value.Ace)
                    {
                        aceFound = true;
                    } else {
                        totalValue += (int)card.GetValue();
                        if (totalValue > 6)
                        {
                            return false;
                        }
                    }
                }
                if (totalValue == 6 && aceFound)
                {
                    return true;
                }
            }
            return false;
        }
    }
}

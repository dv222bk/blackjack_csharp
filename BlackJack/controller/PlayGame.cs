using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.controller
{
    class PlayGame
    {
        public bool Play(model.Game a_game, view.IView a_view)
        {
            a_view.DisplayWelcomeMessage();
            
            a_view.DisplayDealerHand(a_game.GetDealerHand(), a_game.GetDealerScore());
            a_view.DisplayPlayerHand(a_game.GetPlayerHand(), a_game.GetPlayerScore());

            if (a_game.IsGameOver())
            {
                a_view.DisplayGameOver(a_game.IsDealerWinner());
            }

            BlackJack.view.Event inputEvent = a_view.GetEvent();

            if (inputEvent == BlackJack.view.Event.Start)
            {
                a_game.NewGame();
            }
            else if (inputEvent == BlackJack.view.Event.Hit)
            {
                a_game.Hit();
            }
            else if (inputEvent == BlackJack.view.Event.Stand)
            {
                a_game.Stand();
            }
            else if (inputEvent == BlackJack.view.Event.Quit)
            {
                return false;
            }

            return true;
        }
    }
}

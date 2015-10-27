using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.controller
{
    class PlayGame : model.GameObserver
    {
        private model.Game m_game;
        private view.IView m_view;

        public PlayGame(model.Game a_game, view.IView a_view)
        {
            m_game = a_game;
            m_view = a_view;
            a_game.AddObserver(this);
        }

        public bool Play()
        {
            m_view.DisplayWelcomeMessage();
            
            m_view.DisplayDealerHand(m_game.GetDealerHand(), m_game.GetDealerScore());
            m_view.DisplayPlayerHand(m_game.GetPlayerHand(), m_game.GetPlayerScore());

            if (m_game.IsGameOver())
            {
                m_view.DisplayGameOver(m_game.IsDealerWinner());
            }

            BlackJack.view.Event inputEvent = m_view.GetEvent();

            if (inputEvent == BlackJack.view.Event.Start)
            {
                m_game.NewGame();
            }
            else if (inputEvent == BlackJack.view.Event.Hit)
            {
                m_game.Hit();
            }
            else if (inputEvent == BlackJack.view.Event.Stand)
            {
                m_game.Stand();
            }
            else if (inputEvent == BlackJack.view.Event.Quit)
            {
                return false;
            }

            return true;
        }

        public void Update()
        {
            m_view.PauseGame();
            m_view.DisplayWelcomeMessage();
            m_view.DisplayDealerHand(m_game.GetDealerHand(), m_game.GetDealerScore());
            m_view.DisplayPlayerHand(m_game.GetPlayerHand(), m_game.GetPlayerScore());
        }
    }
}

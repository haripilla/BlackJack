using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackNew
{
    public class BlackJackGame
    {
        private Player _player;
        private Dealer _dealer;
        private DeckofCards _deck;
        private List<Card> _discardPile;

        public bool HasGoneOver21 { get; private set; }

        public void play()
        {
            _discardPile = new List<Card>();
            
            // Create a Player
            _player = new Player();
            // Create a Dealer
            _dealer = new Dealer();
            // Create a Some Card


            _deck = new DeckofCards();
            _deck.Shuffle();

            while (true)
            {


                List<Card> discards;
                discards = _player.ClearYourHand();
                _discardPile.AddRange(discards);
                discards = _dealer.ClearYourHand();
                _discardPile.AddRange(discards);


                Card cardToDeal;
                cardToDeal = GetTopCardFroDeck();
                _player.PutInHand(cardToDeal);

                cardToDeal = GetTopCardFroDeck();
                _dealer.PutInHand(cardToDeal);

                cardToDeal = GetTopCardFroDeck();
                _player.PutInHand(cardToDeal);

                cardToDeal = GetTopCardFroDeck();
                _dealer.PutInHand(cardToDeal);

                Console.Clear();
                PrintTheGame();

                while (_player.HasNotGoneOver21() && _player.WantsAnotherTopCard())
                {
                    cardToDeal = GetTopCardFroDeck();
                    _player.PutInHand(cardToDeal);
                    PrintTheGame();
                }
                if (_player.HasGoneOver21())
                {
                    Console.WriteLine("You have lost Milion");
                    Console.WriteLine("it's bad day in your life ");
                }
                else
                {
                    _dealer.ShowallOFYourCards();
                    while (_dealer.HasNotGoneOver21() && _dealer.WantsAnotherTopCard())
                    {
                        cardToDeal = GetTopCardFroDeck();
                        _dealer.PutInHand(cardToDeal);
                    }
                    PrintTheGame();
                    if (_dealer.HasGoneOver21())
                    {
                        Console.WriteLine("you Win, this time, Humen");
                    }
                    else if (_player.TotalOfHand() >= _dealer.TotalOfHand())
                    {
                        Console.WriteLine("you Win, this time, Humen");
                    }
                    else
                    {
                        Console.WriteLine("you have lost, puny Humen");
                        Console.WriteLine("your have lost, puny Humen");
                    }

                }

                Console.WriteLine("Press any Key but N and Enter to Play another hand");
                string input = Console.ReadLine().ToLower();
                if (input == "n")
                {
                    break;
                }

            }
        }

        private Card GetTopCardFroDeck()
        {
            if (_deck.AreYouEmpty())
            {
                _deck.Restock(_discardPile);
                _discardPile.Clear();
                _deck.Shuffle();
            }
            return _deck.GiveMeTopCard();
        }

        private void PrintTheGame()
        {
            Console.Clear();
            Console.WriteLine(_player);
            Console.WriteLine(_dealer);
        }
    }
}

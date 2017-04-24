using System;
using System.Collections.Generic;

namespace BlackJackNew
{
    public class Dealer
    {
        public Dealer()
        {
            _hand = new List<Card>();
            _shouldShowAllCards = false;

        }
        public void PutInHand(Card incodmingCard)
        {
            _hand.Add(incodmingCard);
        }

        public override string ToString()
        {

            if (_shouldShowAllCards)
            {
                return string.Join(",", _hand);
            }
            else
            {
                return $"{_hand[0]}, ????";
            }
          
        }

        public bool HasNotGoneOver21()
        {
             return TotalOfHand() <= 21;
        }

        public List<Card> ClearYourHand()
        {
            //_hand.Clear();
            _shouldShowAllCards = false;
            List<Card> oldHand = _hand;
            _hand = new List<Card>();
            return oldHand;
            
        }

        public bool HasGoneOver21()
        {
            return TotalOfHand() > 21;
        }

        public int TotalOfHand()
        {
            int TotalOfHand = 0;
            foreach (Card card in _hand)
            {
                TotalOfHand += card.GetValue();
            }
            return TotalOfHand;
        }

        public bool WantsAnotherTopCard()
        {

            return TotalOfHand() < 17;

            //Console.WriteLine("Deal Woul you like another Card ? Y/N ");
            //string input = Console.ReadLine().ToLower();
            //while (input != "y" && input != "n")
            //{
            //    Console.WriteLine("Please enter 'y' or 'n'");
            //    input = Console.ReadLine().ToLower();
            //}
            //return input == "y";
        }

        public void ShowallOFYourCards()
        {
            _shouldShowAllCards = true;
            
        }

        private List<Card> _hand;
        private bool _shouldShowAllCards;
        
    }
}
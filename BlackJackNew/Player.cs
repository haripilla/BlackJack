using System;
using System.Collections.Generic;

namespace BlackJackNew
{
    public class Player
    {
        public Player()
        {
            _hand = new List<Card>();
        }
        public void PutInHand(Card incodmingCard)
        {
            _hand.Add(incodmingCard);
        }

        public override string ToString()  
        {
            return string.Join(",",_hand);
        }

        public bool HasNotGoneOver21()
        {
            return TotalOfHand() <= 21;
        }

        public  bool HasGoneOver21()
        {
            return TotalOfHand()  > 21;
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

        public List<Card> ClearYourHand()
        {
            List<Card> oldHand = _hand;
            _hand = new List<Card>();
            return oldHand;
            //and.Clear();
        }

        public bool WantsAnotherTopCard()
        {
            Console.WriteLine("Would you like another Card ? Y/N ");
            string input = Console.ReadLine().ToLower();
            while (input != "y" && input != "n")
            {
                Console.WriteLine("Please enter 'y' or 'n'");
                input = Console.ReadLine().ToLower();
            }
            return input == "y";
        }


        private List<Card> _hand;

        
    }

}
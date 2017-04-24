using System;
using System.Collections.Generic;

namespace BlackJackNew
{
    public class DeckofCards
    {
        private List<Card> _cards;
        public DeckofCards()
        {
            _cards = new List<Card>();

            string[] suits = new string[] { "Hearts", "Spades", "Diamonds", "Clubs" };
            //string[] suits = new string[] { "Hearts" };
            int[] values = new int[] { 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            foreach (string suit in suits)
            {

                _cards.Add(new AceCard(suit));

                foreach (int value in values)
                {
                    _cards.Add(new NumberCard(suit, value));

                }
                _cards.Add(new FaceCard("Jack", suit));
                _cards.Add(new FaceCard("Queen", suit));
                _cards.Add(new FaceCard("King", suit));

            }
        }

        public Card GiveMeTopCard()
        {
            Card card = _cards[0];
            _cards.RemoveAt(0);
            return card;
        }

        public void Shuffle()
        {
            Random random = new Random();
            for (int i = 0; i < 7; i++)
            {
                List<Card> left = new List<Card>();
                List<Card> right = new List<Card>();
                //bool putCardInLeftPile = true;
                //foreach (Card card in _cards)
                //{
                //    if (putCardInLeftPile)
                //    {
                //        left.Add(card);
                //    }
                //    else
                //    {
                //        right.Add(card);
                //    }
                //    putCardInLeftPile = !putCardInLeftPile;
                //}

                for (int j = 0; j < _cards.Count; j++)
                {
                    if (j < _cards.Count/2)
                    {
                        Card cardTomove = _cards[j];
                        left.Add(cardTomove);
                    }
                    else
                    {
                        Card cardTomove = _cards[j];
                        right.Add(cardTomove);
                    }
                }
                


                _cards.Clear();
                while (left.Count > 0 || right.Count > 0)
                {
                    if (left.Count == 0)
                    {
                        _cards.AddRange(right);
                        right.Clear();
                    }
                    else if (right.Count == 0)
                    {
                        _cards.AddRange(left);
                        left.Clear();
                    }
                    else
                    {
                        int choice = random.Next(2);
                        if (choice == 0)
                        {
                            Card card = left[0];
                            left.RemoveAt(0);
                            _cards.Add(card);
                        }
                        else
                        {
                            Card card = right[0];
                            right.RemoveAt(0);
                            _cards.Add(card);
                        }
                    }

                }
            }
            Console.WriteLine($"you have {_cards.Count} cards");
            foreach (Card card in _cards)
            {
                Console.WriteLine(card);
            }
            //Console.ReadLine();

        }

        public bool AreYouEmpty()
        {
            return _cards.Count == 0;
        }

        public void Restock(List<Card> _discardPile)
        {
            _cards.AddRange(_discardPile);
        }
    }
    
}
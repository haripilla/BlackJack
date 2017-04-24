namespace BlackJackNew
{
    internal class NumberCard : Card
    {
        //private string suit;
        //private int value;

        public NumberCard(string suit, int value)
            :base(value.ToString(),suit,value)
        {

        }
    }
}
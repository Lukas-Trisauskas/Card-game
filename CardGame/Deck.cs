using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;


namespace CardGame
{
    class Deck
    {
        private List<Card> cards = new List<Card>();

        public List<Card> Cards
        {
            get { return cards; }
            private set { cards = value; }
        }
        public Deck()
        {

        string[] suits = new string[] { "Clubs", "Diamonds", "Hearts", "Spades" };
        int[] ranks = Enumerable.Range(2, 13).ToArray();

            for (int i = 0; i < suits.Length; i++)
            {
                for (int j = 0; j < ranks.Length; j++)
                {
                    cards.Add(new Card(suits[i], ranks[j]));
                }
            }
        }

        public bool Empty()
        {
            if (cards.Count == 0) return true;
            return false;
        }

        /* Recursive method */

        public List<Card> Shuffle(int times)
        {
            if (times >= 1)
            {
                SwapCards();
                Shuffle(times - 1);
            }
            return this.cards;
        }
        
        /* A protected and private method that can only be used within its class */

        protected private void SwapCards()
        {
            Random rand = new Random();
            int count = cards.Count;
            
            for (int i = 0; i < count; i++)
            {
                int next = rand.Next(count);
                var temp = cards[next];

                int position = cards.IndexOf(cards[count - 1]);
                cards[next] = cards[position];
                cards[position] = temp;
                count--;
            }
        }

        public List<Card> Deal(int start, int end)
        {
            var temp = cards.GetRange(start, end);
            cards.RemoveRange(start, end);
            return temp;
        }
        public Card GetRandom(int index)
        {
            if (cards.Count != 0)
            {
                return cards[index];
            }
            return null;
        }
    }
}

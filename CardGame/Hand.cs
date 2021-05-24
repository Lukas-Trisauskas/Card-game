using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CardGame
{
    class Hand
    {
        private List<Card> myCards = new List<Card>();
        private List<Card> remainingCards = new List<Card>();


        public List<Card> MyCards
        {
            get { return myCards;  }
            set { myCards = value; }
        }
        public List<Card> RemainingCards
        {
            get { return remainingCards; }
        }
        public int Count
        {
            get { return myCards.Count; }
        }
        public Hand(List<Card> cards)
        {

            foreach (var item in cards)
            {
                myCards.Add(item);
            }

            this.remainingCards = Program.ReturnDeck();
        }
    }
}

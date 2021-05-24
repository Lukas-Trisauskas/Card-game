using System;
using System.Collections.Generic;
using System.Text;

namespace CardGame
{
    class Computer : Player
    {
        public Computer(List<Card> myCards)
        {
            this.hands = new Hand(myCards);
            this.score = 0;
            this.id = 2;
            this.total = total;
            this.hand = new List<Card>();
        }

        // this is where I override both abstract methods

        public override void Play(bool tie)
        {
            Random rand = new Random();
            if (!tie)
            {
                for (int i = 0; i < 2; i++)
                {
                    int index = rand.Next(hands.Count);
                    hand.Add(hands.MyCards[index]);
                    hands.MyCards.RemoveAt(index);
                }
            }
            else
            {
                int index = rand.Next(hands.RemainingCards.Count);
                hand.Add(Program.ReturnDeck()[index]);
                hands.RemainingCards.RemoveAt(index);
            }
            CalculateTotal(tie);
        }
        public override string ToString()
        {
            return string.Format($"Computer -> score: {score}");
        }

    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CardGame
{
    sealed class Card
    {
        public string suit { get; private set; }
        public int rank { get; private set; }
        public string face { get; private set; }

        public Card(string suit, int rank)
        {
            this.suit = suit;
            this.rank = rank;

            Dictionary<int, string> temp = new Dictionary<int, string>
            {
                { 11, "J" },
                { 12, "Q" },
                { 13, "K" }, 
                { 14, "A" },
            };

            //Changes rank value that is equal to the dict key and assigns the key -> value to face

            foreach (KeyValuePair<int, string> item in temp)
            {
                if (rank == item.Key) 
                    face = item.Value;
            }
        }
        public override string ToString()
        {
            //Changes the representation of rank values within 11-14 range without losing its actual value e.g. 11 = Jack
            //Rank values between 2-10 range are not changed

            if (Enumerable.Range(11,14).Contains(rank)) 
                return string.Format("{0} of {1}", face, suit);
            return string.Format("{0} of {1}", rank, suit);
        }
        
    }

}

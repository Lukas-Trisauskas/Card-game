using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace CardGame
{
    abstract class Player : IComparable<Player>
    {
        // fields such as hands and hand list are protected from being changed outside.

        public Hand hands { get; protected set; }
        public List<Card> hand { get; protected set; }

        public int id    { get; set; }
        public int score { get; set; }
        public int total { get; protected set; }
        public static bool amendCompareTo { get; set; }


        // These are only the two abstract methods that are used and overriden in derived classes

        public abstract override string ToString();
        public abstract void Play(bool gameTie);



        public Action<Card> print = x => Console.WriteLine(x);
        protected void RemoveHand(List<Card> targetList) => targetList.RemoveAll(x => hand.Contains(x));

        protected void CalculateTotal(bool tie)
        {
            if (tie)
            {
                total = hand[0].rank;
            }
            else
            {
                total = hand[0].rank + hand[1].rank;
            }
        }
        public void PrintHand() => hand.ForEach(print);
        public void ResetHand() => hand.Clear();
        public void PrintHands(bool tie)
        {
            if (!tie)
            {
                for (int i = 0; i < hands.Count; i++)
                {
                    Console.WriteLine(i + ". " + hands.MyCards[i]);
                }
            }
        }

        // Here is where I perform method overloading / operator overloading

        public int CompareTo(Player other)
        {
            if (this > other) return  1; 
            if (this < other) return -1; 
            return 0;
        }
        public static bool operator > (Player left, Player right)
        {
            if (amendCompareTo)
            {
                return left.score > right.score;
            }
            return left.total > right.total;
        }
        public static bool operator < (Player left, Player right)
        {
            if (amendCompareTo)
            {
                return left.score < right.score;
            }
            return left.total < right.total;
        }
    }
}
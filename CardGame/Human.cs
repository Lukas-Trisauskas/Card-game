using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Diagnostics.CodeAnalysis;

namespace CardGame
{
     // multiple inheritance and interfaces
    class Human : Player, IEquatable<Computer>
    {
        private List<int> indexList = new List<int>();
        public Human(List<Card> myCards)
        {
            this.hands = new Hand(myCards);
            this.score = 0;
            this.id = 1;
            this.total = total;
            this.hand = new List<Card>();
            
        }
        private bool CheckRange(int index, List<Card> targetList) => (index - targetList.Count - 1) * (index - 0) <= 0;
        private bool CheckKey(int index) => indexList.Contains(index);



        // this is where I override both abstract methods
        public override string ToString()
        {
            return string.Format($"Human -> score: {score}");
        }
        public override void Play(bool tie)
        {
            if (tie)
            {
                while (hand.Count != 1)
                {
                    Console.Write("Select a number between 0 and " + (hands.RemainingCards.Count - 1) + ": ");
                    string userInput = Console.ReadLine().Trim();
                    AddCard(userInput, tie, hands.RemainingCards);
                }
                CalculateTotal(tie);
                RemoveHand(hands.RemainingCards);
            }
            else
            {
                int i = 0;
                while (hand.Count != 2)
                {
                    string[] text = new string[] { "1st", "2nd" };
                    Console.Write($"Select your {text[i]} card: ");
                    string userInput = Console.ReadLine().Trim();
                    i += AddCard(userInput, tie, hands.MyCards);
                }
                CalculateTotal(tie);
                RemoveHand(hands.MyCards);
            }
            PrintHand();
            Console.WriteLine("Total: " + total);
            indexList.Clear();
        }

        // this is where I used exceptions and also use 1 of my own custom exceptions
        // KeyException: This prevents the player from selecting the same card twice
        // after all the checks, the userInput is used as index to add the card from Hand into -
        // my temporary hand.

        private int AddCard(string userInput, bool tie, List<Card> targetList)
        {
            int i = 0;
            try
            {
                if (string.IsNullOrEmpty(userInput))
                {
                    throw new FormatException();
                }
                else if (!CheckRange(int.Parse(userInput), targetList))
                {
                    throw new ArgumentOutOfRangeException();
                }
                else if (CheckKey(int.Parse(userInput)))
                {
                    throw new KeyException();
                }
                else if (tie)
                {
                    hand.Add(Program.ReturnDeck()[int.Parse(userInput)]);
                    Program.ReturnDeck().RemoveAt(int.Parse(userInput));
                }
                else
                {
                    hand.Add(hands.MyCards[int.Parse(userInput)]);
                    i++;
                }
                indexList.Add(int.Parse(userInput));
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine($"the number you've entered is not in range");
            }
            catch (FormatException)
            {
                Console.WriteLine("invalid type, must be a number to continue..");
            }
            catch (KeyException)
            {
                Console.WriteLine("you already selected that");
            }
            return i;
        }


        // Here is where I perform method overloading / operator overloading

        public bool Equals(Computer other)
        {
            if (this.total == 0 || other.total == 0) return false;
            return this.total == other.total;
        }
        public static bool operator == (Human left, Computer right)
        {
            return left.Equals(right);
        }
        public static bool operator != (Human left, Computer right)
        {
            return !left.Equals(right);
        }
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

    }
}

using System;
using System.Linq;
using System.Collections.Generic;

namespace CardGame
{
    class Program
    {
        public delegate List<Card> Dealer(int start, int end);

        private static Deck newDeck;
        private static Deck newDeck1;

        private static Human player1;
        private static Computer player2;

        private static Player nextPlayer;
        private static Player prevPlayer;

        static void Main()
        {
            // this is where I instantiate new instance of a deck and both player classes
            // each player is dealt 10 cards, from a shuffled deck.
            // the shuffle algorithm, shuffles recursively, in this this case, it's set to 10

            newDeck = new Deck();
            Dealer deal = newDeck.Deal;

            //newDeck.Shuffle(10);

            newDeck1 = new Deck();
            Dealer deal1 = newDeck1.Deal;


            player2 = new Computer(deal(0,4));
            player1 = new Human(deal1(0, 4));

            nextPlayer = player1;
            prevPlayer = nextPlayer;

            Lincoln match = new Lincoln(player1, player2, prevPlayer);

            bool gameTie = false;
            Player player = null;

            while (true)
            {
                if (player1.hands.Count != 0 && player2.hands.Count != 0)
                {
                    Launch(gameTie);
                }
                else if (gameTie)
                {
                    Console.WriteLine("The game is a tie!");
                    Launch(gameTie);
                }
                else if (player != null)
                {
                    Console.WriteLine("The winner is: " + player!);
                    break;
                    
                }
                // checks and updates the state of the match.
                match.CheckState();

                // assigns the next player
                nextPlayer = match.GetNextPlayer();

                // if there is no winner, it will be set to null
                player = match.CheckForWin();
                gameTie = match.CheckForTie();

                Console.WriteLine(player1);
                Console.WriteLine(player2);

                // resets the hand that holds 2 cards, for the next 2 cards
                player1.ResetHand();
                player2.ResetHand();
            }
            Restart();
        }
        public static List<Card> ReturnDeck()
        {
            return newDeck.Cards;
        }
        public static void Launch(bool gameTie)
        {
            for (int i = 0; i < 2; i++)
            {
                if (nextPlayer == player1)
                {
                    player1.PrintHands(gameTie);
                    Console.WriteLine("Human plays: ");
                    player1.Play(gameTie);
                    Console.WriteLine("-------------");
                    nextPlayer = player2;
                }
                else if (nextPlayer == player2)
                {
                    Console.WriteLine("Computer plays: ");
                    player2.Play(gameTie);
                    player2.PrintHand();
                    Console.WriteLine("Total: " + player2.total);
                    Console.WriteLine("-------------");
                    nextPlayer = player1;
                }
            }
        }
        public static void Restart()
        {
            while (true)
            {
                try
                {
                    Console.Write("Would you like to play again? (y/n): ");
                    string userInput = Console.ReadLine().ToLower().Trim();

                    if (userInput == "y")
                    {
                        Main();
                    }
                    else if (userInput == "n")
                    {
                        Console.WriteLine("Thank you for playing.");
                        Environment.Exit(0);
                    }
                    else
                    {
                        throw new FormatException();
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Enter (y/n) to continue.");
                }
            }
        }
    }
}
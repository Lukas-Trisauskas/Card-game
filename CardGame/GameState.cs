using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace CardGame
{
    class GameState
    {
        
        public Human    player1  { get; private set; }
        public Computer player2  { get; private set; }

        public Player prevPlayer { get; private set; }
        public Player nextPlayer { get; private set; }

        public int pointAccumulator { get; private set; }
        public bool continued { get; private set; }

        public GameState(Human player1, Computer player2, Player prevPlayer)
        {
            this.player1 = player1;
            this.player2 = player2;
            this.prevPlayer = prevPlayer;
        }

        // checks what conditions are met and updates the state of the match
        public void CheckState()
        {
            if (player1 > player2)
            {
                Console.WriteLine("Player1 wins the hand!!");
                nextPlayer = player1;
                player1.score++;
                CheckRound(player1);
            }
            else if (player2 > player1)
            {
                Console.WriteLine("Player2 wins the hand!!");
                nextPlayer = player2;
                player2.score++;
                CheckRound(player2);
            }
            else if (player1 == player2)
            {
                Console.WriteLine("Hand values are the same, round continued to next hand...");
                continued = true;
                pointAccumulator++;
                if (prevPlayer == player1) nextPlayer = player2;
                nextPlayer = player1;
            }
        }
        // if handContinued is true it will add the accumilated points to the player who won
        public void CheckRound(Player obj)
        {
            if (continued)
            {
                obj.score += pointAccumulator;
                continued = false;
            }
        }
        // returns the next assigned player
        public Player GetNextPlayer()
        {
            return nextPlayer;
        }
        // finds which player has most hand wins and assigns that player to winner.
        public Player CheckForWin()
        {
            if ((player1.hands.Count == 0 && player2.hands.Count == 0) && (player1.score > player2.score))
            {
                return player1;
            }
            return player2;
        }
        public bool CheckForTie()
        {
            if ((player1.hands.Count == 0 && player2.hands.Count == 0) && (player1.score == player2.score))
            {
                return true;
            }
            return false;
        }
    }
}


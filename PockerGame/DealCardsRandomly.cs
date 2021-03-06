using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace PockerGame
{
    class DealCardsRandomly : CardsDeck
    {
        private Card[] player1Hand;
        private Card[] sortedPlayer1Hand;

        private Card[] player2Hand;
        private Card[] sortedPlayer2Hand;

        private Card[] player3Hand;
        private Card[] sortedPlayer3Hand;

        private Card[] player4Hand;
        private Card[] sortedPlayer4Hand;

        public DealCardsRandomly()
        {
            player1Hand = new Card[5];
            player2Hand = new Card[5];
            player3Hand = new Card[5];
            player4Hand = new Card[5];
            sortedPlayer1Hand = new Card[5];
            sortedPlayer2Hand = new Card[5];
            sortedPlayer3Hand = new Card[5];
            sortedPlayer4Hand = new Card[5];

        }

        public void DealCards()
        {
            generateDeck();
            getHand();
            sortCards();
            displayCards();
            identifyHands();
        }

        private void identifyHands()
        {
            //create player's hand idenfication objects (passing SORTED hand to constructor)
            HandIdentifier player1HandIdentifier = new HandIdentifier(sortedPlayer1Hand);
            HandIdentifier player2HandIdentifier = new HandIdentifier(sortedPlayer2Hand);
            HandIdentifier player3HandIdentifier = new HandIdentifier(sortedPlayer3Hand);
            HandIdentifier player4HandIdentifier = new HandIdentifier(sortedPlayer4Hand);

            //get the players hand
            Hand player1Hand = player1HandIdentifier.EvaluateHand();
            Hand player2Hand = player2HandIdentifier.EvaluateHand();
            Hand player3Hand = player3HandIdentifier.EvaluateHand();
            Hand player4Hand = player4HandIdentifier.EvaluateHand();


            //display each hand
            Console.WriteLine("\nPlayer 1's Hand: " + player1Hand);
            Console.WriteLine("\nPlayer 2's Hand: " + player2Hand);
            Console.WriteLine("\nPlayer 3's Hand: " + player3Hand);
            Console.WriteLine("\nPlayer 4's Hand: " + player4Hand);
            Console.WriteLine("\n");


            //evaluate hands
            if (player1Hand > player2Hand && player1Hand > player3Hand && player1Hand > player4Hand)
            {
                Console.WriteLine("Player 1 WINS!");
            }
            else if (player2Hand > player1Hand && player2Hand > player3Hand && player2Hand > player4Hand)
            {
                Console.WriteLine("Player 2 WINS!");
            }
            else if (player3Hand > player1Hand && player3Hand > player2Hand && player3Hand > player4Hand)
            {
                Console.WriteLine("Player 3 WINS!");
            }
            else if (player4Hand > player1Hand && player4Hand > player2Hand && player4Hand > player3Hand)
            {
                Console.WriteLine("Player 4 WINS!");
            }
            else //if the hands are the same, evaluate the values
            {
                 Console.WriteLine("Multiple Winners");

                //still more evaluations can be done
            }
        }

        private void displayCards()
        {
            Console.WriteLine("Player 1's Hand ");
            for (int i = 0; i < 5; i++)
            {

                Console.WriteLine($"||{sortedPlayer1Hand[i].SUIT} - {sortedPlayer1Hand[i].VALUE}||");
            }

            Console.WriteLine("\nPlayer 2's Hand");
            for (int i = 0; i < 5; i++)
            {

                Console.WriteLine($"||{sortedPlayer2Hand[i].SUIT} - {sortedPlayer2Hand[i].VALUE}||");
            }

            Console.WriteLine("\nPlayer 3's Hand");
            for (int i = 0; i < 5; i++)
            {

                Console.WriteLine($"||{sortedPlayer3Hand[i].SUIT} - {sortedPlayer3Hand[i].VALUE}||");
            }

            Console.WriteLine("\nPlayer 4's Hand ");
            for (int i = 0; i < 5; i++)
            {

                Console.WriteLine($"||{sortedPlayer4Hand[i].SUIT} - {sortedPlayer4Hand[i].VALUE}||");
            }
        }

        private void sortCards()
        {
            var player1Query = from hand in player1Hand
                               orderby hand.VALUE
                               select hand;
            var player2Query = from hand in player2Hand
                               orderby hand.VALUE
                               select hand;
            var player3Query = from hand in player3Hand
                               orderby hand.VALUE
                               select hand;
            var player4Query = from hand in player4Hand
                               orderby hand.VALUE
                               select hand;

            var index = 0;
            foreach (var element in player1Query.ToList())
            {
                sortedPlayer1Hand[index] = element;
                index++;
            }
            index = 0;
            foreach (var element in player2Query.ToList())
            {
                sortedPlayer2Hand[index] = element;
                index++;
            }
            index = 0;
            foreach (var element in player3Query.ToList())
            {
                sortedPlayer3Hand[index] = element;
                index++;
            }
            index = 0;
            foreach (var element in player4Query.ToList())
            {
                sortedPlayer4Hand[index] = element;
                index++;
            }

        }

        private void getHand()
        {
            for(int i = 0; i < 5; i++)
            {
                player1Hand[i] = getDeck[i];
            }

            for (int i = 5; i < 10; i++)
            {
                player2Hand[i-5] = getDeck[i];
            }

            for (int i = 10; i < 15; i++)
            {
                player3Hand[i-10] = getDeck[i];
            }

            for (int i = 15; i < 20; i++)
            {
                player4Hand[i-15] = getDeck[i];
            }
        }
    }
}

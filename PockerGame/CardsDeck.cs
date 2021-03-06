using System;
using System.Collections.Generic;
using System.Text;

namespace PockerGame
{
    class CardsDeck : Card
    {
        //array of cards to hold all the 52 cars of the deck
        private Card[] deck;

        //initialize the size of deck
        //later we can initialize depending upon number of decks
        //for now let us assume its 1 book of standard 52 cards
        public CardsDeck()
        {
            deck = new Card[52];
        }

        //method to retrieve current deck
        public Card[] getDeck { get { return deck; } }

        //generate deck of cards
        //4 suits and 13 values of each suits
        public void generateDeck()
        {
            int i = 0;
            //for every card suit there is 13 values 
            //generating values for each card suit and placing in the deck
            foreach(CARD_SUIT cs in Enum.GetValues(typeof(CARD_SUIT)))
            {
                foreach(CARD_VALUE cv in Enum.GetValues(typeof(CARD_VALUE)))
                {
                    deck[i] = new Card
                    {
                        SUIT = cs,
                        VALUE = cv
                    };
                    //Console.WriteLine(deck[i].VALUE);
                    i++;
                }
            }
            ShuffleCards();

        }
        
        //method to shuffle the cards
        public void ShuffleCards()
        {
            Random rand = new Random();

            Card temp;

            for(int shuffleTimes = 0; shuffleTimes < 100; shuffleTimes++)
            {
                for(int i = 0; i < 52; i++)
                {
                    int secondCardIndex = rand.Next(13);
                    temp = deck[i];
                    deck[i] = deck[secondCardIndex];
                    deck[secondCardIndex] = temp;
                }
            }
        }

    }
}

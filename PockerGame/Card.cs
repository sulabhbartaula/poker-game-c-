using System;
using System.Collections.Generic;
using System.Text;

namespace PockerGame
{
    class Card
    {
        public enum CARD_SUIT
        {
            CLUBS, DIAMONDS, HEARTS, SPADES
        }

        public enum CARD_VALUE
        {
            TWO = 2, THREE, FOUR, FIVE, SIX, SEVEN, EIGHT, NINE, TEN, JACK, QUEEN, KING, ACE
        }

        public CARD_SUIT SUIT { get; set; }
        public CARD_VALUE VALUE { get; set; }
    }

    
}

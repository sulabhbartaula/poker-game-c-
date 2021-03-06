using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PockerGame
{
    //used this resource for evaluation
    public enum Hand
    {
        Nothing,
        OnePair,
        TwoPairs,
        ThreeKind,
        Straight,
        Flush,
        FullHouse,
        FourKind
    }

    public struct HandValue
    {
        public int Total { get; set; }
        public int HighCard { get; set; }
    }

    class HandIdentifier : Card
    {
        private int heartsSum;
        private int diamondSum;
        private int clubSum;
        private int spadesSum;
        private Card[] cards;
        private HandValue handValue;

        public HandIdentifier(Card[] sortedHand)
        {
            heartsSum = 0;
            diamondSum = 0;
            clubSum = 0;
            spadesSum = 0;
            cards = new Card[5];
            Cards = sortedHand;
            handValue = new HandValue();
        }

        public HandValue HandValues
        {
            get { return handValue; }
            set { handValue = value; }
        }

        public Card[] Cards
        {
            get { return cards; }
            set
            {
                cards[0] = value[0];
                cards[1] = value[1];
                cards[2] = value[2];
                cards[3] = value[3];
                cards[4] = value[4];
            }
        }

        public Hand EvaluateHand()
        {
            //get the number of each suit on hand
            getNumberOfSuit();
            if (FourOfKind())
                return Hand.FourKind;
            else if (FullHouse())
                return Hand.FullHouse;
            else if (Flush())
                return Hand.Flush;
            else if (Straight())
                return Hand.Straight;
            else if (ThreeOfKind())
                return Hand.ThreeKind;
            else if (TwoPairs())
                return Hand.TwoPairs;
            else if (OnePair())
                return Hand.OnePair;

            //if the hand is nothing, than the player with highest card wins
            handValue.HighCard = (int)cards[4].VALUE;
            return Hand.Nothing;
        }

        private void getNumberOfSuit()
        {
            foreach (var element in Cards)
            {
                if (element.SUIT == Card.CARD_SUIT.HEARTS)
                    heartsSum++;
                else if (element.SUIT == Card.CARD_SUIT.DIAMONDS)
                    diamondSum++;
                else if (element.SUIT == Card.CARD_SUIT.CLUBS)
                    clubSum++;
                else if (element.SUIT == Card.CARD_SUIT.SPADES)
                    spadesSum++;
            }
        }

        private bool FourOfKind()
        {
            //if the first 4 cards, add values of the four cards and last card is the highest
            if (cards[0].VALUE == cards[1].VALUE && cards[0].VALUE == cards[2].VALUE && cards[0].VALUE == cards[3].VALUE)
            {
                handValue.Total = (int)cards[1].VALUE * 4;
                handValue.HighCard = (int)cards[4].VALUE;
                return true;
            }
            else if (cards[1].VALUE == cards[2].VALUE && cards[1].VALUE == cards[3].VALUE && cards[1].VALUE == cards[4].VALUE)
            {
                handValue.Total = (int)cards[1].VALUE * 4;
                handValue.HighCard = (int)cards[0].VALUE;
                return true;
            }

            return false;
        }

        private bool FullHouse()
        {
            //the first three cars and last two cards are of the same value
            //first two cards, and last three cards are of the same value
            if ((cards[0].VALUE == cards[1].VALUE && cards[0].VALUE == cards[2].VALUE && cards[3].VALUE == cards[4].VALUE) ||
                (cards[0].VALUE == cards[1].VALUE && cards[2].VALUE == cards[3].VALUE && cards[2].VALUE == cards[4].VALUE))
            {
                handValue.Total = (int)(cards[0].VALUE) + (int)(cards[1].VALUE) + (int)(cards[2].VALUE) +
                    (int)(cards[3].VALUE) + (int)(cards[4].VALUE);
                return true;
            }

            return false;
        }

        private bool Flush()
        {
            //if all suits are the same
            if (heartsSum == 5 || diamondSum == 5 || clubSum == 5 || spadesSum == 5)
            {
                //if flush, the player with higher cards win
                //whoever has the last card the highest, has automatically all the cards total higher
                handValue.Total = (int)cards[4].VALUE;
                return true;
            }

            return false;
        }

        private bool Straight()
        {
            //if 5 consecutive values
            if (cards[0].VALUE + 1 == cards[1].VALUE &&
                cards[1].VALUE + 1 == cards[2].VALUE &&
                cards[2].VALUE + 1 == cards[3].VALUE &&
                cards[3].VALUE + 1 == cards[4].VALUE)
            {
                //player with the highest value of the last card wins
                handValue.Total = (int)cards[4].VALUE;
                return true;
            }

            return false;
        }

        private bool ThreeOfKind()
        {
            //if the 1,2,3 cards are the same OR
            //2,3,4 cards are the same OR
            //3,4,5 cards are the same
            //3rds card will always be a part of Three of A Kind
            if ((cards[0].VALUE == cards[1].VALUE && cards[0].VALUE == cards[2].VALUE) ||
            (cards[1].VALUE == cards[2].VALUE && cards[1].VALUE == cards[3].VALUE))
            {
                handValue.Total = (int)cards[2].VALUE * 3;
                handValue.HighCard = (int)cards[4].VALUE;
                return true;
            }
            else if (cards[2].VALUE == cards[3].VALUE && cards[2].VALUE == cards[4].VALUE)
            {
                handValue.Total = (int)cards[2].VALUE * 3;
                handValue.HighCard = (int)cards[1].VALUE;
                return true;
            }
            return false;
        }

        private bool TwoPairs()
        {
            //if 1,2 and 3,4
            //if 1.2 and 4,5
            //if 2.3 and 4,5
            //with two pairs, the 2nd card will always be a part of one pair 
            //and 4th card will always be a part of second pair
            if (cards[0].VALUE == cards[1].VALUE && cards[2].VALUE == cards[3].VALUE)
            {
                handValue.Total = ((int)cards[1].VALUE * 2) + ((int)cards[3].VALUE * 2);
                handValue.HighCard = (int)cards[4].VALUE;
                return true;
            }
            else if (cards[0].VALUE == cards[1].VALUE && cards[3].VALUE == cards[4].VALUE)
            {
                handValue.Total = ((int)cards[1].VALUE * 2) + ((int)cards[3].VALUE * 2);
                handValue.HighCard = (int)cards[2].VALUE;
                return true;
            }
            else if (cards[1].VALUE == cards[2].VALUE && cards[3].VALUE == cards[4].VALUE)
            {
                handValue.Total = ((int)cards[1].VALUE * 2) + ((int)cards[3].VALUE * 2);
                handValue.HighCard = (int)cards[0].VALUE;
                return true;
            }
            return false;
        }

        private bool OnePair()
        {
            //if 1,2 -> 5th card has the highest value
            //2.3
            //3,4
            //4,5 -> card #3 has the highest value
            if (cards[0].VALUE == cards[1].VALUE)
            {
                handValue.Total = (int)cards[0].VALUE * 2;
                handValue.HighCard = (int)cards[4].VALUE;
                return true;
            }
            else if (cards[1].VALUE == cards[2].VALUE)
            {
                handValue.Total = (int)cards[1].VALUE * 2;
                handValue.HighCard = (int)cards[4].VALUE;
                return true;
            }
            else if (cards[2].VALUE == cards[3].VALUE)
            {
                handValue.Total = (int)cards[2].VALUE * 2;
                handValue.HighCard = (int)cards[4].VALUE;
                return true;
            }
            else if (cards[3].VALUE == cards[4].VALUE)
            {
                handValue.Total = (int)cards[3].VALUE * 2;
                handValue.HighCard = (int)cards[2].VALUE;
                return true;
            }

            return false;
        }

    }
}

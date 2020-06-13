/*************************************************************************
 * Author: DCoreyDuke
 ************************************************************************/

using System;
using System.Collections.Generic;
using DCoreyDuke.CodeBase.Extensions;

namespace DCoreyDuke.CodeBase.GameLogic.Cards
{
    /// <summary>
    /// A deck of cards
    /// </summary>
    public class Deck
    {
        #region Fields

        private readonly List<Card> _Cards = new List<Card>();

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        public Deck()
        {
            // fill the deck with cards
            foreach (Suit suit in Enum.GetValues(typeof(Suit)))
            {
                foreach (Rank rank in Enum.GetValues(typeof(Rank)))
                {
                    _Cards.Add(new Card(rank.GetDisplayName().ToString(), suit.GetDisplayName().ToString()));
                }
            }
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Gets whether the deck is empty
        /// </summary>
        public bool Empty
        {
            get { return _Cards.Count == 0; }
        }

        #endregion Properties

        #region Public methods

        /// <summary>
        /// Cuts the deck of cards at the given location
        /// </summary>
        /// <param name="location">the location at which to cut the deck</param>
        public void Cut(int location)
        {
            int cutIndex = _Cards.Count - location;
            Card[] newCards = new Card[_Cards.Count];
            _Cards.CopyTo(cutIndex, newCards, 0, location);
            _Cards.CopyTo(0, newCards, location, cutIndex);
            _Cards.Clear();
            _Cards.InsertRange(0, newCards);
        }

        /// <summary>
        /// Prints the contents of the deck
        /// </summary>
        public void Print()
        {
            foreach (Card card in _Cards)
            {
                Console.WriteLine(card.Rank + " of " + card.Suit);
            }
        }

        /// <summary>
        /// Shuffles the deck
        ///
        /// Reference: http://download.oracle.com/javase/1.5.0/docs/api/java/util/Collections.html#shuffle%28java.util.List%29
        /// </summary>
        public void Shuffle()
        {
            Random rand = new Random();
            for (int i = _Cards.Count - 1; i > 0; i--)
            {
                int randomIndex = rand.Next(i + 1);
                Card tempCard = _Cards[i];
                _Cards[i] = _Cards[randomIndex];
                _Cards[randomIndex] = tempCard;
            }
        }

        /// <summary>
        /// Takes the top card from the deck. If the deck is empty, returns null
        /// </summary>
        /// <returns>the top card</returns>
        public Card TakeTopCard()
        {
            if (!Empty)
            {
                Card topCard = _Cards[_Cards.Count - 1];
                _Cards.RemoveAt(_Cards.Count - 1);
                return topCard;
            }
            else
            {
                return null;
            }
        }

        #endregion Public methods
    }
}
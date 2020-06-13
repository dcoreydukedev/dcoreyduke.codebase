/*************************************************************************
 * Author: DCoreyDuke
 ************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DCoreyDuke.CodeBase.GameLogic.Cards
{
    /// <summary>
    /// A playing card
    /// </summary>
    public class Card
    {
        #region Fields

        private readonly string _Rank;
        private readonly string _Suit;
        private bool _FaceUp;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Constructs a card with the given rank and suit
        /// </summary>
        /// <param name="rank">the rank</param>
        /// <param name="suit">the suit</param>
        public Card(string rank, string suit)
        {
            this._Rank = rank;
            this._Suit = suit;
            _FaceUp = false;
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Gets whether or not the card is face up
        /// </summary>
        public bool FaceUp
        {
            get { return _FaceUp; }
        }

        /// <summary>
        /// Gets the card rank
        /// </summary>
        public string Rank
        {
            get { return _Rank; }
        }

        /// <summary>
        /// Gets the card suit
        /// </summary>
        public string Suit
        {
            get { return _Suit; }
        }

        #endregion Properties

        #region Public methods

        /// <summary>
        /// Flips the card over
        /// </summary>
        public void FlipOver()
        {
            _FaceUp = !_FaceUp;
        }

        #endregion Public methods
    }
}
/*************************************************************************
 * Author: DCoreyDuke
 ************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DCoreyDuke.CodeBase.GameLogic.Dice
{
    /// <summary>
    /// A die
    /// </summary>
    public class Die
    {
        #region Fields

        private readonly int _NumSides;
        private int _TopSide;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Constructor for six-sided die
        /// </summary>
        public Die() : this(6)
        {
        }

        /// <summary>
        /// Constructor for a die with the given number of sides
        /// </summary>
        /// <param name="numSides">the number of sides</param>
        public Die(int numSides)
        {
            this._NumSides = numSides;
            _TopSide = 1;
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Gets the number of sides the die has
        /// </summary>
        public int NumSides
        {
            get { return _NumSides; }
        }

        /// <summary>
        /// Gets the current top side of the die
        /// </summary>
        public int TopSide
        {
            get { return _TopSide; }
        }

        #endregion Properties

        #region Public methods

        /// <summary>
        /// Rolls the die
        /// </summary>
        public void Roll()
        {
            _TopSide = RandomNumberGenerator.Uniform(_NumSides) + 1;
        }

        #endregion Public methods
    }
}
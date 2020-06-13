/*************************************************************************
 * Author: DCoreyDuke
 ************************************************************************/

using System.ComponentModel.DataAnnotations;

namespace DCoreyDuke.CodeBase.GameLogic.Cards
{
    /// <summary>
    /// An enumeration for card ranks
    /// </summary>
    public enum Rank
    {
        [Display(Name = "A")]
        Ace,

        [Display(Name = "2")]
        Two,

        [Display(Name = "3")]
        Three,

        [Display(Name = "4")]
        Four,

        [Display(Name = "5")]
        Five,

        [Display(Name = "6")]
        Six,

        [Display(Name = "7")]
        Seven,

        [Display(Name = "8")]
        Eight,

        [Display(Name = "9")]
        Nine,

        [Display(Name = "10")]
        Ten,

        [Display(Name = "J")]
        Jack,

        [Display(Name = "Q")]
        Queen,

        [Display(Name = "K")]
        King
    }

    /// <summary>
    /// An enumeration for card suits
    /// </summary>
    public enum Suit
    {
        [Display(Name = "♣")]
        Clubs,

        [Display(Name = "♦")]
        Diamonds,

        [Display(Name = "♥")]
        Hearts,

        [Display(Name = "♠")]
        Spades
    }
}
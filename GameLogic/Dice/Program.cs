/*************************************************************************
 * Author: DCoreyDuke
 ************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCoreyDuke.CodeBase.GameLogic.Dice
{
    internal class Program
    {
        /// <summary>
        /// Demonstrates rolling and using two dice
        /// </summary>
        private static void Main()
        {
            // create two dice
            Die die1 = new Die();
            Die die2 = new Die();

            // tell the dice to roll themselves
            die1.Roll();
            die2.Roll();

            // print the top sides and the sum of the dice
            Console.WriteLine("Die 1: " + die1.TopSide);
            Console.WriteLine("Die 2: " + die2.TopSide);
            int sum = die1.TopSide + die2.TopSide;
            Console.WriteLine("Sum of Dice: " + sum);

            Console.WriteLine();
            Console.ReadKey();
        }
    }
}
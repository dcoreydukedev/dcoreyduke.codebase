/*************************************************************************
 * Author: DCoreyDuke
 ************************************************************************/

using System;

namespace DCoreyDuke.CodeBase.KeyGenerators
{
    /// <summary>
    /// Generate Passwords Like Google Does
    /// </summary>
    public sealed class PasswordGenerator : IStringKeyGenerator
    {
        private static readonly Random _Random = new Random();
        private readonly StringKeyGeneratorOptions _Opts;
        private StringKeyGenerator _Gen;

        public PasswordGenerator()
        {
            _Opts = new StringKeyGeneratorOptions();
        }

        public string Generate()
        {
            _Opts.Length = GetLength();
            _Opts.IncludeCaps = true;
            _Opts.IncludeDigits = true;
            _Opts.IncludeSpecialChars = true;

            _Gen = new StringKeyGenerator(_Opts);

            return _Gen.Generate();
        }

        /// <summary>
        /// Get a Random Length between 8 and 12
        /// </summary>
        /// <returns></returns>
        private int GetLength()
        {
            return _Random.Next(6, 12);
        }
    }
}
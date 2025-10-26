using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Evaluation_Tool_for_ENNA_.Helper
{
    /// <summary>
    /// This class provides helper functions to convert from and to byte lists
    /// </summary>
    public static class ByteConversion
    {
        /// <summary>
        /// Convert a hex string into a list of bytes.
        /// </summary>
        /// <param name="hex">The hex string to convert
        ///     Format: Groups of 2 hex digits (with or without leading '0x') seperated by ',', ' ', both or nothing.
        ///        e.g. "0x21, 0xAf" or "123456789ABCDEF0" or "11 22 33 44"</param>
        /// <returns>The resulting bytes</returns>
        public static byte[] HexStringToBytes(string hex)
        {
            if (!Regex.IsMatch(hex, "^((0x)?[0-9A-Fa-f]{2},? ?)+$"))
                throw new ArgumentException($"Invalid Hex String {hex}");

            string numbersOnly = hex.Replace(" ", "").Replace(",", "").Replace("0x", "");

            return Enumerable.Range(0, (numbersOnly.Length / 2))
                .Select(i => Convert.ToByte(numbersOnly.Substring(i * 2, 2), 16))
                .ToArray(); ;
        }

    }
}

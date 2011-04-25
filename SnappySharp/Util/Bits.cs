using System;

namespace SnappySharp.Util
{
	/// <summary>
	/// 	Some bit-manipulation functions.
	/// </summary>
	public static class Bits
	{
		/// <summary>
		/// 	Lookuptable for fast computation of NumberOfTrailingZeros
		/// </summary>
		private static readonly int[] lookup = new int[]
		{
			32, 0, 1, 26, 2, 23, 27, 0, 3, 16, 24, 30, 28, 11, 0, 13, 4, 7, 17,
        	0, 25, 22, 31, 15, 29, 10, 12, 6, 0, 21, 14, 9, 5, 20, 8, 19, 18
		};
		
		/// <summary>
		/// 	Return floor(log2(n)) for positive integer n.  Returns -1 iff n == 0.
		/// </summary>
		/// <returns>
		/// 	floor(log2(n))
		/// </returns>
		/// <param name='n'>
		/// 	n
		/// </param>
		public static int Log2Floor (int n)
		{
			return n == 0 ? -1 : 31 ^ NumberOfLeadingZeros (n);
		}
		
		/// <summary>
		/// Finds the LSB set non zero.
		/// </summary>
		/// <returns>
		/// The LSB set non zero.
		/// </returns>
		/// <param name='n'>
		/// N.
		/// </param>
		public static int FindLSBSetNonZero (int n)
		{
			return NumberOfTrailingZeros (n);
		}
		
		/// <summary>
		/// Numbers the of trailing zeros.
		/// </summary>
		/// <returns>
		/// The of trailing zeros.
		/// </returns>
		/// <param name='i'>
		/// I.
		/// </param>
		private static int NumberOfTrailingZeros (int i)
		{
			return lookup[(i & -i) % 37];
		}
		
		/// <summary>
		/// Numbers the of leading zeros.
		/// </summary>
		/// <returns>
		/// The of leading zeros.
		/// </returns>
		/// <param name='i'>
		/// I.
		/// </param>
		private static int NumberOfLeadingZeros (int i)
		{
			// 32-bit word to reverse bit order
			int v = i; 
			// swap odd and even bits
			v = ((v >> 1) & 0x55555555) | ((v & 0x55555555) << 1);
			// swap consecutive pairs
			v = ((v >> 2) & 0x33333333) | ((v & 0x33333333) << 2);
			// swap nibbles ... 
			v = ((v >> 4) & 0x0F0F0F0F) | ((v & 0x0F0F0F0F) << 4);
			// swap bytes
			v = ((v >> 8) & 0x00FF00FF) | ((v & 0x00FF00FF) << 8);
			// swap 2-byte long pairs
			v = ( v >> 16             ) | ( v               << 16);
			return NumberOfTrailingZeros (v);
		}
	}
}


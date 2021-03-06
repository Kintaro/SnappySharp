using System;

namespace SnappySharp
{
	public static class Api
	{
		/// <summary>
		/// 	Constant max hash table bits.
		/// </summary>
		public const int MaxHashTableBits = 14;
		/// <summary>
		/// 	Constant max hash table size.
		/// </summary>
		public const int MaxHashTableSize = 1 << MaxHashTableBits;
		
		public enum Status 
		{
			OK = 0,
			InvalidInput = 1,
			BufferTooSmall = 2,
		}
		
		public static int Compress (Source source, Sink sink)
		{
			return 0;
		}
		
		public static bool GetUncompressedLength (Source source, ref int result)
		{
			SnappyDecompressor decompressor = new SnappyDecompressor (source);
			return decompressor.ReadUncompressedLength (ref result);
		}
		
		public static int Compress (byte[] input, int inputLength, ref string output)
		{
			return 0;
		}
		
		public static bool Uncompress (byte[] compressed, int compressedLength, ref string uncompressed)
		{
			return true;
		}
	}
}


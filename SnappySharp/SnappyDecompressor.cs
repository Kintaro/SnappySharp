using System.IO;

namespace SnappySharp
{
	/// <summary>
	/// 	Snappy decompressor.
	/// </summary>
	internal class SnappyDecompressor
	{
		/// <summary>
		/// 	The reader.
		/// </summary>
		private Source reader = null;
		
		/// <summary>
		/// 	Initializes a new instance of the <see cref="SnappySharp.SnappyDecompressor"/> class.
		/// </summary>
		/// <param name='reader'>
		/// 	Reader.
		/// </param>
		public SnappyDecompressor (Source reader)
		{
			this.reader = reader;
		}
		
		/// <summary>
		/// 	Reads the length of the uncompressed.
		/// </summary>
		/// <returns>
		/// 	The uncompressed length.
		/// </returns>
		/// <param name='result'>
		/// 	If set to <c>true</c> result.
		/// </param>
		public bool ReadUncompressedLength (ref int result)
		{
			result = 0;
			uint shift = 0;
			
			while (true)
			{
				if (shift >= 32)
					return false;
				int n = 0;
				MemoryStream ip = reader.Peek (ref n);
				
				if (n == 0)
					return false;
				
				uint c = (uint)ip.ReadByte ();
				reader.Skip (1);
				result |= (int)(c & 0x7Fu) << (int)shift;
				if (c < 128)
					break;
				shift += 7;
			}
			return true;
		}
	}
}


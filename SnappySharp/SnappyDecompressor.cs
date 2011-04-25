using System.IO;
using SnappySharp.Writer;

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
		/// 	The EOF marker.
		/// </summary>
		private bool eof = false;
		/// <summary>
		/// 	The internal pointer.
		/// </summary>
		private long internalPointer = 0;
		/// <summary>
		/// 	The internal pointer limit.
		/// </summary>
		private long internalPointerLimit = 0;
		/// <summary>
		/// 	The peeked.
		/// </summary>
		private int peeked = 0;
		
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
		/// 	Sets a value indicating whether this <see cref="SnappySharp.SnappyDecompressor"/> is EOF.
		/// </summary>
		/// <value>
		/// 	<c>true</c> if EOF; otherwise, <c>false</c>.
		/// </value>
		public bool Eof { get { return this.eof; } }
		
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
		
		/// <summary>
		/// 	Step the specified writer.
		/// </summary>
		/// <param name='writer'>
		/// 	If set to <c>true</c> writer.
		/// </param>
		/// <typeparam name='Writer'>
		/// 	The 1st type parameter.
		/// </typeparam>
		public bool Step (IWriter writer)
		{
			return true;
		}
		
		/// <summary>
		/// 	Refills the tag.
		/// </summary>
		/// <returns>
		/// 	The tag.
		/// </returns>
		public bool RefillTag ()
		{
			long ip = this.internalPointer;
			
			if (this.internalPointer == this.internalPointerLimit)
			{
				int n = 0;
				this.reader.Skip (this.peeked);
				ip = this.reader.Peek (ref n).Position;
				this.peeked = n;
				
				if (n == 0)
				{
					this.eof = true;
					return false;
				}
				this.internalPointerLimit = ip + n;
			}
			
			return true;
		}
	}
}


using System.IO;

namespace SnappySharp
{
	/// <summary>
	/// 	Sink.
	/// </summary>
	public abstract class Sink
	{		
		/// <summary>
		/// 	Gets the append buffer.
		/// </summary>
		/// <returns>
		/// 	The append buffer.
		/// </returns>
		/// <param name='length'>
		/// 	Length.
		/// </param>
		/// <param name='scratch'>
		/// 	Scratch.
		/// </param>
		public virtual MemoryStream GetAppendBuffer (int length, MemoryStream scratch) 
		{
			return scratch;
		}
		
		/// <summary>
		/// 	Append the specified bytes and n.
		/// </summary>
		/// <param name='bytes'>
		/// 	Bytes.
		/// </param>
		/// <param name='n'>
		/// 	N.
		/// </param>
		public abstract void Append (MemoryStream bytes, int n);
	}
}


using System.IO;

namespace SnappySharp
{
	/// <summary>
	/// 	Unchecked byte array sink.
	/// </summary>
	public class UncheckedByteArraySink : Sink
	{
		/// <summary>
		/// 	The destination.
		/// </summary>
		MemoryStream destination = null;
		
		/// <summary>
		/// 	Initializes a new instance of the <see cref="SnappySharp.UncheckedByteArraySink"/> class.
		/// </summary>
		/// <param name='dest'>
		/// 	Destination.
		/// </param>
		public UncheckedByteArraySink (MemoryStream destination)
		{
			this.destination = destination;
		}
		
		/// <summary>
		/// 	Gets the current destination.
		/// </summary>
		/// <value>
		/// 	The current destination.
		/// </value>
		public MemoryStream CurrentDestination { get { return this.destination; } }
		
		/// <summary>
		/// 	Append the specified bytes and n.
		/// </summary>
		/// <param name='bytes'>
		/// 	Bytes.
		/// </param>
		/// <param name='n'>
		/// 	N.
		/// </param>
		public override void Append (byte[] bytes, int n)
		{
			this.destination.Seek (n, SeekOrigin.Current);
		}
		
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
		public override MemoryStream GetAppendBuffer (int length, System.IO.MemoryStream scratch)
		{
			return this.destination;
		}
	}
}


using System.IO;

namespace SnappySharp
{
	/// <summary>
	/// 	Byte array source.
	/// </summary>
	public class ByteArraySource : Source
	{
		/// <summary>
		/// 	The left.
		/// </summary>
		private int left = 0;
		/// <summary>
		/// 	The pointer.
		/// </summary>
		private MemoryStream pointer = null;
		
		/// <summary>
		/// 	Initializes a new instance of the <see cref="SnappySharp.ByteArraySource"/> class.
		/// </summary>
		/// <param name='pointer'>
		/// 	Pointer.
		/// </param>
		/// <param name='n'>
		/// 	N.
		/// </param>
		public ByteArraySource (MemoryStream pointer, int n)
		{
			this.left = n;
			this.pointer = pointer;
		}
		
		/// <summary>
		/// 	Available this instance.
		/// </summary>
		public override int Available ()
		{
			return this.left;
		}
		
		/// <summary>
		/// 	Peek the specified length.
		/// </summary>
		/// <param name='length'>
		/// 	Length.
		/// </param>
		public override MemoryStream Peek (ref int length)
		{
			length = this.left;
			return this.pointer;
		}
		
		/// <summary>
		/// 	Skip the specified n.
		/// </summary>
		/// <param name='n'>
		/// 	N.
		/// </param>
		public override void Skip (int n)
		{
			this.left -= n;
			this.pointer.Seek (n, SeekOrigin.Current);
		}
	}
}


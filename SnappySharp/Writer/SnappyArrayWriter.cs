using System.IO;

namespace SnappySharp.Writer
{
	/// <summary>
	/// 	Snappy array writer.
	/// </summary>
	public class SnappyArrayWriter : IWriter
	{
		/// <summary>
		/// 	The destination.
		/// </summary>
		private byte[] destination = null;
		/// <summary>
		/// 	The op.
		/// </summary>
		private int op = 0;
		/// <summary>
		/// 	The limit.
		/// </summary>
		private int limit = 0;
		
		/// <summary>
		/// 	Initializes a new instance of the <see cref="SnappySharp.Writer.SnappyArrayWriter"/> class.
		/// </summary>
		/// <param name='destination'>
		/// 	Destination array.
		/// </param>
		public SnappyArrayWriter (byte[] destination)
		{
			this.destination = destination;
		}

		#region IWriter implementation
		public bool AppendFromSelf (int offset, int length)
		{
			int spaceLeft = this.limit - this.op;
			if (this.op <= offset - 1u)
				return false;
			if (spaceLeft < length)
				return false;
			for (int i = 0; i < length; ++i)
				this.destination[this.op - offset + i] = this.destination[this.op + i];
			this.op += length;
			return true;
		}
	
		public bool Append (MemoryStream pointer, int length, bool allowFastpath)
		{
			int spaceLeft = this.limit - this.op;
			if (spaceLeft < length)
				return false;
			pointer.Read (this.destination, this.op, length);
			this.op += length;
			return true;
		}
	
		public bool CheckLength ()
		{
			return this.limit == this.op;
		}
	
		public void SetExpectedLength (int length)
		{
			this.limit = this.op + length;
		}
		#endregion
	}
}


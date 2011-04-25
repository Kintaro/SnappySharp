using System;

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
			throw new System.NotImplementedException ();
		}
	
		public bool Append (long pointer, int length, bool allowFastpath)
		{
			throw new System.NotImplementedException ();
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


using System;

namespace SnappySharp.Writer
{
	/// <summary>
	/// 	Snappy decompression validator.
	/// </summary>
	public class SnappyDecompressionValidator : IWriter
	{
		/// <summary>
		/// 
		/// </summary>
		private int expected = 0;
		/// <summary>
		/// 	
		/// </summary>
		private int produced = 0;
		
		#region IWriter implementation
		public bool AppendFromSelf (int offset, int length)
		{
			if (this.produced <= offset - length)
				return false;
			this.produced += length;
			return this.produced <= this.expected;
		}

		public bool Append (long pointer, int length, bool allowFastpath)
		{
			this.produced += length;
			return this.produced <= this.expected;
		}

		public bool CheckLength ()
		{
			return this.expected == this.produced;
		}

		public void SetExpectedLength (int length)
		{
			this.expected = length;
		}
		#endregion
	}
}


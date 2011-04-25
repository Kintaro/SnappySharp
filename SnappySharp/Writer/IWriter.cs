using System;

namespace SnappySharp.Writer
{
	/// <summary>
	/// 	Writer interface
	/// </summary>
	public interface IWriter
	{
		/// <summary>
		/// 	Sets the expected length.
		/// </summary>
		/// <param name='length'>
		/// 	Length.
		/// </param>
		void SetExpectedLength (int length);
		/// <summary>
		/// 	Checks the length.
		/// </summary>
		/// <returns>
		/// 	The length.
		/// </returns>
		bool CheckLength ();
		/// <summary>
		/// 	Append the specified pointer, length and allowFastpath.
		/// </summary>
		/// <param name='pointer'>
		/// 	If set to <c>true</c> pointer.
		/// </param>
		/// <param name='length'>
		/// 	If set to <c>true</c> length.
		/// </param>
		/// <param name='allowFastpath'>
		/// 	If set to <c>true</c> allow fastpath.
		/// </param>
		bool Append (long pointer, int length, bool allowFastpath);
		/// <summary>
		/// 	Appends from self.
		/// </summary>
		/// <returns>
		/// 	The from self.
		/// </returns>
		/// <param name='offset'>
		/// 	If set to <c>true</c> offset.
		/// </param>
		/// <param name='length'>
		/// 	If set to <c>true</c> length.
		/// </param>
		bool AppendFromSelf (int offset, int length);
	}
}


using System.IO;

namespace SnappySharp
{
	/// <summary>
	/// 	Source.
	/// </summary>
	public abstract class Source
	{
		/// <summary>
		/// 	Initializes a new instance of the <see cref="SnappySharp.Source"/> class.
		/// </summary>
		public Source ()
		{
		}
		
		/// <summary>
		/// 	Available this instance.
		/// </summary>
		public abstract int Available ();
		/// <summary>
		/// 	Peek the specified length.
		/// </summary>
		/// <param name='length'>
		/// 	Length.
		/// </param>
		public abstract MemoryStream Peek (ref int length);
		/// <summary>
		/// 	Skip the specified n.
		/// </summary>
		/// <param name='n'>
		/// 	N.
		/// </param>
		public abstract void Skip (int n);
	}
}


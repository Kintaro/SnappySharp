using System;

namespace SnappySharp
{
	/// <summary>
	/// 	Working memory.
	/// </summary>
	public class WorkingMemory
	{
		/// <summary>
		/// 	The short table.
		/// </summary>
		ushort[] shortTable = new ushort[1 << 10];
		/// <summary>
		/// 	The large table.
		/// </summary>
		ushort[] largeTable = null;
		
		/// <summary>
		/// 	Gets the hash table.
		/// </summary>
		/// <returns>
		/// 	The hash table.
		/// </returns>
		/// <param name='inputSize'>
		/// 	Input size.
		/// </param>
		/// <param name='tableSize'>
		/// 	Table size.
		/// </param>
		public ushort[] GetHashTable (int inputSize, ref int tableSize)
		{
			int htSize = 256;
			while (htSize < inputSize)
				htSize <<= 1;
			ushort[] table = null;
			if (htSize < Api.MaxHashTableSize && htSize <= (1 << 10))
				table = this.shortTable;
			else
			{
				if (this.largeTable == null)
					this.largeTable = new ushort[Api.MaxHashTableSize];
				table = this.largeTable;
			}
			tableSize = htSize;
			return table;
		}
	}
}


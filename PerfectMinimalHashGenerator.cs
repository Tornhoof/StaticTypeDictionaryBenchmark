using System.CodeDom;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Microsoft.CodeAnalysis;

namespace StaticTypeDictionaryBenchmark
{

	public static class PerfectMinimalHashGenerator
	{

		public readonly struct HashDictionary<T>
		{
			private readonly int[] _seeds;
			private readonly T?[] _values;

			public HashDictionary(int[] seeds, T?[] values)
			{
				_seeds = seeds;
				_values = values;
			}

			public T? Get(in ReadOnlySpan<char> key)
			{
				var offset = Hash(key, 0) % _seeds.Length;
				var d = _seeds[offset];
				if (d < 0)
				{
					return _values[0 - d - 1];
				}

				return _values[Hash(key, d) % _values.Length];
			}
		}

		public static HashDictionary<T> Build<T>(IDictionary<string, T> input) where T : class
		{
			var size = input.Count;
			List<string>?[] buckets = new List<string>[size];
			var result = new int[size];
			foreach (var key in input.Keys)
			{
				var hashedKey = Hash(key, 0) % size;
				buckets[hashedKey] ??= new List<string>(1);
				buckets[hashedKey]!.Add(key);
			}

			Array.Sort(buckets, Comparison);

			bool[] used = new bool[size];
			List<int> slots = new List<int>();
			T?[] values = new T[size];
			int b = 0;
			for (; b < size; b++)
			{
				var bucket = buckets[b];
				if (bucket is null || bucket!.Count <= 1)
				{
					break;
				}

				int counter = 0;
				int d = 1;
				Array.Fill(used, false);
				slots.Clear();
				while (counter < bucket.Count)
				{
					var slot = Hash(bucket[counter], d) % size;
					if (values[slot] is not null || used[slot])
					{
						d++;
						counter = 0;
						slots.Clear();
						Array.Fill(used, false);
					}
					else
					{
						used[slot] = true;
						slots.Add(slot);
						counter++;
					}
				}

				result[Hash(bucket[0], 0) % size] = d;
				for (int i = 0; i < bucket.Count; i++)
				{
					var slot = slots[i];
					Debug.Assert(values[slot] is null);
					values[slot] = input[bucket[i]];
				}
			}


			Queue<int> freelist = new Queue<int>();
			for (int i = 0; i < size; i++)
			{
				if (values[i] is null)
				{
					freelist.Enqueue(i);
				}
			}

			for (; b < size; b++)
			{
				var bucket = buckets[b];
				if (bucket is null)
				{
					break;
				}

				Debug.Assert(bucket.Count == 1);
				var slot = freelist.Dequeue();
				result[Hash(bucket[0], 0) % size] = 0 - slot - 1;
				Debug.Assert(values[slot] is null);
				values[slot] = input[bucket[0]];
			}

			var bytes = MemoryMarshal.AsBytes(result.AsSpan());
			var text =
				$"public ReadOnlySpan<byte> Data => new[] {{{string.Join(',', bytes.ToArray().Select(a => "0x"+a.ToString("X2")))}}};";
			return new HashDictionary<T>(result, values);

			static int Comparison(List<string>? x, List<string>? y)
			{
				if (ReferenceEquals(x, y))
				{
					return 0;
				}

				if (x is null)
				{
					return 1;
				}

				if (y is null)
				{
					return -1;
				}

				return -x.Count.CompareTo(y.Count);
			}
		}


		private static int Hash(in ReadOnlySpan<char> key, int seed)
		{
			var bytes = MemoryMarshal.AsBytes(key);
			uint output = 0;
			var outputBytes = MemoryMarshal.AsBytes(MemoryMarshal.CreateSpan(ref output, 1));
			System.IO.Hashing.XxHash32.Hash(bytes, outputBytes, seed);
			return (int) (output & 0x7FFFFFF);
		}
	}
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;

namespace StaticTypeDictionaryBenchmark
{
	[ShortRunJob]
	[DisassemblyDiagnoser(1)]
	public class HashBenchmark
	{
		private Dictionary<string, string> m_Values;
		private PerfectMinimalHashGenerator.HashDictionary<string> m_Dict;
		private List<string> m_Keys = new List<string>();
		private GPerf gPerf = new GPerf();
		private GPerf2 gPerf2 = new GPerf2();

		public HashBenchmark()
		{
			m_Values = new Dictionary<string, string>(1000);
			for (int i = 0; i < 1000; i++)
			{
				var key = "MyLongNamespace.Type.Request" + i;
				var value = "MyLongNamespace.Type.Response" + i;

				if (i % 1000 == 0)
				{
					m_Keys.Add(key);
				}

				m_Values.Add(key, value);
			}

			m_Dict = PerfectMinimalHashGenerator.Build(m_Values);
		}

		[ParamsSource(nameof(Keys))] public string Key { get; set; }

		public IEnumerable<string> Keys => m_Keys;

		//[Benchmark]

		//public string Dictionary()
		//{
		//	return m_Values[Key];
		//}

		//[Benchmark]

		//public string HashDict()
		//{
		//	return m_Dict.Get(Key)!;
		//}

		[Benchmark]
		public string? GPerfDict()
		{
			return gPerf.InWordSet(Key);
		}

		[Benchmark]
		public string? GPerf2Dict()
		{
			return gPerf2.InWordSet(Key);
		}
	}
}
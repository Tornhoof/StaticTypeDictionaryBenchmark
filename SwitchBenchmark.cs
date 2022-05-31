using BenchmarkDotNet.Attributes;

namespace StaticTypeDictionaryBenchmark
{
	[ShortRunJob]
	public class SwitchBenchmark
	{
		private static readonly Request1 Request1 = new();
		private static readonly Request100 Request100 = new();
		private static readonly Request200 Request200 = new();
		private static readonly Request300 Request300 = new();
		private static readonly Request400 Request400 = new();
		private static readonly Request500 Request500 = new();
		private static readonly Request600 Request600 = new();
		private static readonly Request700 Request700 = new();
		private static readonly Request800 Request800 = new();
		private static readonly Request900 Request900 = new();
		private static readonly Request1000 Request1000 = new();

		[Benchmark]
		public int SwitchRequest1()
		{
			return SwitchHelper.Switch(Request1);
		}

		[Benchmark]
		public int SwitchRequest100()
		{
			return SwitchHelper.Switch(Request100);
		}

		[Benchmark]
		public int SwitchRequest200()
		{
			return SwitchHelper.Switch(Request200);
		}

		[Benchmark]
		public int SwitchRequest300()
		{
			return SwitchHelper.Switch(Request300);
		}

		[Benchmark]
		public int SwitchRequest400()
		{
			return SwitchHelper.Switch(Request400);
		}

		[Benchmark]
		public int SwitchRequest500()
		{
			return SwitchHelper.Switch(Request500);
		}

		[Benchmark]
		public int SwitchRequest600()
		{
			return SwitchHelper.Switch(Request600);
		}

		[Benchmark]
		public int SwitchRequest700()
		{
			return SwitchHelper.Switch(Request700);
		}
		[Benchmark]
		public int SwitchRequest800()
		{
			return SwitchHelper.Switch(Request800);
		}

		[Benchmark]
		public int SwitchRequest900()
		{
			return SwitchHelper.Switch(Request900);
		}

		[Benchmark]
		public int SwitchRequest1000()
		{
			return SwitchHelper.Switch(Request1000);
		}

		[Benchmark]
		public int StaticSwitchRequest1()
		{
			return StaticSwitchHelper.Switch(Request1);
		}

		[Benchmark]
		public int StaticSwitchRequest100()
		{
			return StaticSwitchHelper.Switch(Request100);
		}

		[Benchmark]
		public int StaticSwitchRequest200()
		{
			return StaticSwitchHelper.Switch(Request200);
		}

		[Benchmark]
		public int StaticSwitchRequest300()
		{
			return StaticSwitchHelper.Switch(Request300);
		}

		[Benchmark]
		public int StaticSwitchRequest400()
		{
			return StaticSwitchHelper.Switch(Request400);
		}

		[Benchmark]
		public int StaticSwitchRequest500()
		{
			return StaticSwitchHelper.Switch(Request500);
		}

		[Benchmark]
		public int StaticSwitchRequest600()
		{
			return StaticSwitchHelper.Switch(Request600);
		}

		[Benchmark]
		public int StaticSwitchRequest700()
		{
			return StaticSwitchHelper.Switch(Request700);
		}
		[Benchmark]
		public int StaticSwitchRequest800()
		{
			return StaticSwitchHelper.Switch(Request800);
		}

		[Benchmark]
		public int StaticSwitchRequest900()
		{
			return StaticSwitchHelper.Switch(Request900);
		}

		[Benchmark]
		public int StaticSwitchRequest1000()
		{
			return StaticSwitchHelper.Switch(Request1000);
		}
	}
}

// See https://aka.ms/new-console-template for more information

using System.Runtime.CompilerServices;
using System.Text;
using BenchmarkDotNet.Running;
using StaticTypeDictionaryBenchmark;


var values = new Dictionary<string, string>(1000);
for (int i = 0; i < 1000; i++)
{
	var key = "MyLongNamespace.Type.Request" + i;
	var value = "MyLongNamespace.Type.Response" + i;
	values.Add(key, value);
}

//var sb = new StringBuilder();
//foreach (var kvp in values)
//{
//	sb.AppendLine(kvp.Key);
//}

//File.WriteAllText("output.txt", sb.ToString());

GPerf p = new GPerf();
foreach (var kvp in values)
{
	var k = p.InWordSet(kvp.Key);
}

var dict = PerfectMinimalHashGenerator.Build(values);

foreach (var kvp in values)
{
	var x = dict.Get(kvp.Key);
	if (x != kvp.Value)
	{
		throw new InvalidOperationException("blub");
	}
}

//StaticSwitchHelper.Switch(new Request500());

BenchmarkRunner.Run<HashBenchmark>();
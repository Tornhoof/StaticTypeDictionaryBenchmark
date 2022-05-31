namespace StaticTypeDictionaryBenchmark
{

	public static class TypeIndex<TValue> where TValue : class
	{
		private static int _typeIndex = -1;
		private static readonly TValue[] s_Values = new TValue[1000];
		private static class TypeKey<TKey>
		{
			// ReSharper disable once StaticMemberInGenericType
			internal static readonly int Id = Interlocked.Increment(ref _typeIndex);
		}
		public static TValue Add<TKey>(TValue value) => s_Values[TypeKey<TKey>.Id] = value;
		public static TValue Get<TKey>() => s_Values[TypeKey<TKey>.Id];
	}
}

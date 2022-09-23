global using Xunit;
using KDS.Primitives.Abstraction.ValueObjects;

class TestClass
{
	public string TestString1 { get; set; }
	public string TestString2 { get; set; }

	public TestClass() { }

	public TestClass(string testString1, string testString2)
	{
		TestString1 = testString1;
		TestString2 = testString2;
	}
}

class TestClassInheritValueObject : ValueObject
{
	public string TestString1 { get; set; }
	public string TestString2 { get; set; }

	public TestClassInheritValueObject() { }

	public TestClassInheritValueObject(string testString1, string testString2)
	{
		TestString1 = testString1;
		TestString2 = testString2;
	}

	/// <inheritdoc />
	protected override IEnumerable<object> GetAtomicValues()
	{
		yield return TestString1;
		yield return TestString2;
	}
}
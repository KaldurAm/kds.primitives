global using Xunit;

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
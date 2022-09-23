namespace KDS.Primitives.UnitTests;

public class AbstractionTests
{
	private readonly TestClass _testClass1;
	private readonly TestClass _testClass2;

	public AbstractionTests()
	{
		_testClass1 = new();
		_testClass2 = new();
	}
	
	[Fact]
	public void TestClassNotInheritValueObject_Should_EqualFalse_EqualityOperatorFalse()
	{
		
	}
}
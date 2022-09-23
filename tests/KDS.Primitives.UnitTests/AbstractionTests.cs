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
	public void TestClassNotInheritValueObject_Should_EqualFalse_EqualityOperatorFalse_NotEqualTrue()
	{
		TestClass testClass1 = new("Some data 1", "Some data 2");
		TestClass testClass2 = new("Some data 1", "Some data 2");
		var resultOfEqualMethod = testClass1.Equals(testClass2);
		var resultOfEqualOperator = testClass1 == testClass2;
		var resultOfNotEqualOperator = testClass1 != testClass2;
		Assert.False(resultOfEqualMethod);
		Assert.False(resultOfEqualOperator);
		Assert.True(resultOfNotEqualOperator);
	}

	[Fact]
	public void TestClassInheritValueObject_Should_EqualTrue_EqualityOperatorTrue_NotEqualFalse()
	{
		TestClassInheritValueObject testClass1 = new("Some data 1", "Some data 2");
		TestClassInheritValueObject testClass2 = new("Some data 1", "Some data 2");
		var resultOfEqualMethod = testClass1.Equals(testClass2);
		var resultOfEqualOperator = testClass1 == testClass2;
		var resultOfNotEqualOperator = testClass1 != testClass2;
		Assert.True(resultOfEqualMethod);
		Assert.True(resultOfEqualOperator);
		Assert.False(resultOfNotEqualOperator);
	}
}
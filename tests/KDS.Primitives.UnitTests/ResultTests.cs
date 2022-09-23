using KDS.Primitives.FluentResult;

namespace KDS.Primitives.UnitTests;

public class ResultTests
{
    private const string _errorCode = "TEST_ERROR_CODE";
    private const string _errorMessage = "Some error occured the run tests";
    
    [Fact]
    public void SuccessTest_Should_BeNotNull()
    {
        TestClass testClass = new();
        var result = Result.Success(testClass);
        Assert.NotNull(result);
    }
    
    [Fact]
    public void SuccessTest_Should_ErrorBeNone()
    {
        TestClass testClass = new();
        var result = Result.Success(testClass);
        Assert.Equal(new Error(String.Empty, String.Empty), result.Error);
    }

    [Fact]
    public void ErrorCreationTest_Shoul_BeValueObject()
    {
        Error error1 = new(String.Empty, String.Empty);
        Error error2 = new(String.Empty, String.Empty);

        var resultOfEqualOperatorShouldBeTrue = error1 == error2;
        var resultOfEqualMethodShouldBeTrue = error1.Equals(error2);

        Assert.True(resultOfEqualOperatorShouldBeTrue);
        Assert.True(resultOfEqualMethodShouldBeTrue);
    }

    [Fact]
    public void FailureTest_Should_ReturnError()
    {
        Error error = new(_errorCode, _errorMessage);
        var resultOfMethodFailure = Result.Failure(error);
        Assert.NotNull(resultOfMethodFailure);
        Assert.True(resultOfMethodFailure.IsFailed);
        Assert.NotNull(resultOfMethodFailure.Error);
        Assert.Equal(_errorCode, resultOfMethodFailure.Error.Code);
        Assert.Equal(_errorCode, resultOfMethodFailure.Error.Code);
    }

    [Fact]
    public void CreateTest_Should_ReturnGenericResult_IsFailedTrue_ErrorNotNull_ErrorContainsCodeAndMessage()
    {
        TestClass testClass = null!;
        Error error = new(_errorCode, _errorMessage);
        var resultOfFailureCreation = Result.Create(testClass, error);
        Assert.IsType<Result<TestClass>>(resultOfFailureCreation);
        Assert.True(resultOfFailureCreation.IsFailed);
        Assert.NotNull(resultOfFailureCreation.Error);
        Assert.NotNull(resultOfFailureCreation.Error.Code);
        Assert.NotNull(resultOfFailureCreation.Error.Message);
        Assert.NotEmpty(resultOfFailureCreation.Error.Code);
        Assert.NotEmpty(resultOfFailureCreation.Error.Message);
    }

    [Fact]
    public void CreateTest_Should_ReturnGenericResult_IsSuccessTrue_ErrorNone()
    {
        TestClass testClass = new();
        Error error = new(_errorCode, _errorMessage);
        Error expectedError = new(String.Empty, String.Empty);
        var resultOfSuccessCreation = Result.Create(testClass, error);
        Assert.IsType<Result<TestClass>>(resultOfSuccessCreation);
        Assert.True(resultOfSuccessCreation.IsSuccess);
        Assert.NotNull(resultOfSuccessCreation.Value);
        Assert.Equal(expectedError, resultOfSuccessCreation.Error);
    }
}
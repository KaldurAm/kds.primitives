namespace KDS.Primitives.FluentResult;

/// <summary>
/// represents a result of some operation, with status information and possibly an error
/// </summary>
public class Result
{
	/// <summary>
	/// initialize a new instance of the <see cref="Result"/> class with the specified parameters
	/// </summary>
	/// <param name="isSuccess"></param>
	/// <param name="error"></param>
	/// <exception cref="InvalidOperationException"></exception>
	protected Result(bool isSuccess, Error error)
	{
		if (isSuccess && error != Error.None)
			throw new InvalidOperationException();

		if (!isSuccess && error == Error.None)
			throw new InvalidOperationException();

		IsSuccess = isSuccess;
		Error = error;
	}
	
	/// <summary>
	/// gets a value indicating whether the result is a success result
	/// </summary>
	public bool IsSuccess { get; }
	
	/// <summary>
	/// gets a value indicating whether the result is a failure result
	/// </summary>
	public bool IsFailed => !IsSuccess;
	
	/// <summary>
	/// gets the error
	/// </summary>
	public Error Error { get; }

	/// <summary>
	/// returns a success <see cref="Result"/> with the success flag set
	/// </summary>
	/// <returns></returns>
	public static Result Success() => new(true, Error.None);

	/// <summary>
	/// returns a success <see cref="Result{TValue}"/> with the specified value
	/// </summary>
	/// <param name="value"></param>
	/// <typeparam name="TValue"></typeparam>
	/// <returns></returns>
	public static Result<TValue> Success<TValue>(TValue value) => new Result<TValue>(value, true, Error.None);

	/// <summary>
	/// creates a new <see cref="Result{TValue}"/> with the specified nullable value and the specified error
	/// </summary>
	/// <param name="value"></param>
	/// <param name="error"></param>
	/// <typeparam name="TValue"></typeparam>
	/// <returns></returns>
	public static Result<TValue> Create<TValue>(TValue value, Error error)
		where TValue : class => value is null ? Failure<TValue>(error) : Success(value);

	/// <summary>
	/// returns a failure <see cref="Result"/> with the specified error
	/// </summary>
	/// <param name="error"></param>
	/// <returns></returns>
	public static Result Failure(Error error) => new(false, error);

	/// <summary>
	/// returns a failure <see cref="Result{TValue}"/> with the specified error
	/// </summary>
	/// <param name="error"></param>
	/// <typeparam name="TValue"></typeparam>
	/// <returns></returns>
	public static Result<TValue> Failure<TValue>(Error error) => new Result<TValue>(default!, false, error);

	public static Result FirstFailureOrSuccess(params Result[] results)
	{
		foreach(Result result in results)
		{
			if (result.IsFailed)
			{
				return result;
			}
		}

		return Success();
	}
}
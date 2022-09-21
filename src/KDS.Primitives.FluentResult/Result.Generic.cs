namespace KDS.Primitives.FluentResult;

/// <summary>
/// represents the result of some operation with status information and possibly a value and an error
/// </summary>
/// <typeparam name="TValue"></typeparam>
public class Result<TValue> : Result
{
	private readonly TValue _value;

	/// <summary>
	/// initialize a new instance of the <see cref="Result{TValue}"/> class with the specified parameters
	/// </summary>
	/// <param name="value"></param>
	/// <param name="isSuccess"></param>
	/// <param name="error"></param>
	protected internal Result(TValue value, bool isSuccess, Error error)
		: base(isSuccess, error) => _value = value;

	/// <summary>
	/// gets the result value if the result is successful, otherwise throws an exception
	/// </summary>
	/// <exception cref="InvalidOperationException"></exception>
	public TValue Value => IsSuccess ?
		_value :
		throw new InvalidOperationException("The value of a failure result can not be accessed.");

	public static implicit operator Result<TValue>(TValue value) => Success(value);
}
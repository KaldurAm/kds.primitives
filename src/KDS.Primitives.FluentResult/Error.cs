using KDS.Primitives.Abstraction.ValueObjects;

namespace KDS.Primitives.FluentResult;

public class Error : ValueObject
{
	/// <summary>
	/// initializes a new instance of the <see cref="Error" /> class
	/// </summary>
	/// <param name="code"></param>
	/// <param name="message"></param>
	public Error(string code, string message)
	{
		Code = code;
		Message = message;
	}

	/// <summary>
	/// gets the error code
	/// </summary>
	public string Code { get; }
	
	/// <summary>
	/// gets the error message
	/// </summary>
	public string Message { get; }

	internal static Error None => new(String.Empty, String.Empty);
	public static implicit operator string(Error error) => error?.Code ?? String.Empty;

	/// <inheritdoc />
	protected override IEnumerable<object> GetAtomicValues()
	{
		yield return Code;
		yield return Message;
	}
}
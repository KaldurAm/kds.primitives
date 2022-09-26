namespace KDS.Primitives.FluentApiResponse;

public class Reply<TBody> : Reply
{
	private readonly TBody _body;

	/// <inheritdoc />
	internal Reply(TBody body, ErrorMessage? error) 
		: base(error) => _body = body;
	
	/// <summary>
	/// gets the result value if the result is successful, otherwise throws an exception
	/// </summary>
	/// <exception cref="InvalidOperationException"></exception>
	public TBody Body => IsSuccess ? _body :
		throw new InvalidOperationException("The value of a failure reply can not be accessed.");
	
	public static implicit operator Reply<TBody>(TBody value) => Success(value);
}
using KDS.Primitives.Abstraction.ValueObjects;

namespace KDS.Primitives.FluentApiResponse;

/// <summary>
/// represents the error message
/// </summary>
public sealed class ErrorMessage : ValueObject
{
	private ErrorMessage()
	{
		RequestGuid = String.Empty;
		Code = String.Empty;
		Title = String.Empty;
		Details = String.Empty;
		Source = String.Empty;
	}

	private ErrorMessage(string requestGuid, string code, string title, string details, string source)
	{
		RequestGuid = requestGuid;
		Code = code;
		Title = title;
		Details = details;
		Source = source;
	}
	
	/// <summary>
	/// id of the failed request
	/// </summary>
	public string RequestGuid { get; }
	
	/// <summary>
	/// error of the failed request
	/// </summary>
	public string Code { get; }
	
	/// <summary>
	/// title of the failed request
	/// </summary>
	public string Title { get; }
	
	/// <summary>
	/// details information of the failed request
	/// </summary>
	public string Details { get; }
	
	/// <summary>
	/// source where request failed
	/// </summary>
	public string Source { get; }

	public static ErrorMessage Empty => new ErrorMessage();
	public static ErrorMessage? Null => null;

	/// <inheritdoc />
	protected override IEnumerable<object> GetAtomicValues()
	{
		yield return RequestGuid;
		yield return Code;
		yield return Title;
		yield return Details;
		yield return Source;
	}
}
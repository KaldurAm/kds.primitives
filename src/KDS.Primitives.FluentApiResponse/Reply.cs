using System.Text.Json.Serialization;

namespace KDS.Primitives.FluentApiResponse;

public class Reply
{
	/// <summary>
	/// initialize instance of <see cref="Reply"/> by <see cref="ErrorMessage"/> parameter
	/// </summary>
	/// <param name="error"></param>
	protected Reply(ErrorMessage? error)
	{
		Error = error;
	}
	
	/// <summary>
	/// Error message
	/// </summary>
	[JsonPropertyName("error")]
	public ErrorMessage? Error { get; }

	/// <summary>
	/// Success status of request
	/// </summary>
	[JsonPropertyName("isSuccess")]
	public bool IsSuccess => Error is null;

	/// <summary>
	/// create instance of <see cref="Reply"/> with success true status and null <see cref="ErrorMessage"/>
	/// </summary>
	/// <returns></returns>
	public static Reply Success() => new(ErrorMessage.Null);

	/// <summary>
	/// create instance of <see cref="Reply{TBody}"/> class as reponse
	/// </summary>
	/// <param name="responseBody"></param>
	/// <typeparam name="TBody"></typeparam>
	/// <returns></returns>
	public static Reply<TBody> Success<TBody>(TBody responseBody)
		=> new(responseBody, ErrorMessage.Null);

	/// <summary>
	/// create instance of the <see cref="Reply{TBody}"/> by the parameter
	/// if first parameter will be null, the instance of reply will be initiate with failure
	/// </summary>
	/// <param name="responseBody"></param>
	/// <param name="errorMessage"></param>
	/// <typeparam name="TBody"></typeparam>
	/// <returns></returns>
	public static Reply<TBody> Create<TBody>(TBody? responseBody, ErrorMessage? errorMessage) =>
		responseBody is null ? Failure<TBody>(errorMessage!) : Success(responseBody);

	/// <summary>
	/// create instance of <see cref="Reply"/> with failed status and error message
	/// </summary>
	/// <param name="error"></param>
	/// <returns></returns>
	public static Reply Failure(ErrorMessage error) => new(error);

	/// <summary>
	/// create instance of the <see cref="Reply{TBody}"/> with failure
	/// </summary>
	/// <param name="error"></param>
	/// <typeparam name="TBody"></typeparam>
	/// <returns></returns>
	public static Reply<TBody> Failure<TBody>(ErrorMessage error) => new Reply<TBody>(default!, error);
}
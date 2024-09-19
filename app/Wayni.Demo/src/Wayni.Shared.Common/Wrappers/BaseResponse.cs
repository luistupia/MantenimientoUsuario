using System.Text.Json.Serialization;

namespace Wayni.Shared.Common.Wrappers;

public class BaseResponse<T>
{
    [JsonPropertyName("success")]
    public bool IsSuccess { get; set; }

    [JsonPropertyName("message")]
    public string? Message { get; set; }

    [JsonPropertyName("result")]
    public T? Data { get; set; }

    public BaseResponse(T? data, string? message)
    {
        IsSuccess = true;
        Data = data;
        Message = message;
    }

    public BaseResponse(string? message)
    {
        IsSuccess = false;
        Message = message;
    }

    public static BaseResponse<T> Ok(T? data, string? message = null) => new(data, message);
    public static BaseResponse<T> Error(string? message) => new(message);
}
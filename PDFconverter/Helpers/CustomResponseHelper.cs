using Newtonsoft.Json;

namespace PDFconverter.Helpers;

public class CustomResponseHelper
{
	[JsonProperty(Order = 1)] public bool IsSucceed { get; set; } = true;

	[JsonProperty(Order = 1)] public string? Message { get; set; }

	[JsonProperty(Order = 3)] public int? ErrorCode { get; set; }

	[JsonProperty(Order = 4)] public CustomResponseHelperType CustomResponseHelperType { get; set; }

	public static CustomResponseHelper Success(string message = null)
	{
		return new CustomResponseHelper
		{
			IsSucceed = true,
			Message = message,
			ErrorCode = 0,
			CustomResponseHelperType = CustomResponseHelperType.Success
		};
	}

	public static CustomResponseHelper<T> Success<T>(T data, string message = null)
	{
		return new CustomResponseHelper<T>
		{
			IsSucceed = true,
			Message = message,
			ErrorCode = 0,
			CustomResponseHelperType = CustomResponseHelperType.Success,
			Data = data
		};
	}

	public static CustomResponseHelper Warning(string message = null)
	{
		return new CustomResponseHelper
		{
			IsSucceed = false,
			Message = message,
			CustomResponseHelperType = CustomResponseHelperType.Warning
		};
	}

	public static CustomResponseHelper<T> Warning<T>(T data, string message = null)
	{
		return new CustomResponseHelper<T>
		{
			IsSucceed = false,
			Message = message,
			CustomResponseHelperType = CustomResponseHelperType.Warning,
			Data = data
		};
	}

	public static CustomResponseHelper Info(string message = null)
	{
		return new CustomResponseHelper
		{
			IsSucceed = true,
			Message = message,
			CustomResponseHelperType = CustomResponseHelperType.Info
		};
	}

	public static CustomResponseHelper<T> Info<T>(T data, string message = null)
	{
		return new CustomResponseHelper<T>
		{
			IsSucceed = true,
			Message = message,
			CustomResponseHelperType = CustomResponseHelperType.Info,
			Data = data
		};
	}

	public static CustomResponseHelper Error(string message = null, int? errorCode = null)
	{
		return new CustomResponseHelper
		{
			IsSucceed = false,
			Message = message,
			CustomResponseHelperType = CustomResponseHelperType.Error,
			ErrorCode = errorCode
		};
	}

	public static CustomResponseHelper<T> Error<T>(T data, string message = null, int? errorCode = null)
	{
		return new CustomResponseHelper<T>
		{
			IsSucceed = false,
			Message = message,
			CustomResponseHelperType = CustomResponseHelperType.Error,
			ErrorCode = errorCode,
			Data = data
		};
	}
}

public class CustomResponseHelper<T> : CustomResponseHelper
{
	[JsonProperty(Order = 5)] public T Data { get; set; }
}

public enum CustomResponseHelperType : byte
{
	Success = 1,
	Info = 2,
	Warning = 3,
	Error = 4
}

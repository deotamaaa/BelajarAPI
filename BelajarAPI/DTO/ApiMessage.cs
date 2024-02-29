namespace BelajarAPI.DTO;

public class ApiMessage<T> where T : class
{
	public int? StatusCode { get; set; }

	public string? Status { get; set; }

	public string? Message { get; set; }

	public T? Data { get; set; }
}
namespace BelajarAPI.DTO;

public class IssueUpdateRequest
{
	public Guid Id { get; set; }
	public string? Title { get; set; }
	
	public string? Description { get; set; }
	
}
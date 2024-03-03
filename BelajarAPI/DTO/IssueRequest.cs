using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using BelajarAPI.Models;

namespace BelajarAPI.DTO;

public class IssueRequest
{
	[JsonPropertyName("user_id")]
	public Guid UserId { get; set; }

	[Required]
	[JsonPropertyName("title")]
	public string Title { get; set; }

	[Required]
	[JsonPropertyName("description")]
	public string Description { get; set; }

	[JsonPropertyName("priority")]
	public Priority Priority { get; set; }

	[JsonPropertyName("type")]
	public IssueType IssueType { get; set; }

	[Required]
	[JsonPropertyName("created-at")]
	public DateTime CreatedAt { get; set; }

	[Required]
	[JsonPropertyName("completed-at")]
	public DateTime CompletedAt { get; set; }
}
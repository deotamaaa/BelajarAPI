using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BelajarAPI.Models;

[Table("tb_issue")]
public class Issue
{
	[Key, Column("id")]
	public Guid Id { get; set; }

	[Required, Column("title")]
	public string Title { get; set; }

	[Required, Column("description")]
	public string Description { get; set; }
	
	[Required, Column("priority")]
	public Priority Priority { get; set; }
	
	[Required, Column("issue_type")]
	public IssueType IssueType { get; set; }

	[Required, Column("created")]
	public DateTime Created { get; set; }
	
	[Required, Column("completed")]
	public DateTime? Completed { get; set; }
}

public enum Priority
{
	Low,
	Normal,
	High
}

public enum IssueType
{
	Feature,
	Bug,
	Documentation
}

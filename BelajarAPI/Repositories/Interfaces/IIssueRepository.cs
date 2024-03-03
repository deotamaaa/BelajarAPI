using BelajarAPI.Models;

namespace BelajarAPI.Repositories.Interfaces;

public interface IIssueRepository
{
	public Issue CreateIssue(Issue issue);
	
	public IEnumerable<Issue> GetIssues();
	
	public Issue GetIssueById(Guid id);
	
	public Issue UpdateIssue(Issue issue);
	
	public int DeleteIssue(Guid id);
}
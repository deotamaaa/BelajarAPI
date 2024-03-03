using BelajarAPI.Context;
using BelajarAPI.Models;
using BelajarAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BelajarAPI.Repositories;

public class IssueRepository : IIssueRepository
{
	private readonly DataContexts _contexts;
	public IssueRepository(DataContexts contexts)
	{
		_contexts = contexts;
	}
	public Issue CreateIssue(Issue issue)
	{
		try
		{
			_contexts.Issues?.Add(issue);
			_contexts.SaveChanges();
			return issue;
		}
		catch (Exception e)
		{
			Console.WriteLine(e);
			throw new Exception(e.Message);
		}
	}

	public IEnumerable<Issue> GetIssues()
	{
		try
		{
			var result = _contexts.Issues?.Include(issue => issue.User).ToList();
			return result!;
		}
		catch (Exception e)
		{
			Console.WriteLine(e);
			throw new Exception(e.Message);
		}
	}

	public Issue GetIssueById(Guid id)
	{
		try
		{
			var result = _contexts.Issues?.Include(issue => issue.User).FirstOrDefault(x => x.Id == id);
			return result!;
		}
		catch (Exception e)
		{
			Console.WriteLine(e);
			throw new Exception(e.Message);
		}
	}

	public Issue UpdateIssue(Issue issue)
	{
		throw new NotImplementedException();
	}

	public int DeleteIssue(Guid id)
	{
		throw new NotImplementedException();
	}
}
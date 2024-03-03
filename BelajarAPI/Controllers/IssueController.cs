using System.Net;
using BelajarAPI.DTO;
using BelajarAPI.Models;
using BelajarAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BelajarAPI.Controllers;

[ApiController]
[Route("api/issue")]
public class IssueController : ControllerBase
{
	private readonly IIssueRepository _issueRepository;
	private readonly IUserRepository _userRepository;

	public IssueController( IIssueRepository issueRepository, IUserRepository userRepository)
	{
		_issueRepository = issueRepository;
		_userRepository = userRepository;
	}
	
	[HttpPost]
	[Route("create-issue")]
	public ActionResult CreateIssue([FromBody] IssueRequest? request)
	{
		try
		{
			if (request == null)
			{
				return BadRequest(new ApiMessage<Issue>
				{
					StatusCode = (int)HttpStatusCode.BadRequest,
					Status = "Bad Request",
					Message = "Request cannot be empty.",
					Data = null 
				});
			}

			if (string.IsNullOrEmpty(request.Title) || string.IsNullOrEmpty(request.Description))
			{
				return BadRequest(new ApiMessage<Issue>
				{
					StatusCode = (int)HttpStatusCode.BadRequest,
					Status = "Bad Request",
					Message = "Title, Description, and UserId are required fields.",
					Data = null 
				});
			}
			
			var user = _userRepository.GetUserById(request.UserId);
			if (user == null)
			{
				return NotFound(new ApiMessage<Issue>
				{
					StatusCode = (int)HttpStatusCode.NotFound,
					Status = "Not Found",
					Message = "UserId not Valid.",
					Data = null 
				});
			}
			var issue = new Issue
			{
				UserId = user.UsersId,
				Title = request.Title,
				Description = request.Description,
				Created = DateTime.Now,
				Completed = request.CompletedAt,
				IssueType = request.IssueType,
				Priority = request.Priority,
				User = user
			};
			var createdIssue = _issueRepository.CreateIssue(issue);
			
			return Ok(new ApiMessage<Issue>()
			{
				StatusCode = (int)HttpStatusCode.OK,
				Status = "Ok",
				Message = "Issue Created Successfully!",
				Data = createdIssue
			});
		}
		catch (Exception e)
		{
			Console.WriteLine(e);
			throw new Exception(e.Message);
		}
	}

	[HttpGet]
	[Route("get-issues")]
	public ActionResult<IEnumerable<Issue>> GetIssue()
	{
		try
		{
			var result = _issueRepository.GetIssues();
			return Ok(new ApiMessage<IEnumerable<Issue>>()
			{
				StatusCode = (int)HttpStatusCode.OK,
				Status = "Ok",
				Message = "Get Issues Successfully!",
				Data = result
			});
		}
		catch (Exception e)
		{
			Console.WriteLine(e);
			throw new Exception(e.Message);
		}
	}

	[HttpPost]
	[Route("get-issue-by-id")]
	public ActionResult GetIssueById([FromBody]Guid id)
	{
		try
		{
			var result = _issueRepository.GetIssueById(id);
			if (result == null)
			{
				return NotFound(new ApiMessage<Issue>
				{
					StatusCode = (int)HttpStatusCode.NotFound,
					Status = "Not Found",
					Message = "Issue not found.",
					Data = null
				});
			}
			return Ok(new ApiMessage<Issue>
			{
				StatusCode = (int)HttpStatusCode.OK,
				Status = "Ok",
				Message = "Get Issue Successfully!",
				Data = result
			});
		}
		catch (Exception e)
		{
			Console.WriteLine(e);
			throw new Exception(e.Message);
		}
	}	
}
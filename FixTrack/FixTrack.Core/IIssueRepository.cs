namespace FixTrack.Core;

public interface IIssueRepository
{
    List<Issue> GetAll();
    Issue Add(Issue issue);
}
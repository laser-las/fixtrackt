namespace FixTrack.Core;

public class MemoryIssueRepository : IIssueRepository
{
    private readonly List<Issue> issues = new();
    private int nextId = 1;

    public List<Issue> GetAll() => issues.ToList();

    public Issue Add(Issue issue)
    {
        issue.Id = nextId++;
        issues.Add(issue);
        return issue;
    }
}
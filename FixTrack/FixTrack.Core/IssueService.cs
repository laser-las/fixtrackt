namespace FixTrack.Core;

public class IssueService
{
    private readonly IIssueRepository repository;

    private readonly Dictionary<string, string> statusLabels = new()
    {
        ["new"] = "Ny",
        ["resolved"] = "Löst"
    };

    public IssueService(IIssueRepository repository)
    {
        this.repository = repository;
    }

    public Issue Create(string title, int priority)
    {
        var issue = new Issue(title, priority);
        return repository.Add(issue);
    }

    public List<Issue> GetIssues(string? status = null)
    {
        var query = repository.GetAll().AsEnumerable();

        if (!string.IsNullOrWhiteSpace(status))
            query = query.Where(i => i.Status == status);

        return query
            .OrderBy(i => i.Priority)
            .ThenBy(i => i.Id)
            .ToList();
    }

    public string GetStatusLabel(string status)
        => statusLabels.TryGetValue(status, out var label)
            ? label
            : status;
}
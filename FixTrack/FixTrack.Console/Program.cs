using FixTrack.Core;

var repository = new MemoryIssueRepository();
var service = new IssueService(repository);

service.Create("Trasig skärm", 1);
service.Create("Mus saknas", 2);
service.Create("Långsam dator", 3);

foreach (var issue in service.GetIssues("new"))
{
    Console.WriteLine(
        $"{issue.Id}: {issue.Title} | " +
        $"P{issue.Priority} | " +
        service.GetStatusLabel(issue.Status));
}
using Microsoft.EntityFrameworkCore;

namespace FixTrack.Core;

public class SqliteIssueRepository : IIssueRepository
{
    public List<Issue> GetAll()
    {
        using var db = new FixTrackDb();
        return db.Issues.AsNoTracking().ToList();
    }

    public Issue Add(Issue issue)
    {
        using var db = new FixTrackDb();
        db.Issues.Add(issue);
        db.SaveChanges();
        return issue;
    }
}

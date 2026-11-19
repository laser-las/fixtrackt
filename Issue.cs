namespace FixTrack.Core;

public class Issue
{
    public int Id { get; set; }
    public string Title { get; private set; }
    public int Priority { get; private set; }
    public string Status { get; private set; } = "new";

    public Issue(string title, int priority)
    {
        if (string.IsNullOrWhiteSpace(title)
            || title.Trim().Length < 3)
            throw new ArgumentException("Minst tre tecken.");

        if (priority < 1 || priority > 3)
            throw new ArgumentException("Prioritet 1–3.");

        Title = title.Trim();
        Priority = priority;
    }

    public void Resolve() => Status = "resolved";
}
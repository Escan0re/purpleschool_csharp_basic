namespace csharp_basic;

public sealed record Book(
    string Title,
    string Author,
    string Year,
    string Isbn,
    string? Comment = null,
    bool IsRead = false
)
{
    public override string ToString() =>
        $"{Title} — {Author}, {Year}, ISBN: {Isbn}, " +
        $"Комментарий: {(string.IsNullOrWhiteSpace(Comment) ? "—" : Comment)}, " +
        $"Статус: {(IsRead ? "прочитана" : "не прочитана")}";
}
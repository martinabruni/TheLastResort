namespace TheLastResort.Core.Infrastructure.Models;

public partial class LogEntity
{
    public int Id { get; set; }

    public string Message { get; set; } = null!;

    public DateTime? Timestamp { get; set; }
}

using TheLastResort.Core.Domain.Interfaces;

namespace TheLastResort.Core.Infrastructure.Models;

public partial class LogEntity : IEntity<int>
{
    public int Id { get; set; }

    public string Message { get; set; } = null!;

    public DateTime? Timestamp { get; set; }
}

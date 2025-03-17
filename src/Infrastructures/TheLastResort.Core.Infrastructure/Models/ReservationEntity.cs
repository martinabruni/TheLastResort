using TheLastResort.Core.Domain.Interfaces;

namespace TheLastResort.Core.Infrastructure.Models;

public partial class ReservationEntity : IEntity<Guid>
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }

    public Guid BuildingId { get; set; }

    public string ReservationType { get; set; } = null!;

    public DateOnly StartDate { get; set; }

    public DateOnly EndDate { get; set; }

    public DateTime? CreatedDate { get; set; }

    public bool? Cancelled { get; set; }

    public DateTime? CancelledDate { get; set; }

    public virtual BuildingEntity Building { get; set; } = null!;

    public virtual UserEntity User { get; set; } = null!;
}

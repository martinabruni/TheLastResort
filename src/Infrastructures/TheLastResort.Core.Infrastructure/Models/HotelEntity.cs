using TheLastResort.Core.Domain.Interfaces;

namespace TheLastResort.Core.Infrastructure.Models;

public partial class HotelEntity : IEntity<Guid>
{
    public Guid Id { get; set; }

    public string Address { get; set; } = null!;

    public virtual BuildingEntity Building { get; set; } = null!;
}

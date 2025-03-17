namespace TheLastResort.Core.Infrastructure.Models;

public partial class HotelEntity
{
    public Guid BuildingId { get; set; }

    public string Address { get; set; } = null!;

    public virtual BuildingEntity Building { get; set; } = null!;
}

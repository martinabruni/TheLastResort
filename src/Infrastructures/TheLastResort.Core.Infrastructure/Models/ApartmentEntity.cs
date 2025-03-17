namespace TheLastResort.Core.Infrastructure.Models;

public partial class ApartmentEntity
{
    public Guid BuildingId { get; set; }

    public string ManagerPhone { get; set; } = null!;

    public virtual BuildingEntity Building { get; set; } = null!;
}

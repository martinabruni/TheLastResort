using TheLastResort.Core.Domain.Interfaces;

namespace TheLastResort.Core.Infrastructure.Models;

public partial class BuildingEntity : IEntity<Guid>
{
    public Guid Id { get; set; }

    public string BuildingType { get; set; } = null!;

    public string Name { get; set; } = null!;

    public DateTime? CreatedDate { get; set; }

    public virtual ApartmentEntity? ApartmentEntity { get; set; }

    public virtual HotelEntity? HotelEntity { get; set; }

    public virtual ICollection<ReservationEntity> ReservationEntities { get; set; } = new List<ReservationEntity>();
}

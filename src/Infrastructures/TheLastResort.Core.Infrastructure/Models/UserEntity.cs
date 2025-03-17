using TheLastResort.Core.Domain.Interfaces;

namespace TheLastResort.Core.Infrastructure.Models;

public partial class UserEntity : IEntity<Guid>
{
    public Guid Id { get; set; }

    public string UserName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public DateTime? CreatedDate { get; set; }

    public virtual ICollection<ReservationEntity> ReservationEntities { get; set; } = new List<ReservationEntity>();
}

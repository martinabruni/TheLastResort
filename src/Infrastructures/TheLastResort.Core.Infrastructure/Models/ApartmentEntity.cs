﻿using TheLastResort.Core.Domain.Interfaces;

namespace TheLastResort.Core.Infrastructure.Models;

public partial class ApartmentEntity : IEntity<Guid>
{
    public Guid Id { get; set; }

    public string ManagerPhone { get; set; } = null!;

    public virtual BuildingEntity Building { get; set; } = null!;
}

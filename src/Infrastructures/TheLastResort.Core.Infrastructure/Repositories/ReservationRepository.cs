using TheLastResort.Core.Infrastructure.Models;

namespace TheLastResort.Core.Infrastructure.Repositories
{
    internal class ReservationRepository : ARepositoryBase<ReservationEntity, Guid>
    {
        public ReservationRepository(SqldbThelastresortCoreDevContext dbContext) : base(dbContext)
        {
        }
    }
}

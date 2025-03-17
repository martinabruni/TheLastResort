using TheLastResort.Core.Infrastructure.Models;

namespace TheLastResort.Core.Infrastructure.Repositories
{
    internal class HotelRepository : ARepositoryBase<HotelEntity, Guid>
    {
        public HotelRepository(SqldbThelastresortCoreDevContext dbContext) : base(dbContext)
        {
        }
    }
}

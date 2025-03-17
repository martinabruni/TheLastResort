using TheLastResort.Core.Infrastructure.Models;

namespace TheLastResort.Core.Infrastructure.Repositories
{
    internal class BuildingRepository : ARepositoryBase<BuildingEntity, Guid>
    {
        public BuildingRepository(SqldbThelastresortCoreDevContext dbContext) : base(dbContext)
        {
        }
    }
}

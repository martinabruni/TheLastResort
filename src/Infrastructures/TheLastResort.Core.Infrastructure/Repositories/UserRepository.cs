using TheLastResort.Core.Infrastructure.Models;

namespace TheLastResort.Core.Infrastructure.Repositories
{
    internal class UserRepository : ARepositoryBase<UserEntity, Guid>
    {
        public UserRepository(SqldbThelastresortCoreDevContext dbContext) : base(dbContext)
        {
        }
    }
}

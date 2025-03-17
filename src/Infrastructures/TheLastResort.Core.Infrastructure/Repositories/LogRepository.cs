using TheLastResort.Core.Infrastructure.Models;

namespace TheLastResort.Core.Infrastructure.Repositories
{
    internal class LogRepository : ARepositoryBase<LogEntity, int>
    {
        public LogRepository(SqldbThelastresortCoreDevContext dbContext) : base(dbContext)
        {
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TheLastResort.Core.Domain.Interfaces;
using TheLastResort.Core.Infrastructure.Models;
using TheLastResort.Core.Infrastructure.Repositories;

namespace TheLastResort.Core.Domain
{
    public static class ServiceBuilderExtension
    {
        public static Dictionary<Type, Func<object>> AddInfrastructureServices(this ServiceBuilder builder, IConfiguration configuration)
        {
            builder.Register(() => new DbContextOptionsBuilder<SqldbThelastresortCoreDevContext>());

            var optionsBuilder = builder.Resolve<DbContextOptionsBuilder<SqldbThelastresortCoreDevContext>>();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("Sql"));
            
            builder.Register(() => new SqldbThelastresortCoreDevContext(optionsBuilder.Options));
            builder.Register<IRepository<UserEntity, Guid>, UserRepository>(() => new UserRepository(builder.Resolve<SqldbThelastresortCoreDevContext>()));
            builder.Register<IRepository<BuildingEntity, Guid>, BuildingRepository>(() => new BuildingRepository(builder.Resolve<SqldbThelastresortCoreDevContext>()));
            builder.Register<IRepository<ApartmentEntity, Guid>, ApartmentRepository>(() => new ApartmentRepository(builder.Resolve<SqldbThelastresortCoreDevContext>()));
            builder.Register<IRepository<HotelEntity, Guid>, HotelRepository>(() => new HotelRepository(builder.Resolve<SqldbThelastresortCoreDevContext>()));
            builder.Register<IRepository<LogEntity, int>, LogRepository>(() => new LogRepository(builder.Resolve<SqldbThelastresortCoreDevContext>()));
            builder.Register<IRepository<ReservationEntity, Guid>, ReservationRepository>(() => new ReservationRepository(builder.Resolve<SqldbThelastresortCoreDevContext>()));

            return builder.Services;
        }
    }
}

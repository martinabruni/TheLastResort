namespace TheLastResort.Core.Domain
{
    public class ServiceBuilder
    {
        public Dictionary<Type, Func<object>> Services { get; } = new Dictionary<Type, Func<object>>();

        public void Register<TService>(Func<TService> factory)
        {
            if (factory is null)
                return;
            Services[typeof(TService)] = () => factory()!;
        }

        public void Register<TServiceAbstraction, TService>(Func<TService> factory)
        {
            if (factory is null)
                return;
            Services[typeof(TServiceAbstraction)] = () => factory()!;
        }

        public TService Resolve<TService>()
        {
            if (Services.TryGetValue(typeof(TService), out var factory))
            {
                return (TService)factory();
            }
            throw new InvalidOperationException($"Service of type {typeof(TService).Name} is not registered.");
        }
    }
}

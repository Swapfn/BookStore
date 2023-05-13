using System.Reflection;

namespace WebAPI
{
    public class RegisterServices
    {
        public static void AddRepositories(IServiceCollection services)
        {
            List<Type>? types = Assembly.Load("Data.Repositories").ExportedTypes.Where(t => t.Name.ToLower().EndsWith("repository")).ToList();
            List<Type>? interfaces = types.Where(i => i.IsInterface).ToList();
            List<Type>? implementations = types.Where(s => s.IsClass).ToList();
            RegisterTypes(services, interfaces, implementations);
        }
        public static void AddServices(IServiceCollection services)
        {

            List<Type>? types = Assembly.Load("Services").ExportedTypes.Where(t => t.Name.ToLower().EndsWith("service")).ToList();
            List<Type>? interfaces = types.Where(i => i.IsInterface).ToList();
            List<Type>? implementations = types.Where(s => s.IsClass).ToList();
            RegisterTypes(services, interfaces, implementations);
        }
        static void RegisterTypes(IServiceCollection services, List<Type> interfaces, List<Type> implementation)
        {
            interfaces.ForEach(interfaceType =>
            {
                Type? serviceType = implementation.FirstOrDefault(imp => interfaceType.IsAssignableFrom(imp));
                if (serviceType != null)
                    services.AddScoped(interfaceType, serviceType);
            });
        }
    }
}

using AutoMapper;
using System;
using System.Linq;
using System.Reflection;

namespace TALTechChallenge.Core.Common.Mappings
{
    public class MappingProfile : Profile
    {
        private const string Mapping = nameof(Mapping);

        public MappingProfile()
        {
            ApplyMappingsFromAssembly(Assembly.GetExecutingAssembly());
        }

        private void ApplyMappingsFromAssembly(Assembly assembly)
        {
            var types = assembly.GetExportedTypes()
                .Where(type => type.GetInterfaces()
                    .Any(internalType => internalType.IsGenericType &&
                                         (internalType.GetGenericTypeDefinition() == typeof(IMapFrom<>)
                                          || internalType.GetGenericTypeDefinition() == typeof(IMapTo<>))))
                .ToList();

            foreach (var type in types)
            {
                var instance = Activator.CreateInstance(type);

                var methodInfo = type.GetMethod(Mapping)
                                 ?? type.GetInterface("IMapFrom`1")?.GetMethod(Mapping)
                                 ?? type.GetInterface("IMapTo`1")?.GetMethod(Mapping);

                methodInfo?.Invoke(instance, new object[] { this });
            }
        }
    }
}

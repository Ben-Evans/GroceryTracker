// Uncomment when Mapster updates to .NET 6
/*using Mapster;
using System.Reflection;

namespace Models;

public class MapsterDtoGenRegister : ICodeGenerationRegister
{
    private static readonly string domainModelProject = $"{nameof(Models)}";
    private static readonly string domainModelNamespace = $"{domainModelProject}.{nameof(Models.DomainModels)}";
    public void Register(CodeGenerationConfig config)
    {
        config.AdaptTo("[name]Dto")
            .ForAllTypesInNamespace(Assembly.GetExecutingAssembly(), domainModelNamespace);

        config.GenerateMapper("[name]Mapper")
            .ForAllTypesInNamespace(Assembly.GetExecutingAssembly(), domainModelNamespace);
    }
}*/

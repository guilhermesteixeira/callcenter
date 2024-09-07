using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Callcenter.Backend.Infrastructure.Common.Persistence;

public static class FluentApiExtensions
{
    public static PropertyBuilder<T> HasListOfIdsConverter<T>(this PropertyBuilder<T> propertyBuilder)
    {
        return propertyBuilder.HasConversion(
            new ListOfIdsConverter(),
            new ListOfIdsComparer());
    }
}
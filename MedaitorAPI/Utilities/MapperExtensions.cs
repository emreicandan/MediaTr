using System;
namespace MedaitorAPI.Utilities;

public static class MapperExtensions
{
      public static TSource MapWithSource<TSource,TDestination>(this TSource source , TDestination destination)
        where TSource : class
        where TDestination : class
    {
        var sourceProperties = typeof(TSource).GetProperties().ToList();
        typeof(TDestination).GetProperties().ToList().ForEach(prop =>
        {
            var sourceFindedProperty = sourceProperties.Where(i => i.Name == prop.Name).FirstOrDefault();
            if (sourceFindedProperty != null)
            {
                sourceFindedProperty.SetValue(source, prop.GetValue(destination));
            }
        });

        return source;

    }

    public static async Task<TSource> MapWithSourceAsync<TSource, TDestination>(this Task<TSource> asyncSource, TDestination destination)
        where TSource : class
        where TDestination : class
    {

        var source = await asyncSource;
        var sourceProperties = typeof(TSource).GetProperties().ToList();
        typeof(TDestination).GetProperties().ToList().ForEach(prop =>
        {
            var sourceFindedProperty = sourceProperties.Where(i => i.Name == prop.Name).FirstOrDefault();
            if (sourceFindedProperty != null)
            {
                sourceFindedProperty.SetValue(source, prop.GetValue(destination));
            }
        });

        return source;

    }
}


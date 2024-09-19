using AutoMapper;

namespace Wayni.Shared.Common.Extensions;

public static class MapObjectExtensions
{
    public static List<TDestination> MapTo<TSource, TDestination>(this List<TSource> sourceList)
    {
        if (sourceList == null)
            throw new ArgumentNullException(nameof(sourceList));

        var config = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<TSource, TDestination>();
        });

        var mapper = config.CreateMapper();
        return sourceList.ConvertAll(source => mapper.Map<TDestination>(source));
    }

    public static TDestination MapTo<TSource, TDestination>(this TSource source) where TDestination : new()
    {
        if (source == null)
            throw new ArgumentNullException(nameof(source));

        var config = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<TSource, TDestination>();
        });

        var mapper = config.CreateMapper();
        return mapper.Map<TDestination>(source);
    }
}
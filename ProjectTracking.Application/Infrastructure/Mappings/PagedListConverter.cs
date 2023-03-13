using AutoMapper;
using ProjectTracking.Application.Infrastructure.Helpers;

namespace ProjectTracking.Application.Infrastructure.Mappings;

class PagedListConverter<TSource, TDestination> : ITypeConverter<PagedList<TSource>, PagedList<TDestination>>
{
    public PagedList<TDestination> Convert(PagedList<TSource> source, PagedList<TDestination> destination, ResolutionContext context)
    {
        return new PagedList<TDestination>(context.Mapper.Map<List<TSource>, List<TDestination>>(source), source.Count, source.CurrentPage, source.PageSize);
    }
}
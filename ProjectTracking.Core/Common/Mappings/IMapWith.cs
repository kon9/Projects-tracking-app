using AutoMapper;

namespace ProjectTracking.Core.Common.Mappings
{
    public interface IMapWith<T>
    {
        void Mapping(Profile profile) => profile.CreateMap(typeof(T), GetType());
    }

}

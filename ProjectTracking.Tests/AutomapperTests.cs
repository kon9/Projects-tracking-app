using ProjectTracking.Application.Infrastructure.Mappings.Base;

namespace ProjectTracking.Tests
{
    public class AutomapperTests
    {
        [Fact]
        [Trait("Automapper", "MapperConfiguration")]
        public void ItShouldCorrectlyConfigured()
        {
            var cfg = MapperRegistration.GetMapperConfiguration();

            cfg.AssertConfigurationIsValid();
        }
    }
}

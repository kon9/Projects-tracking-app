using ProjectTracking.Application.Infrastructure.Mappings.Base;

namespace ProjectTracking.Tests
{
    public class AutomapperTests
    {
        [Fact]
        [Trait("Automapper", "MapperConfiguration")]
        public void ItShouldBeCorrectlyConfigured()
        {
            var cfg = MapperRegistration.GetMapperConfiguration();

            cfg.AssertConfigurationIsValid();
        }
    }
}

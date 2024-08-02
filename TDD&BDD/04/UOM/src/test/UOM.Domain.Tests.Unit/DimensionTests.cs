using FluentAssertions;

namespace UOM.Domain.Tests.Unit
{
    public class DimensionTests
    {
        [Fact]
        public void dimension_constructed_properly()
        {
            var measurement = new Dimension(1, "Mass", "m");

            measurement.Id.Should().Be(1);
            measurement.Name.Should().Be("Mass");
            measurement.Symbol.Should().Be("m");
        }

    }
}



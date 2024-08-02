using FluentAssertions;
using System.Threading.Channels;
using System.Xml.Linq;
using UOM.Domain.Tests.Unit.TestUtils;

namespace UOM.Domain.Tests.Unit
{
    public class BaseUnitOfMeasuresTests
    {
        [Fact]
        public void base_unit_of_measure_is_defined_in_a_dimension()
        {
            var mass = DimensionFactory.CreateMassDimension();

            var gram = BaseUnitOfMeasureFactory.CreateGram();

            gram.Id.Should().Be(1);
            gram.DimensionId.Should().Be(mass.Id);
            gram.Name.Should().Be("Gram");
            gram.Symbol.Should().Be("gr");
        }
    }
}



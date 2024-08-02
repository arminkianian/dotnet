using FluentAssertions;
using UOM.Domain.Tests.Unit.TestUtils;

namespace UOM.Domain.Tests.Unit
{
    public class ScaledUnitOfMeasureTests
    {
        private readonly BaseUnitOfMeasure gram;

        public ScaledUnitOfMeasureTests()
        {
            gram = BaseUnitOfMeasureFactory.CreateGram();
        }

        [Fact]
        public void scaled_unit_of_measure_constructed_properly()
        {
            var kilogram = new ScaledUnitOfMeasure(2, "Kilogram", "KG", 1000M, gram);

            kilogram.Id.Should().Be(2);
            kilogram.Name.Should().Be("Kilogram");
            kilogram.Symbol.Should().Be("KG");
            kilogram.BaseUnitOfMeasureId.Should().Be(gram.Id);
        }

        [Fact]
        public void scaled_unit_of_measure_converts_to_base_when_its_on_higher_scale()
        {
            var kilogram = new ScaledUnitOfMeasure(2, "Kilogram", "KG", 1000M, gram);

            var amountInBase = kilogram.ConvertToBase(3);

            amountInBase.Should().Be(3000);
        }

        [Fact]
        public void scaled_unit_of_measure_converts_to_base_when_its_on_smaller_scale()
        {
            var milligram = new ScaledUnitOfMeasure(2, "Milligram", "MG", 0.001M, gram);

            var amountInBase = milligram.ConvertToBase(500);

            amountInBase.Should().Be(0.5M);
        }

        [Fact]
        public void scaled_unit_of_measure_converts_to_bigger_scaled_unit_of_measure()
        {
            var kilogram = new ScaledUnitOfMeasure(2, "Kilogram", "KG", 1000, gram);
            var milligram = new ScaledUnitOfMeasure(2, "Milligram", "MG", 0.001M, gram);

            var amountInKg = milligram.ConvertTo(kilogram, 2000);

            amountInKg.Should().Be(0.002M);
        }

        [Fact]
        public void scaled_unit_of_measure_converts_to_smaller_scaled_unit_of_measure()
        {
            var kilogram = new ScaledUnitOfMeasure(2, "Kilogram", "KG", 1000, gram);
            var milligram = new ScaledUnitOfMeasure(2, "Milligram", "MG", 0.001M, gram);

            var amountInMg = kilogram.ConvertTo(milligram, 2);

            amountInMg.Should().Be(2_000_000);
        }
    }
}



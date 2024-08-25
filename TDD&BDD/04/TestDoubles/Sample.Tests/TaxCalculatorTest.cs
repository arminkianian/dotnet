using Sample.Tests.TestDoubles;

namespace Sample.Tests
{
    public class TaxCalculatorTest
    {
        [Theory]
        [InlineData(1_000_000, 9, 910_000)]
        [InlineData(1_000_000, 9.5, 905_000)]
        [InlineData(1_000_000, 0, 1_000_000)]
        public void tax_is_subtracted_from_salary(long salary, double taxRate, double expected)
        {
            var taxRepository = StubTaxRepository
                .CreateNewStub()
                .WitchReturnsTaxRateAs(taxRate);

            var taxService = new TaxService(taxRepository);

            var salaryWithoutTaxes = taxService.CalculateSalary(salary);

            Assert.Equal(expected, salaryWithoutTaxes);
        }
    }
}
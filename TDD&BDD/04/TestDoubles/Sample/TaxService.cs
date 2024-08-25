namespace Sample
{
    public class TaxService
    {
        private readonly ITaxRepository taxRepository;

        public TaxService(ITaxRepository taxRepository)
        {
            this.taxRepository = taxRepository;
        }

        public double CalculateSalary(long salary)
        {
            var taxRate = taxRepository.GetCurrentTaxRate();
            var valueToSubtract = taxRate * salary / 100;
            return salary - valueToSubtract;
        }
    }
}
